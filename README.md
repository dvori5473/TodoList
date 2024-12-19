# ToDo List - Fullstack Project              
https://todolist-kga5.onrender.com/
## Overview

The **ToDo List** project is a Fullstack application designed for task management. It incorporates a **.NET 8 Minimal API** backend, a **React.js** client, and a **MySQL** database, providing seamless task CRUD operations with a focus on simplicity and performance.

## Features

- **Task Management**: Create, retrieve, update, and delete tasks.
- **Database Integration**: Uses MySQL with Entity Framework Core for robust data persistence.
- **Minimal API**: Simplified backend development with clear and concise route handling.
- **Client-Server Communication**: React client integrated with Axios for API interaction.
- **Swagger Documentation**: Built-in API testing interface.
- **CORS Support**: Enables secure cross-origin requests.
- **Error Handling**: Axios interceptors for efficient error logging.

## Tech Stack

### Backend
- **.NET 8 Minimal API**
- **Entity Framework Core** (with Pomelo for MySQL)
- **Swagger (Swashbuckle)**

### Frontend
- **React.js**
- **Axios**

### Database
- **MySQL** (managed via MySQL Workbench)

## API Endpoints

- **GET** `/tasks` - Retrieve all tasks
- **POST** `/tasks` - Add a new task
- **PUT** `/tasks/{id}` - Update an existing task
- **DELETE** `/tasks/{id}` - Delete a task

## Setup and Usage

### Prerequisites

- **MySQL** installed and running
- **Node.js** and **npm** installed
- **.NET 8 SDK** installed

### Backend

1. Navigate to the `TodoApi` directory.
2. Configure `appsettings.json` with your MySQL connection string.
3. Run the backend:
   ```bash
   dotnet watch run

### Frontend

1. Navigate to the `Client` directory.

2. Install dependencies:
   ```bash
   npm install
3. Run the frontend:
   ```bash
   npm start

## Acknowledgments

Special thanks to the tools and libraries that made this project possible:

- **Microsoft .NET**
- **React.js**
- **Axios**
- **MySQL Workbench**





