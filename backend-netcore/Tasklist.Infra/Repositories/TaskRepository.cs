using Microsoft.EntityFrameworkCore;
using Tasklist.Domain.Interfaces;
using Tasklist.Domain.Entities;

namespace Tasklist.Infra.Repositories
{
    public class TaskRepository : GenerickRepository<Task>, ITaskRepository
    {
        public TaskRepository(DbContext context) : base(context)
        {

        }
    }
}
