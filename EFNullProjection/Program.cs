using EFNullProjection;
using Microsoft.EntityFrameworkCore;

await using var context = new TestContext();

await context.Database.OpenConnectionAsync();
await context.Database.EnsureCreatedAsync();

var crafts = await context.Crafts
    .Select(
        craft => new Projection
        {
            Id = (Guid?)craft.Label!.Id ?? Guid.Empty
        })
    .ToListAsync();

crafts.ForEach(craft => Console.WriteLine(craft.Id));
