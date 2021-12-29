using Benner.Tecnologia.Business.Validation.Validators;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace Patrus.Transportes.Treinamento.Vitor.Entities
{
    /// <summary>
    /// Nome da Tabela: K_TRN_MODELOSV_VITOR.
    /// Essa é uma classe parcial, os atributos, herança e propriedades estão definidos no arquivo ModelosvVitor.properties.cs
    /// </summary>
    public partial class ModelosvVitor
    {
        const int tamanhominimo = 5;
        public override void Validate(ValidationResults validationResults)
        {
            var modelorepositoriy = ModelosvVitorDao.CreateInstance();
            var marcarepository = MarcasVitorDao.CreateInstance();

            if (Nome.Length < tamanhominimo) validationResults.AddMessage($"Modelo com menos de 5 Caracteres");


            if (modelorepositoriy.Exists(Modelo => Modelo.Nome == this.Nome && Modelo.Handle !=this.Handle && Modelo.MarcaHandle == this.MarcaHandle ))
                validationResults.AddMessage($"O modelo ou Marca Ja existente na base com este Modelo {Nome}");

            base.Validate(validationResults);
        }
    }
}
