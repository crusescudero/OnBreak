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
        private OnBreakEntities conn = new OnBreakEntities();
        public string IdModalidad { get; set; }
        public int IdTipoEvento { get; set; }
        public string Nombre { get; set; }
        public double ValorBase { get; set; }
        public int PersonalBase { get; set; }


        public List<Negocio.ModalidadServicio> ListarPorTE()
        {
            try
            {
                List<Datos.ModalidadServicio> listDatos = conn.ModalidadServicio.Where(ms => ms.IdTipoEvento == this.IdTipoEvento).ToList();
                List<Negocio.ModalidadServicio> listMS = new List<ModalidadServicio>();
                foreach (Datos.ModalidadServicio ms in listDatos)
                {
                    Negocio.ModalidadServicio mod = new ModalidadServicio();
                    mod.IdModalidad = ms.IdModalidad;
                    mod.IdTipoEvento = ms.IdTipoEvento;
                    mod.Nombre = ms.Nombre;
                    listMS.Add(mod);
                }
                return listMS;
            }
            catch
            {
                return new List<ModalidadServicio>();
            }

        }
    }
}
