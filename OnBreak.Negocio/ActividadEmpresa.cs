using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreak.Datos;

namespace OnBreak.Negocio
{
    public class ActividadEmpresa
    {
        
        public int IdActividadEmpresa { get; set; }
        public string Descripcion { get; set; }

        public List<ActividadEmpresa> ListarTodo()
        {
            try
            {
                Datos.OnBreakEntities conexion = new OnBreakEntities();
                List<Datos.ActividadEmpresa> listadatos = conexion.ActividadEmpresa.ToList<Datos.ActividadEmpresa>();
                List<Negocio.ActividadEmpresa> listaTipo = new List<ActividadEmpresa>();

                foreach (Datos.ActividadEmpresa objDat in listadatos)
                {
                    Negocio.ActividadEmpresa objTip = new ActividadEmpresa();
                    objTip.IdActividadEmpresa = objDat.IdActividadEmpresa;
                    objTip.Descripcion = objDat.Descripcion;

                    listaTipo.Add(objTip);
                }
                return listaTipo;
            }
            catch (Exception e)
            {
                return new List<ActividadEmpresa>();
            }

        }

    }
}
