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

        public bool Agregar()
        {
            Datos.OnBreakEntities conexion = new OnBreakEntities();
            Datos.Cliente objCli = new Datos.Cliente();

            try
            {
                objCli.RutCliente = this.RutCliente;
                objCli.RazonSocial = this.RazonSocial;
                objCli.NombreContacto = this.NombreContacto;
                objCli.MailContacto = this.MailContacto;
                objCli.Direccion = this.Direccion;
                objCli.Telefono = this.Telefono;
                objCli.IdActividadEmpresa = this.IdActividadEmpresa;
                objCli.IdTipoEmpresa = this.IdTipoEmpresa;

                conexion.Cliente.Add(objCli);
                conexion.SaveChanges();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }


        public List<Negocio.Cliente> LeerTodo()
        {
            try
            {
                
                Datos.OnBreakEntities conexion = new OnBreakEntities();
                
                List<Datos.Cliente> listDatos = conexion.Cliente.ToList<Datos.Cliente>(); 
                List<Negocio.Cliente> listNegocio = new List<Cliente>();
              
                foreach (Datos.Cliente objDatos in listDatos)
                {   
                    Negocio.Cliente objCliente = new Cliente();
                    objCliente.RutCliente = objDatos.RutCliente;
                    objCliente.RazonSocial = objDatos.RazonSocial;
                    objCliente.NombreContacto = objDatos.NombreContacto;
                    objCliente.MailContacto = objDatos.MailContacto;
                    objCliente.Direccion = objDatos.Direccion;
                    objCliente.Telefono = objDatos.Telefono;
                    objCliente.IdActividadEmpresa = objDatos.IdActividadEmpresa;
                    objCliente.IdTipoEmpresa = objDatos.IdTipoEmpresa;
                   
                    listNegocio.Add(objCliente);
                }
                return listNegocio;
            }
            catch (Exception e)
            {
                return new List<Negocio.Cliente>(); 
            }

        }

        public bool Eliminar()
        {
            Datos.OnBreakEntities conexion = new OnBreakEntities();
            try
            {
                Datos.Cliente objCli = conexion.Cliente.First(c => c.RutCliente == this.RutCliente);
                conexion.Cliente.Remove(objCli);
                conexion.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }    
        }

        public bool Modificar()
        {

            Datos.OnBreakEntities conexion = new OnBreakEntities();
            try
            {
                Datos.Cliente objCli = conexion.Cliente.First(c => c.RutCliente == this.RutCliente);
                objCli.RutCliente = this.RutCliente;
                objCli.RazonSocial = this.RazonSocial;
                objCli.NombreContacto = this.NombreContacto;
                objCli.MailContacto = this.MailContacto;
                objCli.Direccion = this.Direccion;
                objCli.Telefono = this.Telefono;
                objCli.IdActividadEmpresa = this.IdActividadEmpresa;
                objCli.IdTipoEmpresa = this.IdTipoEmpresa;

                conexion.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Negocio.Cliente> ListarPorRut()
        {
            Datos.OnBreakEntities conexion = new OnBreakEntities();
            List<Negocio.Cliente> listaCli = new List<Cliente>();
            try
            {
                List<Datos.Cliente> listaDatos = conexion.Cliente.Where(c => c.RutCliente.Contains(this.RutCliente)).ToList();
                foreach (Datos.Cliente objDatos in listaDatos)
                { 
                    Negocio.Cliente objCliente = new Cliente();
                    objCliente.RutCliente = objDatos.RutCliente;
                    objCliente.RazonSocial = objDatos.RazonSocial;
                    objCliente.NombreContacto = objDatos.NombreContacto;
                    objCliente.MailContacto = objDatos.MailContacto;
                    objCliente.Direccion = objDatos.Direccion;
                    objCliente.Telefono = objDatos.Telefono;
                    objCliente.IdActividadEmpresa = objDatos.IdActividadEmpresa;
                    objCliente.IdTipoEmpresa = objDatos.IdTipoEmpresa;
                    
                    listaCli.Add(objCliente);
                }
                return listaCli;
            }
            catch
            {
                return new List<Cliente>();
            }
        }
    }
}
