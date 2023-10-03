using System.ComponentModel.DataAnnotations;

namespace DuplexCenima.Models
{
    public class ShoppingCartitem
    {
        [Key]
        public int Id { get; set; } 
        public Movie Movie { get; set; }
        public int Amount { get; set; }  
        public string ShoppingCartId { get; set; }

    }
}
