DROP DATABASE Factory;

CREATE DATABASE Factory
GO
use Factory;


CREATE TABLE Employee(
Fname nvarchar(50),
Lname nvarchar(50),
Balance float,
salary float,
ID int IDENTITY(1,1) ,
userName nvarchar(50) UNIQUE,
password nvarchar(50),
Bdata DATE, 
Jop_title nvarchar(50) not null,
NationalId char(14),
Gender char(1),
Address nvarchar(50),
Religion nvarchar(50),
Status char(1),
PRIMARY KEY (ID)
);


CREATE TABLE Machine(
Name nvarchar(20),
ID int  IDENTITY(1,1), /*Should it be string or number?*/
Start_date DATE,
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
name nvarchar(20),
ID int IDENTITY(1,1),
Location nvarchar(50),
Supervisor_id int,
PRIMARY KEY(ID),
FOREIGN KEY (Supervisor_id) REFERENCES Employee
	ON DELETE NO ACTION
	ON UPDATE NO ACTION,
)



CREATE TABLE Line_has_machine(
Line_id int,
machine_id int
PRIMARY KEY(Line_id, machine_id),
FOREIGN KEY (Line_id) REFERENCES Production_line
	ON DELETE CASCADE
	ON UPDATE CASCADE,

FOREIGN KEY (machine_id) REFERENCES Machine
	ON DELETE CASCADE
	ON UPDATE CASCADE,

)


CREATE TABLE Product(
ID int,
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


CREATE TABLE msg (
msgID int IDENTITY(1,1),
senderId int,
msg nvarchar(MAX),
primary key(msgID),
)

create table msg_to
(
msgID int,
receiverId int,
primary key(msgID,receiverID),
)








