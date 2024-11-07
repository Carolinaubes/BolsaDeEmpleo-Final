using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    public class Acciones
    {
        [Key] public int Id { get; set; } //Identificador de Acciones
        public string? Nombre { get; set; } //Corresponde al nombre de la Accion

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
                return false;
            return true;
        }
    }
}