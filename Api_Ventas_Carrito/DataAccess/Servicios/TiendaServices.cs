using Api_Ventas_Carrito.DataAccess.Interfaces;
using Api_Ventas_Carrito.Models;

namespace Api_Ventas_Carrito.DataAccess.Servicios
{
    public class TiendaServices : ITiendaRepository<Tienda>, IDisposable
    {

        private SistemaVentasContext context;

        public TiendaServices(SistemaVentasContext context)
        {
            this.context = context;
        }

        public List<Tienda> findTiendas()
        {
            return context.Tiendas.ToList();
        }

        public Tienda findTiendaById(int idTienda)
        {
            Tienda Tienda = context.Tiendas.Where(x => x.Id == idTienda).FirstOrDefault();
            if (Tienda == null) Tienda = new Tienda();
            return Tienda;
        }

        public Tienda storageTienda(Tienda Tienda)
        {
            try
            {
                context.Tiendas.Add(Tienda);
                Save();
                return Tienda;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Tienda = new Tienda();
            }
        }

        public Tienda deleteTiendaById(int idTienda)
        {
            Tienda Tienda = context.Tiendas.Where(x => x.Id == idTienda).FirstOrDefault();
            if (Tienda == null)
            {
                return Tienda = new Tienda();
            }
            else
            {
                RemoveVentasDelTienda(idTienda);
                context.Tiendas.Remove(Tienda);
                Save();
                return Tienda;
            }
        }

        public void RemoveVentasDelTienda(int idPersona)
        {
            List<Venta> ventas = context.Ventas.Where(x => x.Id == idPersona).ToList();
            foreach (var venta in ventas)
            {
                context.Ventas.Remove(venta);
                Save();
            }
        }

        

        public Tienda updateTienda(Tienda Tienda)
        {
            try
            {
                context.Tiendas.Update(Tienda);
                Save();
                return Tienda;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Tienda = new Tienda();
            }
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
