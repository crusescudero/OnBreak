using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreak.Datos;

namespace OnBreak.Negocio
{
    public class ModalidadServicio
    {

        public string IdModalidad { get; set; }
        public int IdTipoEvento { get; set; }
        public string Nombre { get; set; }
        public double ValorBase { get; set; }
        public int PersonalBase { get; set; }

        public List<ModalidadServicio> ListarTodo()
        {
            try
            {
                Datos.OnBreakEntities conexion = new OnBreakEntities();
                List<Datos.ModalidadServicio> listadatos = conexion.ModalidadServicio.ToList<Datos.ModalidadServicio>();
                List<Negocio.ModalidadServicio> listaTipo = new List<ModalidadServicio>();

                foreach (Datos.ModalidadServicio objDat in listadatos)
                {
                    Negocio.ModalidadServicio objTip = new ModalidadServicio();
                    objTip.IdModalidad = objDat.IdModalidad;
                    objTip.IdTipoEvento = objDat.IdTipoEvento;
                    objTip.Nombre = objDat.Nombre;
                    objTip.ValorBase = objDat.ValorBase;
                    objTip.PersonalBase = objDat.PersonalBase;


                    listaTipo.Add(objTip);
                }
                return listaTipo;
            }
            catch (Exception e)
            {
                return new List<ModalidadServicio>();
            }
        }
    }
}
