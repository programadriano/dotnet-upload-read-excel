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

                    while (reader.Read()) //Each row of the file
                    {
                        examples.Add(new Exemplo(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString()));
                    }
                }
            }

            //Factory/Service...etc
            var validate = new ValidateExample();

            foreach (var item in examples)
            {
                if (item.ValorA.Contains("A"))
                {
                    validate.Error.Add(item);
                }
                else
                {
                    validate.Success.Add(item);

                }

            }

            return Ok(validate);
        }


    }
}
