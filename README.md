# E-Library Management System
└── Purpose of this POC to have knowledge about design patterns and SOLID principals implementation. 

# A console application for library management, application built with below technology:
└── C#.Net Console Application

# GitHub public repositories (branch : basic-POC)
├── https://github.com/rajeevsharma4nagarro/Design-Patterns-POC-Basic
└── https://github.com/rajeevsharma4nagarro/Design-Patterns-POC-Basic.git

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
   └── Create a new user (Member/Librarian) based on user role input
└── Singleton:
   └── Create a single instance of the Library class to manage the library operations in the application "Program.cs"

Structural Patterns
├── Adapter:
   └── Adapter pattern is used to adapt the Azure Message to send notifications to users.
├── Decorator:
   └── Create a decorator ReservingBook class for book to add reserve or unreserve functionality to the book class.
└── Facade:
   └── UserAndBookGenerate class is used to provide a simplified interface to the complex/multiple subsystem of user and book management in single class.

Behavioral Patterns
├── Command:
   └── BookCommand class is used to implement the command pattern to encapsulate the request for book Create.
├── Observer:
   └── Notification class created as an observer to notify all users who have borrowed the book.
└── Iterator:
   └── Created a custom iterator for iterating those books which are already issued to the user.

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

# Screenshots of the application in action
├── /Screen-Shots/home-terminal.png
├── /Screen-Shots/Book-A-key-Add.png
├── /Screen-Shots/Book-D-key-Delete.png
├── /Screen-Shots/Book-H-key-Hold-Reserve.png
├── /Screen-Shots/Book-U-key-Update.png
├── /Screen-Shots/Book-V-key-View.png
├── /Screen-Shots/Loan-B-key-Borrow.png
├── /Screen-Shots/Loan-R-key-Return.png
├── /Screen-Shots/Loan-T-key-Track.png
├── /Screen-Shots/Notify-N-key-Notify-all-borrowers.png
├── /Screen-Shots/User-E-key-Edit.png
├── /Screen-Shots/User-L-key-ListUser.png
├── /Screen-Shots/User-P-key-Delete.png
└── /Screen-Shots/User-S-key-Signup.png




