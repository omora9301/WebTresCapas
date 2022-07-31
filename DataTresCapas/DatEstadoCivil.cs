using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTresCapas
{
    public class DatEstadoCivil
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable Obtener()
        {
            SqlCommand cmd = new SqlCommand("spObtenerEstadoCivil", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            //string sentencia = "Select * From personas Order By Nombre";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
