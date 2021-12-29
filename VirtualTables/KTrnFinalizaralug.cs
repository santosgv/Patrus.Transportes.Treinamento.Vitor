using Patrus.Transportes.Treinamento.Vitor.Services;

namespace Patrus.Transportes.Treinamento.Vitor.VirtualTables
{
    /// <summary>
    /// Nome da Tabela: K_TRN_FINALIZARALUG_VITOR.
    /// Essa é uma classe parcial, os atributos, herança e propriedades estão definidos no arquivo KTrnFinalizaralug.properties.cs
    /// </summary>
    public partial class KTrnFinalizaralug
    {
        protected override void Saving()
        {
            var servico = AluguelService.CreateInstance();
            servico.FinalizarAluguelVeiculo(VeiculoHandle, DataDevolucao.GetValueOrDefault(), ResponsavelDevolucao);
            base.Saving();
        }
    }
}
