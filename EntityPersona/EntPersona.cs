using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityPersona
{
    public class EntPersona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public int Edad { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int EstadoCivil { get; set; }

        public EntEstadoCivil EntEstadoCivil { get; set; } 

        public string nombreCompleto;
        public string NombreCompleto 
        {
            get 
            {
                nombreCompleto =$"{Nombre} {Paterno} {Materno}";
                return nombreCompleto; 
            }
        }


    }
}
