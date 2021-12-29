using Benner.Tecnologia.Business.Validation.Validators;
using Benner.Tecnologia.Common;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System;

namespace Patrus.Transportes.Treinamento.Vitor.Entities
{
    /// <summary>
    /// Nome da Tabela: K_TRN_VITOR_VEICULOS.
    /// Essa é uma classe parcial, os atributos, herança e propriedades estão definidos no arquivo Veiculo.properties.cs
    /// </summary>
    public partial class Veiculo
    {
        public override void Validate(ValidationResults validationResults)
        {

            // valida o ano do veiculo 
            if (Ano.GetValueOrDefault() > BennerContext.Administration.ServerDate().Year)
                validationResults.AddMessage("O ano do veículo não pode ser superior ao ano corrente !");

            // tipo do cadastro proprio
            if (Tipo == 1)
            {
                //data aquisicao nao pode ser superior
                if (DataAquisicao.GetValueOrDefault() > BennerContext.Administration.ServerDate().Date)
                    validationResults.AddMessage("A data da aquisiçao nao pode ser superior a data atual !");

                // obriga o preenchimento da data aquisicao
                if (DataAquisicao.HasValue == false)
                    validationResults.AddMessage("O campo data de Aquisiçao precisa de uma data");

                //  o se o valor da aquisicao for preenchido o mesmo precisa ser maior que zero
                if (ValorAquisicao.HasValue == true)
                    if (ValorAquisicao.GetValueOrDefault() <= 0)
                        validationResults.AddMessage("O valor precisa ser maior que Zero");
            }

            //tipo do cadastro fornecedor
            if (Tipo == 2)
            {
               if (Fornecedor.IsHandleValid() ==false)
                {
                    // obriga o preenchimento do fornecedor
                    validationResults.AddMessage("O fornecedor e obrigatorio");
                }

                // obriga o preenchimento da data fim
                if (DataFim.HasValue() == false)
                    validationResults.AddMessage("O campo data fim de uso é obrigatório");
                // data fim nao pode ser inferior a data corrente
                if (DataFim.GetValueOrDefault() < BennerContext.Administration.ServerDate().Date)
                    validationResults.AddMessage("A data Fim nao pode ser inferior a data corrente");
            }

            var veiculorepositoriy = VeiculoDao.CreateInstance();
            // expressao lambda de verificar consulta no banco

            if (veiculorepositoriy.Exists(Veiculo => Veiculo.Placa == this.Placa && Veiculo.Handle != this.Handle.Value))
                validationResults.AddMessage($"O veiculo ja possui registro na base '{Placa}' usando expressao lambda");

            // Usando o criteria para consultar o banco
            // var Criteria = new Criteria("A.MODELO=:MODELO", new Parameter("MODELO", this.Modelo));
            // if (veiculorepositoriy.Exists(Criteria))
            //    validationResults.AddMessage($"Esta marca ja possui registro na base '{Modelo}' ");



            if (Marcad.Handle.ToLong().IsHandleValid())
                Marcad.LocalWhere = $"Marca = {MarcadHandle}";
            else
                Marcad.LocalWhere = string.Empty;
            Marcad.Clear();


            if (Modelocad.Handle.ToLong().IsHandleInvalid())
                Modelocad.LocalWhere = $"Modelo = {ModelocadHandle}";
            else
                Modelocad.LocalWhere = string.Empty;



            base.Validate(validationResults);
        }


    }
}
