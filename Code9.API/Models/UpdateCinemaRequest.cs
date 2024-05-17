using System.ComponentModel.DataAnnotations;

namespace Code9.API.Models
{
    public class UpdateCinemaRequest
    {
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int NumberOfAuditoriums { get; set; }
    }
}
