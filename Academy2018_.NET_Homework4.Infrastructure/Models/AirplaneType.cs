using System.ComponentModel.DataAnnotations;
using Academy2018_.NET_Homework5.Infrastructure.Abstractions;

namespace Academy2018_.NET_Homework5.Infrastructure.Models
{
    public class AirplaneType : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string AirplaneModel { get; set; }

        [Required]
        public int SeatsCount { get; set; }

        [Required]
        public int CarryingCapacity { get; set; }
    }
}
