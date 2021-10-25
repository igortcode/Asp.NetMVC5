using DevIO.Business.Models.Fornecedores;
using System;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DevIO.Infra.Data.Repository
{
    class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await context.Fornecedores.AsNoTracking()
                .Include(f => f.Endereco)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutoEndereco(Guid id)
        {
            return await context.Fornecedores.AsNoTracking()
               .Include(f => f.Endereco)
               .Include(f => f.Produtos)
               .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
