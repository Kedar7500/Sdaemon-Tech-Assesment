# Sdaemon-Tech-Assesment
  This repository contains my implementation of the Task Management API challenge, built with ASP.NET Core and Entity Framework Core.
  
	## Prerequisites
		- .NET 8.0 SDK
		- Entity Framework Core (if not installed)

		### 1. Clone the repository
			- Open git bash
			- clone repository to local repository
			- git clone https://github.com/Kedar7500/Sdaemon-Tech-Assesment.git 
			
		### 2. Database

			- as there is inmemory Database configuration used here is no need to update any configuration related to Database.

		### 3. Run the application 

			- dotnet Run
		
	## Base URL - 
		
		https://localhost:7298/api/TaskManagement
		
	## Available Endpoints - 
	
		### GET - to get all tasks
			https://localhost:7298/api/TaskManagement 
			
		### GET - get tasks by id 
			https://localhost:7298/api/TaskManagement/{id}
			
		### POST - create new Task
			https://localhost:7298/api/TaskManagement
			
		### PUT - update existing Task
			https://localhost:7298/api/TaskManagement/{id}
			
		### DELETE - to delete task 
			https://localhost:7298/api/TaskManagement{id}
			
	## Example request 
	
		### POST - https://localhost:7298/api/TaskManagement
		Content-Type : application/json
		{
		  "Id" : "1"
		  "title": "Complete project",
		  "description": "Finish the API implementation",
		  "dueDate": "2023-12-31",
		  "isCompleted": false
		}
		
		
	## Optional Features 
	
		No UI implementation in this submission
		
	## Future Enhancements
	
	-	Add JWT authentication
	-	Implement pagination and filtering
	-	Initializing Database connection to connect with SQL server for large data process
	-	Add comprehensive unit tests
	
# End Of Document

	


