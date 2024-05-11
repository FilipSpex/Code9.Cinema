using Code9.Domain.Interfaces;
using Code9.Domain.Models;
using Code9.Domain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code9.Domain.Handlers
{
    public class GetAllCinemasHandler : IRequestHandler<GetAllCinemasQuery, List<Cinema>>
    {
        private readonly ICinemaRepository _cinemaRepository;

        public GetAllCinemasHandler(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<List<Cinema>> Handle(GetAllCinemasQuery request, CancellationToken cancellationToken)
        {
            return await _cinemaRepository.GetAllCinemas();
        }
    }
}
