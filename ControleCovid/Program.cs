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
            string escolha;
            int contador = 0;

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

            FilaSemCovid filaSemCovid = new FilaSemCovid
            {
                Tail = null,
                Head = null,
            };

            FilaQuarentena filaQuarentena = new FilaQuarentena
            {
                Tail = null,
                Head = null,
            };

            FilaInternada filaInternado = new FilaInternada
            {
                Tail = null,
                Head = null,
            };

            do {

                escolha = MenuFilaChegada();

                switch (escolha)
                {
                    case "1":

                        Pessoa p = DadosPaciente();
                        if (p.CalculaIdade() >= 60)
                            filaP.Push(p);
                        else
                            fila.Push(p);
                        break;

                    case "2":

                        Console.WriteLine("Fila Preferencial");
                        filaP.Imprimir();

                        Console.WriteLine("Fila Normal");
                        fila.Imprimir();
                        break;

                    case "3":
                        Pessoa pP;
                        if (contador < 2 && !(filaP.Vazia()))
                        {
                            // IDOSO
                            pP = filaP.Pop();
                            CadastrarDoencas(pP);

                            contador++;
                        }
                        else
                        {
                            pP = fila.Pop();
                            CadastrarDoencas(pP);

                            // NORMAL
                            contador = 0;
                        }

                        switch (pP.fichaDoencas.Status)
                        {
                            case 1: // FILA QUARENTENA
                                filaQuarentena.Push(pP);
                                break;
                            case 2: // FILA INTERNADOS
                                filaInternado.Push(pP);

                                break;
                            case 3: // FILA SEM COVID
                                filaSemCovid.Push(pP);

                                break;
                        }
                        break;

                    case "4": // IMPRESSAO COM COVID

                        Console.WriteLine("INTERNADOS");
                        filaInternado.Imprimir();

                        Console.WriteLine("QUARENTENA");
                        filaQuarentena.Imprimir();
                        break;

                    case "5": // IMPRESSAO SEM COVID

                        filaSemCovid.Imprimir();

                        break;

                    case "6":

                        break;

                }

            } while (escolha != "0");

            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        static string MenuFilaChegada()
        {
            string escolha;

            Console.WriteLine("Informe o que você deseja: ");
           
            Console.WriteLine("\n1)Cadastrar paciente: " +
                              "\n2)Mostrar Fila do atendimento inicial: " +
                              "\n3)Cadastro de ficha médica" +
                              "\n4)Mostrar fila com pacientes com Covid-19" +
                              "\n5)Mostrar fila com pacientes sem Covid 19" +
                              "\n6)Relatório" +
                              "\n7)Procurar Pessoas por ID: (EM MANUTENÇÃO)" +
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

        static void CadastrarDoencas(Pessoa p)
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
            if(int.Parse(Console.ReadLine()) == 0)
            {
                agravante = false;
            }else
                agravante = true;


            p.fichaDoencas = new FichaDoencas
            {
                Agravante = agravante,
                DiasSintomas = diasSintomas, 
                Status = status
            };

            

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
