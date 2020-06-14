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
        Datos.OnBreakEntities conexion = new OnBreakEntities();
        public string Numero { get; set; }
        public System.DateTime Creacion { get; set; }
        public System.DateTime Termino { get; set; }
        public string RutCliente { get; set; }
        public string IdModalidad { get; set; }
        public int IdTipoEvento { get; set; }
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

                conexion.Contrato.Add(objCont);
                conexion.SaveChanges();

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
                List<Negocio.Contrato> listContrato = new List<Contrato>();
                List<Datos.Contrato> listDatos = conexion.Contrato.ToList(); 
                
            
                foreach (Datos.Contrato objDatos in listDatos)
                {   
                    Negocio.Contrato objContrato = new Contrato();
                    objContrato.Numero = objDatos.Numero;
                    objContrato.Creacion = objDatos.Creacion;
                    objContrato.Termino = objDatos.Termino;
                    objContrato.RutCliente = objDatos.RutCliente;
                    objContrato.IdModalidad = objDatos.IdModalidad;
                    objContrato.IdTipoEvento = objDatos.IdTipoEvento;
                    objContrato.FechaHoraInicio = objDatos.FechaHoraInicio;
                    objContrato.FechaHoraTermino = objDatos.FechaHoraTermino;
                    objContrato.Asistentes = objDatos.Asistentes;
                    objContrato.PersonalAdicional = objDatos.PersonalAdicional;
                    objContrato.Realizado = objDatos.Realizado;
                    objContrato.ValorTotalContrato = objDatos.ValorTotalContrato;
                    objContrato.Observaciones = objDatos.Observaciones;
                                 
                    listContrato.Add(objContrato);

                }
                return listContrato;
            }
            catch (Exception e)
            {
                return new List<Negocio.Contrato>(); 
            }

        }

        




    }

}
