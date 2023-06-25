using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDaniel
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }

        //public Cliente() 
        //{
        //    Id = 011111;
        //}


        public override string ToString()
        {
            return " ==== Dados do Cliente ==== \n" +
                   $"Nome do cliente: {this.Nome} \n" +
                   $"Idade do cliente: {this.Idade} \n" +
                   $"Cpf do cliente: {this.Cpf} \n" +
                   $"Email do cliente: {this.Email}\n\n";

        }
    }
}
