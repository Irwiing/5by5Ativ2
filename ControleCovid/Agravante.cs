namespace ControleCovid
{
    public class Agravante
    {
        public bool Diabetes { get; set; }
        public bool Fumante { get; set; }
        public bool Hipertensao { get; set; }
        public bool ProblemasRespiratorios { get; set; }
        public bool Obesidade { get; set; }
        public override string ToString()
        {
            return $"\nDiabetes: {Diabetes}\nFumante: {Fumante}\nHipertensão: {Hipertensao}" +
                $"\nProblemas respiratorios: {ProblemasRespiratorios}\nObesidade: {Obesidade}";
        }
        public string ConverterCSV()
        {
            return $"{Diabetes},{Fumante},{Hipertensao},{ProblemasRespiratorios},{Obesidade}";
        }
    }
}