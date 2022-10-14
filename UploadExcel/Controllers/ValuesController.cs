using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using UploadExcel.Models;

namespace UploadExcel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {


        // POST api/values
        [HttpPost]
        public IActionResult Post(IFormFile file)
        {
            List<Exemplo> examples = new List<Exemplo>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                stream.Position = 0;
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();
                    DataRowCollection dt = result.Tables[0].Rows;


                    //for (int i = 1; i < dt.Count; i++)
                    //{
                    //    for (int j = 1; j < dt.Count; j++)
                    //    {

                    //    }
                    //}

                    while (reader.Read()) //Each row of the file
                    {
                        examples.Add(new Exemplo(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString()));
                    }
                }
            }

            return Ok(examples);
        }


    }
}
