using System.Threading.Tasks;
using Layered.Services.Contracts;
using Layered.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArchStyles.Controllers;

[Route("/layered/")]
public class LayeredController : ControllerBase
{
    private readonly IDogService dogService;

    public LayeredController(IDogService dogService)
    {
        this.dogService = dogService;
    }
    
    [HttpGet("")]
    public async Task<IActionResult> Get()
    {
        return this.Ok(await this.dogService.GetDogsAsync());
    }
    
    [HttpPost("")]
    public async Task<IActionResult> Post([FromBody]DogModel model)
    {
        return this.Ok(await this.dogService.CreateDogAsync(model));
    }
}