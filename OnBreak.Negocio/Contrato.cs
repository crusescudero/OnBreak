using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreak.Datos;

namespace OnBreak.Negocio
{
    public class Contrato
    {
        private OnBreakEntities conn = new OnBreakEntities();
        public string Numero { get; set; }
        public System.DateTime Creacion { get; set; }
        public System.DateTime Termino { get; set; }
        public string RutCliente { get; set; }
        public string IdModalidad { get; set; }
        public string Nombre { get; set; }
        public double ValorBase { get; set; }
        public int PersonalBase { get; set; }
        public int IdTipoEvento { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaHoraInicio { get; set; }
        public System.DateTime FechaHoraTermino { get; set; }
        public int Asistentes { get; set; }
        public int PersonalAdicional { get; set; }
        public bool Realizado { get; set; }
        public double ValorTotalContrato { get; set; }
        public string Observaciones { get; set; }

        public bool Agregar()
        {
            try
            {
                Datos.Contrato objCont = new Datos.Contrato();
                objCont.Numero = this.Numero;
                objCont.Creacion = this.Creacion;
                objCont.Termino = this.Termino;
                objCont.RutCliente = this.RutCliente;
                objCont.IdModalidad = this.IdModalidad;
                objCont.IdTipoEvento = this.IdTipoEvento;
                objCont.FechaHoraInicio = this.FechaHoraInicio;
                objCont.FechaHoraTermino= this.FechaHoraTermino;
                objCont.Asistentes = this.Asistentes;
                objCont.PersonalAdicional = this.PersonalAdicional;
                objCont.Realizado = this.Realizado;
                objCont.ValorTotalContrato = this.ValorTotalContrato;
                objCont.Observaciones = this.Observaciones;

                conn.Contrato.Add(objCont);
                conn.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public List<Negocio.Contrato> LeerTodo()

        {

            try
            {
                List<Contrato> listCont = new List<Contrato>();
                var listDatos = conn.Contrato.Join(conn.ModalidadServicio, c => c.IdModalidad, m => m.IdModalidad, (c, m) => new { c, m })
                    .Join(conn.TipoEvento, cm => cm.c.IdTipoEvento, te => te.IdTipoEvento, (cm, te) => new { cm, te })
                    .Where(cont => (cont.cm.c.RutCliente == this.RutCliente || this.RutCliente == null)
                           && (cont.cm.c.IdTipoEvento == this.IdTipoEvento || this.IdTipoEvento == 0)
                           && (cont.cm.c.IdModalidad == this.IdModalidad || this.IdModalidad == null)).ToList();
                foreach (var v_cont in listDatos)
                {
                    Contrato c = new Contrato();
                    c.Numero = v_cont.cm.c.Numero;
                    c.Creacion = v_cont.cm.c.Creacion;
                    c.Termino = v_cont.cm.c.Termino;
                    c.RutCliente = v_cont.cm.c.RutCliente;
                    c.IdModalidad = v_cont.cm.c.IdModalidad;
                    c.Nombre = v_cont.cm.m.Nombre;
                    c.ValorBase = v_cont.cm.m.ValorBase;
                    c.PersonalBase = v_cont.cm.m.PersonalBase;
                    c.PersonalAdicional = v_cont.cm.c.PersonalAdicional;
                    c.IdTipoEvento = v_cont.cm.c.IdTipoEvento;
                    c.Descripcion = v_cont.te.Descripcion;
                    c.FechaHoraInicio = v_cont.cm.c.FechaHoraInicio;
                    c.FechaHoraTermino = v_cont.cm.c.FechaHoraTermino;
                    c.Asistentes = v_cont.cm.c.Asistentes;
                    c.PersonalAdicional = v_cont.cm.c.PersonalAdicional;
                    c.Realizado = v_cont.cm.c.Realizado;
                    c.ValorTotalContrato = v_cont.cm.c.ValorTotalContrato;
                    c.Observaciones = v_cont.cm.c.Observaciones;
                    listCont.Add(c);
                }
                return listCont;
            }
            catch (Exception e)
            {
                return new List<Contrato>();

            }

        }

        




    }

}
