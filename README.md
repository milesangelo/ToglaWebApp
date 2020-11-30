# ToglaWebApp
Togla Market Data API Webapp

Requirements:
- .NET installed on local machine.
- database provider of choice!  (thanks, EFCore!) (I am currently using PostgreSQL)
- IDE/Text Editor of choice! (Visual Studio - pc or Rider/VSCode - mac)

Projects include in solution:
- Togla.Data
  Fundamental Database models
- Togla.DataImporter
  Imports data into database using external methods.
- Togla.Services
  Link between the database context and view controllers.
- Togla.Tests
  Unit tests project.
- Togla.Web
  Handles HTTP Requests/ API calls made to web service.


Roadmap

- ~~Ability to load historical market data (equity/options) into database using Togla.DataImporter~~ 
  
