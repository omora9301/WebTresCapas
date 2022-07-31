using DataTresCapas;
using EntityPersona;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTresCapas
{
    public class BusEstadoCivil
    {
        DatEstadoCivil objConexion = new DatEstadoCivil();
        public List<EntEstadoCivil> Obtener()
        {
            DataTable dt = objConexion.Obtener();
            List<EntEstadoCivil> ls = new List<EntEstadoCivil>();
            foreach (DataRow dr in dt.Rows)
            {
                EntEstadoCivil ec = new EntEstadoCivil();
                
                ec.Id = Convert.ToInt32(dr["IdEC"]);
                ec.NombreEC = dr["NombreEC"].ToString();

                ls.Add(ec);//LLena la lista entidadpersona
            }
            return ls;
        }
    }
}
