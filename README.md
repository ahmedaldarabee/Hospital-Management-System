 Hospital Management System

This project is a comprehensive hospital management system built using ASP.NET Core and Entity Framework Core.

 Key Features

- Patient Management: Add, edit, and delete patient information.
- Doctor Management: Register doctor details and their specializations.
- Appointments: Schedule and manage patient appointments with doctors.
- Reporting: Generate statistical reports on patient numbers and appointments.

 Technologies Used

- ASP.NET Core MVC: For building the user interface and following the MVC pattern.
- Entity Framework Core: For database interactions (ORM).
- SQL Server: As the database.
- Bootstrap: For a responsive and modern UI design.

 How to Run the Project

1.  Clone the Repository:
    ```bash
    git clone [https://github.com/YourGitHubUsername/YourRepositoryName.git](https://github.com/YourGitHubUsername/YourRepositoryName.git)
    ```
2.  Open the Project:
    Open the solution file (`.sln`) in Visual Studio.
3.  Update the Database:
    If the project uses Entity Framework Core Migrations, run the following command in the Package Manager Console:
    ```
    Update-Database
    ```
    Note: If you're using a Code-First approach, this command will create the database and tables for you. If you're using Database-First, the project will connect to the existing database.
4.  Run the Application:
    Press `F5` in Visual Studio to run the application.
