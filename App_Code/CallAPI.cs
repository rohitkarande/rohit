using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

/// <summary>
/// Summary description for CallAPI
/// </summary>
public class CallAPI
{
    public string call(string _Title,string _Message,string[] _SrNoGUID,string _SrNoBuilding,string _SrNoSector,string _SrNoTownship)
    {
        string str = "";
        string sBaseUrl = "";  //API URL
        if (sBaseUrl != "")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sBaseUrl);
            request.Method = "POST";
            request.ContentType = "application/json;charset=utf-8";
            //request.UnsafeAuthenticatedConnectionSharing = true;
            //request.Credentials = new NetworkCredential("mrinalkumarjha", "*******");

            request.Headers.Add("_Title", _Title);
            request.Headers.Add("_Message", _Message);
            //request.Headers.Add("_SrNoGUID", _SrNoGUID);
            request.Headers.Add("_SrNoBuilding", _SrNoBuilding);
            request.Headers.Add("_SrNoSector", _SrNoSector);
            request.Headers.Add("_SrNoTownship", _SrNoTownship);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            str = reader.ReadToEnd();
        }
        else
        {
            str = "Please Enter base URL";
        }
        return str;
    }
    
     //static void Main()
     //   {
     //       RunAsync().Wait();
     //   }


        //static async Task RunAsync()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:9000/");
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        // HTTP GET
        //        HttpResponseMessage response = await client.GetAsync("api/products/1");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            Notice _ObjNotice = await response.Content.ReadAsAsync<Notice>();
        //            Console.WriteLine("{0}\t${1}\t{2}", _ObjNotice._FlatNo, _ObjNotice._Sector, _ObjNotice._Title);
        //        }

        //        // HTTP POST
        //        var gizmo = new Notice() { Name = "Gizmo", Price = 100, Category = "Widget" };
        //        response = await client.PostAsJsonAsync("api/products", gizmo);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            Uri gizmoUrl = response.Headers.Location;

        //            // HTTP PUT
        //            gizmo.Price = 80;   // Update price
        //            response = await client.PutAsJsonAsync(gizmoUrl, gizmo);

        //            // HTTP DELETE
        //            response = await client.DeleteAsync(gizmoUrl);
        //        }
        //    }
        //}
    

}