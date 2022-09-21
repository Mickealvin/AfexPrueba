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
          await ListView_GetData();
        }

        protected async void btnBuscar_Click(object sender, EventArgs e)
        {
            var result = await videosService.SaveVideo(txtUrl.Text);
            await ListView_GetData();
        }

        public async Task<List<Videos>> ListView_GetData()
        {
            var result = await videosService.GetAll();
            return result;
        }
    }
}