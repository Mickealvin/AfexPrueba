using AfexPrueba.Model;
using AfexPrueba.Shared;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;


namespace AfexPrueba.Services
{
    public class VideosService
    {
        private readonly string API_KEY;
        private readonly HttpClient httpClient;
        private readonly AfexDbContext context;
        public VideosService()
        {
            context = new AfexDbContext();
            this.API_KEY = "AIzaSyCS2sI0Ox6-hKuW29SjMpUfYGD1ytE5BHM";
            this.httpClient = new HttpClient();
            if (httpClient.BaseAddress == null)
            {
                httpClient.BaseAddress = new Uri("https://www.googleapis.com/youtube/v3/");

            }

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<VideoInfoResponse> GetVideoInfo(string url)
        {
            // sacar el id de la url del video
            var temp = new Uri(url);
            string videoId = url.Substring(url.IndexOf("v=") + 2);
            var response = await httpClient.GetAsync($"videos?id={videoId}&key={API_KEY}&part=snippet");
            response.EnsureSuccessStatusCode();

            var video = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VideoInfoResponse>(video);
            return result;
        }

        public async Task<Videos> SaveVideo(string url)
        {
          var getvideo = await  GetVideoInfo(url);
           var result =  getvideo.Items.FirstOrDefault();

            Videos toSaveVideo = new Videos()
            {
                Titulo = result.Snippet.Title,
                Imagen = result.Snippet.Thumbnails.standard.url,
                Descripcion = result.Snippet.Description,
                Link  = url
                
            };
            context.Videos.Add(toSaveVideo);
            context.SaveChanges();
            return toSaveVideo;
        }

        public async Task<List<Videos>> GetAll()
        {
            var videos = await context.Videos.OrderByDescending(x => x.Id).ToListAsync();
            return videos;
        }
        
    }
}