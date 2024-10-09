using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clean.Domain;

namespace Clean.Application.Contracts;

public interface IDogRepository
{
    Task<IEnumerable<Dog>> GetAllAsync();
    
    Task<Guid> CreateAsync(Dog dog);
}