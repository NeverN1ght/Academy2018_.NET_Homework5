using Academy2018_.NET_Homework5.Infrastructure.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy2018_.NET_Homework5.Infrastructure.Models
{
    public class Ticket : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("Flights")]
        public string FlightNumber { get; set; }
    }
}
