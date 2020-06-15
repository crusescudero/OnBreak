using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreak.Datos;

namespace OnBreak.Negocio
{
    public class TipoEvento
    {
        private OnBreakEntities conexion = new OnBreakEntities();
        public int IdTipoEvento { get; set; }
        public string Descripcion { get; set; }

        public TipoEvento() { }

        public TipoEvento(int id_tipo, string desc)
        {
            this.IdTipoEvento = id_tipo;
            this.Descripcion = desc;
        }

        public List<Negocio.TipoEvento> ListaTodo()
        {
            try
            {
                List<Datos.TipoEvento> listDatos = conexion.TipoEvento.ToList();
                List<Negocio.TipoEvento> listNeg = new List<TipoEvento>();
                foreach (Datos.TipoEvento te in listDatos)
                {
                    Negocio.TipoEvento tipo = new TipoEvento();
                    tipo.IdTipoEvento = te.IdTipoEvento;
                    tipo.Descripcion = te.Descripcion;
                    listNeg.Add(tipo);
                }
                return listNeg;
            }
            catch (Exception e)
            {
                return new List<TipoEvento>();

            }

        }

        public List<Negocio.TipoEvento> ListaCombo()
        {
            try
            {
                List<Datos.TipoEvento> listDatos = conexion.TipoEvento.ToList();
                List<Negocio.TipoEvento> listNeg = new List<TipoEvento>();
                listNeg.Add(new TipoEvento(0, "Seleccione"));
                foreach (Datos.TipoEvento te in listDatos)
                {
                    Negocio.TipoEvento tipo = new TipoEvento();
                    tipo.IdTipoEvento = te.IdTipoEvento;
                    tipo.Descripcion = te.Descripcion;
                    listNeg.Add(tipo);
                }
                return listNeg;
            }
            catch (Exception e)
            {
                return new List<TipoEvento>();

            }

        }
    }
}
