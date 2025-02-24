# LibroMate Backend (ASP.NET Web API)

This is the backend API for the **LibroMate Library Management System**, built using **ASP.NET Web API** and **SQLite**.

## **Prerequisites**
Ensure you have the following installed on your system:
- .NET SDK (Latest Version) → [Download](https://dotnet.microsoft.com/en-us/download)
- Visual Studio (Recommended)
- SQLite
- Postman (For API testing - Optional)

## **Setup Instructions**

### **1. Clone the Repository**
```sh
git clone <backend-repository-url>
cd <backend-repository-folder>

### **2. Open the Project in Visual Studio*
```sh
Open LibroMate.sln in Visual Studio.


### **3. Install Dependencies**
```sh
Restore missing NuGet packages (Visual Studio should handle this automatically).

### **4. Run Database Migrations**
If database migrations are not applied, run:
```sh
dotnet ef database update



