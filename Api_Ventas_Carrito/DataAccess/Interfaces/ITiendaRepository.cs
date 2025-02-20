namespace Api_Ventas_Carrito.DataAccess.Interfaces
{
    public interface ITiendaRepository<Tienda> : IDisposable
    {

        List<Tienda> findTiendas();
        Tienda findTiendaById(int idTienda);
        Tienda storageTienda(Tienda Tienda);
        Tienda deleteTiendaById(int idTienda);
        Tienda updateTienda(Tienda Tienda);
        void Save();

    }
}
