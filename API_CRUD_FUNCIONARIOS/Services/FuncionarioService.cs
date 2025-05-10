using API_CRUD_FUNCIONARIOS.Models.Entities;
using API_CRUD_FUNCIONARIOS.Models;
using API_CRUD_FUNCIONARIOS.Context;

namespace API_CRUD_FUNCIONARIOS.Services
{
    public class FuncionarioService : IFuncionarioService
    {

        private FuncionarioContext _context;

        public FuncionarioService(FuncionarioContext context)
        {
            _context = context;
        }

        public Task<Response<Funcionario>> CreateFuncionario(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Funcionario>> FuncionariGet()
        {
            throw new NotImplementedException();
        }
    }
}
