using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Cargos_Estudios
    {
        [Key] public int Id { get; set; } // //Identificador de la relacion entre Cargos y Estudios
        public int Cargo_id { get; set; } //Identificador de Cargos
        public int Estudio_id { get; set; } //Identificador de Estudio

        //Creacion de objetos
        [NotMapped] public Cargos? _Cargo { get; set; } //Objeto de Cargos
        [NotMapped] public Estudios? _Estudio { get; set; } //Objeto de Estudios

        public bool Validar()
        {
            if (Cargo_id == 0 ||
                Estudio_id == 0)
                return false;
            return true;
        }
    }
}