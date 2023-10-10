insert into Cards( Card_Nr, Expire_Date, CVV, Client_Name, Pin, Spending_Limit)
values (555555  ,'08/05/2006', 555, 'bob saget', 2626, 2000);

insert into Accounts(Balance, Card_Id)
values (200, 1);

koden er Kode1234!
insert into Clients(Client_Name, Username, PasswordHashed)
values ('bob saget', 'bobfagger', '$2a$11$XeefVJPVMJHlzMsTJ/0JI.cj0GwCe4cB96xhu.vr.JF1s5eZ5MF9C');

insert into Client_Account(Client_Id, Account_Id)
values (1, 1);

insert into Addresses(Post_Nr, City, Street, House_Nr)
values (2650, 'Hvidovre', 'Høvedstensvej', 18);

insert into Employees(Position, Username, PasswordHashed)
values ('position is dude', 'username123', 'password1234');

insert into CPRs(Client_Id, Address_Id, Employee_Id, CPR_Nr)
values (1, 1, 1, 1265984587);

insert into Job(Income, Job_Name)
values (1000000, 'Model');

insert into Loans(Client_Id, APR, Amount)
values (1, 2, 5000);

insert into Transactions(Amount, Date_Time, Account_Id)
values (1000, '08/05/2006 03:05:15', 1);

insert into Client_Job(CLient_Id, Job_Id)
values (1,1);


select * from Transactions;
select * from Accounts;

insert into Cards( Card_Nr, Expire_Date, CVV, Client_Name, Pin, Spending_Limit)
values (666  ,'08/05/2006', 555, 'bob baget', 2626, 2000);

insert into Accounts(Balance, Card_Id)
values (200, 2);

insert into Clients(Client_Name, Username, PasswordHashed)
values ('bob saget', 'bobsagger', '$2a$11$XeefVJPVMJHlzMsTJ/0JI.cj0GwCe4cB96xhu.vr.JF1s5eZ5MF9C');

insert into Client_Account(Client_Id, Account_Id)
values (2, 2);

insert into Addresses(Post_Nr, City, Street, House_Nr)
values (2650, 'Hvidovre', 'Høvedstensvej', 18);

insert into Employees(Position, Username, PasswordHashed)
values ('position is dude', 'username123', 'password1234');

insert into CPRs(Client_Id, Address_Id, Employee_Id, CPR_Nr)
values (2, 2, 2, 1235984587);

insert into Job(Income, Job_Name)
values (1000000, 'Model');

insert into Loans(Client_Id, APR, Amount)
values (2, 3, 5000);

insert into Transactions(Amount, Date_Time, Account_Id)
values (-1000, '08/05/2006 03:05:15', 2);

insert into Client_Job(CLient_Id, Job_Id)
values (2,2);