using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Academy2018_.NET_Homework5.Infrastructure.Abstractions;

namespace Academy2018_.NET_Homework5.Infrastructure.Models
{
    public class Crew : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Pilot Pilot { get; set; }

        [Required]
        public List<Stewardesse> Stewardesses { get; set; }
    }
}
