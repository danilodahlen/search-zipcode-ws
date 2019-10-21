using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json.Serialization;
using System.Configuration;
using zipcode_ws.Services;
using System.Web.Http.Cors;

namespace zipcode_ws.Controllers
{
    public class ZipCodeController : ApiController
    {
        [EnableCors("*", "*", "*")]
        [RoutePrefix("api/zipcode")]
        public class ZipCodeCController : ApiController
        {
            [HttpGet]
            [Route("search")]
            public IHttpActionResult search(string code)
            {
                try
                {
                    ZibCodeService ZibCodeService = new ZibCodeService();
                    var Result = ZibCodeService.returnZipCodeViaCep(code);

                    if (Result.Errors.Any())
                        return InternalServerError(new Exception(Result.Errors.FirstOrDefault().ToString()));
                    else
                        return Ok(Result.Object);

                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
        }
    }
}
