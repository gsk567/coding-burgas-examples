using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Layered.Data;
using Layered.Services.Contracts;
using Layered.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Layered.Services.Implementations;

public class DogService : IDogService
{
    private readonly LayeredEntityContext context;

    public DogService(LayeredEntityContext context)
    {
        this.context = context;
    }
    
    public async Task<Guid> CreateDogAsync(DogModel dog)
    {
        var dogEntity = new Dog
        {
            Name = dog.Name,
            OwnerName = dog.OwnerName
        };
        
        this.context.Dogs.Add(dogEntity);
        await this.context.SaveChangesAsync();

        return dogEntity.Id;
    }

    public async Task<IEnumerable<DogModel>> GetDogsAsync()
    {
        return await this.context
            .Dogs
            .Select(x => new DogModel
            {
                Id = x.Id,
                Name = x.Name,
                OwnerName = x.OwnerName,
            })
            .ToListAsync();
    }
}