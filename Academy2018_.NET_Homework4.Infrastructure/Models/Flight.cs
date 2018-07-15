using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Academy2018_.NET_Homework5.Infrastructure.Models
{
    public class Flight
    {
        [Key]
        public string Number { get; set; }

        [Required]
        [StringLength(50)]
        public string DeparturePoint { get; set; }

        [Required]
        [StringLength(50)]
        public string DestinationPoint { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        public List<Ticket> Tickets { get; set; }
    }
}
