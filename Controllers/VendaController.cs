using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/venda")]
    public class VendaController : ControllerBase
    {
        private readonly DataContext _context;
        public VendaController(DataContext context)
        {
            _context = context;
        }

        //GET: api/venda/list
        //ALTERAR O MÉTODO PARA MOSTRAR TODOS OS DADOS DA VENDA E OS DADOS RELACIONADOS
        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            var venda = _context.Vendas
            .Include(p => p.FormaPagamento)
            .Include(p => p.Itens)     
            .ThenInclude(i => i.Produto)
            .ThenInclude(p => p.Categoria)
            .ToList();
            return Ok(venda);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] Venda venda)
        {
            _context.Vendas.Add(venda);
            _context.SaveChanges();
            return Created("", venda);
        }
    }
}