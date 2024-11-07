using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    public class Roles
    {
        [Key] public int Id { get; set; } //Identificador de Roles
        public string? Nombre { get; set; } //Corresponde al nombre del Rol

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
                return false;
            return true;
        }
    }
}