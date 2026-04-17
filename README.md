# Author - Shaikh Adeeba Aspiring .Net Developer

This project is a full-stack Student Management System built using ASP.NET Core Web API and ASP.NET Core MVC.
It demonstrates how a frontend MVC application can consume RESTful APIs to perform CRUD operations on student data.

The system allows users to create, read, update, and delete student records with seamless integration between frontend and backend.

# Technologies Used
ASP.NET Core MVC
ASP.NET Core Web API
Entity Framework Core
SQL Server
HttpClient (for API consumption)
Swagger (API testing)
C#
# Key Features
🔹 RESTful API for student management
🔹 MVC frontend consuming Web API
🔹 Full CRUD operations (Create, Read, Update, Delete)
🔹 Entity Framework Core for database operations
🔹 Swagger UI for API testing and documentation
🔹 Clean separation between API and UI layers
🔹 Form validation and user-friendly interface
# Project Architecture

# The project is divided into two main parts:

Web API Project------->Handles all backend logic and database operations. Exposes RESTful endpoints
MVC Project---------->Acts as the frontend UI, Consumes Web API using HttpClient
# API Endpoints
Method	Endpoint	Description
GET	/api/StudentApi	Get all students
GET	/api/StudentApi/{id}	Get student by ID
POST	/api/StudentApi	Add new student
PUT	/api/StudentApi/{id}	Update student
DELETE	/api/StudentApi/{id}	Delete student

# How to Run the Project
Clone the repository
Open both API and MVC projects in Visual Studio
Update database connection string in appsettings.json
Run database migrations (if needed)
Start the Web API project first
Run the MVC project
Open browser and use the application
# What I Learned
Building RESTful APIs using ASP.NET Core
Consuming APIs in MVC using HttpClient
Working with Entity Framework Core
Structuring full-stack .NET applications
Debugging real-time API integration issues
# Future Improvements
Add Authentication & Authorization (Login System)
Implement Role-based access
Improve UI design
Deploy project on cloud (Azure)
