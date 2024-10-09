using System;

namespace Layered.Data;

public class Dog
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public string? OwnerName { get; set; }
}