using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDaniel
{
    public class ClienteDAO
    {
        private ProjetoContext contexto;


        public ClienteDAO()
        {
            this.contexto = new ProjetoContext();
        }


        public void Adicionar(Cliente cliente)
        {
            contexto.Clientes.Add(cliente);
            contexto.SaveChanges();
        }
    }
}
