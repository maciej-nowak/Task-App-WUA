using System;
using System.Collections.Generic;
using System.Text;
using Windows.Web.Http.Headers;
using Windows.Web.Http;
using Newtonsoft.Json;
using TaskApp.Models;
using System.Threading.Tasks;

namespace TaskApp
{
    public static class RestApi
    {
        
        public static String URL = "http://windowsphoneuam.azurewebsites.net/api/todotasks";
        public static Uri URI = new Uri(URL);
        public static HttpClient httpClient = new HttpClient();

        public static async Task<List<ToDoTask>> getTasks()
        {
            List<ToDoTask> tasks = null;
            try
            {
                var result = await httpClient.GetStringAsync(URI);
                tasks = JsonConvert.DeserializeObject<List<ToDoTask>>(result);
            }
            catch
            {     
            }

            return tasks;
        }

        public static async Task<ToDoTask> getTask(int id)
        {
            Uri uriID = new Uri(URL + "?id=" + id.ToString());
            ToDoTask task = null;
            try
            {
                var result = await httpClient.GetStringAsync(uriID);
                task = JsonConvert.DeserializeObject<ToDoTask>(result);
            }
            catch
            {
            }
            return task;
        }

        public static async Task<int> postTask(String postBody)
        {
            int code = 500;
            try
            {               
                HttpRequestMessage msg = new HttpRequestMessage(new HttpMethod("POST"), URI);
                msg.Content = new HttpStringContent(postBody);
                msg.Content.Headers.ContentType = new HttpMediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await httpClient.SendRequestAsync(msg);
                code = (int) response.StatusCode;
            }
            catch
            {
            }
            return code;
        }
        public static async Task<int> deleteTask(int id)
        {
            int code = 500;
            Uri uriID = new Uri(URL + "?id=" + id.ToString());
            try
            {
                HttpResponseMessage response = await httpClient.DeleteAsync(uriID);
                code = (int)response.StatusCode;
            }
            catch
            {
            }
            return code;
        }

        public static async Task<int> putTask(int id, String postBody)
        {
            int code = 500;
            Uri uriID = new Uri(URL + "?id=" + id.ToString());
            try
            {
                HttpRequestMessage msg = new HttpRequestMessage(new HttpMethod("PUT"), uriID);
                msg.Content = new HttpStringContent(postBody);
                msg.Content.Headers.ContentType = new HttpMediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await httpClient.SendRequestAsync(msg);
                code = (int)response.StatusCode;
            }
            catch
            {
            }
            return code;
        }
    }


}
