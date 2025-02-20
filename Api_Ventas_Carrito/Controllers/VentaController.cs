using Api_Ventas_Carrito.DataAccess.Interfaces;
using Api_Ventas_Carrito.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Ventas_Carrito.Controllers
{
    [ApiController]
    [Route("Ventas")]
    public class VentaController : Controller
    {
        private readonly IVentasRepository<Venta> _context;

        public VentaController(IVentasRepository<Venta> context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getVentas")]
        public List<Venta> getTiendas()
        {
            return _context.getVentas();
        }

        [HttpPost]
        [Route("insertVenta")]
        public Venta insertTienda(Venta venta)
        {
            return _context.storageVenta(venta);
        }

        [HttpGet]
        [Route("GetListaDeCompras")]
        public List<ModeloListaDeCompras> GetListaDeCompras(int idCliente)
        {
            return _context.GetListaDeCompras(idCliente);
        }

    }
}
