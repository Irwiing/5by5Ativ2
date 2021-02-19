﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCovid
{
    class FilaPreferencial
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
            Console.WriteLine("\nDados do paciente preferencial inserido com sucesso!!!\n");
            Cont++;
        }
        public Pessoa Pop()
        {
            Pessoa aux = Head;
            if (Vazia())
            {
                Console.WriteLine("A fila preferencial está vazia!");

            }
            else
            {
                Head = Head.Proximo;
                Console.WriteLine("\nPaciente preferencial transferido de fila\n");
                Cont--;
            }
            return aux;


        }

        public void Imprimir()
        {
            if (Vazia())
            {
                Console.WriteLine("\nA fila preferencial está vazia!\n");
                Console.ReadKey();
            }
            else
            {
                Pessoa aux = Head;
                do
                {
                    Console.WriteLine("\n"+aux.ToString()+"\n");
                    aux = aux.Proximo;

                } while (aux != null);
            }
        }

    }
}
