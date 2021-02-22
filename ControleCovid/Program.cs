using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ControleCovid
{
    class Program
    {

        static void Main(string[] args)
        {
            string escolha;
            int contador = 0;

            FilaChegada filaChegadaPreferencial = new FilaChegada
            {
                Tail = null,
                Head = null
            };

            FilaChegada filaChegada = new FilaChegada
            {
                Tail = null,
                Head = null,
            };

            FilaChegada filaSemCovid = new FilaChegada
            {
                Tail = null,
                Head = null,
            };

            FilaChegada filaQuarentena = new FilaChegada
            {
                Tail = null,
                Head = null,
            };

            FilaChegada filaInternado = new FilaChegada
            {
                Tail = null,
                Head = null,
            };

            FilaChegada relatorio = new FilaChegada
            {
                Tail = null,
                Head = null,
            };

            filaChegada.SalvarCSV("FilaChegada.csv", true); //segundo parametro booleano para não recriar o arquivo
            filaChegada.ConsultarCSV("FilaChegada.csv", true); //segundo parametro booleano para saber se já tem cadastro de fixa


            filaChegadaPreferencial.SalvarCSV("FilaChegadaPreferencial.csv", true); ;//segundo parametro booleano para não recriar o arquivo
            filaChegadaPreferencial.ConsultarCSV("FilaChegadaPreferencial.csv", true);//segundo parametro booleano para saber se já tem cadastro de fixa


            filaSemCovid.SalvarCSV("filaSemCovid.csv", true); //segundo parametro booleano para não recriar o arquivo
            filaSemCovid.ConsultarCSV("filaSemCovid.csv", false);//segundo parametro booleano para saber se já tem cadastro de fixa


            filaQuarentena.SalvarCSV("filaQuarentena.csv", true); //segundo parametro booleano para não recriar o arquivo
            filaQuarentena.ConsultarCSV("filaQuarentena.csv", false);//segundo parametro booleano para saber se já tem cadastro de fixa


            filaInternado.SalvarCSV("filaInternado.csv", true);//segundo parametro booleano para não recriar o arquivo
            filaInternado.ConsultarCSV("filaInternado.csv", false);//segundo parametro booleano para saber se já tem cadastro de fixa



            do
            {
                escolha = MenuFilaChegada();

                switch (escolha)
                {
                    case "1":

                        Pessoa p = DadosPaciente();
                        if (p.CalculaIdade() >= 60)
                        {
                            filaChegadaPreferencial.Push(p);
                            filaChegadaPreferencial.SalvarCSV("FilaChegadaPreferencial.csv");
                        }
                        else
                        {

                            filaChegada.Push(p);
                            filaChegada.SalvarCSV("FilaChegada.csv");

                        }
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("\t\n----------Lista de espera----------\n");
                        Console.WriteLine(" ---> Fila Preferencial <---\n");
                        filaChegadaPreferencial.Imprimir();

                        Console.WriteLine(" ---> Fila Normal <---\n");
                        filaChegada.Imprimir();


                        Console.WriteLine("\nPressione qualquer tecla voltar ao menu principal...");
                        Console.ReadKey();
                        break;

                    case "3":

                        Pessoa pP;
                        if (contador < 2 && !(filaChegadaPreferencial.Vazia()))
                        {
                            // IDOSO
                            pP = filaChegadaPreferencial.Pop();
                            pP = CadastrarDoencas(pP);
                            pP.Proximo = null;
                            filaChegadaPreferencial.SalvarCSV("FilaChegadaPreferencial.csv");
                            contador++;
                        }
                        else if (!filaChegada.Vazia())
                        {
                            // NORMAL

                            pP = filaChegada.Pop();
                            pP = CadastrarDoencas(pP);
                            pP.Proximo = null;

                            filaChegada.SalvarCSV("FilaChegada.csv");
                            contador = 0;
                        }
                        else
                        {
                            break;
                        }


                        switch (pP.fichaDoencas.Status)
                        {
                            case 1: // FILA QUARENTENA
                                filaQuarentena.Push(pP);
                                filaQuarentena.SalvarCSV("filaQuarentena.csv", pP);
                                break;
                            case 2: // FILA INTERNADOS

                                filaInternado.Push(pP);
                                filaInternado.SalvarCSV("filaInternado.csv", pP);

                                break;
                            case 3: // FILA SEM COVID
                                filaSemCovid.Push(pP);
                                filaSemCovid.SalvarCSV("filaSemCovid.csv", pP);
                                break;
                        }
                        break;

                    case "4": // IMPRESSAO COM COVID
                        Console.Clear();

                        Console.WriteLine(" ---> Fila de espera para Internação <---\n");
                        filaInternado.Imprimir();

                        Console.WriteLine(" ---> Fila de espera para Quarentena <---\n");
                        filaQuarentena.Imprimir();

                        Console.WriteLine("\nPressione qualquer tecla voltar ao menu principal...");
                        Console.ReadKey();
                        break;

                    case "5": // IMPRESSAO SEM COVID
                        Console.Clear();

                        Console.WriteLine(" ---> Fila de espera de Alta <--- ");
                        filaSemCovid.Imprimir();

                        Console.WriteLine("\nPressione qualquer tecla voltar ao menu principal...");
                        Console.ReadKey();

                        break;

                    case "6":

                        while (!filaInternado.Vazia())
                        {
                            Pessoa pessoa = filaInternado.Pop();
                            filaInternado.SalvarCSV("filaInternado.csv");
                            relatorio.Push(pessoa);
                        }


                        while (!filaQuarentena.Vazia())
                        {
                            Pessoa pessoa = filaQuarentena.Pop();
                            filaQuarentena.SalvarCSV("filaQuarentena.csv");
                            relatorio.Push(pessoa);
                        }


                        while (!filaSemCovid.Vazia())
                        {
                            Pessoa pessoa = filaSemCovid.Pop();
                            filaSemCovid.SalvarCSV("filaSemCovid.csv");
                            relatorio.Push(pessoa);
                        }

                        relatorio.SalvarCSV("Relatorio.csv");
                        relatorio = new FilaChegada();
                        relatorio.ConsultarCSV("Relatorio.csv", false);
                        Console.Clear();
                        Console.WriteLine(" ---> Relatorio de Consultas <--- ");
                        relatorio.Imprimir();

                        Console.WriteLine("\nPressione qualquer tecla voltar ao menu principal...");
                        Console.ReadKey();
                        break;
                }

            } while (escolha != "0");

        }

        static string MenuFilaChegada()
        {
            string escolha;
            Console.Clear();
            Console.WriteLine("Informe o que você deseja: ");

            Console.WriteLine("\n1)Cadastrar paciente: " +
                              "\n2)Mostrar Fila do atendimento inicial: " +
                              "\n3)Cadastro de ficha médica" +
                              "\n4)Mostrar fila com pacientes com Covid-19" +
                              "\n5)Mostrar fila com pacientes sem Covid 19" +
                              "\n6)Relatório" +
                              "\n0)Sair do programa!");
            escolha = Console.ReadLine();
            return escolha;
        }

        static Pessoa DadosPaciente()
        {
            int id;
            string nome, sexo;
            long cpf;
            DateTime data_nascimento;

            Console.WriteLine("Informe o ID do paciente: ");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o nome do paciente: ");
            nome = Console.ReadLine();
            Console.WriteLine("Informe o sexo do paciente: ");
            sexo = Console.ReadLine();
            Console.WriteLine("Informe o CPF do paciente: ");
            cpf = long.Parse(Console.ReadLine());
            Console.WriteLine("Informe a data de nascimento do paciente (xx/xx/xxxx): ");
            data_nascimento = DateTime.Parse(Console.ReadLine());



            return new Pessoa
            {
                Id = id,
                Nome = nome,
                Sexo = sexo,
                Cpf = cpf,
                DataNascimento = data_nascimento,
            };
        }

        static Pessoa CadastrarDoencas(Pessoa pessoa)
        {
            int diasSintomas, status;
            bool diabetes, fumante, hipertensao, problemasRespiratorios, obesidade;
            Console.Clear();

            Console.WriteLine(pessoa.ToString() + "\n");

            Console.WriteLine("A quantos dias o paciente percebeu os sintomas: ");
            diasSintomas = int.Parse(Console.ReadLine());
            
            Console.WriteLine("O paciente possui diabetes? 0(Não) ou 1(Sim): ");
            diabetes = int.Parse(Console.ReadLine()) == 0 ? false : true;

            Console.WriteLine("O paciente fuma? 0(Não) ou 1(Sim): ");
            fumante = int.Parse(Console.ReadLine()) == 0 ? false : true;

            Console.WriteLine("O paciente possui hipertensao 0(Não) ou 1(Sim): ");
            hipertensao = int.Parse(Console.ReadLine()) == 0 ? false : true;

            Console.WriteLine("O paciente possui problemas respiratorios 0(Não) ou 1(Sim): ");
            problemasRespiratorios = int.Parse(Console.ReadLine()) == 0 ? false : true;

            Console.WriteLine("O paciente possui obesidade 0(Não) ou 1(Sim): ");
            obesidade = int.Parse(Console.ReadLine()) == 0 ? false : true;

            do
            {
                Console.WriteLine("\nQual fila o paciente será mandado " +
                              "\n1)Quarentena" +
                              "\n2)Internados" +
                              "\n3)Sem Covid-19 ");
                status = int.Parse(Console.ReadLine());
            } while (status != 1 && status != 2 && status != 3);


            pessoa.fichaDoencas = new FichaDoencas
            {
                agravante = new Agravante
                {
                    Diabetes = diabetes,
                    Fumante = fumante,
                    Hipertensao = hipertensao,
                    ProblemasRespiratorios = problemasRespiratorios,
                    Obesidade = obesidade
                },
                DiasSintomas = diasSintomas,
                Status = status
            };



            return pessoa;

        }
    }
}
