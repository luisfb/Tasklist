using System;
using System.Collections.Generic;

namespace Tasklist.Domain.DTO
{
    public class TaskDto
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Concluido { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime? Alteracao { get; set; }
        public DateTime? Conclusao { get; set; }
        public ICollection<string> Erros { get; set; }
    }
}
