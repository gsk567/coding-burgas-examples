using System;

namespace Clean.Domain;

public class Dog
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public string? OwnerName { get; set; }
}