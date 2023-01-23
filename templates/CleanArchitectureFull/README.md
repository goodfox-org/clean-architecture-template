# Clean Architecture Template

Every instantiation of the Clean Architecture Template provides structure for your application based on this presentation: [Clean architecture - Jason Taylor - NDC Sydney 2019](https://www.youtube.com/watch?v=5OtUm1BLmG0 "Clean Architecture")
The basis of this structure is to breakdown and organize the application into distinguishable layers, each with unique responsibilities.

## Layer breakdown: 

Presentation 
- This layer contains what is presented to the caller/user of the app: REST/gRPC/websockets/GraphQL APIs, web UI, mobile UI, desktop UI, CLI.
- This layer should contain it's own set of models to carry data to and from frontend interfaces/applications.

Application 
- This layer contains the business logic. 
- Business logic is handled using the [CQRS](https://martinfowler.com/bliki/CQRS.html) pattern and implemented with the [MediatR library](https://github.com/jbogard/MediatR).
  - A request DTO (command or query) is passed to a handler, processed, and if applicable, data is returned to the presentation layer using a response DTO.
- Validation is also handled in this layer by the [Fluent Validation library](https://fluentvalidation.net/)
- This layer is environment agnostic. 

Infrastructure 
- This layer makes a connection with anything external to the application: file system, other APIs, databases, queues, printer, etc.
- Traditionally, this layer connects to a data source using the repository pattern.

Domain 
- Contains models that can be used across all layers. 
- The domain itself does not have any dependencies, but other layers depend on it. It's like the glue of the application. 
- This layer is environment agnostic.

