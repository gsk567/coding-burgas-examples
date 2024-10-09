using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Layered.Services.Models;

namespace Layered.Services.Contracts;

public interface IDogService
{
    Task<Guid> CreateDogAsync(DogModel dog);
    
    Task<IEnumerable<DogModel>> GetDogsAsync();
}