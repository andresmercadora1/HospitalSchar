using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CDCita
    {
        Conexion objConexion = new Conexion();
        SqlCommand objCommand = new SqlCommand();
        public bool guardarCita(CECita oCita)
        {
            try
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Connection = objConexion.conectar("BDHospital");
                objCommand.CommandText = "agregar_cita"; //Nombre del procedimiento almacenado en DB
                objCommand.Parameters.AddWithValue("@cod_cita", oCita.Cod_cita);
                objCommand.Parameters.AddWithValue("@fecha", oCita.Fecha);
                objCommand.Parameters.AddWithValue("@hora", oCita.Hora);
                objCommand.Parameters.AddWithValue("@id_paciente", oCita.Id_paciente);
                objCommand.Parameters.AddWithValue("@id_medico", oCita.Id_medico);
                objCommand.Parameters.AddWithValue("@valor", oCita.Valor);
                objCommand.Parameters.AddWithValue("@diagnostico", oCita.Diagnostico);
                objCommand.Parameters.AddWithValue("@nom_acompanante", oCita.Nom_acompaante);
                objCommand.Parameters.Add("@activo", oCita.Activo); // Formato mas antiguo

                objCommand.ExecuteNonQuery();
                return true;
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool actualizarCita(CECita oCita)
        {
            try
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Connection = objConexion.conectar("BDHospital");
                objCommand.CommandText = "modificar_cita"; //Nombre del procedimiento almacenado en DB
                objCommand.Parameters.AddWithValue("@cod_cita", oCita.Cod_cita);
                objCommand.Parameters.AddWithValue("@fecha", oCita.Fecha);
                objCommand.Parameters.AddWithValue("@hora", oCita.Hora);
                objCommand.Parameters.AddWithValue("@id_paciente", oCita.Id_paciente);
                objCommand.Parameters.AddWithValue("@id_medico", oCita.Id_medico);
                objCommand.Parameters.AddWithValue("@valor", oCita.Valor);
                objCommand.Parameters.AddWithValue("@diagnostico", oCita.Diagnostico);
                objCommand.Parameters.AddWithValue("@nom_acompanante", oCita.Nom_acompaante);
                objCommand.Parameters.Add("@activo", oCita.Activo); // Formato mas antiguo

                objCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                throw new Exception("Error de ejecucion de query");
            }
        }

        public DataSet consultarCita(CECita oCita)
        {
            try
            {
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Connection = objConexion.conectar("BDHospital");
                objCommand.CommandText = "consultar_cita";
                objCommand.Parameters.AddWithValue("@cod_cita", oCita.Cod_cita);
                SqlDataAdapter dat = new SqlDataAdapter(objCommand);
                DataSet ds = new DataSet();
                dat.Fill(ds);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
