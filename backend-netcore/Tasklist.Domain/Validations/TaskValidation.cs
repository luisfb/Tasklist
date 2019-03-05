using System;
using System.Collections.Generic;
using System.Text;
using Tasklist.Domain.Entities;

namespace Tasklist.Domain.Validations
{
    public static class TaskValidation
    {
        public static void Validate(this Task task)
        {
            if(string.IsNullOrWhiteSpace(task.Titulo))
                task.ValidationErrors.Add("O título é obrigatório.");
        }
    }
}
