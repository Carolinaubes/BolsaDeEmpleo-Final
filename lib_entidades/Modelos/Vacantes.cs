using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Vacantes
    {
        [Key] public int Id { get; set; } //Identificador de la vacante
        public int Empresa_id { get; set; } //Identificador de Empresa
        public int Cargo_id { get; set; } //Identificador de Cargo.
        public bool Disponibilidad { get; set; } //Se refiere a la disponibilidad de la vacante, si está activa o no

        //Creacion de objetos
        [NotMapped] public Empresas? _Empresa { get; set; }//Objeto de empresa
        [NotMapped] public Cargos? _Cargo { get; set; } //Objeto de cargo

        public bool Validar()
        {
            if (Empresa_id == 0 ||
                Cargo_id == 0)
                return false;
            return true;
        }
    }
}