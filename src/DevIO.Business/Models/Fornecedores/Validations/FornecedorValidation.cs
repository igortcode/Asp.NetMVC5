using FluentValidation;
using DevIO.Business.Core.Validations.Documents;

namespace DevIO.Business.Models.Fornecedores.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2,200)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            When(f => f.TipoFornecedor == Enums.TipoFornecedor.PessoaFisica, () => {
                RuleFor(f => ValidaCPF.IsCpf(f.Documento)).Equal(true).WithMessage("O documento fornecido é inválido");
                
                });


            When(f => f.TipoFornecedor == Enums.TipoFornecedor.PessoaJuridica, () => {
            RuleFor(f => ValidaCNPJ.IsCnpj(f.Documento)).Equal(true).WithMessage("O documento fornecido é inválido"));
            });
        }


    }
}
