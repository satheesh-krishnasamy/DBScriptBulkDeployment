drop procedure procedure1
GO
create procedure procedure1
as
begin
	select * from sys.tables with(nolock);
end
go