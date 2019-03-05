using System;
using Tasklist.Domain.Enumerations;
using Tasklist.Domain.Validations;

namespace Tasklist.Domain.Entities
{
    public class Task : EntityBase
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.Active;
        public DateTime Criacao { get; private set; } = DateTime.Now;
        public DateTime? Alteracao { get; set; }
        public DateTime? Remocao { get; set; }
        public DateTime? Conclusao { get; set; }

        public override bool IsValid()
        {
            this.Validate();
            return ValidationErrors.Count == 0;
        }
    }
}
