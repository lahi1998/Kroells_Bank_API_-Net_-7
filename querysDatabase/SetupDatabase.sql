Create Database Kroells_Bank;

CREATE TABLE Cards (
    Card_Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Card_Nr int NOT NULL,
    Expire_Date date NOT NULL,
    CVV smallint NOT NULL,
    Client_Name	Varchar(50) NOT NULL,
	Pin smallint NOT NULL,
	Spending_Limit int
);

Create Table Accounts(
	Account_Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Balance int NOT NULL,
	Card_Id int NOT NULL,

	FOREIGN KEY (Card_Id) REFERENCES Cards(Card_Id)
);

Create Table Transactions(
	Transaction_Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Amount int NOT NULL,
	Date_Time DateTime NOT NULL,
	Account_Id int NOT NULL,

	FOREIGN KEY (Account_Id) REFERENCES Accounts(Account_Id)
);

Create Table Clients(
	Client_Id int IDENTITY(1,1) PRIMARY KEY,
	Client_Name Varchar(50) NOT NULL,
	Username Varchar(50),
	PasswordHashed Varchar(255)
);

Create Table Client_Account(
	Client_Account_Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Client_Id int NOT NULL,
	Account_Id int NOT NULL,

	FOREIGN KEY (Client_Id) REFERENCES Clients(Client_Id),
	FOREIGN KEY (Account_Id) REFERENCES Accounts(Account_Id)
);

Create Table Addresses(
	Address_Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Zip_Code int NOT NULL,
	City Varchar(30) NOT NULL,
	Street Varchar(40) NOT NULL,
	House_Nr int NOT NULL
);

Create Table Employees(
	Employee_Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Position Varchar(30) NOT NULL,
		Username Varchar(50) NOT NULL,
	PasswordHashed Varchar(255) NOT NULL
);

Create Table CPRs(
	CPR_Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Client_Id int NOT NULL,
	Address_Id int NOT NULL,
	Employee_Id int NOT NULL,
	CPR_Nr int NOT NULL,

	FOREIGN KEY (Client_Id) REFERENCES Clients(Client_Id),
	FOREIGN KEY (Address_Id) REFERENCES Addresses(Address_Id),
	FOREIGN KEY (Employee_Id) REFERENCES Employees(Employee_Id)
);

Create Table Loans(
	Client_Account_Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Client_Id int NOT NULL,
	APR tinyint NOT NULL,
	Amount int NOT NULL

	FOREIGN KEY (Client_Id) REFERENCES Clients(Client_Id)
);

Create Table Job(
	Job_Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Income int NOT NULL,
	Job_Name varchar(30) NOT NULL
);

Create Table Client_Job(
	Client_Job_Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	CLient_Id int NOT NULL,
	Job_Id int NOT NULL,

	FOREIGN KEY (Client_Id) REFERENCES Clients(Client_Id),
	FOREIGN KEY (Job_Id) REFERENCES Job(Job_Id)
);