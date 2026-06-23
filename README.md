# E-Library Management System
└── Purpose of this POC to have knowledge about design patterns and SOLID principals implementation. 

# A console application for library management, application built with below technology:
└── C#.Net Console Application

# GitHub public repositories (branch : basic-POC)
├── https://github.com/rajeevsharma4nagarro/Design-Patterns-POC-Basic
└── https://github.com/rajeevsharma4nagarro/Design-Patterns-POC-Basic.git

# Application Setup

Prerequisites
├── .Net Framwork: 10.0
└── c#: 14

Clone git repository, Build and Start application
├── Create any directory and open command prompt in same directory
├── cmd> git clone  https://github.com/rajeevsharma4nagarro/Design-Patterns-POC-Basic.git
├── cmd> dotnet build
├── cmd> dotnet run
└── User Input/Output screeen */Screen-Shots/home-terminal.png
	
# Project Structure
E-Library/
├── Books
├── Enums
├── Notifications
├── Screen-Shots
├── Users
├── Utilities
├── E-Library.csproj
├── E-Library.slnx
├── ELibraryApp.cs
├── Program.cs
└── README.md
	
# SOLID Principles implemented in this application
SOLID Implementation
├──S (Every class has single responsibility, such as Notifications/INotifyUser.cs)
├──O (Open for extension but not for  modification such as Users/Member.cs)
├──L (Liskov Substitution Principle, such as Users/Member.cs and Users/Librarian.cs)
├──I (Interface Segregation Principle, such as Notifications/INotifyUser.cs)
└──D (Dependency Inversion Principle, such as Users/User.cs where Notify function)

# Design Patterns implemented in this application
Creational Patterns
├── Factory Method:
└── Singleton:

Structural Patterns
├── Adapter:
├── Decorator:
└── Facade:

Behavioral Patterns
├── Command:
├── Observer:
└── Iterator:

# Screenshots of the application in action
├── Home screen (home-terminal.png)
├── 
└── 




