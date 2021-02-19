using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCovid
{
    class FilaQuarentena
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
            Console.WriteLine("\nDados do paciente na fila da quarentena inserido com sucesso!!!\n");
            Cont++;
        }
        public Pessoa Pop()
        {
            Pessoa aux = Head;
            if (Vazia())
            {
                Console.WriteLine("A fila da quarentena está vazia!");

            }
            else
            {
                Head = Head.Proximo;
                if (Head == null)
                    Tail = null;
                Cont--;
            }
            return aux;


        }
        public void Imprimir()
        {
            if (Vazia())
            {
                Console.WriteLine("\nA fila de quarentena está vazia!\n");
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
    }
}
