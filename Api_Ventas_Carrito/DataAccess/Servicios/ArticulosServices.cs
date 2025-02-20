using Api_Ventas_Carrito.DataAccess.Interfaces;
using Api_Ventas_Carrito.Models;

namespace Api_Ventas_Carrito.DataAccess.Servicios
{
    public class ArticulosServices : IArticulosRepository<Articulo>, IDisposable
    {

        private SistemaVentasContext context;

        public ArticulosServices(SistemaVentasContext context)
        {
            this.context = context;
        }

        public List<Articulo> findArticulos()
        {
            return context.Articulos.ToList();
        }

        public List<ListArticulos> listArticulosModel()
        {
            List<ListArticulos> list= new List<ListArticulos>();
            var query = from articulo in context.Articulos
                        join tienda in context.Tiendas on articulo.Sucursal equals tienda.Id
                        select new
                        {
                            articulo.Id,
                            articulo.Codigo,
                            articulo.Precio,
                            articulo.Descripcion,
                            articulo.Imagen,
                            articulo.Stock,
                            tienda.Sucursal
                        };
            foreach (var item in query)
            {
                if (item.Stock > 0)
                {
                    ListArticulos articulomodel = new()
                    {
                        Id = item.Id,
                        Codigo = item.Codigo,
                        Descripcion = item.Descripcion,
                        Precio = item.Precio,
                        Imagen = item.Imagen,
                        Stock = item.Stock,
                        Tienda = item.Sucursal
                    };
                    list.Add(articulomodel);
                }   
            }
            return list;
        }

        public Articulo findArticuloById(int idArticulo)
        {
            Articulo Articulo = context.Articulos.Where(x => x.Id == idArticulo).FirstOrDefault();
            if (Articulo == null) Articulo = new Articulo();
            return Articulo;
        }

        public Articulo storageArticulo(Articulo Articulo)
        {
            try
            {
                context.Articulos.Add(Articulo);
                Save();
                return Articulo;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Articulo = new Articulo();
            }
        }

        public Articulo deleteArticuloById(int idArticulo)
        {
            Articulo Articulo = context.Articulos.Where(x => x.Id == idArticulo).FirstOrDefault();
            if (Articulo == null)
            {
                return Articulo = new Articulo();
            }
            else
            {
                RemoveVentasDelArticulo(idArticulo);
                context.Articulos.Remove(Articulo);
                Save();
                return Articulo;
            }
        }

        public void RemoveVentasDelArticulo(int idPersona)
        {
            List<Venta> ventas = context.Ventas.Where(x => x.Id == idPersona).ToList();
            foreach (var venta in ventas)
            {
                context.Ventas.Remove(venta);
                Save();
            }
        }


        public Articulo updateArticulo(Articulo Articulo)
        {
            try
            {
                context.Articulos.Update(Articulo);
                Save();
                return Articulo;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Articulo = new Articulo();
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
