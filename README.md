# maad-api
maad-api

maad-api
├── Domain
│   ├── Entities
│   ├── Exceptions
│   ├── Validation
│   └── ValueObjects
├── Application
│   ├── Interfaces
│   ├── Request Dto's
│   ├── Response Dto's
│   └── Services
├── DataAccess
│   ├── Data
│   │   ├── Repositories
│   │   ├── Contexts
│   │   └── Migrations
│   └── Logging
├── WebAPI
│   ├── Routs
│   ├── Models
│   ├── Services
│   └── Validators
├── Tests
│   ├── Domain.Tests
│   ├── Application.Tests
│   ├── Infrastructure.Tests
│   └── WebAPI.Tests
└── maad-api.sln

Here's a brief description of each directory:

Domain: This directory contains the domain entities, interfaces, services, exceptions, and value objects that represent the business logic of the application.

Application: This directory contains the application services, interfaces, and use cases that orchestrate the interactions between the domain and infrastructure layers.

Infrastructure: This directory contains the implementation of the infrastructure layer, including data access and persistence, external services, and logging.

WebAPI: This directory contains the implementation of the presentation layer, including the controllers, models, services, and validators for a web API.

Tests: This directory contains the automated tests for each layer of the application.

maad-api: This is the Visual Studio solution file that contains the project references and configuration settings.
