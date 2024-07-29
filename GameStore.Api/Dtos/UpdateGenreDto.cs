﻿using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record class UpdateGenreDto(
    int Id,
    [Required][StringLength(50)] string Name
);
