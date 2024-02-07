using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MvcCoreAdoNet.Models
{
    public class Mascota
    {
        public string nombre { get; set; }
        public string raza { get; set; }
        public int edad {  get; set; }

        public Mascota(string nombre, string  raza, int edad)
        {
            this.nombre = nombre;
            this.raza = raza;
            this.edad = edad;
        }
    }
}
