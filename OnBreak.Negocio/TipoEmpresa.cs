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
        
        public int IdTipoEmpresa { get; set; }
        public string Descripcion { get; set; }

        public List<TipoEmpresa> ListarTodo()
        {
           
            try
            {
                Datos.OnBreakEntities conexion = new OnBreakEntities();
                List<Datos.TipoEmpresa> listadatos = conexion.TipoEmpresa.ToList<Datos.TipoEmpresa>();
                List<Negocio.TipoEmpresa> listaTipo = new List<TipoEmpresa>();

                foreach (Datos.TipoEmpresa objDat in listadatos)
                {
                    Negocio.TipoEmpresa objTip = new TipoEmpresa();
                    objTip.IdTipoEmpresa = objDat.IdTipoEmpresa;
                    objTip.Descripcion = objDat.Descripcion;

                    listaTipo.Add(objTip);
                }
                return listaTipo;
            }
            catch(Exception e)
            {
                return new List<TipoEmpresa>();
            }

        }

    }
}
