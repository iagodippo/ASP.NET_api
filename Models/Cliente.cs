using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{

    public class Cliente
    {
        [Key] // Necessário para que o "Id" seja uma chave
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Saldo { get; set; }
        
    }
}