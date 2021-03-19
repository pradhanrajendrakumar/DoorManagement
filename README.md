# DoorManagement
Door management system provides a solution to manage all the doors at a facility. System enables you list all the doors at a facility.
It also enables you to modify the label to provide a user friendly name to an individual door. System also allow user to remove an existing door and add a new door.
Application support multiple concurrent clients monitoring the system and that changes to door statuses or configuration to be promptly reflected on all clients using SignalR connection.

Features:
1.	Listing Doors – Application loads all the doors at facility when client launches and displaying them in DataGrid
2.	Add Door- User can add a new door.
3.	 Delete – User can delete an existing door. Delete button is present in DataGrid.
4.	 Edit - User can edit an existing door. Here user can provide a user-friendly label, open or close the door, lock or unlock the door.

Technology & Tools Used:
1.	Visual Studio 2019
2.	.Net Core 5
3.	WPF for Client development
4.	ASP.NET Core Web API for Server development
5.	C#
6.	SignalR for real-time update
7.	EF Core 5 for data access
8.	EF Core In Memory database.

Steps to run the application:
1.	Launch the server application “API”.
2.	Launch the Client application “DesktopClient”.
3.	Launch another Client application “DesktopClient” for monitoring the system.

Door Management System overview:
Server: 
Server application implemented using ASP.NET Core 5 WEB API. It has a door controller who exposes endpoints for door application. 
It does CRUD operation like for listing, removing, adding, and editing the doors.
Server has a SignalR Hub for real time data updates. 

Client:
Client application implemented using C#, WPF and MVVM. It sends HTTP requests to server to list the doors at facility, removes the existing door, edits the existing door, and adds a new door.
Client calls SignalR Hub methods to notify other connected clients for data refresh.
 



