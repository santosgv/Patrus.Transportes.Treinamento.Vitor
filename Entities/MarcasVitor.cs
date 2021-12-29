using Benner.Tecnologia.Business.Validation.Validators;
using Benner.Tecnologia.Common;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace Patrus.Transportes.Treinamento.Vitor.Entities
{
    /// <summary>
    /// Nome da Tabela: K_TRN_MARCAS_VITOR.
    /// Essa é uma classe parcial, os atributos, herança e propriedades estão definidos no arquivo MarcasVitor.properties.cs
    /// </summary>
    public partial class MarcasVitor
    {
        public override void Validate(ValidationResults validationResults)
        {
            var marcarepository = MarcasVitorDao.CreateInstance();

            if (marcarepository.Exists(Marca => Marca.Nome == this.Nome && Marca.Handle !=this.Handle.Value ))
                validationResults.AddMessage($"Ja existe uma marca com este nome {Nome}");


            base.Validate(validationResults);
        }


    }
}
