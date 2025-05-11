using API_CRUD_FUNCIONARIOS.Models;
using API_CRUD_FUNCIONARIOS.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_CRUD_FUNCIONARIOS.Services
{
    public interface IFuncionarioService

    {
        public Task<Response<Funcionario>> CreateFuncionario(Funcionario funcionario);
        public Task<Response<List<Funcionario>>> GetAllFuncionarios();
        public Task<Response<Funcionario>> GetPerId(int id);
        public Task<Response<Funcionario>> DeletePerId(int id);
    }
}
