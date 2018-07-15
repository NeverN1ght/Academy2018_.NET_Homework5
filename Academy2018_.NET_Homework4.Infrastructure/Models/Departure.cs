using System;
using System.ComponentModel.DataAnnotations;
using Academy2018_.NET_Homework5.Infrastructure.Abstractions;

namespace Academy2018_.NET_Homework5.Infrastructure.Models
{
    public class Departure : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string FlightNumber { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public Crew Crew { get; set; }

        [Required]
        public Airplane Airplane { get; set; }
    }
}
