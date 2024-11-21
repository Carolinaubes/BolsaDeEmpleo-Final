using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Auditorias
    {
        [Key] public int Id { get; set; } //Identificador de Auditorias
        public string? Nom_Entidad { get; set; } //Corresponde al nombre de la tabla en la que se hizo cambios
        public int Entidad_id { get; set; } //Identificador del objeto en especifico el cual fue modificado
        public string? Accion { get; set; } //Accion que se hizo

        
        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nom_Entidad) ||
                Entidad_id == 0 ||
                string.IsNullOrEmpty(Accion))
                return false;
            return true;
        }
    }
}