using Api_Ventas_Carrito.Models;

namespace Api_Ventas_Carrito.DataAccess.Interfaces
{
    public interface IClienteRepository<Cliente> : IDisposable
    {
        List<Cliente> findClientes();
        Cliente findClienteById(int idCliente);
        Cliente storageCliente(Cliente cliente);
        Cliente deleteClienteById(int idCliente);
        Cliente updateCliente(Cliente cliente);
        User validaUser(User user);
        void Save();
        
    }
}
