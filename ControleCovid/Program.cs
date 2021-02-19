using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCovid
{

    class Program
    {

        static void Main(string[] args)
        {
            FilaPreferencial filaP = new FilaPreferencial
            {
                Tail = null,
                Head = null
            };

            FilaChegada fila = new FilaChegada
            {
                Tail = null,
                Head = null,
            };


            MenuFilaChegada(fila, filaP);
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        static void MenuFilaChegada(FilaChegada fila, FilaPreferencial filaP)
        {
            string escolha;

            Console.WriteLine("Informe o que você deseja: ");
            do
            {
                
                Console.WriteLine("\n1)Cadastrar paciente: " +
                                  "\n2)Mostrar Fila do atendimento inicial: " +
                                  "\n3)Procurar Pessoas por ID: " +
                                  "\n4)Mostrar fila com pacientes com Covid-19" +
                                  "\n5)Mostrar fila com pacientes sem Covid 19" +
                                  "\n6)Mostrar Internações" +
                                  "\n7)Sair do programa!");
                escolha = Console.ReadLine();
                Console.Clear();

                switch (escolha)
                {
                    case "1":

                        Pessoa p = DadosPaciente();
                        if (p.CalculaIdade() >= 60)
                        {
                            filaP.Push(p);
                        }
                        else
                        {
                            fila.Push(p);
                        }
                        break;

                    case "2":
                        Console.WriteLine("\tFila Preferencial");
                        filaP.Imprimir();

                        Console.WriteLine("\tFila normal");
                        fila.Imprimir();
                        break;

                    case "3":
                        CadastrarDoencas();
                        break;

                    case "4":

                        break;

                    case "5":

                        break;

                    case "6":

                        break;

                }

            } while (escolha != "7");
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
            Console.WriteLine("Informe a data de nascimento do paciente: ");
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

        static FichaDoencas CadastrarDoencas(Pessoa p)
        {
            int diasSintomas, status;
            bool agravante;

            Console.WriteLine("A quantos dias o paciente percebeu os sintomas: ");
            diasSintomas = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual fila o paciente será mandado " +
                              "\n1)Quarentena" +
                              "\n2)Internados" +
                              "\n3)Sem Covid-19 ");
            status = int.Parse(Console.ReadLine());

            Console.WriteLine("O paciente possui agravantes 0(Não) ou 1(Sim): ");
            agravante = bool.Parse(Console.ReadLine());

            p.fichaDoencas = new FichaDoencas
            {
                Agravante = agravante,
                DiasSintomas = diasSintomas, 
                Status = status
            };

            switch (status)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
            /*string diabetes, hipertensão, obesidade, doenca_respiratoria, fumante;

            Console.WriteLine("Informe se o paciente tem diabates: ");
            diabetes = Console.ReadLine();
            Console.WriteLine("Informe se o paciente tem obesidade: ");
            obesidade = Console.ReadLine();
            Console.WriteLine("Informe se o paciente tem hipertensão: ");
            hipertensão = Console.ReadLine();
            Console.WriteLine("Informe se o paciente tem alguma doença respiratória: ");
            doenca_respiratoria = Console.ReadLine();
            Console.WriteLine("Informe se o paciente é fumante: ");
            fumante = Console.ReadLine();*/

            return;
        }


    }
}
