using System;

namespace Clean.Application.Requests.Queries.GetAllDogs;

public class DogModel
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public string? OwnerName { get; set; }
}