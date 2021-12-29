using Benner.Tecnologia.Common.Scripting.UserInterface;


namespace Patrus.Transportes.Treinamento.Vitor.Entities
{
    
    
    [ScriptUI()]
    public partial class Aluguel
    {
        [ViewLoaded]
        public void ViewLoaded()
        {
            //AfterScroll

            Visualization.Fields[FieldNames.ValorInicial].ReadOnly = !PgtoAntecipado.GetValueOrDefault();
        }
    }
}
