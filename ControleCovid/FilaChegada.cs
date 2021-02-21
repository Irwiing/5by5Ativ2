using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCovid
{
    class FilaChegada
    {
        public Pessoa Head { get; set; }
        public Pessoa Tail { get; set; }
        public int Cont { get; set; }


        public bool Vazia()
        {
            if (Head == null && Tail == null)
            {
                return true;
            }
            return false;
        }

        public void Push(Pessoa aux)
        {
            if (Vazia())
            {
                Head = aux;
                Tail = aux;
            }
            else
            {
                Tail.Proximo = aux;
                Tail = aux;
            }
            Console.WriteLine("\nDados do paciente inserido na fila com sucesso!!!\n");
            Cont++;
        }

        public Pessoa Pop()
        {
            Pessoa aux = Head;
            if (Vazia())
            {
                Console.WriteLine("A fila está vazia!");

            }
            else
            {
                Head = Head.Proximo;
                if (Head == null)
                    Tail = null;
                Console.WriteLine("\nPaciente transferido de fila\n");
                Cont--;
            }
            return aux;


        }

        public void Imprimir()
        {
            if (Vazia())
            {
                Console.WriteLine("\tA fila está vazia!\n");
            }
            else
            {
                Pessoa aux = Head;

                do
                {
                    Console.WriteLine("\n" + aux.ToString() + "\n");
                    aux = aux.Proximo;
                } while (aux != null);

            }
        }
        public void SalvarCSV(string nomeArquivo)
        {
            using (StreamWriter filaWriter = new StreamWriter(nomeArquivo))
            {
                Pessoa aux = Head;
                while (aux != null)
                {
                    filaWriter.WriteLine(aux.ConverterCSV());
                    aux = aux.Proximo;
                }
            }
        }
        public void SalvarCSV(string nomeArquivo, Pessoa pessoa)
        {
            using (StreamWriter filaWriter = new StreamWriter(nomeArquivo, true))
            {
                filaWriter.WriteLine(pessoa.ConverterCSV());
            }
        }
        public void SalvarCSV(string nomeArquivo, bool escrita)
        {
            using (StreamWriter filaWriter = new StreamWriter(nomeArquivo, escrita))
            {
                Pessoa aux = Head;
                while (aux != null)
                {
                    filaWriter.WriteLine(aux.ConverterCSV());
                    aux = aux.Proximo;
                }
            }
        }

        public void ConsultarCSV(string nomeArquivo, bool estaFilaChegada)
        {
            using (StreamReader filaReader = new StreamReader(nomeArquivo))
            {
                string file = filaReader.ReadToEnd();
                string[] lines = file.Split(new char[] { '\n' });
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
                        Push(pessoa);
                    }
                }
                else
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
                        Push(pessoa);
                    }
                }
            }
        }
    }
}
