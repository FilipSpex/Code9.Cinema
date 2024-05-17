using Code9.API.Models;
using Code9.Domain.Commands;
using Code9.Domain.Handlers;
using Code9.Domain.Models;
using Code9.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Code9.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : Controller
    {

        private readonly IMediator _mediator;

        public CinemaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cinema>>> GetAllCinemas()
        {
            var query = new GetAllCinemasQuery();
            var cinemas = await _mediator.Send(query);

            return Ok(cinemas);
        }

        [HttpPost]
        public async Task<ActionResult<Cinema>> AddCinema(AddCinemaRequest addCinemaRequest)
        {
            var addCinemaCommand = new AddCinemaCommand
            {
                Name = addCinemaRequest.Name,
                City = addCinemaRequest.City,
                Street = addCinemaRequest.Street,
                NumberOfAuditoriums = addCinemaRequest.NumberOfAuditoriums
            };

            var cinema = _mediator.Send(addCinemaCommand);

            return CreatedAtAction(nameof(GetAllCinemas), new { id = cinema.Id }, cinema);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Cinema>> UpdateCinema([FromRoute]Guid id, UpdateCinemaRequest updateCinemaRequest)
        {
            var updateCinemaCommand = new UpdateCinemaCommand
            {
                Id = id,
                City = updateCinemaRequest.City,
                Street = updateCinemaRequest.Street,
                Name = updateCinemaRequest.Name,
                NumberOfAuditoriums = updateCinemaRequest.NumberOfAuditoriums
            };

            var cinema  = await _mediator.Send(updateCinemaCommand);

            if (cinema == null) 
            {
                return NotFound();
            }

            return Ok(cinema);
        }
    }
}
