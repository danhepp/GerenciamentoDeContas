using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDaniel
{
    [Serializable]
    public class ProjetoException: Exception
    {
        public ProjetoException() { }
        public ProjetoException(string message) : base("Aconteceu uma exceção ->" + message) { }
        public ProjetoException(string message, Exception inner) : base(message, inner) { }
        protected ProjetoException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
