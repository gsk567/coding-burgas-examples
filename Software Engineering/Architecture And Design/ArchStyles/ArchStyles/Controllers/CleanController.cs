using System.Threading.Tasks;
using Clean.Application.Requests.Commands.CreateDog;
using Clean.Application.Requests.Queries.GetAllDogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArchStyles.Controllers;

[Route("/clean")]
public class CleanController : ControllerBase
{
    private readonly IMediator mediator;

    public CleanController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    [HttpGet("")]
    public async Task<IActionResult> Get()
    {
        return this.Ok(await this.mediator.Send(new GetAllDogsQuery()));
    }
    
    [HttpPost("")]
    public async Task<IActionResult> Post([FromBody]CreateDogCommand command)
    {
        return this.Ok(await this.mediator.Send(command));
    }
}