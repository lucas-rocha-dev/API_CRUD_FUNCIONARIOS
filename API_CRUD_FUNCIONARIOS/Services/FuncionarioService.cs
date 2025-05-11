using API_CRUD_FUNCIONARIOS.Models.Entities;
using API_CRUD_FUNCIONARIOS.Models;
using API_CRUD_FUNCIONARIOS.Context;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD_FUNCIONARIOS.Services
{
    public class FuncionarioService : IFuncionarioService
    {

        private readonly FuncionarioContext _context;

        public FuncionarioService(FuncionarioContext context)
        {
            _context = context;
        }

        public async Task<Response<Funcionario>> CreateFuncionario(Funcionario funcionario)
        {
            Response<Funcionario> resposta = new Response<Funcionario>();

            try {
                _context.Funcionarios.Add(funcionario);
                await _context.SaveChangesAsync();

                resposta.DADOS = funcionario; 
                resposta.STATUS = true;
                return resposta;
            }
            catch (Exception ex) {
                resposta.DADOS = null;
                resposta.STATUS = false;
                return resposta;
            }
  
            
        }

        public async Task<Response<Funcionario>> FuncionariGet()
        {
            throw new NotImplementedException();
        }
    }
}
