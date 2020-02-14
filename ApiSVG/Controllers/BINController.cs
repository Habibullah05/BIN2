using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ApiSVG.Controllers
{
    [System.Web.Http.Route("[controller]")]
    public class BINController : Controller

    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BINController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
         
        }


        [HttpGet]
        [Route("GetFile")]
        public  FileResult GetFile()
        {

            string filePath =Path.Combine(_webHostEnvironment.ContentRootPath, "Contents/BINTAB_20190530.csv");
            string type = "application/csv";

            return PhysicalFile(filePath, type);
        }
        

    }
}