using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCovid
{
    class FichaDoencas
    {      

        public Agravante agravante { get; set; }

        public int DiasSintomas { get; set; }

        public int Status { get; set; }

        public override string ToString()
        {
            return $"\nDias de sintomas: {DiasSintomas}{agravante}\nStatus: {Status}";
        }
        public string ConverterCSV()
        {
            return $"{DiasSintomas},{Status},{agravante?.ConverterCSV()}";
        }

    }
}
