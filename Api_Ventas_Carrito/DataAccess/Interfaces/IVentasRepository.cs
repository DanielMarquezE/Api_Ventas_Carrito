using Api_Ventas_Carrito.Models;

namespace Api_Ventas_Carrito.DataAccess.Interfaces
{
    public interface IVentasRepository<Venta> : IDisposable
    {
        List<Venta> getVentas();
        Venta storageVenta(Venta venta);
        List<ModeloListaDeCompras> GetListaDeCompras(int idCliente);
        void Save();
    }
}
