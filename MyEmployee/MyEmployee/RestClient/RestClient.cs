using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyEmployee.RestClient
{
    public class RestClient<T>
    {
        private const string WebServiceUrl = "http://oxynovasoft.com/api/Employees/";

        public async Task<List<T>> GetAsync()
        {
            var httpClient = new HttpClient();
            try
            {
                var json = await httpClient.GetStringAsync(WebServiceUrl);
                
                var taskModels = JsonConvert.DeserializeObject<List<T>>(json);
        BugTracker.BugTrackers.NetworkSteps += " Time : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") +" Api  Get  Funcation   : "+ WebServiceUrl+"  \r \n ";
  
        return taskModels;
            }
            catch (Exception ex)
            {
            }
            return null;


        }

        public async Task<T> PostAsync(T t,string url)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);
      if(!url.Contains("http://screenshare.azurewebsites.net/"))
            BugTracker.BugTrackers.NetworkSteps += " Time : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " Api  POST  Funcation   : " + url + "  + data "+ json + " \r \n ";
        
      httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(url, httpContent);
          var responseString = await result.Content.ReadAsStringAsync();
      var taskModels = JsonConvert.DeserializeObject<T>(responseString);

      return taskModels;
        }

        public async Task<bool> PutAsync(int id, T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
      BugTracker.BugTrackers.NetworkSteps += " Time : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " Api  PUT  Funcation   : " + WebServiceUrl + id + "  + data " + json + " \r \n ";


      var result = await httpClient.PutAsync(WebServiceUrl + id, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id, T t)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(WebServiceUrl + id);
      BugTracker.BugTrackers.NetworkSteps += " Time : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " Api  Delete   Funcation   : " + WebServiceUrl + id + " \r \n ";

      return response.IsSuccessStatusCode;
        }
    }
}
