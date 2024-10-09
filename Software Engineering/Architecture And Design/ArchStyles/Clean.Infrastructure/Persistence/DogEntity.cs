using System;

namespace Clean.Infrastructure.Persistence;

public class DogEntity
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public string? OwnerName { get; set; }
}