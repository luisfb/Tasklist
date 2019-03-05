using System;
using System.Collections.Generic;
using System.Text;
using Tasklist.Domain.DTO;

namespace Tasklist.Domain.Interfaces
{
    public interface ITaskService
    {
        ICollection<TaskDto> Listar();
        long Cadastrar(TaskDto task);
        bool Atualizar(long id, TaskDto taskDto);
        bool Apagar(long id);
        bool AlterarStatus(long id);
    }
}
