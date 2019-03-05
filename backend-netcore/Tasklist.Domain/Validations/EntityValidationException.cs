using System;
using System.Collections.Generic;
using System.Text;

namespace Tasklist.Domain.Validations
{
    public class EntityValidationException : Exception
    {
        public IList<string> Erros { get; private set; }
        public EntityValidationException(IList<string> erros) : base("Entidade inválida")
        {
            Erros = erros;
        }
    }
}
