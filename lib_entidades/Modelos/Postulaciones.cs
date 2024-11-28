using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Postulaciones
    {
        [Key] public int Id { get; set; } //Identificador de la postulaciones
        public int Vacante_id { get; set; } //Identificador de la vacante
        public int Persona_id { get; set; } //Identificador de persona
        public bool Elegido { get; set; } //Indica si la persona fue seleccionada o no

        //Creacion de objetos
        [ForeignKey("Vacante_id")] public Vacantes? _Vacante { get; set; } //Objeto de vacantes
        [ForeignKey("Persona_id")] public Personas? _Persona { get; set; } //Objeto de personas

        public bool Validar()
        {
            if (Vacante_id == 0 ||
                Persona_id == 0)
                return false;
            return true;
        }
    }
}