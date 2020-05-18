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


        public List<Negocio.Contrato> LeerTodo()

        {

            try

            {
                //primero necesito conectarme
                Datos.OnBreakEntities conexion = new OnBreakEntities();
                //lista de datos: trae todos los datos de la bdd.

                List<Datos.Contrato> listDatos = conexion.Contrato.ToList<Datos.Contrato>(); //Select * de la bdd
                                                                                             //lista de tipo negocio: se pasan los datos de la lista anterior a esta y es la que se devolverá a presentación

                List<Negocio.Contrato> listNegocio = new List<Contrato>();
                //llenado de lista

                foreach (Datos.Contrato objDatos in listDatos)//por cada objeto tablaPrueba de Datos que este en la listDatos voy a:

                {   //instanciar un objetoCli de tipo Negocio.Cliente

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
                    //finalmente a mi lista de negocios que es la que tengo que devolver le paso el objeto cliente

                    listNegocio.Add(objContrato);

                }

                return listNegocio;

            }

            catch (Exception e)

            {
                return new List<Negocio.Contrato>(); //si se cae me devuelve la lista vacia

            }

        }






    }

}
