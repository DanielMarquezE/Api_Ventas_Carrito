using Api_Ventas_Carrito.DataAccess.Interfaces;
using Api_Ventas_Carrito.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Ventas_Carrito.Controllers
{

    [ApiController]
    [Route("Articulos")]
    public class ArticuloController : Controller
    {
        private readonly IArticulosRepository<Articulo> _context;

        public ArticuloController(IArticulosRepository<Articulo> context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getArticulos")]
        public List<Articulo> getArticulos()
        {
            return _context.findArticulos();
        }

        [HttpGet]
        [Route("getListCartArticulo")]
        public List<ListArticulos> getListCartArticulo()
        {
            return _context.listArticulosModel();
        }

        [HttpGet]
        [Route("getArticulosById")]
        public Articulo getArticuloById(int idArticulo)
        {
            return _context.findArticuloById(idArticulo);
        }

        [HttpPost]
        [Route("insertArticulo")]
        public Articulo insertArticulo(Articulo Articulo)
        {
            return _context.storageArticulo(Articulo);
        }

        [HttpDelete]
        [Route("deleteArticulo")]
        public Articulo deletePersona(int idArticulo)
        {
            return _context.deleteArticuloById(idArticulo);
        }

        [HttpPut]
        [Route("updateArticulo")]
        public Articulo updateArticulo(Articulo Articulo)
        {
            return _context.updateArticulo(Articulo);
        }


    }
}
