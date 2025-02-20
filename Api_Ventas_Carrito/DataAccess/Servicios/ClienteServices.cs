using Api_Ventas_Carrito.DataAccess.Interfaces;
using Api_Ventas_Carrito.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Api_Ventas_Carrito.DataAccess.Servicios
{
    public class ClienteServices : IClienteRepository<Cliente>, IDisposable
    {
        private SistemaVentasContext context;

        public ClienteServices(SistemaVentasContext context)
        {
            this.context = context;
        }   

        public List<Cliente> findClientes()
        {
            return context.Clientes.ToList();
        }

        public Cliente findClienteById(int idCliente)
        {
            Cliente cliente= context.Clientes.Where(x => x.Id==idCliente).FirstOrDefault();
            if(cliente==null) cliente = new Cliente();
            return cliente;
        }

        public Cliente storageCliente(Cliente cliente)
        {
            try
            {
                context.Clientes.Add(cliente);  
                Save();
                addUser(cliente.UserName, cliente.Password, cliente.Id);
                return cliente;
                
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return cliente= new Cliente();
            }
        }

        public Cliente deleteClienteById(int idCliente)
        {
            Cliente cliente = context.Clientes.Where(x => x.Id == idCliente).FirstOrDefault();
            if (cliente == null)
            {
                return cliente=new Cliente();
            }
            else
            {
                RemoveVentasDelCliente(idCliente);
                context.Clientes.Remove(cliente);
                Save();
                deleteUser(idCliente);
                return cliente;
            }
        }

        public void RemoveVentasDelCliente(int idCliente)
        {
            List<Venta> ventas= context.Ventas.Where(x => x.Id== idCliente).ToList();
            foreach (var venta in ventas)
            {
                context.Ventas.Remove(venta);
                Save();
            }
        }

        public Cliente updateCliente(Cliente cliente)
        {
            try
            {
                context.Clientes.Update(cliente);
                Save();
                updateUser(cliente.UserName,cliente.Password,cliente.Id);
                return cliente;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return cliente = new Cliente();
            }
        }

        public User validaUser(User uservalida)
        {
            User user = context.Users.Where(x => x.UserName == uservalida.UserName && x.Password== uservalida.Password).FirstOrDefault();
            if (user != null) return user;
            else return user = new User();
        }

        private void deleteUser(int idCliente)
        {
            User user = context.Users.Where(x => x.IdCliente == idCliente).FirstOrDefault();
            if (user != null)
            {
                context.Users.Remove(user);
                Save();
            }
            else
            {
                Console.WriteLine("Error al eliminar el cliente");
            }
        }

        private void addUser(string userName, string password, int IdCliente)
        {
            User user = new User();
            user.UserName = userName;
            user.Password = password;   
            user.IdCliente = IdCliente;
            user.IsAdmin = "0";
            try
            {
                context.Users.Add(user);
                Save();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void updateUser(string userName, string password, int IdCliente)
        {
            try
            {
                User user = context.Users.Where(x => x.IdCliente == IdCliente).FirstOrDefault();
                if (user != null)
                {
                    user.UserName = userName;
                    user.Password = password;
                    context.Users.Update(user);
                    Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }


        private bool disposed=false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
