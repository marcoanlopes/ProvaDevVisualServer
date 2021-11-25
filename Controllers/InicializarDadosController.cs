using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/inicializar")]
    public class InicializarDadosController : ControllerBase
    {
        private readonly DataContext _context;
        public InicializarDadosController(DataContext context)
        {
            _context = context;
        }

        //POST: api/inicializar/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create()
        {
            _context.Categorias.AddRange(new Categoria[]
                {
                    new Categoria { CategoriaId = 1, Nome = "Eletrodomésticos" },
                }
            );
            _context.Produtos.AddRange(new Produto[]
                {
                    new Produto { ProdutoId = 1, Nome = "Aspirador", Preco = 15, Quantidade = 20, CategoriaId = 1 },
                    new Produto { ProdutoId = 2, Nome = "Geladeira", Preco = 33, Quantidade = 13, CategoriaId = 1 },
                    new Produto { ProdutoId = 3, Nome = "Fogão", Preco = 49, Quantidade = 11, CategoriaId = 1 },
                }
            );
            _context.SaveChanges();
            return Ok(new { message = "Dados inicializados com sucesso!" });
        }
    }
}