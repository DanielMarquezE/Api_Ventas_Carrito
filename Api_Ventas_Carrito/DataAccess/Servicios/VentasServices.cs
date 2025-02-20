using Api_Ventas_Carrito.DataAccess.Interfaces;
using Api_Ventas_Carrito.Models;

namespace Api_Ventas_Carrito.DataAccess.Servicios
{
    public class VentasServices : IVentasRepository<Venta>, IDisposable
    {
        private SistemaVentasContext context;

        public VentasServices(SistemaVentasContext context)
        {
            this.context = context;
        }

        public List<ModeloListaDeCompras> GetListaDeCompras(int idCliente)
        {
            List<ModeloListaDeCompras> list= new List<ModeloListaDeCompras>();
            var query = from venta in context.Ventas
                        join articulo in context.Articulos on venta.IdProducto equals articulo.Id
                        join cliente in context.Clientes on venta.IdCliente equals cliente.Id
                        where cliente.Id == idCliente
                        select new
                        {
                            venta.Id,
                            articulo.Codigo,
                            cliente.Nombres,
                            articulo.Imagen,
                            venta.CantidadProducto,
                            venta.TotalVenta,
                            venta.FechaVenta
                        };
            foreach (var item in query)
            {
                ModeloListaDeCompras compraModel= new()
                {
                    Id=item.Id,
                    CodeProducto=item.Codigo,
                    NombreCliente=item.Nombres,
                    imagen=item.Imagen,
                    CantidadProducto=item.CantidadProducto,
                    TotalVenta=item.TotalVenta,
                    FechaVenta= item.FechaVenta
                };
                list.Add(compraModel);
            }
            return list;
        }

        public List<Venta> getVentas()
        {
            return context.Ventas.ToList();
        }

        public Venta storageVenta(Venta venta)
        {
            try
            {
                context.Ventas.Add(venta);
                Save();
                descontarStock(venta);
                return venta;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return venta = new Venta();
            }
        }

        private void descontarStock(Venta venta)
        {
            Articulo art= context.Articulos.Where(x => x.Id == venta.IdProducto).FirstOrDefault();
            art.Stock = art.Stock - venta.CantidadProducto;
            context.Articulos.Update(art);
            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

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
