using System.Threading.Tasks; // programação assincrona
using api.Data; //data context. Acesso ao DB
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class ClienteController : ControllerBase 
    {
        private DataContext dc;

        public ClienteController(DataContext context) // construtor da classe
        {
            this.dc = context; 
        }


        [HttpPost("api")]
        public async Task<ActionResult> cadastrar([FromBody] Cliente c)
        {
            dc.cliente.Add(c);
            await dc.SaveChangesAsync(); //vai esperar o salvamento no banco de dados
            
            return Created("Objeto cliente", c); //retorna 201, criado.
        }


        [HttpGet("api")]
        public async Task<ActionResult> listar() // listar todos os registros do db
        {
            var dados = await dc.cliente.ToListAsync();
            return Ok(dados); // Listou e deu certo
        }


        [HttpGet("api/{id}")] // identificador específico de cada cliente
        public Cliente filtrar(int id) // buscar dado específico de um clinete
        {
            Cliente c = dc.cliente.Find(id);
            return c;
        }


        [HttpPut("api")]
        public async Task<ActionResult> atualizar([FromBody] Cliente c) // dados que serão passados para atualizar o cadastro
        {
            dc.cliente.Update(c);
            await dc.SaveChangesAsync();
            return Ok(c);
        }


        [HttpDelete("api/{id}")]
        public async Task<ActionResult> remover(int id) // o delete precisa dos dados completos
        {
            Cliente c = filtrar(id); // utilizo o id com o metodo filtrar para buscar o cadastro a ser excluído

            if(c == null)
            {
                return NotFound();
            }
            else
            {
                dc.cliente.Remove(c);
                await dc.SaveChangesAsync();
                return Ok();
            }
        }
    }
}