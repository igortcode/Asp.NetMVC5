using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevIO.Business.Models.Produtos;

namespace DevIO.Infra.Data.Mappings
{
    public class ProdutoConfig : EntityTypeConfiguration<Business.Models.Produtos.Produto>
    {
        public ProdutoConfig()
        {
            HasKey(p => p.Id);
            
            Property(p => p.Nome)
                .HasMaxLength(200)
                .IsRequired();
            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(1000);
            Property(p => p.Imagem)
                .IsRequired()
                .HasMaxLength(200);

            HasRequired(p => p.Fornecedor)
                .WithMany(f => f.Produtos)
                .HasForeignKey(p => p.FornecedorId);

            ToTable("Produtos");

        }
    }
}
