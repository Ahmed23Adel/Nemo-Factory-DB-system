use Factory go

create procedure h_viewAssignedMachines
@username nvarchar(50)
as
 select m.Name,m.ID,m.Start_date as Date,p.name as Line
 from Machine as m join Line_has_machine as lm on m.ID = lm.machine_id
 join Production_line as p on p.ID = lm.Line_id
 join Employee as sup on sup.ID = p.Supervisor_id
 where userName = @username
 go 
 
 create procedure h_getAllLines
 as
 select Name,p.ID as ID,Location,CONCAT(Fname,' ',Lname) as Supervisor 
 from production_line as p join employee as e on Supervisor_id=e.ID 
 go

 create procedure h_loadWorkerTranscript
@username nvarchar(50)
as
select CONCAT(e.Fname,' ',e.Lname) as Name, e.ID as ID, e.salary, e.balance,
m.Name as Machine, CONCAT(sup.Fname, ' ', sup.Lname) as Supervisor
from employee as e
join Works_on as w on e.ID = w.Emp_id
join Machine as m on m.ID = w.Machine_id
join Line_has_machine as l on l.machine_id = w.Machine_id
join Production_line as p on l.Line_id = p.ID
join Employee as sup on sup.ID = p.Supervisor_id
where e.userName = @username
go

create procedure h_getAssignedLines
@username nvarchar(50)
as
select Name,p.ID,Location
from Production_line as p , Employee as sup
where p.Supervisor_id = sup.ID and sup.userName =@username
go

create procedure h_getWorkersAndMachines
@username nvarchar(50)
as
select CONCAT(e.Fname, ' ', e.Lname)AS Name, e.ID as ID, m.Name as Machine
from Employee as e
join Works_on as w on e.ID = w.Emp_id
join Machine as m on m.ID = w.Machine_id
join Line_has_machine as lm on m.ID = lm.Machine_id
join Production_line as p on p.ID = lm.Line_id
join Employee as sup on sup.ID=p.Supervisor_id
where sup.username=@username
union
select CONCAT(e.Fname, ' ', e.Lname)AS Name, e.ID as ID, m.Name
from Employee as e  left join(Works_on as w join Machine as m on m.ID = w.Machine_id) on e.id = w.emp_id
where jop_title='W' and e.ID not  in (select Emp_id from Works_on where Emp_id = e.id)
order by m.Name desc
go

create procedure h_getAllSupervisors
 as
 select concat(fname,' ',lname) as name,ID from employee where jop_title='S'
GO

create procedure h_insertLine @name nvarchar(20),@location nvarchar(50),@supervisor int
as	
insert into production_line  values (@name,@location,@supervisor)
GO

create procedure h_deleteLine @lineId int
as					 
delete from production_line where ID=@lineId
GO				 
				 
create procedure h_deleteMachine @machineId int
as			
delete from machine where ID=@machineId
GO			

create procedure h_getMessages @username nvarchar(50)
as
select CONCAT(e.Fname, ' ', e.Lname) as Name,Subject,Msg
from MsgTo join msg on msgto.MsgID = Msg.MsgID join Employee as e on e.ID = Msg.SenderId , Employee as r
where r.userName = @username
go

create procedure h_getProduction @username nvarchar(50)
as					 
select l.Name, l.ID, prdct.Name as Prodcut, prds.Daily_amount as Amount
from Production_line as l
left join(Produces as prds join Product prdct on prdct.ID = prds.product_id) on l.ID = prds.Line_id
where Supervisor_id in ( select e.ID from Employee as e where e.userName=@username )
go

create procedure h_doesLineProduces @lineID int,@productID int
as
select count(*) as count from Produces where Line_id=@lineID and product_id=@productID
go

create procedure h_insertProduction @lineID int,@productID int,@amount int
as					 
insert into Produces values (@lineID,@productID,@amount)
GO		

create procedure h_updateProdcution @lineID int,@productID int,@amount int
as
update produces 
set Daily_amount=@amount
where Line_id = @lineID and product_id =@productID
go
				 
create procedure h_getLineNameAndID @username nvarchar(50)
as	
select p.Name, p.ID from Production_line as p join Employee as e on p.Supervisor_id = e.ID where e.userName =@username
GO

create procedure h_getAllProducts
as
select p.Name, p.ID from Product as p
go
