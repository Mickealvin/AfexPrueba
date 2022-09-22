using AfexPrueba.Model;
using AfexPrueba.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AfexPrueba
{
    public partial class _Default : Page
    {
        private readonly VideosService videosService;
        private Videos selectedVideo;
        public _Default()
        {
            videosService = new VideosService();
          
        }
        protected async Task Page_LoadAsync(object sender, EventArgs e)
        {
          
        }

        protected async void btnBuscar_Click(object sender, EventArgs e)
        {
            await videosService.SaveVideo(txtUrl.Text);
            ListView1.DataBind();
        }

        public async Task<List<Videos>> ListView_GetData()
        {
            var result = await videosService.GetAll();
            return result;
        }

        protected async void Mostrar_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            hdField.Value = id.ToString();
            selectedVideo = await videosService.GetId(id);

            LB.Text = selectedVideo.Titulo;
            DS.Text = selectedVideo.Descripcion;
            IMG.ImageUrl = selectedVideo.Imagen;

           ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected async void Delete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(hdField.Value))
            {
                await videosService.Delete(Convert.ToInt32(hdField.Value));
                ListView1.DataBind();
            }
        }

        protected async void video_Click(object sender, EventArgs e)
        {
            selectedVideo = await videosService.GetId(Convert.ToInt32(hdField.Value));
            string videoId = selectedVideo.Link.Substring(selectedVideo.Link.IndexOf("v=") + 2);
            videoPlayer.Src = $"https://www.youtube.com/embed/{videoId}";
            videoPlayer.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popu", "videoModal()", true);
        }
    }
}