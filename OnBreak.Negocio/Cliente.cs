using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBreak.Datos;

namespace OnBreak.Negocio
{
    public class Cliente
    {
        public string RutCliente { get; set; }
        public string RazonSocial { get; set; }
        public string NombreContacto { get; set; }
        public string MailContacto { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdActividadEmpresa { get; set; }
        public int IdTipoEmpresa { get; set; }



        public List<Negocio.Cliente> LeerTodo()

        {

            try

            {
                //primero necesito conectarme
                Datos.OnBreakEntities conexion = new OnBreakEntities();
                //lista de datos: trae todos los datos de la bdd.

                List<Datos.Cliente> listDatos = conexion.Cliente.ToList<Datos.Cliente>(); //Select * de la bdd
                                                                                             //lista de tipo negocio: se pasan los datos de la lista anterior a esta y es la que se devolverá a presentación

                List<Negocio.Cliente> listNegocio = new List<Cliente>();
                //llenado de lista

                foreach (Datos.Cliente objDatos in listDatos)//por cada objeto tablaPrueba de Datos que este en la listDatos voy a:

                {   //instanciar un objetoCli de tipo Negocio.Cliente

                    Negocio.Cliente objCliente = new Cliente();
                    objCliente.RutCliente = objDatos.RutCliente;
                    objCliente.RazonSocial = objDatos.RazonSocial;
                    objCliente.NombreContacto = objDatos.NombreContacto;
                    objCliente.MailContacto = objDatos.MailContacto;
                    objCliente.Direccion = objDatos.Direccion;
                    objCliente.Telefono = objDatos.Telefono;
                    objCliente.IdActividadEmpresa = objDatos.IdActividadEmpresa;
                    objCliente.IdTipoEmpresa = objDatos.IdTipoEmpresa;

                    //finalmente a mi lista de negocios que es la que tengo que devolver le paso el objeto cliente

                    listNegocio.Add(objCliente);

                }

                return listNegocio;

            }

            catch (Exception e)

            {
                return new List<Negocio.Cliente>(); //si se cae me devuelve la lista vacia

            }

        }
    }
}
