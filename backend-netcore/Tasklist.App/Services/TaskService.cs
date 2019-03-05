using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Tasklist.Domain.DTO;
using Tasklist.Domain.Entities;
using Tasklist.Domain.Enumerations;
using Tasklist.Domain.Interfaces;

namespace Tasklist.App.Services
{
    public class TaskService : ITaskService
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _repository;
        public TaskService(IMapper mapper, ITaskRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public ICollection<TaskDto> Listar()
        {
            return _repository.QueryAsNoTracking()
                .Where(x => x.Status != TaskStatus.Deleted)
                .Select(x => _mapper.Map<TaskDto>(x)).ToList();
        }

        public long Cadastrar(TaskDto task)
        {
            return _repository.SaveOrUpdate(_mapper.Map<Task>(task));
        }

        public bool Atualizar(long id, TaskDto taskDto)
        {
            var task = _repository.GetById(id);
            task.Descricao = taskDto.Descricao;
            task.Titulo = taskDto.Titulo;
            task.Alteracao = DateTime.Now;
            return _repository.SaveOrUpdate(task) > 0;
        }

        public bool Apagar(long id)
        {
            var task = _repository.GetById(id);
            task.Status = TaskStatus.Deleted;
            task.Remocao = DateTime.Now;
            return _repository.SaveOrUpdate(task) > 0;
        }

        public bool AlterarStatus(long id)
        {
            var task = _repository.GetById(id);

            if (task.Status == TaskStatus.Active)
            {
                task.Status = TaskStatus.Done;
                task.Conclusao = DateTime.Now;
            }
            else
            {
                task.Status = TaskStatus.Active;
                task.Conclusao = null;
            }

            return _repository.SaveOrUpdate(task) > 0;
        }
        
    }
}
