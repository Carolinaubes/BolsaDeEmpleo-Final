using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    public class Estudios
    {
        [Key] public int Id { get; set; } //Identificador de Estudios
        public int Cod_estudio { get; set; } //Es un codigo que identifica a la empresa
        public string? Nombre { get; set; } //Corresponde al nombre del Estudio

        public bool Validar()
        {
            if (Cod_estudio <= 0 ||
                string.IsNullOrEmpty(Nombre))
                return false;
            return true;
        }
    }
}