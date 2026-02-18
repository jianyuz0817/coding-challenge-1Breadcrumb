# Library App (Breadcrumb Challenge)

Full-stack sample for a simple library inventory system. The backend is a .NET 8 Web API with MediatR + FluentValidation, and the frontend is a React + Vite + TypeScript app.

## Overview
- Backend: ASP.NET Core Web API, MediatR request/handler pattern, FluentValidation pipeline, EF Core InMemory persistence, Swagger in Development.
- Frontend: React 18, Vite dev server, basic CRUD UI for books (list + search + toggle availability; create/delete/search are TODOs).

## Tech Stack
**Backend**
- .NET 8 (`net8.0`)
- ASP.NET Core Web API
- MediatR
- FluentValidation
- EF Core InMemory
- Swashbuckle (Swagger)

**Frontend**
- React 18
- TypeScript
- Vite

## Repository Layout
- `backend/` .NET solution (`LibraryApp.sln`)
  - `src/LibraryApp.Api/` API project
  - `src/LibraryApp.Application/` use cases, DTOs, validation behavior
  - `src/LibraryApp.Domain/` domain entities/interfaces/exceptions
  - `src/LibraryApp.Infrastructure/` persistence + repository implementations
  - `tests/LibraryApp.UnitTests/` xUnit tests
- `frontend/` React app

## Backend Details
### Projects
- **LibraryApp.Api**: HTTP endpoints, exception handling, Swagger, CORS, health checks, DB seeding
- **LibraryApp.Application**: Use cases (MediatR requests/handlers), validation pipeline
- **LibraryApp.Domain**: Domain models and repository contracts
- **LibraryApp.Infrastructure**: EF Core InMemory database and repository

### Key Runtime Behavior
- In-memory database seeded on startup with three sample books (see `DbInitializer`).
- Global exception handler maps:
  - `ValidationException` ? 400 with validation errors
  - `BookNotFoundException` ? 404
  - all others ? 500
- Health endpoints:
  - `/health/live`
  - `/health/ready`

### API Endpoints
Base URL (dev): `https://localhost:7073`

- `GET /books?pageNumber=&pageSize=`
  - Returns paged list of books
- `GET /books/{id}`
  - Returns a book by id
- `GET /books/search?title=`
  - Search by title
- `POST /books`
  - Body: `{ "title": string, "author": string, "isAvailable": boolean }`
- `PATCH /books/{id}/availability`
  - Body: `{ "isAvailable": boolean }`
- `DELETE /books/{id}`
  - Archives a book

### Configuration
- CORS allows: `http://localhost:5173`, `https://localhost:5173`
- Swagger enabled in Development

## Frontend Details
### UI
- Book list with pagination
- Search input (currently only updates local state)
- Toggle availability
- Add and Delete buttons exist but are not wired

### API Client
- `frontend/src/shared/config/api.ts` uses `https://localhost:7073`
- Vite dev server also proxies `/api` to `https://localhost:5001` (note the mismatch below)

## Running the App
### Prerequisites
- .NET 8 SDK
- Node.js 18+ (or compatible with Vite 5)

### Backend
From `backend/`:
```bash
# restore & run API
 dotnet restore
 dotnet run --project src/LibraryApp.Api/LibraryApp.Api.csproj
```
Default URLs:
- `https://localhost:7073`
- `http://localhost:5157`

### Frontend
From `frontend/`:
```bash
 npm install
 npm run dev
```
Default Vite URL: `http://localhost:5173`

## Testing
From `backend/`:
```bash
 dotnet test
```

## Known Gaps / TODOs
**Backend**
- `GetBookByIdHandler`, `SearchBooksHandler`, `CreateBookHandler`, and `ArchiveBookHandler` are not implemented.
- Validators for `GetBookById`, `SearchBooks`, `CreateBook`, and `ArchiveBook` are TODOs.

**Frontend**
- Search, delete, and create workflows are not implemented.
- Add Book button has no action wired.

**Tests**
- `BookHandlersTests` currently expects a `CreateBookCommand` signature with additional fields (ISBN and publish date). This does not match the current `CreateBookCommand` signature in `LibraryApp.Application` and will not compile until reconciled.

## Notes
- The backend uses EF Core InMemory provider, so data is not persisted between runs.
- `vite.config.ts` proxies `/api` to `https://localhost:5001`, but the API launch profile uses `https://localhost:7073`. Update one side if you want to use the proxy.
