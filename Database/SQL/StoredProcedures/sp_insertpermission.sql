











CREATE    proc [dbo].[sp_insertpermission]
@UserName as varchar(50),
@strSetUp as varchar(8000),
@strEmployeeInformation as varchar(8000),
@strTimekeeping as varchar(8000),
@strpayroll as varchar(8000)


as

begin transaction
--insert into [User](UserName,[Password],FullName) values(@UserName,@Password,@FullName)

delete Permission where userName =@UserName
DECLARE @index int
DECLARE @length int
DECLARE @lstLen int
DECLARE @FormID VarChar(50)
SET @index=1
SET @lstLen=datalength(@strSetUp)
WHILE(@index<@lstLen)
BEGIN
	SET @length=CHARINDEX(',',@strSetUp,@index)-@index
	IF(@length<1)
	BEGIN
		SET @length=@lstLen-@index+1
	END
	SET @FormID=SUBSTRING(@strSetUp,@index,@length)
	insert into Permission(UserName,FormID) values(@UserName,@FormID)
	SET @index=@index+@length+1
END

SET @index=1
SET @lstLen=datalength(@strEmployeeInformation)
WHILE(@index<@lstLen)
BEGIN
	SET @length=CHARINDEX(',',@strEmployeeInformation,@index)-@index
	IF(@length<1)
	BEGIN
		SET @length=@lstLen-@index+1
	END
	SET @FormID=SUBSTRING(@strEmployeeInformation,@index,@length)
	insert into Permission(UserName,FormID) values(@UserName,@FormID)
	SET @index=@index+@length+1
END


SET @index=1
SET @lstLen=datalength(@strTimekeeping)
WHILE(@index<@lstLen)
BEGIN
	SET @length=CHARINDEX(',',@strTimekeeping,@index)-@index
	IF(@length<1)
	BEGIN
		SET @length=@lstLen-@index+1
	END
	SET @FormID=SUBSTRING(@strTimekeeping,@index,@length)
	insert into Permission(UserName,FormID) values(@UserName,@FormID)
	SET @index=@index+@length+1
END


SET @index=1
SET @lstLen=datalength(@strpayroll)
WHILE(@index<@lstLen)
BEGIN
	SET @length=CHARINDEX(',',@strpayroll,@index)-@index
	IF(@length<1)
	BEGIN
		SET @length=@lstLen-@index+1
	END
	SET @FormID=SUBSTRING(@strpayroll,@index,@length)
	insert into Permission(UserName,FormID) values(@UserName,@FormID)
	SET @index=@index+@length+1
END


commit transaction















GO
