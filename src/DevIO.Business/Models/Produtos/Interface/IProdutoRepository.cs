using DevIO.Business.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Business.Models.Produtos.Interface
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosFornecedor(Guid fornecedorId);
        Task<IEnumerable<Produto>> ObterProdutoFornecedores();
        Task<Produto> ObterProdutoFornecedor(Guid id);
    }
}
