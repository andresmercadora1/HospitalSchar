using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocio
{
    public class CNCita
    {
        CDCita objDatoCita = new CDCita();

        public bool guardarCita(CECita oCita)
        {
            return objDatoCita.guardarCita(oCita);
        }

        public bool actualizarCita(CECita oCita)
        {
            return objDatoCita.actualizarCita(oCita);
        }

        public DataSet consultarCita(CECita oCita)
        {
            return objDatoCita.consultarCita(oCita);
        }
    }
}
