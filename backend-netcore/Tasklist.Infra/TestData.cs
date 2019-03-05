using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Tasklist.Domain.Entities;
using Tasklist.Infra.Repositories;

namespace Tasklist.Infra
{
    public static class TestData
    {
        private static bool _dataAdded;

        public static void AddTestData(DbContext context)
        {
            if(_dataAdded) return;
            _dataAdded = true;
            var repo = new TaskRepository(context);

            var task1 = new Task
            {
                Titulo = "Task 1",
                Descricao = "Descrição Task 1"
            };

            var task2 = new Task()
            {
                Titulo = "Task 2",
                Descricao = "Descrição Task 2"
            };

            repo.SaveOrUpdate(task1);
            repo.SaveOrUpdate(task2);
        }
    }
}
