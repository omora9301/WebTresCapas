using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataTresCapas;//Datos Persona namesspace
using EntityPersona;//Entity Persona Namesspace

namespace BusinessTresCapas
{
    public class BusPersona
    {
        DatPersona objConexion = new DatPersona();
        DatEstadoCivil objCnn = new DatEstadoCivil();
        public List<EntPersona> Obtener()
        {
            DataTable dt = objConexion.Obtener();
            List<EntPersona> ls = new List<EntPersona>();

            foreach (DataRow dr in dt.Rows)
            {
                EntPersona p = new EntPersona();
                EntEstadoCivil ec = new EntEstadoCivil();
                p.Id = Convert.ToInt32(dr["Id"]);
                p.Nombre = dr["Nombre"].ToString();
                p.Paterno = dr["Paterno"].ToString();
                p.Materno = dr["Materno"].ToString();
                p.Edad = Convert.ToInt32(dr["Edad"]);
                p.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);

                p.EstadoCivil = Convert.ToInt32(dr["EstadoCivil"]);

                ec.Id = Convert.ToInt32(dr["IdEC"]);
                ec.NombreEC = dr["NombreEC"].ToString();

                p.EntEstadoCivil = ec;
                
                ls.Add(p);//LLena la lista entidadpersona
            }
            return ls;
        }
        public EntPersona ObtenerPersona(int id)
        {
            DataRow dr = objConexion.ObtenerEditar(id);

            EntPersona p = new EntPersona();
            p.Id = Convert.ToInt32(dr["Id"]);
            p.Nombre = dr["Nombre"].ToString();
            p.Paterno = dr["Paterno"].ToString();
            p.Materno = dr["Materno"].ToString();
            p.Edad = Convert.ToInt32(dr["Edad"]);
            p.EstadoCivil = Convert.ToInt32(dr["EstadoCivil"]);
            //p.EstadoCivil =Convert.ToInt32(dr["EstadoCivil"]is DBNull ? 0:dr["EstadoCivil"]);
            //p.EstadoCivil = Convert.ToInt32(dr["EstadoCivil"]= 0);
            //p.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);

            return p;
        }
        public string EditarPersona(EntPersona persona)
        {
            objConexion.Editar(persona.Id, persona.Nombre, persona.Paterno, persona.Materno, persona.Edad, persona.EstadoCivil);
            return $"Se edito correctamente a: {persona.NombreCompleto }";
        }
        public string AgregarPersona(EntPersona persona)
        {
            objConexion.Agregar(persona.Nombre, persona.Paterno, persona.Materno, persona.Edad, persona.EstadoCivil);
            return $"Se agrego correctamente a: {persona.NombreCompleto }";
        }
        public string EliminarPersona(EntPersona persona)
        {
            objConexion.Eliminar(persona.Id);
            return $"Se elimino correctamente a:{persona.NombreCompleto} ";
        }
        public List<EntPersona> Buscar(string valor)
        {
            DataTable dt = objConexion.Buscar(valor);
            List<EntPersona> ls = new List<EntPersona>();

            foreach (DataRow dr in dt.Rows)
            {
                EntPersona p = new EntPersona();
                p.Nombre = dr["Nombre"].ToString();
                p.Paterno = dr["Paterno"].ToString();
                p.Materno = dr["Materno"].ToString();
                p.Edad = Convert.ToInt32(dr["Edad"]);
                p.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);

                ls.Add(p);//LLena la lista entidadpersona
            }
            return ls;

        }
        public void Validar(EntPersona persona)
        {
            /*objConexion.ValidarPersona(persona.Nombre, persona.Paterno, persona.Materno);*/
            DataTable existe = objConexion.ValidarPersona(persona.Nombre, persona.Paterno, persona.Materno);
            if (existe.Rows.Count > 0)
            {
                throw new ApplicationException($"El usario {persona.Nombre} ya existe. ");
            }
        }
        public void ValidarEdad(EntPersona persona)
        {
            if (persona.Edad < 18)
            {
                throw new Exception($"El usuario {persona.NombreCompleto} es menor de edad.");
            }
        }
        public void ValidarCampos(EntPersona p)
        {
            if (p.Nombre == null || p.Paterno == null || p.Materno == null || p.Edad == 0)
            {
                throw new Exception("Campos Obligatorios");
            }
        }

        public void EditarPersonaRepetido(EntPersona persona)
        {
            DataTable existe = objConexion.UsuarioRepetidoEditar(persona.Id, persona.Nombre, persona.Paterno, persona.Materno);
            if (existe.Rows.Count > 0)
            {
                throw new ApplicationException($"El usario {persona.Nombre} ya existe. ");
            }
        }
    }
}
