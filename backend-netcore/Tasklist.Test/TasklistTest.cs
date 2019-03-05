using System;
using FluentAssertions;
using Tasklist.Domain.Entities;
using Tasklist.Domain.Interfaces;
using Tasklist.Infra.Repositories;
using Tasklist.API;
using Tasklist.Domain.DTO;
using Tasklist.Domain.Enumerations;
using Xunit;

namespace Tasklist.Test
{
    public class TasklistTest
    {

        private ITaskRepository _repository;
        private ITaskService _taskService;

        public TasklistTest()
        {
            var webhost = Program.BuildWebHost(null);
            _repository = (ITaskRepository)webhost.Services.GetService(typeof(ITaskRepository));
            _taskService = (ITaskService)webhost.Services.GetService(typeof(ITaskService));
        }

        [Fact]
        public void DadaUmaTask_AoSalvar_DeveTerSalvoNoBancoDeDados()
        {
            var taskDto = new TaskDto();
            taskDto.Titulo = "Titulo";
            taskDto.Descricao = "Descrição";

            var id = _taskService.Cadastrar(taskDto);

            var task = _repository.GetById(id);

            task.Titulo.Should().Be(taskDto.Titulo);
            task.Descricao.Should().Be(taskDto.Descricao);
        }

        [Fact]
        public void DadaUmaTask_AoApagar_DeveTerAlteradoOStatusParaApagado()
        {
            var taskDto = new TaskDto();
            taskDto.Titulo = "Titulo";
            taskDto.Descricao = "Descrição";

            var id = _taskService.Cadastrar(taskDto);
            _taskService.Apagar(id);
            var task = _repository.GetById(id);
            task.Status.Should().Be(TaskStatus.Deleted);
        }

        [Fact]
        public void DadaUmaTask_AoMarcarComoFeito_DeveTerAlteradoOStatusParaFeito()
        {
            var taskDto = new TaskDto();
            taskDto.Titulo = "Titulo";
            taskDto.Descricao = "Descrição";

            var id = _taskService.Cadastrar(taskDto);
            _taskService.MarcarComoFeito(id);
            var task = _repository.GetById(id);
            task.Status.Should().Be(TaskStatus.Done);
        }
    }
}
