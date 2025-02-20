using Api_Ventas_Carrito.DataAccess.Interfaces;
using Api_Ventas_Carrito.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Ventas_Carrito.Controllers
{
    [ApiController]
    [Route("Tiendas")]
    public class TiendaController : Controller
    {
        private readonly ITiendaRepository<Tienda> _context;

        public TiendaController(ITiendaRepository<Tienda> context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getTiendas")]
        public List<Tienda> getTiendas()
        {
            return _context.findTiendas();
        }

        [HttpGet]
        [Route("getTiendasById")]
        public Tienda getTiendaById(int idTienda)
        {
            return _context.findTiendaById(idTienda);
        }

        [HttpPost]
        [Route("insertTienda")]
        public Tienda insertTienda(Tienda Tienda)
        {
            return _context.storageTienda(Tienda);
        }

        [HttpDelete]
        [Route("deleteTienda")]
        public Tienda deletePersona(int idTienda)
        {
            return _context.deleteTiendaById(idTienda);
        }

        [HttpPut]
        [Route("updateTienda")]
        public Tienda updateTienda(Tienda Tienda)
        {
            return _context.updateTienda(Tienda);
        }
    }
}
