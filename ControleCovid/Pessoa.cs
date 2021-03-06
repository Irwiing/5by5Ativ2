﻿using System;
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
    }
}
