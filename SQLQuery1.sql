DROP DATABASE Factory;

CREATE DATABASE Factory
GO
use Factory;


CREATE TABLE Employee(
ID int IDENTITY(1,1) ,
Fname nvarchar(14),
Lname nvarchar(14),
userName nvarchar(50) UNIQUE NOT NULL,
password nvarchar(50) NOT NULL,
Balance float,
salary float,
Bdata DATE, 
Jop_title nvarchar(50),
NationalId char(14),
Gender char(1),
Address nvarchar(50),
Religion nvarchar(50) DEFAULT 'N',
Status char(1) DEFAULT 'N',
PRIMARY KEY (ID)
);


CREATE TABLE Machine(
ID int  IDENTITY(1,1), 
Name nvarchar(20),
Start_date DATE DEFAULT GETDATE() ,
PRIMARY KEY(ID)
);



CREATE TABLE Works_on(
Machine_id int,
Emp_id int,
PRIMARY KEY (Machine_id, Emp_id),
FOREIGN KEY (Machine_id) REFERENCES  Machine
	ON DELETE CASCADE
	ON UPDATE CASCADE,
FOREIGN KEY (Emp_id) REFERENCES  Employee
	ON DELETE CASCADE
	ON UPDATE CASCADE,

);

CREATE TABLE Production_line(
ID int IDENTITY(1,1),
Name nvarchar(20),
Location nvarchar(50),
Supervisor_id int,
PRIMARY KEY(ID),
FOREIGN KEY (Supervisor_id) REFERENCES Employee
	ON DELETE NO ACTION
	ON UPDATE NO ACTION,
)



CREATE TABLE Line_has_machine(
Line_id int,
Machine_id int
PRIMARY KEY(Line_id, machine_id),
FOREIGN KEY (Line_id) REFERENCES Production_line
	ON DELETE CASCADE
	ON UPDATE CASCADE,

FOREIGN KEY (machine_id) REFERENCES Machine
	ON DELETE CASCADE
	ON UPDATE CASCADE,

)


CREATE TABLE Product(
ID int IDENTITY(1,1),
Name nvarchar(50),
cost real,
PRIMARY KEY(ID)
)



CREATE TABLE Produces(
Line_id int,
product_id int,
Daily_amount int,
PRIMARY KEY(Line_id, product_id),
FOREIGN KEY (Line_id) REFERENCES Production_line
	ON DELETE CASCADE
	ON UPDATE CASCADE,

FOREIGN KEY (product_id) REFERENCES Product
	ON DELETE CASCADE
	ON UPDATE CASCADE,
)


CREATE TABLE Msg (
MsgID int IDENTITY(1,1),
SenderId int,
Subject nvarchar(50),
Msg nvarchar(MAX),
primary key(msgID),
)

create table MsgTo
(
MsgID int,
ReceiverId int,
primary key(msgID,receiverID),
FOREIGN KEY (MsgID) REFERENCES Msg
	ON DELETE CASCADE
	ON UPDATE CASCADE,
)








