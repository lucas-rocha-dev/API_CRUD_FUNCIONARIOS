using API_CRUD_FUNCIONARIOS.Models.Entities;
using API_CRUD_FUNCIONARIOS.Models;
using API_CRUD_FUNCIONARIOS.Context;
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
                resposta.MENSAGEM = "Funcionario cadastrado";
                return resposta;
            }
            catch (Exception ex) {
                resposta.DADOS = null;
                resposta.STATUS = false;
                resposta.MENSAGEM = ex.Message;

                return resposta;

            }


        }

        public async Task<Response<List<Funcionario>>> GetAllFuncionarios()
        {
            Response<List<Funcionario>> resposta = new Response<List<Funcionario>>();
            try {
                var funcionarios = await _context.Funcionarios.ToListAsync();
                resposta.DADOS = funcionarios;
                resposta.STATUS = true;
                resposta.MENSAGEM = "Todos funcionarios listados";


                return resposta;
            }
            catch (Exception ex) {
                resposta.DADOS = null;
                resposta.STATUS = true;
                resposta.MENSAGEM = ex.Message;
                return resposta;
            }
        }

        public async Task<Response<Funcionario>> GetPerId(int id)
        {
            Response<Funcionario> resposta = new Response<Funcionario>();


            try {
                var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(fun => fun.ID == id);
                if(funcionario == null) {
                    resposta.DADOS = funcionario;
                    resposta.STATUS = true;
                    resposta.MENSAGEM = "Funcionario não existe!";

                }
                else {
                    resposta.DADOS = funcionario;
                    resposta.STATUS = true;
                    resposta.MENSAGEM = "Funcionario encontrado!";
                }

                return resposta;
            
            }catch (Exception ex) {

                resposta.DADOS = null;
                resposta.STATUS = true;
                resposta.MENSAGEM= ex.Message;
                return resposta;

            }
        }

        public async Task<Response<Funcionario>> DeletePerId(int id)
        {
            Response<Funcionario> resposta = new Response<Funcionario>();

            try {
                var funcionario = await _context.Funcionarios.FirstOrDefaultAsync( fun => fun.ID == id);
                if (funcionario == null) {
                    resposta.STATUS = true;
                    resposta.DADOS = null;
                    resposta.MENSAGEM = "Funcionario não encontrado";
                }
                else {
                    resposta.STATUS = true;
                    resposta.DADOS = funcionario;
                    resposta.MENSAGEM = "Funcionario DELETADO!";
                     _context.Funcionarios.Remove(funcionario);
                    await _context.SaveChangesAsync();
                }
                return resposta;
            
            } catch(Exception ex) {
                resposta.STATUS = true;
                resposta.DADOS = null;
                resposta.MENSAGEM = ex.Message;

                return resposta;

            }
            
        }

        public async Task<Response<Funcionario>> EditPerId(Funcionario funcionario)
        {
            Response<Funcionario> resposta = new Response<Funcionario>();

            try {
                var funcionarioResposta = await _context.Funcionarios.FirstOrDefaultAsync(fun => fun == funcionario);
                if (funcionarioResposta == null) {
                    resposta.STATUS = true;
                    resposta.DADOS = null;
                    resposta.MENSAGEM = "Funcionario não encontrado";
                }
                else {

                    funcionarioResposta.NOME = funcionario.NOME;
                    funcionarioResposta.SALARIO = funcionario.SALARIO;
                    funcionarioResposta.CARGO = funcionario.CARGO;
                    _context.Funcionarios.Update(funcionarioResposta);

                    await _context.SaveChangesAsync();

                    resposta.STATUS = true;
                    resposta.DADOS = funcionario;
                    resposta.MENSAGEM = "Funcionario Editado!";
                    _context.Funcionarios.Remove(funcionario);
                    await _context.SaveChangesAsync();
                }
                return resposta;


            }
            catch (Exception ex) {
                resposta.STATUS = true;
                resposta.DADOS = null;
                resposta.MENSAGEM = ex.Message;

                return resposta;

            }
        }
    }
}
