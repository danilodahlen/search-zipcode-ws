using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using zipcode_ws.Models;

namespace zipcode_ws.Services
{
    public class ZibCodeService
    {

        public ResultObject<ZipCodeModel> returnZipCodeViaCep(string code)
        {
            ResultObject<ZipCodeModel> result = new ResultObject<ZipCodeModel>();

            try
            {
                string searchURL =  ConfigurationManager.AppSettings["URL"].ToString() + code.ToString() + "/json/";
                var request = (HttpWebRequest)WebRequest.Create(searchURL);
                var response = (HttpWebResponse)request.GetResponse();
                string responseString;
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        responseString = reader.ReadToEnd();

                        result.Object = JsonConvert.DeserializeObject<ZipCodeModel>(responseString);  
                    }
                }
            }
            catch (Exception e)
            {
                result.Errors.Add(e.ToString());
            }

            return result;
        }
    }
}