using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SITE_QUEJAS.Helpers
{
    public class ClsPeticiones
    {
        //private static readonly string UrlApi = "https://localhost:44389/api/";
        private static readonly string UrlApi = "http://localhost:10977/api/";

        public async Task<Trespuesta> PostComplejo<Tenviar, Trespuesta>(Tenviar enviar,string url)
        {
            HttpClient httpClient = new HttpClient();
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(enviar), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var httpResponse = await httpClient.PostAsync(UrlApi + url, httpContent);
            var responses_content = await httpResponse.Content.ReadAsStringAsync();
            Trespuesta response = JsonConvert.DeserializeObject<Trespuesta>(responses_content);

            return response;
        }

        /// <summary>
        /// Envia una peticion get que devuelve objetos como respuesta
        /// </summary>
        /// <param name="token"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<Trespuesta> GetComplejo<Tenviar, Trespuesta>(string url)
        {
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync(UrlApi + url);
            var valor = await response.Content.ReadAsStringAsync();
            Trespuesta respuesta = JsonConvert.DeserializeObject<Trespuesta>(valor);

            return respuesta;
        }

        public async Task<Trespuesta> PostComplejoAutenticado<Tenviar, Trespuesta>(Tenviar enviar, string url, string token)
        {
            Trespuesta respuesta = JsonConvert.DeserializeObject<Trespuesta>(""); ;
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(enviar), Encoding.UTF8);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await httpClient.PostAsync(UrlApi + url, httpContent);
                var valor = await response.Content.ReadAsStringAsync();
                respuesta = JsonConvert.DeserializeObject<Trespuesta>(valor);
                return respuesta;
            }
            catch (Exception ex)
            {
            }

            return respuesta;
        }

        public async Task<Trespuesta> GetComplejoAnonimo<Tenviar, Trespuesta>(string url)
        {
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync(UrlApi + url);
            var valor = await response.Content.ReadAsStringAsync();
            Trespuesta respuesta = JsonConvert.DeserializeObject<Trespuesta>(valor);

            return respuesta;
        }
    }
}
