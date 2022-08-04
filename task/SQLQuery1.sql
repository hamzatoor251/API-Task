create table Student  (
	ID int ,
	Name varchar (100),
	Class varchar(100),
)
declare @id int 
select @id = 1
while @id >=1 and @id <= 4000
begin
    insert into student values(@id,'jack' + convert(varchar(5), @id), 'Web'+ convert(varchar(5), @id))
    select @id = @id + 1
end
select * from Student



drop table Student