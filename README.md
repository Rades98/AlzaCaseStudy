<H1>Alza case study </H1>
REST API service providing available products and its partial update

<h2>About</h2>

This repo contains: 
- REST API service providing all available products of an eshop and enabling the partial update of one product
- Swagger documentation of all endpoints
- Unit tests covering functionality on multiple layers
- Logging
- Caching of loaded data from database

<h2>Architecture</h2>

![Clean architecture](https://miro.medium.com/max/256/0*cKlf8Eymfs0hu8-2.png)

I tried to adhere all good principles and standards like:
- [REST best practices](https://www.vinaysahni.com/best-practices-for-a-pragmatic-restful-api?fbclid=IwAR2oTRiYnQI71XZnpRj4DrFHV-TJ5whT-NAGJEqmvENIfbsnXyGHUygQ2K4)
- [Structured logging](https://code-maze.com/structured-logging-in-asp-net-core-with-serilog/)
- [SOLID design principles](https://www.c-sharpcorner.com/UploadFile/damubetha/solid-principles-in-C-Sharp/)

<h3>Design patterns</h3>

<h4> Used patterns</h4>

- [CQRS](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs) Command Query Responsibility Segregation

- [Mediator pattern](https://en.wikipedia.org/wiki/Mediator_pattern) Behavioral pattern for object interaction interaction

Those two design patterns fits each other [CQRS & Mediator](https://medium.com/@darshana-edirisinghe/cqrs-and-mediator-design-patterns-f11d2e9e9c2e)

<h2>Tools</h2>

<h3>Technology</h3>

- C#
- .net6
- Entity Framework Core
- MSSQL
- x.Unit

<h3>Packages</h3>
<table>
<thead>
  <tr>
    <td>Package</td>
    <td>Usage</td>
  </tr>
</thead>
  <tr>
    <td>MediatR</td>
    <td>Mediator for CQRS design pattern</td>
  </tr>
  <tr>
    <td>Autofac</td>
    <td>Used better DI Container due to lack of solving injection abstractions with MediatR</td>
  </tr>
  <tr>
    <td>FluentValidation</td>
    <td>To construct strongly-typed validation rules for validation pipeline</td>
  </tr>
  <tr>
    <td>Serilog</td>
    <td>Logging</td>
  </tr>
  <tr>
    <td>Serilog</td>
    <td>Logging</td>
  </tr>
  <tr>
    <td>Swashbuckle.AspNetCore</td>
    <td>Swagger tools for documentation</td>
  </tr>
  <tr>
    <td>x.PagedList</td>
    <td>Pagination IEnumerable/IQueryable extension</td>
  </tr>
  <tr>
    <td>Moq</td>
    <td>Mocking framework for Unit tests</td>
  </tr>
  <tr>
    <td>Shouldly</td>
    <td>Assertion framework for Unit tests</td>
  </tr>
</table>

<h2>Prerequisites for running of the project</h2>
To build and run this project there will be need of installation

- .NET 6 framework
- SQL server with MSSQL database running (db name should be configured in AppSettings.json -> ConnectionStrings field) 

<h4>IDE</h4>
<table>
<thead>
  <tr>
    <td>IDE</td>
    <td>info</td>
  </tr>
</thead>
  <tr>
    <td>Visual Studio 2022</td>
    <td>(v17.1)</td>
  </tr>
   <tr>
    <td>Visual Studio 2019 for Mac</td>
    <td>(v8.10)</td>
  </tr>
  <tr>
    <td>Visual Studio 2022 for Mac</td>
    <td>(v17.0 latest preview)</td>
  </tr>
  <tr>
    <td>Visual Studio Code</td>
    <td></td>
  </tr>
</table>
  
<h2>How to run</h2>

<h3>Run API from visual studio</h3>

- Clone repository from this GitHUb using GitChanges
- Optionaly Rebuild the solution, but this step should be provided automatically
- From package manager console Update-Database to get most recent data and table state
- Set API as startup project
- Run

<h3>Run Tests from visual studio</h3>

- Clone repository from this GitHUb using GitChanges
- Optionaly Rebuild the solution, but this step should be provided automatically
- Open Test Explorer
- Run optional or all at once

  
