# TechWrite - A Blog Application

TechWrite is a blogging platform built with **ASP.NET Core MVC**, **Web API**, **SQL Server**, **Entity Framework**, **JWT Authentication**, **Fluent Validation**, and **Repository Design Pattern**. The application allows users to create, view, and manage blog posts while ensuring robust security and scalable architecture through modern design patterns like Dependency Injection.

## Table of Contents
1. [Introduction](#introduction)
2. [Technologies Used](#technologies-used)
3. [Features](#features)
4. [Architecture](#architecture)
5. [Setup Instructions](#setup-instructions)
6. [API Documentation](#api-documentation)
7. [Authentication](#authentication)
8. [Error Handling](#error-handling)
9. [Contributing](#contributing)
10. [License](#license)

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

## Setup Instructions

To get started with **TechWrite**, follow these steps:

### Prerequisites
1. **.NET Core SDK 6.0 or higher**.
2. **SQL Server** (Express or any version) installed.
3. **Visual Studio 2022 or VS Code**.
4. **Postman** (Optional, for testing the API endpoints).

### Step 1: Clone the Repository
Clone the repository to your local machine using Git:

```bash
git clone https://github.com/yourusername/techwrite.git
cd techwrite
