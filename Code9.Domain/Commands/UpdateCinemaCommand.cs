using Code9.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code9.Domain.Commands
{
    public class UpdateCinemaCommand : IRequest<Cinema>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int NumberOfAuditoriums { get; set; }
    }
}
