using System;
using System.ComponentModel.DataAnnotations;
using Academy2018_.NET_Homework5.Infrastructure.Abstractions;

namespace Academy2018_.NET_Homework5.Infrastructure.Models
{
    public class Airplane: IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public AirplaneType Type { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public TimeSpan ExploitationTerm { get; set; }
    }
}
