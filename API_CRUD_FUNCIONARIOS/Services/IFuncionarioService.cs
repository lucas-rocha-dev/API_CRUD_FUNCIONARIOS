using API_CRUD_FUNCIONARIOS.Dto;
using API_CRUD_FUNCIONARIOS.Models;
using API_CRUD_FUNCIONARIOS.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_CRUD_FUNCIONARIOS.Services
{
    public interface IFuncionarioService

    {
        public Task<Response<Funcionario>> CreateFuncionario(FuncionarioCreateDto funcionario);
        public Task<Response<List<Funcionario>>> GetAllFuncionarios();
        public Task<Response<Funcionario>> GetById(int id);
        public Task<Response<Funcionario>> Delete(int id);
        public Task<Response<Funcionario>> EditPerId(Funcionario funcionario);

    }
}
