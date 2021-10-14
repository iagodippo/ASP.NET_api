// Classe para fazer a configuração e busca no DB.
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class DataContext : DbContext // Herança de outra classe
    {
        // Especificando a classe que eu criei para lidar com o DB. Liberando os comandos SQL.
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {}
        // Especificando o nome da classe de modelo
        public DbSet<Cliente> cliente { get; set; } // Um "método" para cada modelo que a API tiver.
        
    }
}