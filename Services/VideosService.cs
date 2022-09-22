using AfexPrueba.Model;
using AfexPrueba.Shared;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        private readonly HttpClient httpClient;
        private readonly AfexDbContext context;
        private static string API_KEY = ConfigurationManager.AppSettings["API_KEY"];
        public VideosService()
        {
            context = new AfexDbContext();
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

            string videoId = url.Substring(url.IndexOf("v=") + 2);
            var response = await httpClient.GetAsync($"videos?id={videoId}&key={API_KEY}&part=snippet");
            response.EnsureSuccessStatusCode();

            var video = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VideoInfoResponse>(video);
            return result;
        }

        public async Task<Videos> SaveVideo(string url)
        {
            var getvideo = await GetVideoInfo(url);
            var result = getvideo.Items.FirstOrDefault();
            if (result != null)
            {
                Videos toSaveVideo = new Videos()
                {
                    Titulo = result.Snippet.Title,
                    Imagen = result.Snippet.Thumbnails.high.url,
                    Descripcion = result.Snippet.Description,
                    Link = url

                };
                context.Videos.Add(toSaveVideo);
                context.SaveChanges();
                return toSaveVideo;
            }
            return null;
        }

        public async Task<List<Videos>> GetAll()
        {
            var videos = await context.Videos.OrderByDescending(x => x.Id).ToListAsync();

            return videos;
        }

        public async Task<Videos> GetId(int id)
        {
            var videos = await context.Videos.FirstOrDefaultAsync(x => x.Id == id);

            return videos;
        }

        public async Task<Videos> Delete(int id)
        {
            var video = await GetId(id);
            context.Videos.Remove(video);
            await context.SaveChangesAsync();
            return video;
        }

    }
}