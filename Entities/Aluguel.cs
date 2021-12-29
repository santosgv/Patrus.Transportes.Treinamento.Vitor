using Benner.Tecnologia.Business.Validation.Validators;
using Benner.Tecnologia.Common;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace Patrus.Transportes.Treinamento.Vitor.Entities
{
    /// <summary>
    /// Nome da Tabela: K_TRN_ALUGUEL_VITOR.
    /// Essa é uma classe parcial, os atributos, herança e propriedades estão definidos no arquivo Aluguel.properties.cs
    /// </summary>
    public partial class Aluguel
    {

        public override void Validate(ValidationResults validationResults)


        {


            
            if (Situacao == AluguelSituacaoListaItens.ItemReservado && DataAluguel.GetValueOrDefault() < BennerContext.Administration.ServerDateTime())
                validationResults.AddMessage("Data do aluguel não pode ser inferior a data/hora corrente");
         
            if(ValorInicial <= 0) validationResults.AddMessage("O valor inicial precisa ser maior que ZERO");

            if (ValorInicial == null) validationResults.AddMessage("O valor inicial precisa de um valor");

            if (PgtoAntecipado.Value)
                this.ValidateNotNullField(FieldNames.ValorInicial, validationResults);
            if (DataPrevistaDevol.HasValue && DataPrevistaDevol.Value < DataAluguel.GetValueOrDefault())
                validationResults.AddMessage("Previsão de devolução não pode ser inferior a data do aluguel!");


            base.Validate(validationResults);
           
        }
        protected override void Saving()
        {
            if (DataPrevistaDevol.HasValue && EstaReservado())
                ValorFinal = CalcularValorEstimado();

            base.Saving();
        }

 

        private decimal CalcularValorEstimado()
        {
            var qtDias = (DataPrevistaDevol.GetValueOrDefault() - DataAluguel.GetValueOrDefault()).Days;
            //var veiculoRepository = VeiculoDao.CreateInstance();
            //var veiculo = veiculoRepository.Get(this.VeiculoHandle);
            //int valortotal =(int) (qtDias * veiculo.ValorDiaria);
            // return valortotal;


            // resultado melhor 
            return qtDias * VeiculoInstance.ValorDiaria.GetValueOrDefault();
        }

        public bool EstaReservado() => Situacao == AluguelSituacaoListaItens.ItemReservado;
    }

}
