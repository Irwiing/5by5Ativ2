using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCovid
{
    class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public long Cpf { get; set; }
        public string Sexo { get; set; }
        public Pessoa Proximo { get; set; }

        public override string ToString()
        {
            return "DADOS PESSOA\nId: " + Id + "\nNome: " + Nome + "\nData Nascimento: " + DataNascimento +
                "\nCPF: " + Cpf + "\nSexo: " + Sexo;
        }

        public int CalculaIdade()
        {
            var birthdate = DataNascimento;
            var today = DateTime.Now;
            var age = today.Year - birthdate.Year;
            if (birthdate > today.AddYears(-age)) age--;
            return age;
        }
    }
}
