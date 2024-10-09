using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean.Application.Contracts;
using Clean.Domain;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Persistence;

public class DogRepository : IDogRepository
{
    private readonly CleanEntityContext context;

    public DogRepository(CleanEntityContext context)
    {
        this.context = context;
    }
    
    public async Task<Guid> CreateAsync(Dog dog)
    {
        var dogEntity = new DogEntity()
        {
            Name = dog.Name,
            OwnerName = dog.OwnerName
        };
        
        this.context.Dogs.Add(dogEntity);
        await this.context.SaveChangesAsync();

        return dogEntity.Id;
    }

    public async Task<IEnumerable<Dog>> GetAllAsync()
    {
        return await this.context
            .Dogs
            .Select(x => new Dog
            {
                Id = x.Id,
                Name = x.Name,
                OwnerName = x.OwnerName,
            })
            .ToListAsync();
    }
}