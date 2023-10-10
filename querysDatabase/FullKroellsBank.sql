CREATE DATABASE Kroells_Bank;

CREATE TABLE Cards (
    Card_Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Card_Nr VARCHAR(16) NOT NULL,
    Expire_Date date NOT NULL,
    CVV smallint NOT NULL,
    Client_Name Varchar(50) NOT NULL,
	Pin smallint NOT NULL,
	Spending_Limit int
);

CREATE TABLE Accounts(
	Account_Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Balance int NOT NULL,
	Card_Id int NOT NULL,
	FOREIGN KEY (Card_Id) REFERENCES Cards(Card_Id)
);

CREATE TABLE Transactions(
	Transaction_Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Amount int NOT NULL,
	Date_Time DateTime NOT NULL,
	Account_Id int NOT NULL,
	FOREIGN KEY (Account_Id) REFERENCES Accounts(Account_Id)
);

CREATE TABLE Clients(
	Client_Id int IDENTITY(1,1) PRIMARY KEY,
	Client_Name Varchar(50) NOT NULL,
	Username Varchar(50),
	PasswordHashed Varchar(255)
);

CREATE TABLE Client_Account(
	Client_Account_Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Client_Id int NOT NULL,
	Account_Id int NOT NULL,
	FOREIGN KEY (Client_Id) REFERENCES Clients(Client_Id),
	FOREIGN KEY (Account_Id) REFERENCES Accounts(Account_Id)
);

CREATE TABLE Addresses(
	Address_Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Zip_Code int NOT NULL,
	City Varchar(30) NOT NULL,
	Street Varchar(40) NOT NULL,
	House_Nr int NOT NULL
);

CREATE TABLE Employees(
	Employee_Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Position Varchar(30) NOT NULL,
	Username Varchar(50) NOT NULL,
	PasswordHashed Varchar(255) NOT NULL
);

CREATE TABLE CPRs(
	CPR_Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Client_Id int NOT NULL,
	Address_Id int NOT NULL,
	Employee_Id int NOT NULL,
	CPR_Nr Varchar(10) NOT NULL,
	FOREIGN KEY (Client_Id) REFERENCES Clients(Client_Id),
	FOREIGN KEY (Address_Id) REFERENCES Addresses(Address_Id),
	FOREIGN KEY (Employee_Id) REFERENCES Employees(Employee_Id)
);

CREATE TABLE Loans(
	Loan_Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Client_Id int NOT NULL,
	APR tinyint NOT NULL,
	Amount int NOT NULL,
	FOREIGN KEY (Client_Id) REFERENCES Clients(Client_Id)
);

CREATE TABLE Jobs(
	Job_Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Income int NOT NULL,
	Job_Name varchar(30) NOT NULL
);

CREATE TABLE Client_Job(
	Client_Job_Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Client_Id int NOT NULL,
	Job_Id int NOT NULL,
	FOREIGN KEY (Client_Id) REFERENCES Clients(Client_Id),
	FOREIGN KEY (Job_Id) REFERENCES Jobs(Job_Id)
);

-- Inserting data into tables
INSERT INTO Cards(Card_Nr, Expire_Date, CVV, Client_Name, Pin, Spending_Limit) 
VALUES ('2138432356321358', '2023-12-31', 123, 'Bob Swagger', 1234, 5000),
       ('2575346873314567', '2023-12-31', 456, 'Jason Bourne', 5678, 7000),
       ('8462976538794563', '2023-12-31', 789, 'James Bond', 4321, 10000),
       ('1485496603485144', '2023-12-31', 246, 'Putin put out', 1357, 2000),
       ('8493849219349545', '2023-12-31', 975, 'Ligma balls', 2468, 3000);

INSERT INTO Accounts(Balance, Card_Id) 
VALUES (2000, 1),
       (5000, 2),
       (10000, 3),
       (1500, 4),
       (3000, 5);

INSERT INTO Transactions (Amount, Date_Time, Account_Id) 
VALUES (500, '2023-10-10 10:30:00', 1),
       (1000, '2023-10-10 11:00:00', 2),
       (200, '2023-10-10 12:00:00', 3),
       (700, '2023-10-10 13:30:00', 4),
       (150, '2023-10-10 14:30:00', 5);

INSERT INTO Clients (Client_Name, Username, PasswordHashed) 
VALUES ('Bob Swagger', 'BobSwagger', '$2a$11$xISoERh.237SWAixIsMTLuzEL8/jDWUPejlmx/xXElSi27aupsVlS'),
       ('Jason Bourne', 'JasonBourne', '$2a$11$61s0d3j6Renr5i8dertvNO7bJpC14iHezmp5Wzn8SV6e5NwpR5fqC'),
       ('James Bond', 'JamesBond', '$2a$11$MRn0M/rWiOJpq4e/67ekv.OCIjqhlXC1DLLx.Ez/AtPHW1vD3Xh3u'),
       ('Putin put out', 'PutinPutOut', '$2a$11$nGErVsidloW/hinzEnoBeOYesGAYeBIAjDxZ0Z5h7oRGpCYYDB4h2'),
       ('Ligma balls', 'LigmaBalls', '$2a$11$7LDOx1GYlBN45B9SRGOO.uywklQtcWlRv5mJyJG7k.HQcq65Qocli');

INSERT INTO Client_Account (Client_Id, Account_Id) 
VALUES (1, 1),
       (2, 2),
       (3, 3),
       (4, 4),
       (5, 5);

INSERT INTO Addresses (Zip_Code, City, Street, House_Nr) 
VALUES (12345, 'New York', 'Broadway', 123),
       (54321, 'Los Angeles', 'Hollywood Blvd', 456),
       (67890, 'Chicago', 'Michigan Ave', 789),
       (13579, 'Miami', 'Ocean Drive', 101),
       (24680, 'Las Vegas', 'Las Vegas Blvd', 111);

INSERT INTO Employees (Position, Username, PasswordHashed) 
VALUES ('Windows server specialist', 'YordanMitov', '$2a$11$xISoERh.237SWAixIsMTLuzEL8/jDWUPejlmx/xXElSi27aupsVlS'),
       ('Teller', 'ShazilShahid', '$2a$11$61s0d3j6Renr5i8dertvNO7bJpC14iHezmp5Wzn8SV6e5NwpR5fqC'),
       ('Manager', 'MagnusLund', '$2a$11$MRn0M/rWiOJpq4e/67ekv.OCIjqhlXC1DLLx.Ez/AtPHW1vD3Xh3u'),
       ('Security', 'AyoubLaroub', '$2a$11$nGErVsidloW/hinzEnoBeOYesGAYeBIAjDxZ0Z5h7oRGpCYYDB4h2'),
       ('Analyst', 'LarsHinge', '$2a$11$7LDOx1GYlBN45B9SRGOO.uywklQtcWlRv5mJyJG7k.HQcq65Qocli'),
       ('Accountant', 'MarcusWind', '$2a$11$7LDOx1GYlBN45B9SRGOO.uywklQtcWlRv5mJyJG7k.HQcq65Qocli'),
       ('CEO', 'MrKroell', '$2a$11$7LDOx1GYlBN45B9SRGOO.uywklQtcWlRv5mJyJG7k.HQcq65Qocli');

INSERT INTO CPRs (Client_Id, Address_Id, Employee_Id, CPR_Nr) 
VALUES (1, 1, 1, '1212121212'),
       (2, 2, 2, '1111111111'),
       (3, 3, 3, '1010101010'),
       (4, 4, 4, '0909090909'),
       (5, 5, 5, '0808080808');

INSERT INTO Loans (Client_Id, APR, Amount) 
VALUES (1, 5, 10000),
       (2, 7, 15000),
       (3, 4, 8000),
       (4, 8, 12000),
       (5, 6, 9000);

INSERT INTO Jobs (Income, Job_Name) 
VALUES (60000, 'Software Engineer'),
       (50000, 'Marketing Manager'),
       (70000, 'Financial Analyst'),
       (45000, 'Customer Representative'),
       (80000, 'Sales Manager');

INSERT INTO Client_Job (Client_Id, Job_Id) 
VALUES (1, 1),
       (2, 2),
       (3, 3),
       (4, 4),
       (5, 5);
