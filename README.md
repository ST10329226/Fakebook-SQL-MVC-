# Fakebook: A Mini Social Media Platform

![Fakebook Logo](https://img.shields.io/badge/Fakebook-Social%20App-blueviolet)
![.NET Version](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)
![Database](https://img.shields.io/badge/SQL_Server-2022-CC2927?logo=microsoftsqlserver)
![License](https://img.shields.io/badge/License-MIT-green)

---

## 📖 Table of Contents

- [🚀 About the Project](#-about-the-project)
- [✨ Features](#-features)
- [💻 Technologies Used](#-technologies-used)
- [🚦 Getting Started](#-getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Database Setup](#database-setup)
  - [Configuration](#configuration)
  - [Running Locally](#running-locally)
- [💡 Usage](#-usage)
- [🤝 Contributing](#-contributing)
- [📄 License](#-license)
- [📞 Contact](#-contact)

---

## 🚀 About the Project

**Fakebook** is a simplified social media platform built using ASP.NET Core MVC. This project serves as a foundational learning exercise to demonstrate key web development concepts including Model-View-Controller (MVC) architecture, database interaction with Entity Framework Core, and dynamic web page rendering with Razor.

It provides core functionalities for managing users and posts, complete with advanced filtering, searching, and sorting capabilities.

## ✨ Features

Fakebook currently supports the following functionalities:

* **User Management:**
    * Displaying a list of all registered users.
    * Advanced search for users by **Username**, **Email**, or **Bio**.
    * Filtering users by **Email Domain** (e.g., @gmail.com, @example.com).
    * Sorting users by **Username** (A-Z, Z-A) and **Email** (A-Z, Z-A).
    * Search results for users are **scored** based on relevance across multiple fields (e.g., username matches score higher).
* **Post Management:**
    * Displaying a list of all posts.
    * Searching posts by **Post Caption (Content)** or **Username of the post owner**.
    * Filtering posts by **Date Range** (created between two specific dates).
    * Filtering posts by **Specific Users** (using a dropdown list of usernames).
    * Sorting posts by **Newest to Oldest** and **Oldest to Newest**.
    * All filters and sorting options **persist** across form submissions.
* **Core MVC Structure:**
    * Clear separation of concerns using MVC.
    * Database interaction via **Entity Framework Core**.
    * Dynamic UI rendering with **Razor Views**.
    * Robust handling of database relationships and nullable types in C#.
* **Basic Navigation:**
    * A simple home page with links to Users, Posts, Comments, and Likes sections.

## 💻 Technologies Used

* **Backend:** C#, ASP.NET Core MVC ([.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) or later)
* **Database:** SQL Server (SQL Server Management Studio - SSMS)
* **ORM (Object-Relational Mapper):** Entity Framework Core
* **Frontend:** HTML, CSS (Bootstrap for basic styling), Razor Syntax
* **Package Management:** NuGet
* **Version Control:** Git, GitHub

## 🚦 Getting Started

To get a local copy up and running, follow these simple steps.

### Prerequisites

* [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) (or compatible version)
* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (Community Edition or higher)
* [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express, Developer, or full version)
* [SQL Server Management Studio (SSMS)](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms) (for database setup)

### Installation

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/YourUsername/Fakebook-Mini-Social-Media-Platform.git](https://github.com/YourUsername/Fakebook-Mini-Social-Media-Platform.git)
    cd Fakebook-Mini-Social-Media-Platform
    ```
    (Replace with your actual repository URL)

2.  **Open the solution in Visual Studio:**
    * Navigate to the cloned directory and double-click `Fakebook.sln`.

### Database Setup

**IMPORTANT:** Before running the application, you must set up your SQL Server database.

1.  **Open SSMS:** Connect to your SQL Server instance (e.g., `(localdb)\MSSQLLocalDB`, `localhost`, or your remote server `jumbotron.database.windows.net,1433`).
2.  **Create the Database:** If you haven't already, create a database named `Fakebook`.
    ```sql
    CREATE DATABASE Fakebook;
    ```
3.  **Run the Schema and Data Script:**
    * Open the `Database/Fakebook_Schema_and_Data.sql` file (you'll need to create this file locally with the provided script).
    * Ensure you are connected to your `Fakebook` database (use the dropdown in SSMS Query window, or add `USE Fakebook;` at the top of the script).
    * Execute the script. This will create all necessary tables (`Users`, `Posts`, `Comments`, `Likes`) and populate them with sample data for testing.

### Configuration

1.  **Update `appsettings.json`:**
    * In your Visual Studio project, open `appsettings.json`.
    * Update the `FakebookContext` connection string to point to your SQL Server instance and `Fakebook` database.
    * If using Active Directory Authentication, ensure your Visual Studio / Azure CLI is authenticated correctly.

    ```json
    {
      "ConnectionStrings": {
        "FakebookContext": "Server=tcp:jumbotron.database.windows.net,1433;Initial Catalog=Fakebook;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=\"Active Directory Default\";"
      }
      // ... other settings
    }
    ```
    **Note:** Replace `jumbotron.database.windows.net,1433`, `User ID=your_username;Password=your_password;` (if using SQL Auth) with your actual server and credentials.

### Running Locally

1.  **Build the Project:**
    * In Visual Studio, go to `Build` > `Rebuild Solution`.
2.  **Run the Application:**
    * Press `F5` or click the green "Play" button in Visual Studio.
    * Your application will launch in your default web browser.

## 💡 Usage

Once the application is running:

1.  **Home Page:** You will land on the home page with navigation links.
2.  **View Users:** Click "View Users" to browse user profiles, search by name/email/bio, filter by email domain, and sort.
3.  **View Posts:** Click "View Posts" to see all posts, search by content/user, filter by date range or specific user, and sort.
4.  **Comments/Likes:** The pages for comments and likes will display their respective data (if populated by your database script).

## 🤝 Contributing

Contributions are welcome! If you have suggestions or find issues, please open an issue or submit a pull request.

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 📞 Contact

[Sheldon Govender] - [Govendersheldon878@gmail.com]

Project Link: [https://github.com/YourUsername/Fakebook-Mini-Social-Media-Platform](https://github.com/YourUsername/Fakebook-Mini-Social-Media-Platform)
