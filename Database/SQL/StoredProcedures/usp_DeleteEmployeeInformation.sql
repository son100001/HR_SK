--exec usp_DeleteEmployeeInformation 'HT000015', 'admin'
--exec usp_DeleteEmployeeInformation N'C16682','admin'
--Delete User where Employee_ID = 'C16682'
CREATE proc [dbo].[usp_DeleteEmployeeInformation]
@Employee_ID nvarchar(Max),
@UserName nvarchar(50) = 'admin'
as
begin
	declare @ThongBao nvarchar(max), @sp_BangChuaMaNhanVien nvarchar(50), @i int, @CountTable int, @TableName nvarchar(100), @ScriptDelete nvarchar(500)
	declare @Table table (ID int identity(1,1), ColName nvarchar(50), TableName nvarchar(100), DATA_TYPE nvarchar(50),primary key (TableName))
	set @sp_BangChuaMaNhanVien = 'sp_BangChuaMaNhanVien'
	--Hàm kiểm tra xem nhân viên có hợp lệ không
	set @ThongBao = ''
	begin try
		begin transaction
		DECLARE @ErrorFlag INT = 0;
			insert into @Table (ColName, TableName, DATA_TYPE)
			Exec(@sp_BangChuaMaNhanVien)

			select @CountTable = count(TableName) from @Table

			set @i = 1
			While @i < @CountTable
			begin
				select @TableName = TableName from @Table where ID = @i
				set @ScriptDelete = 'Delete [' + @TableName + '] where Employee_ID = ''' + @Employee_ID + ''''
				print @ScriptDelete
				Exec (@ScriptDelete)
				set @i = @i + 1
			end
			
			select isnull(@ThongBao,'') as ThongBao
		commit transaction;
	end try
	begin catch
		rollback transaction;
		print 'Rollback completed: ' + error_message()
	end catch;
	
end


GO
