using Code9.Domain.Commands;
using Code9.Domain.Interfaces;
using Code9.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code9.Domain.Handlers
{
    public class UpdateCinemaHandler : IRequestHandler<UpdateCinemaCommand, Cinema>
    {
        private readonly ICinemaRepository _cinemaRepository;

        public UpdateCinemaHandler(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<Cinema> Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
        {
            var cinema = await _cinemaRepository.GetCinema(request.Id);

            if (cinema == null) 
            {
                throw new Exception($"Cinema with Id: {request.Id} does not exist in database.");
            }

            cinema.Name = request.Name;
            cinema.Street = request.Street;
            cinema.City = request.City;
            cinema.NumberOfAuditoriums = request.NumberOfAuditoriums;

            return await _cinemaRepository.UpdateCinema(cinema);
        }
    }
}
