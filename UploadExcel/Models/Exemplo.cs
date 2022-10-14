using System.Collections;
using System.Collections.Generic;

namespace UploadExcel.Models
{

    public class MsgValidade
    {
        public string Count { get; set; }
        public string Result { get; set; }
    }

    public class ValidateExample
    {
        public ValidateExample()
        {
            Error = new List<Exemplo>();
            Success = new List<Exemplo>();
        }
        public List<Exemplo> Error { get; private set; }
        public List<Exemplo> Success { get; private set; }
    }


    public class Exemplo
    {
        public Exemplo(string valorA, string valorB, string valorC, string valorD)
        {
            ValorA = valorA;
            ValorB = valorB;
            ValorC = valorC;
            ValorD = valorD;
        }

        public string ValorA { get; private set; }
        public string ValorB { get; private set; }
        public string ValorC { get; private set; }
        public string ValorD { get; private set; }
    }
}
