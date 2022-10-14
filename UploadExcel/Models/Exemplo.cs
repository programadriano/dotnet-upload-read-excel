namespace UploadExcel.Models
{
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
