# _Eau Claire's Salon_

#### _Database basics independent project for Epicodus_, _Mar. 20 2020_

#### By _**Michelle Morin**_

## Description

_This application allows an owner of a hair salon (Eau Claire's Salon) to help manage her employees (stylists) and their clients. The owner can add a list of stylists working at the salon, and for each stylist, add clients who see that stylist. The stylists have specific specialties, so each client is associated with only one stylist._

## Specifications:

| Specification | Example Input | Example Output |
| ------------- |:-------------:| -------------------:|
| Application creates instance of a Stylist object | owner submits form including stylist name and specialty | new Stylist object created as new row of stylists table in database |
| Application creates instance of a Client object | owner submits form including client name and stylist the client sees | new Client object created as new row of clients table in database |
| If owner visits '/' root route, the application displays a splash page with link to '/stylists' to view list of stylists | user visits '/' route | application displays homepage |
| If owner visits '/stylists' route, applications displays all stylists in database, each clickable to view details about the stylist and all clients that see the stylist | owner visits '/stylists' route | application displays list of stylists |
| If owner clicks "add new stylist" link at '/stylists', the application redirects to a form ('/stylists/new') for adding a new stylist | user clicks "add new stylist" | the application redirects to new stylist form |
| If owner submits the new stylist form, the application adds the new stylist to the stylists table of the michelle_morin database and redirects to '/stylists' | owner submits new stylist form | the application adds new stylist to correct database table and redirects to page displaying all stylists working at the salon |
| If owner visits '/stylists/{id}', the application displays a list of clients belonging to a specific stylist | owner clicks on specific stylist in list at '/stylists' | the application redirects to '/stylists/{id}' to display details for that stylist and all clients for that stylist |
| Owner can add clients to a specific stylists' list of clients | owner clicks "add new client" on '/stylists/{id}' page | the application redirects to a form for adding a new client |
| If the owner submits the new client form, the client is added as a new row of the clients table | owner submits form at '/clients/new' | application adds new client to list of clients associated with specific stylist, and creates new client row in clients table of michelle_morin database |
| The owner can delete stylists that no longer work at the salon. It is assumed that clients of that stylist will follow the stylist to another salon, and thus deleting a stylist also deletes all associated clients | owner selects "delete stylist" option on '/stylists/{id}' then confirms deletion | application deletes stylist and all clients associated with that stylist from the database |
| The owner can delete specific client from salon's list of clientele | owner selects "delete client" option on client details page ('/clients/{id}') then confirms deletion | application removes client from clients table of database |
| The owner can edit detais for a particular stylist | owner selects 'EDIT DETAILS' button on '/stylists/{id}' page | application redirects to form for editing stylist details, and updates values for stylist properties when form is submitted |
| A user can add appointments for a particular stylist | user selects 'SCHEDULE APPOINTMENT' link on '/stylists' page | application redirects to a form for scheduling an appointment with a particular stylist |
| When user submits the new appointment form, a new Appointment object is saved as a new row of the appointments table of the michelle_morin database and appointment details are displayed on corresponding stylist's details page | user submits new appointment form | new appointment saved in database and appointment details displayed on '/stylists/{id}' page |
| Application redirects to error page when user inputs appointment date in invalid format and/or does not complete all form fields of new appointment form | user enters date in format MM-DD-YYYY rather than MM/DD/YYYY | the application redirects to '/Appointments/Error' and displays error message |
| Application redirects to error page when user enters appointment date and/or time that is unavailable for a selected stylist | user enters "04/05/2020" and "1:00 PM", and Appointments table inclues an appointment for that stylist on 04/05/2020 at 1:00 PM | the application redirects to 'Appointments/Error' and displays error message "please select another date and/or time" |

## Setup/Installation Requirements

### Install .NET Core

#### on macOS:
* _[Click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.106-macos-x64-installer) to download a .NET Core SDK from Microsoft Corp._
* _Open the file (this will launch an installer which will walk you through installation steps. Use the default settings the installer suggests.)_

#### on Windows:
* _[Click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.203-windows-x64-installer) to download the 64-bit .NET Core SDK from Microsoft Corp._
* _Open the .exe file and follow the steps provided by the installer for your OS._

#### Install dotnet script
_Enter the command ``dotnet tool install -g dotnet-script`` in Terminal (macOS) or PowerShell (Windows)._

### Install MySQL and MySQL Workbench

#### on macOS:
_Download the MySQL Community Server DMG File [here](https://dev.mysql.com/downloads/file/?id=484914). Follow along with the installer until you reach the configuration page. Once you've reached Configuration, set the following options (or user default if not specified):_
* use legacy password encryption
* set password (and change the password field in appsettings.json file of this repository to match your password)
* click finish
* open Terminal and enter the command ``echo 'export PATH="/usr/local/mysql/bin:$PATH"' >> ~/.bash_profile`` if using Git Bash.
* Verify MySQL installation by opening Terminal and entering the command ``mysql -uroot -p{your password here, omitted brackets}``. If you gain access to the MySQL command line, installation is complete. An error (e.g., -bash: mysql: command not found) indicates something went wrong.

_Download MySQL Workbench DMG file [here](https://dev.mysql.com/downloads/file/?id=484391). Install MySQL Workbench to Applications folder. Open MySQL Workbench and select Local instance 3306 server, then enter the password you set. If it connects, you're all set._

#### on Windows:
_Download the MySQL Web Installer [here](https://dev.mysql.com/downloads/file/?id=484919) and follow along with the installer. Click "Yes" if prompted to update, and accept license terms._
* Choose Custom setup type
* When prompted to Select Products and Features, choose the following: MySQL Server (Will be under MySQL Servers) and MySQL Workbench (Will be under Applications)
* Select Next, then Execute. Wait for download and installation (can take a few minutes)
* Advance through Configuration as follows:
  - High Availability set to Standalone.
  - Defaults are OK under Type and Networking.
  - Authentication Method set to Use Legacy Authentication Method.
  - Set password to epicodus. You can use your own if you want but epicodus will be assumed in the lessons.
  - Unselect Configure MySQL Server as a Windows Service.
* Complete installation process

_Add the MySQL environment variable to the System PATH. Instructions for Windows 10:_
* Open the Control Panel and visit _System > Advanced System Settings > Environment Variables..._
* Select _PATH..._, click _Edit..._, then _Add_.
* Add the exact location of your MySQL installation and click _OK_. (This location is likely C:\Program Files\MySQL\MySQL Server 8.0\bin, but may differ depending on your specific installation.)
* Verify installation by opening Windows PowerShell and entering the command ``mysql -uroot -p{your password here, omitted brackets}``. It's working correctly if you gain access to the MySQL command line. Exit MySQL by entering the command ``exit``.
* Open MySQL Workbench and select Local instance 3306 server (may be named differently). Enter the password you set, and if it connects, you're all set.

### Clone this repository

_Enter the following commands in Terminal (macOS) or PowerShell (Windows):_
* ``cd desktop``
* ``git clone https://github.com/michelle-morin/HairSalon.Solution``
* ``cd HairSalon.Solution``

_Confirm that you have navigated to the HairSalon.Solution directory (e.g., by entering the command_ ``pwd`` _in Terminal)._

_Recreate the ``michelle_morin`` database using the following MySQL commands (in Terminal on macOS or PowerShell on Windows):_
* CREATE DATABASE michelle_morin;
* USE michelle_morin;
* CREATE TABLE `michelle_morin`.`stylists` (
  `StylistId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(255) NULL,
  `Specialty` VARCHAR(255) NULL,
  PRIMARY KEY (`StylistId`));
* CREATE TABLE `michelle_morin`.`clients` (
  `ClientId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(255) NULL,
  `Notes` varchar(255) DEFAULT NULL,
  `StylistId` INT NULL DEFAULT 0,
  PRIMARY KEY (`ClientId`));
* CREATE TABLE `michelle_morin`.`appointments` (
  `AppointmentId` INT NOT NULL AUTO_INCREMENT,
  `Date` VARCHAR(255) NULL,
  `Time` VARCHAR(255) NULL,
  `Notes` VARCHAR(255) NULL,
  `StylistId` INT NULL DEFAULT 0,
  PRIMARY KEY (`AppointmentId`));

_Run this application by entering the following command in Terminal (macOS) or PowerShell (Windows):_
* ``cd HairSalon``
* ``dotnet restore``
* ``dotnet build``
* ``dotnet run`` or ``dotnet watch run``

_To view/edit the source code of this application, open the contents of the HairSalon.Solution directory in a text editor or IDE of your choice (e.g., to open all contents of the directory in Visual Studio Code on macOS, enter the command_ ``code .`` _in Terminal)._

## Technologies Used
* _Git_
* _HTML_
* _CSS_
* _C#_
* _.NET Core 2.2_
* _ASP.NET Core MVC (version 2.2)_
* _Razor_
* _dotnet script_
* _MySQL_
* _MySQL Workbench_
* _Entity Framework Core 2.2_

### License

*This webpage is licensed under the MIT license.*

Copyright (c) 2020 **_Michelle Morin_**
