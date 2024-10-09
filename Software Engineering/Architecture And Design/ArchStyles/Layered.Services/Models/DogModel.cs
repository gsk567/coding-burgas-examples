using System;

namespace Layered.Services.Models;

public class DogModel
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public string? OwnerName { get; set; }
}