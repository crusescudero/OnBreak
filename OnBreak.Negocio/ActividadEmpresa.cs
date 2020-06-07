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
        private Datos.OnBreakEntities conexion = new OnBreakEntities();
        public int IdActividadEmpresa { get; set; }
        public string Descripcion { get; set; }

        public List<ActividadEmpresa> ListarTodo()
        {
            List<ActividadEmpresa> listaActividad = new List<ActividadEmpresa>();
            List<Datos.ActividadEmpresa> listadatos = conexion.ActividadEmpresa.ToList();

            foreach (Datos.ActividadEmpresa dat in listadatos)
            {
                ActividadEmpresa act = new ActividadEmpresa();
                act.IdActividadEmpresa = act.IdActividadEmpresa;
                act.Descripcion = act.Descripcion;

                listaActividad.Add(act);

                
            }
            return listaActividad;

        }

    }
}
