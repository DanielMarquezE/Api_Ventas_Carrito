using Api_Ventas_Carrito.DataAccess.Interfaces;
using Api_Ventas_Carrito.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Ventas_Carrito.Controllers
{

    [ApiController]
    [Route("Clientes")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository<Cliente> _context;

        public ClienteController(IClienteRepository<Cliente> context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getClientes")]
        public List<Cliente> getClientes() {
            return _context.findClientes();
        }

        [HttpGet]
        [Route("getClientesById")]
        public Cliente getClienteById(int idCliente)
        {
            return _context.findClienteById(idCliente);
        }

        [HttpPost]
        [Route("insertCliente")]
        public Cliente insertCliente(Cliente cliente)
        {
            return _context.storageCliente(cliente);
        }

        [HttpDelete]
        [Route("deleteCliente")]
        public Cliente deletePersona(int idCliente)
        {
            return _context.deleteClienteById(idCliente);
        }

        [HttpPut]
        [Route("updateCliente")]
        public Cliente updateCliente(Cliente cliente)
        {
            return _context.updateCliente(cliente);
        }

        [HttpPost]
        [Route("validateCliente")]
        public User validateCliente(User uservalida)
        {
            return _context.validaUser(uservalida);
        }
    }
}
