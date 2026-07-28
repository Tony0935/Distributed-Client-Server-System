# Distributed-Client-Server-System
Distributed C# system built with a strict client-server architecture: the client application never connects to the database directly, every data operation is mediated by a multithreaded TCP server.

## Overview

This is a desktop client-server system where multiple clients connect concurrently to a central server over TCP sockets. The server is the only component with access to SQL Server, exposing player, inventory, and session data through a socket-based protocol while enforcing business rules and data integrity at the network boundary.

The project focuses on the engineering problems behind that architecture — concurrency control, layered design, data validation, and graceful failure handling — rather than on the specific domain it's modeled around.

The repository contains two independent Visual Studio solutions that together make up the full system:

```
Distributed-Client-Server-System/
├── VideojuegoCliente/      → client solution (3 projects)
├── VideojuegoServidor/     → server solution (5 projects)
├── README.md
└── .gitignore
```

## Architecture

### Client — `VideojuegoCliente` (3 projects)

| Project | Responsibility |
|---|---|
| `VideojuegoCliente.Comunicacion` | Handles the socket connection to the server (`ClienteSocket.cs`) and message serialization (`Mensaje.cs`) |
| `VideojuegoCliente.GUI` | Windows Forms client UI — login, main menu, registration and query forms |
| `VideojuegoServidor.Entidades` | Shared entity/DTO classes (referenced by both client and server — see note below) |

### Server — `VideojuegoServidor` (5 projects)

| Project | Responsibility |
|---|---|
| `VideojuegoServidor.AccesoDatos` | The only layer with a database connection (`ConexionBD.cs`) — handles all SQL Server access via ADO.NET, one class per entity (`JugadorAD`, `CriaturasAD`, `InventarioAD`, `EquipoAD`, `BatallaAD`, `RondasAD`) |
| `VideojuegoServidor.Comunicacion` | Multithreaded TCP listener (`ServidorSocket.cs`) that accepts and manages concurrent client connections |
| `VideojuegoServidor.Entidades` | Shared entity/DTO classes |
| `VideojuegoServidor.GUI` | Admin/monitoring Windows Forms console, connection log (`BitacoraLog.cs`), and `App.config` (connection string) |
| `VideojuegoServidor.Logica` | Business rules and validation logic (`Logica Negocios`, `Validaciones`) |

> **Note:** the entities project is shared between client and server so both sides work against the same data contracts, while only the server's `AccesoDatos` project is able to reach SQL Server — the client only ever talks to the server through `Comunicacion`.

**Network protocol:** TCP sockets (`127.0.0.1:14100`). All client requests are serialized and sent to the server; the client holds no database connection string or direct SQL access.

## Key Features

- **Concurrency control** — the server (`ServidorSocket`) handles multiple clients via multithreading, supporting up to 8 simultaneous connections; a 9th connection queues until a slot frees up.
- **Live server monitoring** — the admin console (`FormServidor`, `BitacoraLog`) shows a real-time connection log and a live count of connected clients.
- **Authentication** — client login (`FormLogin`, `LoginDTO`) validated against SQL Server through the server, with the authenticated user persisted in the client session.
- **Business rule enforcement** — validation rules (e.g., tiered pricing, ownership constraints, eligibility checks) live in `VideojuegoServidor.Logica` and are also enforced at the database level via unique/composite keys.
- **Session engine** — a real-time, round-based battle flow (`BatallaEntidad`, `RondasEntidad`) with matchmaking-style queuing when no counterpart is available, and synchronized state updates across connected clients.
- **Query/reporting module** — aggregate views (e.g., rankings) and per-session history/detail lookups via the `ConsultasForms`.
- **Global exception handling** — all database and network exceptions are caught and translated into user-friendly messages; the application does not crash on invalid input or connection issues.

## Tech Stack

- **Language:** C#
- **Data Access:** ADO.NET (parameterized queries)
- **Database:** SQL Server (Windows Integrated Security via `App.config`)
- **UI:** Windows Forms
- **Networking:** TCP/IP Sockets, multithreading

## UI/UX Constraints

- Read-only `DataGridView` grids with full-row selection and human-readable headers (no raw property names exposed).
- Locked `ComboBox` controls (selection-only, no free text).
- No blocking `MessageBox` dialogs for routine input/output — only for validation errors and exceptions.

## Database Setup

The system requires SQL Server with a database named **BATALLAS**.  
A ready-to-use DDL script is available in `/Database/CreateDatabase.sql`.

### Setup Steps
1. Open SQL Server Management Studio (SSMS), Azure Data Studio, or your preferred SQL client.
2. Connect to your local SQL Server instance.
3. Execute `CreateDatabase.sql` to create the **BATALLAS** database with all required tables, constraints, and foreign keys.
4. Verify that the database and tables were created successfully.
5. Update the connection string in `VideojuegoServidor.GUI/App.config` to match your SQL Server setup.

### Connection Configuration Examples

**Default Instance (Windows Authentication)**
```xml
connectionString="Data Source=.;Initial Catalog=BATALLAS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;"
```
**Named Instance / SQLExpress
```xml
connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=BATALLAS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;"
```
**SQL Server Authentication
```xml
connectionString="Data Source=localhost;Initial Catalog=BATALLAS;User ID=sa;Password=your_password;Encrypt=True;TrustServerCertificate=True;"
```

### Getting Started
Open VideojuegoServidor.sln in Visual Studio and set VideojuegoServidor.GUI as the startup project.

Run the server — it must be listening before any client connects.

Open VideojuegoCliente.sln in a separate Visual Studio instance (or run the built executable), set VideojuegoCliente.GUI as the startup project, and run it to connect to 127.0.0.1:14100.

Repeat step 3 to launch additional client instances and test concurrent connections.


## Status

Completed academic project. Not under active development.

## Author

**Anthony Mendoza Rivas**
[LinkedIn](http://www.linkedin.com/in/anthonymendozarivas) · [GitHub](https://github.com/Tony0935)
