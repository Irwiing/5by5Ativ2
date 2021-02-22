using System;
using System.Collections.Generic;
using System.IO;
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
        public FichaDoencas fichaDoencas { get; set; }
        public Pessoa Proximo { get; set; }

        public override string ToString()
        {
            return $"DADOS PESSOA\nId: {Id}\nNome: {Nome}\nData Nascimento:  {DataNascimento.ToString("dd/MM/yyyy")} " +
                $"\nCPF: {Cpf}\nSexo: {Sexo}{fichaDoencas}";
        }

        public int CalculaIdade()
        {
            var birthdate = DataNascimento;
            var today = DateTime.Now;
            var age = today.Year - birthdate.Year;
            if (birthdate > today.AddYears(-age)) age--;
            return age;
        }

        public string ConverterCSV()
        {
            return $"{Id},{Nome},{DataNascimento},{Cpf},{Sexo},{fichaDoencas?.ConverterCSV()}";
        }
        public void SalvarCSV(string nomeArquivo)
        {
            using (StreamWriter filaWriter = new StreamWriter(nomeArquivo, true))
            {
                filaWriter.WriteLine(ConverterCSV());
            }
        }
        public Pessoa[] ConsultarCSV(string nomeArquivo, bool estaFilaChegada)
        {
            using (StreamReader filaReader = new StreamReader(nomeArquivo))
            {
                string file = filaReader.ReadToEnd();
                string[] lines = file.Split(new char[] { '\n' });
                List<Pessoa> listaPessoa = new List<Pessoa>();
                if (estaFilaChegada)
                {
                    for (int i = 0; i < lines.Length - 1; i++)
                    {
                        string[] infoPessoa = lines[i].Split(',');
                        Pessoa pessoa = new Pessoa()
                        {
                            Id = int.Parse(infoPessoa[0]),
                            Nome = infoPessoa[1],
                            DataNascimento = DateTime.Parse(infoPessoa[2]),
                            Cpf = long.Parse(infoPessoa[3]),
                            Sexo = infoPessoa[4]
                        };

                        listaPessoa.Add(pessoa);
                    }
                }else
                {
                    for (int i = 0; i < lines.Length - 1; i++)
                    {
                        string[] infoPessoa = lines[i].Split(',');
                        Pessoa pessoa = new Pessoa()
                        {
                            Id = int.Parse(infoPessoa[0]),
                            Nome = infoPessoa[1],
                            DataNascimento = DateTime.Parse(infoPessoa[2]),
                            Cpf = long.Parse(infoPessoa[3]),
                            Sexo = infoPessoa[4],
                            fichaDoencas = new FichaDoencas 
                            {
                                DiasSintomas = int.Parse(infoPessoa[5]),
                                Status = int.Parse(infoPessoa[6]),
                                agravante = new Agravante
                                {
                                    Diabetes = bool.Parse(infoPessoa[7]),
                                    Fumante = bool.Parse(infoPessoa[8]),
                                    Hipertensao = bool.Parse(infoPessoa[9]),
                                    ProblemasRespiratorios = bool.Parse(infoPessoa[10]),
                                    Obesidade = bool.Parse(infoPessoa[11])
                                }
                            }
                        };

                        listaPessoa.Add(pessoa);
                    }
                }
                return listaPessoa.ToArray();
            }
        }
    }
}
