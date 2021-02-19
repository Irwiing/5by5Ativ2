using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu_Fila_Chegada();
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        static void Menu_Fila_Chegada()
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

                switch (escolha)
                {
                    case "1":
                        {
                            Dados_Paciente();
                            break;
                        }
                    case "2":
                        {
                            break;
                        }
                    case "3":
                        {
                            break;
                        }
                    case "4":
                        {
                            break;
                        }
                    case "5":
                        {
                            break;
                        }
                    case "6":
                        {
                            break;
                        }
                }

            } while (escolha != "7");
        }

        static void Dados_Paciente()
        {
            string nome, sexo;
            long cpf;
            DateTime data_nascimento;

            Console.WriteLine("Informe o nome do paciente: ");
            nome = Console.ReadLine();
            Console.WriteLine("Informe o sexo do paciente: ");
            sexo = Console.ReadLine();
            Console.WriteLine("Informe o CPF do paciente: ");
            cpf = long.Parse(Console.ReadLine());
            Console.WriteLine("Informe a data de nascimento do paciente: ");
            data_nascimento = DateTime.Parse(Console.ReadLine());
        }

        static void Agravantes()
        {
            string diabetes, hipertensão, obesidade,doenca_respiratoria, fumante;

            Console.WriteLine("Informe se o paciente tem diabates: ");
            diabetes = Console.ReadLine();
            Console.WriteLine("Informe se o paciente tem obesidade: ");
            obesidade = Console.ReadLine();
            Console.WriteLine("Informe se o paciente tem hipertensão: ");
            hipertensão = Console.ReadLine();
            Console.WriteLine("Informe se o paciente tem alguma doença respiratória: ");
            doenca_respiratoria = Console.ReadLine();
            Console.WriteLine("Informe se o paciente é fumante: ");
            fumante = Console.ReadLine();

        }
    }
}
