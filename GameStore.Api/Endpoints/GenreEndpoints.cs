using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;
using GameStore.Api.Data;
using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

public static class GenreEndpoints
{
    public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/genres");

        //GET /genres
        group.MapGet("/", async (GameStoreContext dbContext) =>
            await dbContext.Genre.Select(Genre => Genre.ToDto()).AsNoTracking().ToListAsync()
        );
        //GET /genres/id
        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            Genre? genre = await dbContext.Genre.FindAsync(id);
            return genre is null ? Results.NotFound() : Results.Ok(genre.ToDto());
        });
        //POST /genres
        group.MapPost("/", async (CreateGenreDto newGenre, GameStoreContext dbContext) =>
        {
            Genre genre = newGenre.ToEntity();
            dbContext.Genre.Add(genre);
            await dbContext.SaveChangesAsync();

            return Results.Created($"/genres/{genre.Id}", genre.ToDto());
        });

        //PUT /genres/id
        group.MapPut("/{id}", async (int id, UpdateGenreDto updatedGenre, GameStoreContext dbContext) =>
        {
            var existingGenre = await dbContext.Genre.FindAsync(id);

            if (existingGenre is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingGenre).CurrentValues.SetValues(updatedGenre.ToEntity(id));
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        //DELETE /genres/id

        group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            var genre = await dbContext.Genre.FindAsync(id);

            if (genre is null)
            {
                return Results.NotFound();
            }

            dbContext.Genre.Remove(genre);
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        return group;
    }
}
