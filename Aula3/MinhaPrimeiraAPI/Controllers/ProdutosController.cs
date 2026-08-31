using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraAPI.Models;

namespace MinhaPrimeiraAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private static List<Produto> produtos = new()
    {
        new() { Id = 1, Nome = "Notebook", Preco = 3500 },
        new() { Id = 2, Nome = "Mouse", Preco = 120 },
        new() { Id = 3, Nome = "Teclado", Preco = 250 }
    };

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var produto = produtos.FirstOrDefault(p => p.Id == id);

        if (produto == null)
        {
            return NotFound();
        }

        return Ok(produto);
    }

    [HttpPost]
    public IActionResult Post(Produto produto)
    {
        produto.Id = produtos.Count + 1;
        produtos.Add(produto);

        return Ok(produto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Produto produto)
    {
        var atual = produtos.FirstOrDefault(p => p.Id == id);

        if (atual == null)
        {
            return NotFound();
        }

        atual.Nome = produto.Nome;
        atual.Preco = produto.Preco;

        return Ok(atual);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var produto = produtos.FirstOrDefault(p => p.Id == id);

        if (produto == null)
        {
            return NotFound();
        }

        produtos.Remove(produto);

        return NoContent();
    }
}