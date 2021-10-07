using DevIO.Business.Models.Fornecedores;
using DevIO.Business.Models.Produtos;
using DevIO.Infra.Data.Mappings;
using System.Data.Entity;

namespace DevIO.Infra.Data.Context
{
    public class MeusProdutosDbContext : DbContext
    {
        public MeusProdutosDbContext() : base("DefaultConnection")
        {}

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProdutoConfig());
            modelBuilder.Configurations.Add(new FornecedorConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
        }
    }
}
