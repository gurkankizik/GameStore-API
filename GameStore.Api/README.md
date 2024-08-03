# GameStore.Api

GameStore.Api is a RESTful API for managing a game store. It allows users to perform CRUD operations on games, manage user accounts, and handle transactions. The project also includes Docker support, enabling easy containerization and deployment of the application.

## Table of Contents

- [Features](#features)
- [Technologies](#technologies)

## Features

- CRUD operations for games
- User account management
- Transaction handling
- Logging and error handling
- Secure authentication and authorization

## Technologies

- ASP.NET Core
- Entity Framework Core
- SQLite
- Docker
- Swagger for API documentation

## API Endpoints

### Categories

- **GET** `/api/games`: Get all games.
- **GET** `/api/games/{id}`: Get a game by ID.
- **POST** `/api/games`: Create a new game.
- **PUT** `/api/games/{id}`: Update an existing game.
- **DELETE** `/api/games/{id}`: Delete a game.

### Products

- **GET** `/api/genres`: Get all genres.
- **GET** `/api/genres/{id}`: Get a genre by ID.
- **POST** `/api/genres`: Create a new genre.
- **PUT** `/api/genres/{id}`: Update an existing genre.
- **DELETE** `/api/genres/{id}`: Delete a genre.


