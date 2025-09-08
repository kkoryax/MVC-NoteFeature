# NoteFeature

A simple note-taking web application built with ASP.NET Core MVC (.NET 8), Razor Views, Entity Framework Core, and Bootstrap 5.

## Features

- **Create, Read, Update, Delete (CRUD) Notes:**  
  Users can add, view, edit, and delete personal notes.
- **Responsive UI:**  
  Clean, mobile-friendly interface using Bootstrap 5 and Bootstrap Icons.
- **Dashboard:**  
  View all notes in a card-based layout with creation timestamps.
- **Navigation:**  
  Sidebar and off-canvas menu for easy navigation on desktop and mobile.
- **Validation:**  
  Client-side and server-side validation for note input.
- **Persistence:**  
  Notes are stored in a SQL Server database via Entity Framework Core.

## Project Structure

- `Controllers/NoteController.cs`  
  Handles all note-related HTTP requests and CRUD operations.
- `Models/NoteModel.cs`  
  Defines the Note entity with properties.
- `Data/ApplicationDBContext.cs`  
  Entity Framework Core context for database access.
- `Views/Note/`  
  Razor views for listing, creating, editing, and deleting notes.
- `Views/Shared/_Layout.cshtml`  
  Main layout with navigation and responsive design.
- `wwwroot/`  
  Static files including Bootstrap, jQuery, and custom styles/scripts.
