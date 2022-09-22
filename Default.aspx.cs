using AfexPrueba.Model;
using AfexPrueba.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AfexPrueba
{
    public partial class _Default : Page
    {
        private readonly VideosService videosService;
        public _Default()
        {
            videosService = new VideosService();
          
        }
        protected async Task Page_LoadAsync(object sender, EventArgs e)
        {
          
        }

        protected async void btnBuscar_Click(object sender, EventArgs e)
        {
            var result = await videosService.SaveVideo(txtUrl.Text);
            ListView1.DataBind();
        }

        public async Task<List<Videos>> ListView_GetData()
        {
            var result = await videosService.GetAll();
            return result;
        }

        protected async void Mostrar_Command(object sender, CommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument);
            var hola = await videosService.GetId(Id);

            LB.Text = hola.Titulo;
            DS.Text = hola.Descripcion;
            IMG.ImageUrl = hola.Imagen;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

        }
    }
}