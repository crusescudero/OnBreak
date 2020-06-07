using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreak.Datos;

namespace OnBreak.Negocio
{
    public class TipoEmpresa
    {
        private Datos.OnBreakEntities conexion = new OnBreakEntities();
        public int IdTipoEmpresa { get; set; }
        public string Descripcion { get; set; }

        public List<TipoEmpresa> ListarTodo()
        {
            List<TipoEmpresa> listaTipo = new List<TipoEmpresa>();
            List<Datos.TipoEmpresa> listadatos = conexion.TipoEmpresa.ToList();

            foreach (Datos.TipoEmpresa dat in listadatos)
            {
                TipoEmpresa tip = new TipoEmpresa();
                tip.IdTipoEmpresa = tip.IdTipoEmpresa;
                tip.Descripcion = tip.Descripcion;

                listaTipo.Add(tip);
            }
            return listaTipo;
        }

    }
}
