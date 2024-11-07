using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    public class Cargos
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
                return false;
            return true;
        }
    }
}