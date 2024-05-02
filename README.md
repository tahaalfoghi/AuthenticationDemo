# JWT Authentication Demo with ASP.NET Core Web API

This is a simple demonstration of how to implement JWT (JSON Web Token) authentication in an ASP.NET Core Web API using C#.

## Overview

JWT authentication is a popular method for securing APIs by generating and validating tokens. This demo illustrates how to integrate JWT authentication into an ASP.NET Core Web API project.

## API Endpoints

### Authentication

- **POST /api/authenticate**
  - Request body should contain username and password.
  - Returns a JWT token if the credentials are valid.

### Protected Routes

These routes require a valid JWT token obtained from the authentication endpoint.

- **Post /api/login**
- - **Post /api/register**
- Returns a message indicating successful authentication.

## Example

To authenticate and access protected routes:

1. Send a POST request to `/api/Auth/login` with valid credentials.
2. Receive a JWT token.
3. Include the token in the Authorization header for subsequent requests to protected routes.


