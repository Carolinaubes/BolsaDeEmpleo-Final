using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Auditorias
    {
        [Key] public int Id { get; set; } //Identificador de Auditorias
        public string? Nom_Entidad { get; set; } //Corresponde al nombre de la tabla en la que se hizo cambios
        public int Entidad_id { get; set; } //Identificador del objeto en especifico el cual fue modificado
        public int Accion_id { get; set; } //Identificador de la accion que se hizo

        //Creacion de objetos
        [ForeignKey("Accion_id")] public Acciones? _Accion { get; set; } //Objeto de Acciones

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nom_Entidad) ||
                Entidad_id == 0 ||
                Accion_id == 0)
                return false;
            return true;
        }
    }
}