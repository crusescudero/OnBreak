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
        private Datos.OnBreakEntities conexion = new OnBreakEntities();

        public string IdModalidad { get; set; }
        public int IdTipoEvento { get; set; }
        public string Nombre { get; set; }
        public double ValorBase { get; set; }
        public int PersonalBase { get; set; }

        public List<ModalidadServicio> ListarTodo()
        {
            List<ModalidadServicio> listaMod = new List<ModalidadServicio>();
            List<Datos.ModalidadServicio> listadatos = conexion.ModalidadServicio.ToList();

            foreach (Datos.ModalidadServicio dat in listadatos)
            {
                ModalidadServicio mod = new ModalidadServicio();
                mod.IdModalidad = mod.IdModalidad;
                mod.IdTipoEvento = mod.IdTipoEvento;
                mod.Nombre = mod.Nombre;
                mod.ValorBase = mod.ValorBase;
                mod.PersonalBase = mod.PersonalBase;

                listaMod.Add(mod);
            }
            return listaMod;
        }
    }
}
