using API_CRUD_FUNCIONARIOS.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace API_CRUD_FUNCIONARIOS.Context
{
    public class FuncionarioContext : DbContext
    {
        public FuncionarioContext(DbContextOptions<FuncionarioContext> options) : base(options) {

        }

        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
