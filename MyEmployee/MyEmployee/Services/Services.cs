using MyEmployee.Models;
using MyEmployee.RestClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MyEmployee.Services
{

  public class Service<T>
  {


  
    public async Task<T> MakeOCRRequest(byte[] byteData)
    {
      //try
      //{
      HttpClient client = new HttpClient();

      // Request headers.
      client.DefaultRequestHeaders.Add(
          "Ocp-Apim-Subscription-Key", "b4f923a7911342389b1181eba21412d3");

      // Request parameters. 
      // The language parameter doesn't specify a language, so the 
      // method detects it automatically.
      // The detectOrientation parameter is set to true, so the method detects and
      // and corrects text orientation before detecting text.
      string requestParameters = "language=unk&detectOrientation=true";

      // Assemble the URI for the REST API method.
      string uri = "https://imageprocessingtrahtripa.cognitiveservices.azure.com/vision/v2.1/ocr" + "?" + requestParameters;

      HttpResponseMessage response;

      // Read the contents of the specified local image
      // into a byte array.
      //	byte[] byteData = GetImageAsByteArray(imageFilePath);

      // Add the byte array as an octet stream to the request body.
      using (ByteArrayContent content = new ByteArrayContent(byteData))
      {
        // This example uses the "application/octet-stream" content type.
        // The other content types you can use are "application/json"
        // and "multipart/form-data".
        content.Headers.ContentType =
            new MediaTypeHeaderValue("application/octet-stream");

        // Asynchronously call the REST API method.
        response = await client.PostAsync(uri, content);
      }

      // Asynchronously get the JSON response.
      string contentString = await response.Content.ReadAsStringAsync();
      var taskModels = JsonConvert.DeserializeObject<T>(contentString);
      return taskModels;
      // Display the JSON response.
      //	Console.WriteLine("\nResponse:\n\n{0}\n",
      //	JToken.Parse(contentString).ToString());

    }
  }
  public class Services
    {

        List<Employees> listEmployee { get; set; }

        public async Task<List<Employees>> getEmployee()
        {

            listEmployee = new List<Employees>();

            RestClient<Employees> restClient = new RestClient<Employees>();
            try
            {
                listEmployee = await restClient.GetAsync();
               BugTracker.BugTrackers.steps += " Time : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " Services  Funcation   : getEmployee \r \n ";

      }
            catch (Exception ex)
            {

            }
            return listEmployee;
        }



        public async Task<Employees> AddEmployee(Employees employees)
        {
            RestClient<Employees> restClient = new RestClient<Employees>();
            BugTracker.BugTrackers.steps += " Time : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " Services  Funcation   : AddEmployee \r \n ";

      var status = await   restClient.PostAsync(employees, "http://oxynovasoft.com/api/Employees/");
            

            return status;
        }

        public async Task<bool> UpdateEmployee(Employees employees)
        {
            RestClient<Employees> restClient = new RestClient<Employees>();
            BugTracker.BugTrackers.steps += " Time : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " Services  Funcation   : UpdateEmployee \r \n ";

      bool status = await restClient.PutAsync(employees.Id,employees);


            return status;
        }
  }
}
