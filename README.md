# Onion Architecture – Post Module

A small C# project demonstrating the **domain layer of an Onion Architecture** using a simple province and city management domain.

The project focuses on keeping domain entities and repository contracts independent from infrastructure concerns such as database access, APIs, or user interfaces.

## Overview

The solution models a simple geographical domain containing **Provinces** and **Cities**.

It demonstrates several concepts commonly used in layered and Onion Architecture designs:

- Domain entities
- Generic base entities
- Repository abstractions
- Encapsulated domain behavior
- Entity relationships
- Separation of domain logic from persistence implementation

The project is implemented as a **.NET Framework 4.7.2 class library**.

---

## Architecture

The current repository represents the **Domain layer** of the application.

```text
             Outer Layers
    ┌─────────────────────────┐
    │      Presentation       │
    │       Application       │
    │      Infrastructure     │
    │                         │
    │   ┌─────────────────┐   │
    │   │     Domain      │   │
    │   │                 │   │
    │   │    Entities     │   │
    │   │   Repository    │   │
    │   │    Contracts    │   │
    │   └─────────────────┘   │
    └─────────────────────────┘
```

Only the domain-related components are implemented in this repository.

The project does not currently include a presentation layer, API, or concrete persistence implementation.

---

## Domain Model

### BaseEntity

`BaseEntity<TKey>` provides common properties shared by domain entities.

```csharp
public class BaseEntity<TKEY>
{
    public TKEY Id { get; set; }
    public DateTime CreatedDate { get; set; }
}
```

Using a generic key allows domain entities to use different identifier types while sharing common entity behavior.

---

### Province

The `Province` entity represents a province and contains:

- `Id`
- `Title`
- `CreatedDate`
- neighboring/related province information
- collection of cities

The entity also contains domain operations for modifying its state.

```csharp
public void Edit(string title)
{
    Title = title;
}
```

Related province identifiers can also be updated through:

```csharp
ChangeCloseProvince(...)
```

---

### City

The `City` entity belongs to a province and contains:

- `Title`
- `ProvinceId`
- `Province`
- `IsCapital`
- `IsCenterCity`

Instead of exposing all state changes directly, the entity provides methods representing domain operations.

Examples include:

```csharp
Edit(...)
IsCaptal()
IsCenter()
NotCenterOrTehran()
```

These operations manage whether a city represents the capital, the center city of a province, or neither.

---

## Entity Relationship

The basic domain relationship is:

```text
Province
   │
   │ 1
   │
   │
   │ *
   ▼
 City
```

A province can contain multiple cities, while each city references its province through `ProvinceId` and `Province`.

---

## Repository Abstraction

Persistence contracts are defined inside the domain project without providing a concrete database implementation.

The generic repository interface is:

```csharp
IRepository<TKey, T>
```

and defines common persistence operations including:

```csharp
GetAll()
GetAllBy(...)
GetById(...)
Create(...)
Delete(...)
ExistBy(...)
Save()
```

Domain-specific repository contracts extend the generic repository.

```csharp
ICityRepository : IRepository<int, City>
```

and:

```csharp
IProvinceRepository : IRepository<int, Province>
```

This design allows persistence implementations to be provided by an outer infrastructure layer without coupling the domain entities to a particular database technology.

---

## Project Structure

```text
OnionArchProj/
│
├── Base/
│   └── BaseEntity.cs
│
├── CityEntity/
│   └── City.cs
│
├── ProvinceEntity/
│   └── Province.cs
│
├── Reposity/
│   ├── IRepository.cs
│   ├── ICityRepository.cs
│   └── IProvinceRepository.cs
│
├── Properties/
│   └── AssemblyInfo.cs
│
├── PostModule.Domain.csproj
└── PostModule.sln
```

---

## Technologies

- C#
- .NET Framework 4.7.2
- Visual Studio
- Generic Repository Pattern
- Onion Architecture principles
- Object-oriented domain modeling

---

## Design Concepts

### Onion Architecture

The project keeps core domain concepts independent from infrastructure and presentation concerns.

The domain defines the business entities and contracts, while concrete implementations can be introduced in outer layers.

### Repository Pattern

Repository interfaces abstract persistence operations from the domain model.

This allows the persistence mechanism to change without requiring domain entities to depend directly on database-specific code.

### Generic Base Entity

Common entity information such as identifiers and creation timestamps is centralized in:

```text
BaseEntity<TKey>
```

### Encapsulated Domain Behavior

The `City` entity uses methods such as `IsCenter()` and `IsCaptal()` to change related state instead of requiring consumers to manipulate every property independently.

---

## Building the Project

The project targets:

```text
.NET Framework 4.7.2
```

Open:

```text
PostModule.sln
```

in Visual Studio and build the solution.

Alternatively, from a Visual Studio Developer Command Prompt:

```bash
msbuild PostModule.sln
```

---

## Current Scope

This repository currently contains the **domain model and repository contracts**.

It does not currently contain:

- REST API or presentation layer
- concrete repository implementations
- database context
- authentication
- frontend
- automated tests

These concerns would normally be implemented in the outer layers of a complete Onion Architecture application.

---

## Purpose

The purpose of this project is to demonstrate how core domain entities and persistence contracts can be structured independently from infrastructure concerns using Onion Architecture principles.

The example uses a small province/city domain to demonstrate entity relationships, domain behavior, generic repository abstractions, and separation of concerns.
