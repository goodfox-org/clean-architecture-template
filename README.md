# Clean Architecture template

### Build, Run

```bash
cd /repo/root/templates/CleanArchitectureFull
dotnet build
dotnet dotnet run --project .\presentation\CleanArchitecture.Template.RestApi\CleanArchitecture.Template.RestApi.csproj
```

```bash
curl -i 'http://localhost:5000/user' \
--header 'Content-Type: application/json' \
--data '{
    "firstName": "John",
    "lastName": "Doe"
}'
```

# MediatR, CQRS, and FluentValidation

The main functionality follows 2 design patterns: Mediator and CQRS.

- [CQRS](https://martinfowler.com/bliki/CQRS.html)
- [Mediator](https://en.wikipedia.org/wiki/Mediator_pattern)
- [MediatR library](https://github.com/jbogard/MediatR)
- [Fluent Validation library](https://fluentvalidation.net/)

# Links

[Clean architecture - Jason Taylor - NDC Sydney 2019](https://www.youtube.com/watch?v=5OtUm1BLmG0 "Clean Architecture")  
[Repository Pattern with C# and Entity Framework, Done Right | Mosh](https://www.youtube.com/watch?v=rtXpYpZdOzM "Repository patter")
