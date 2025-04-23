# 🚀TNS Backend

## 📖 Overview
This backend API, built with **.NET 8** and **PostgreSQL**, handles CRUD operations for **Departments** and **Users** in a **1:M relationship**.

## 🛠️ Tools Used
- 💻 **Visual Studio Code**: Code editor.
- 🌿 **GIT**: Version control.
- 🖥️ **.NET SDK 8**: Framework for the API.
- 🐘 **PostgreSQL**: Database for Departments and Users.

---

## 📂 Project Structure
Key components of the project :
```sh
TNS-Backend/ 
├── Controllers/
│   ├── DepartmentsController.cs 
│   ├── UsersController.cs 
├── Data/
│   ├── AppDbContext.cs 
│   ├── AppDbContextFactory.cs 
├── Models/
│   ├── Department.cs 
│   ├── User.cs 
├── Program.cs
├── appsettings.json
└── README.md
```

---

## 🗃️ Database Schema
The database consists of two main tables :

### 🏢 Departments Table
| Column | Type | Description |
|--------|------|------------|
| **Id** | `int` | Auto-generated primary key 🔑 |
| **Name** | `text` | Department name (required) 📛 |

### 👥 Users Table
| Column | Type | Description |
|--------|------|------------|
| **Id** | `int` | Auto-generated primary key 🔑 |
| **FullName** | `text` | User’s name (required) 🧑 |
| **DepartmentId** | `int` | Foreign key linking to **Departments** (deleting a department removes its users) 🔗 |

---

## ⚙️ Setup Instructions

### 📥 Clone the Repository
```sh
git clone https://github.com/windme2/tns-backend.git
cd tns-backend
```

### 🔧 Install Dependencies

```sh
dotnet restore
```

### 🐘 Set Up PostgreSQL :
Create a database named tnsdb.
Update the connection string in appsettings.json:
```sh
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=tnsdb;Username=postgres;Password=admin"
}
```

### 🚀Run Migrations :
```sh
dotnet ef database update
```
### ▶️ Run the Application :
```sh
dotnet run
```
---

### API will be available at 🔗 [http://localhost:5000/swagger/](http://localhost:5000/swagger/)


## 🌐 API Endpoints

🏢 Departments
| Method | Endpoint | Description | 
|----------|----------|--------------------|
| GET | /api/Departments | Get all Departments 📋 | 
| GET | /api/Departments/{id} | Get a Department by ID 🔍 | 
| POST | /api/Departments | Create a Department ➕ | 
| PUT | /api/Departments/{id} | Update a Department ✏️ | 
| DELETE | /api/Departments/{id} | Delete a Department 🗑️ | 

👥 Users
| Method | Endpoint | Description | 
|----------|----------|--------------------|
| GET | /api/Users | Get all users 📋 | 
| GET | /api/Users/{id} | Get a User by ID 🔍 | 
| POST | /api/Users | Create a User ➕ | 
| PUT | /api/Users/{id} | Update a User ✏️ | 
| DELETE | /api/Users/{id} | Delete a User 🗑️ | 

---

## 📦 GitHub Repository

The source code is available at: https://github.com/windme2/tns-backend 🌐

---

## 📜 License

This project is licensed under the MIT License.
