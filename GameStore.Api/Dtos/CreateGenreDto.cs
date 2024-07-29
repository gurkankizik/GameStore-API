using System.ComponentModel.DataAnnotations;
using GameStore.Api.Entities;

namespace GameStore.Api.Dtos;

public record class CreateGenreDto(
    int Id,
    [Required][StringLength(50)] string Name
);
