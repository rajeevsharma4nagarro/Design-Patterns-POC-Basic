# E-Library Management System
└── Purpose of this POC to have knowledge about design patterns and SOLID principals implementation. 

# A console application for library management, application built with below technology:
└── C#.Net Console Application
	
# Project Structure
E-Library/
├── bin
├── Books
├── Enums
├── Notifications
├── obj
├── Screen-Shots
├── Users
├── Utilities
├── E-Library.csproj
├── E-Library.slnx
├── ELibraryApp.cs
├── Program.cs
└── README.md
	

# SOLID Implementation

├──S Login page with JWT token storage
├──O Users dashboard with CRUD operations
├──L Add/Edit User component with reactive forms
├──I Authentication guard (CanActivate)
└──D Responsive styling with basic CSS


# GitHub public repositories (branch : advance-POC)
├── https://github.com/rajeevsharma4nagarro/Design-Patterns-POC-Basic
└── https://github.com/rajeevsharma4nagarro/Design-Patterns-POC-Basic.git


# Docker & Compose Setup

Prerequisites
├── .Net Framwork: 10.0
└── c#: 14

# GitHub CI/CD Pipe line configuration
├── Make changes in any branch	
├── Create PR for source branch (main) which is set as default branch
├── CI/CD Action workflow job (Docker Advance CI-CD Pipe line POC : ci-cd.yml) is configured on push changes in main branch
├── I have configured jobs: build-and-deploy which run ubuntu:latest
├── Steps I covered in ci/cd pipe line:
├── ── Check out git branch
├── ── Login Docker hub
├── ── Build UI Application and push image with tag V{$ github.run_number } and Latest
├── ── Build Api Service and push image with tag V{$ github.run_number } and Latest
├── Now Latest image will published on docker repository

Note: docker-compose.yml file have image referenc from shared docker hub respository, so to run the application in local environment just download repository from git.
Open terminal and nevigate to this path run below command, it will bring up application.

# Screenshots of the application in action
├── Login screen (Login-Screen.png)
├── Dashboard (User-Dashboard.png)
├── Add User (User-add.png)
├── Edit User (User-edit.png)
├── Dashboard-Dataload-from-cache.png
└── Dashboard-Dataload-from-database.png

# Download all images, Build and Start All Services
├── docker compose --env-file .env.deve up --build -d  (when we are using development environment build, It will run Frontend on 4201 port)
├── docker compose --env-file .env.prod up --build -d  (when we are using production environment build, It will run Frontend on 8080 port)
├── open http://localhost:8080
├── login screen will be prefilled credential Admin/Admin1
├── From dashboard click Add button, fill form and click Save. Next time this user credential can be use for login.
├── To check the data caching open developer tool and nevigate to network tab.
├── After login when dashboard page opens check response it  will show source  as  db because 1st hit  fetch data from database.
├── Refresh the same page with in 60 seconds and check api response source will cache
├── Cache will persist  for 60 seconds or till the time any add/delete action not taken 
└── For reference refer scree shots Dashboard-Dataload-from-cache.png, Dashboard-Dataload-from-database.png


