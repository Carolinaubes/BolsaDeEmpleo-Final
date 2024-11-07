using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Personas_Estudios
    {
        [Key] public int Id { get; set; }  //Identificador de la relacion entre Personas y Estudios
        public int Persona_id { get; set; } //Identificador de Personas
        public int Estudio_id { get; set; } //Identificador de Estudios

        //Creacion de objetos
        [NotMapped] public Personas? _Persona { get; set; } //Objeto de personas
        [NotMapped] public Estudios? _Estudio { get; set; } //Objeto de Estudios

        public bool Validar()
        {
            if (Persona_id == 0 ||
                Estudio_id == 0)
                return false;
            return true;
        }
    }
}