# What is this project about?

HRM Project is a lab API. Lab has been used technology .NET Core with Clean Architecture, JWT, Roles based Authorization,...

# What does the Solution offer?

The Solution is built keeping in mind the most fundamental blocks an API must have in order to build a scalable and near-perfect API component. The solution offers a complete implementation of the following:

- [x] Clean Architecture with separated layers for API, Core, Infrastructure
- [x] UnitOfWork with Generic Repository
- [x] Entity Framework Core migrations with SQLServer
- [x] Complete CRUD for an Entity following CQRS, with segregated Commands and Queries
- [x] Fluent Validation of input inside the Command classes
- [x] Using SignalR to handle realtime
- [x] Preconfigured Swagger UI
- [x] ETag generation and validation on the API side for Response Caching (GET) and Collision detection (PUT)
- [x] JWT Token API for Generation and Configured JWT Validation
- [x] Roles based Authorization with predefined Roles
- [x] Complete Client Implementation of Entity CRUD and Token management in ReactJS
- [x] API Versioning with separated Swagger Documentation
- [x] AutoMapper implementation for Entity-to-DTO conversion
- [x] ILogger logging implementation
- [x] Database Seeding with a Single User and Roles added as the application starts
- [x] Auditable Entities with User Tracking (Comming Soon)
- [x] In-Memory Caching for single Entity via IMemoryCache (Comming Soon)
- [x] Distributed Caching implementation via IDistributedCache, with NCache (Comming Soon)
- [x] One Command deployment in Docker with Docker Compose (Comming Soon)

# Technologies Used

* ASP.NET Core (.NET 3.1) Web API
* Entity Framework Core (EFCore 3.1)
* MediatR for .NET 3.1
* Fluent Validation for .NET 3.1
* SQLServer
* SwaggerUI
* AutoMapper
* SignalR
* React 18 (Client)
