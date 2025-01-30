# TechWrite - A Blog Application
## Application Url :
https://techwrite.azurewebsites.net/

TechWrite is a blogging platform built with **ASP.NET Core MVC**, **Web API**, **SQL Server**, **Entity Framework**, **JWT Authentication**, **Fluent Validation**, and **Repository Design Pattern**. The application allows users to create, view, and manage blog posts while ensuring robust security and scalable architecture through modern design patterns like Dependency Injection.

## Table of Contents
1. [Introduction](#introduction)
2. [Technologies Used](#technologies-used)
3. [Features](#features)
4. [Architecture](#architecture)
5. [Setup Instructions](#setup-instructions)
  
## Introduction
TechWrite is a modern blogging platform that provides an easy-to-use interface for users to create, read, update, and delete (CRUD) blog posts. The project is designed to showcase best practices in **ASP.NET Core MVC**, **Web API**, and modern authentication methods using **JWT Tokens**.

The application uses the **Repository Pattern** for data access and **Dependency Injection** to ensure a decoupled architecture. The application is designed to be scalable, easy to maintain, and test.

## Technologies Used
- **ASP.NET Core MVC**: Web application framework for building dynamic websites.
- **Web API**: RESTful APIs for communication between front-end and back-end.
- **SQL Server**: Database for storing blog posts, user information, and other relevant data.
- **Entity Framework Core**: ORM (Object-Relational Mapping) framework for interacting with the database.
- **JWT Authentication**: Secure authentication method using JSON Web Tokens.
- **Fluent Validation**: Validation library for validating user inputs.
- **Repository Design Pattern**: Structural pattern for abstracting data access logic.
- **Dependency Injection**: To manage the application's dependencies and improve code modularity and testability.
- **System.Security.Cryptography**: For encryption and secure handling of sensitive data.
- **Azure** :Azure App service,Azure sql database.
- **Logging** :Serilog (console,files).
- **CI/CD** :Git Action.


## Features
- **User Authentication**: Secure user login using JWT Tokens.
- **CRUD Operations**: Create, Read, Update, and Delete blog posts.
- **Role-Based Access Control**: Only authorized users (Admin, User) can create or edit posts.
- **Fluent Validation**: Ensures all input data is validated before processing.
- **Error Handling**: Custom error handling with appropriate HTTP status codes.
- **Secure Data Storage**: Uses encryption and hashing for storing sensitive data (like passwords).
- **Repository Pattern**: Abstracts data access logic to ensure loose coupling and easier unit testing.

## Architecture
The application follows a **Layered Architecture** with the following layers:
1. **Presentation Layer** (MVC Controllers and Views): Handles HTTP requests, user interface logic, and returns responses.
2. **Business Logic Layer**: Contains the core business logic, operations on data, and validation.
3. **Data Access Layer**: Uses **Entity Framework Core** and the **Repository Design Pattern** to abstract database operations.
4. **API Layer**: Handles the interactions with the front-end and exposes API endpoints for operations like creating or fetching blog posts.

### Dependency Injection & Repository Pattern
- **Dependency Injection (DI)** is used throughout the project to inject required services (e.g., repositories, business logic) into controllers and other components.
- **Repository Pattern** is implemented to abstract and encapsulate all data access logic, making it easier to swap out the data source if needed.

### Prerequisites
1. **.NET Core SDK 6.0 or higher**.
2. **SQL Server** (Express or any version) installed.
3. **Visual Studio 2022 or VS Code**.
4. **Postman** (Optional, for testing the API endpoints).
   
### API Documentation

TechWrite exposes several API endpoints for interacting with blog posts, user authentication, and validation. Below is the list of available API endpoints.

### Blog Endpoints

#### **GET** `/api/BlogApi/Get`
- **Description**: Retrieves all blog details.
- **Response**: A list of blog posts.
  ```json
  "blogs": [
        {
            "blogId": 25,
            "title": "Mastering Modern Web Development: A Comprehensive Guide for Programmers",
            "description": "GraphQL. Learn how to create responsive, scalable, and efficient web applications, and discover tips for staying ahead in the ever-evolving ",
            "isActive": true,
            "userId": "65f7b244-67e5-45e3-ab57-d2a24c1f9de5",
            "publishedDate": "2024-12-30T06:20:37.1982357",
            "tagId": 2,
            "tagName": "Programming",
            "blogComments": null,
            "isApproved": true,
            "isTranding": false,
            "rejectComment": ""
        },
        {
            "blogId": 24,
            "title": "Others Test",
            "description": "Others ,Your blog has been successfully created and is currently awaiting admin approval.\nWe will notify you once it has been approved .Test",
            "isActive": false,
            "userId": "65f7b244-67e5-45e3-ab57-d2a24c1f9de5",
            "publishedDate": "2024-12-28T10:55:46.4950921",
            "tagId": 32,
            "tagName": "Others",
            "blogComments": null,
            "isApproved": false,
            "isTranding": false,
            "rejectComment": "test reject"
        }]

## Setup Instructions

To get started with **TechWrite**, follow these steps:
```bash
git clone https://github.com/yourusername/techwrite.git
cd techwrite


