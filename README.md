# 📚 Book Library API - Repository Pattern with Unit of Work

A **.NET 8** RESTful Web API for managing a Book Library system, built using **Repository Pattern** and **Unit of Work**, with **JWT Authentication** for securing endpoints.

---

## ✨ Features

- 🏛️ **Repository Pattern** and **Unit of Work** for clean architecture
- 🔒 **Authentication & Authorization** using **JWT Bearer Tokens**
- 📚 **Book Borrowing and Returning** system
- 🛡️ **Role-based access control** (`Admin` role features)
- 🧪 Built-in **Swagger** UI for testing APIs
- 🚀 **Dockerized** for easy deployment

---

## 🏗️ Folder Structure

```
/RepositoryPatternWithUOW.Api       --> Main Web API project
  ├── /Controllers                  --> API Controllers (Auth, Books, Authors)
  ├── appsettings.json              --> Application settings
  ├── Dockerfile                    --> Docker configuration
  ├── Program.cs                    --> Application entry point

/RepositoryPatternWithUOW.Core       --> Core layer (business logic)
  ├── /Constants                    --> Static values/constants
  ├── /Interfaces                   --> Repository and Unit of Work interfaces
  ├── /Models                       --> Entity and business models
  ├── IUnitOfWork.cs                --> Unit of Work interface

/RepositoryPatternWithUOW.EF         --> Infrastructure layer (Entity Framework)
  ├── /Migrations                   --> EF Core Migrations
  ├── /Repositories                 --> Repository implementations
  ├── ApplicationDbContext.cs       --> EF Core DbContext
  ├── UnitOfWork.cs                 --> Unit of Work implementation
```

---

## 🔑 Authentication & Authorization

- 🔒 **JWT Bearer Authentication** secures the API.
- 🛡️ Some endpoints require specific **Roles** (e.g., `Admin`) for sensitive actions.

---

## 🚀 API Endpoints Overview

### 📑 Auth Endpoints (`/api/auth`)

| Method | Route            | Description                  | Authorization Required |
|:-------|:------------------|:------------------------------|:------------------------|
| POST   | `/register`        | Register a new user           | ❌                      |
| POST   | `/login`           | Login and get JWT token       | ❌                      |
| POST   | `/addrole`         | Add a role to a user          | ✅ (Admin only)          |

---

### 📑 Books Endpoints (`/api/books`)

| Method | Route                 | Description                     | Authorization Required |
|:-------|:----------------------|:---------------------------------|:------------------------|
| GET    | `/GetAllAvailable`     | Get all available (not borrowed) books | ❌              |
| GET    | `/GetAll`              | Get all books                   | ✅ (Admin only)          |
| POST   | `/AddBook`             | Add a new book                  | ✅ (Admin only)          |
| POST   | `/BorrowBook`          | Borrow a book                   | ✅                      |
| POST   | `/ReturnBook`          | Return a borrowed book          | ✅                      |
| GET    | `/GetByName`           | Get a book by Title ("NewBook")  | ❌                      |
| GET    | `/GetAllWithAuthors`   | Get books with author information (Title contains "NewBook") | ❌ |
| GET    | `/GetOrdered`          | Get books ordered by Id (Title contains "NewBook") | ❌ |

---

### 📑 Authors Endpoints (`/api/authors`)

| Method | Route           | Description                  | Authorization Required |
|:-------|:-----------------|:------------------------------|:------------------------|
| GET    | `/`              | Get author by static ID (id=1) | ✅                      |
| GET    | `/GetbyIdAsync`  | Get author asynchronously by ID (id=1) | ❌            |

---

## 🛠️ Tech Stack

| Technology             | Purpose                  |
|:------------------------|:-------------------------|
| .NET 8                  | Backend Framework        |
| Entity Framework Core   | ORM                      |
| JWT Bearer Authentication | Authentication        |
| Docker                  | Containerization         |
| Swagger (Swashbuckle)   | API Documentation         |

---

## ⚡ Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker](https://www.docker.com/) (optional)

---

### Run Locally

```bash
git clone https://github.com/YOUR_GITHUB_USERNAME/RepositoryPatternWithUOW.git
cd RepositoryPatternWithUOW
```

```bash
cd RepositoryPatternWithUOW.Api
dotnet restore
dotnet run
```

Swagger UI will be available at:  
➡️ `https://localhost:5001/swagger` (HTTPS)  
➡️ `http://localhost:5000/swagger` (HTTP)

---

### Run with Docker

```bash
docker build -t booklibraryapi .
docker run -d -p 5000:80 booklibraryapi
```

---

## 🧪 Example API Requests

### Register a New User

```http
POST /api/auth/register
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "YourSecurePassword123!"
}
```

### Login and Obtain JWT Token

```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "YourSecurePassword123!"
}
```

Use the received token in Authorization headers:

```
Authorization: Bearer YOUR_JWT_TOKEN
```

---

### Borrow a Book

```http
POST /api/books/BorrowBook?BookId=1&UserId=your_user_id
Authorization: Bearer YOUR_JWT_TOKEN
```

---

## 👨‍💻 Author

Made with ❤️ by **Filo Salah**  
🔗 Docker Hub: [filosalah](https://hub.docker.com/u/filosalah)

---

#️⃣ _Feel free to fork, contribute, and star the project!_

