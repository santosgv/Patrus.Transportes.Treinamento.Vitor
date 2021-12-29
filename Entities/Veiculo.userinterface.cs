using Benner.Tecnologia.Common;
using Benner.Tecnologia.Common.Scripting.UserInterface;


namespace Patrus.Transportes.Treinamento.Vitor.Entities
{
    
    
    [ScriptUI()]
    public partial class Veiculo
    {
        [FieldChanged(FieldNames.EstadoPlaca)]



        public void EstadoChange()
        {
            {
                if (EstadoPlaca.Handle.ToLong().IsHandleValid())
                    Municipio.Association.LocalWhere = $"MUNICIPIOS.ESTADO = {EstadoPlacaHandle}";
                else
                    Municipio.Association.LocalWhere = string.Empty;
                Municipio.Clear();



            }
        }



        [FieldChanged(FieldNames.Municipio)]



        public void MunicipioChanged()
        {



            if (Municipio.Handle.ToLong().IsHandleInvalid())
                Municipio.Association.LocalWhere = $"ESTADOS.MUNICIPIO = {MunicipioHandle}";



            else
                EstadoPlaca.Association.LocalWhere = string.Empty;

        }



    }
}
