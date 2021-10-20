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
        [HttpGet("oi")] // GET para exibir
        public string oi()
        {
            return "Hello World";
        }

    }
}