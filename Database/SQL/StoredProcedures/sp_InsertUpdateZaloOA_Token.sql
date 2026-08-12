create proc sp_InsertUpdateZaloOA_Token
@app_id bigint,
@access_token nvarchar(2048),
@refresh_token nvarchar(2048),
@expires_at_utc datetime,
@updated_at_utc datetime
as
begin
	insert ZaloOA_Token (app_id,access_token,refresh_token,expires_at_utc,created_at_utc,updated_at_utc)
	values (@app_id,@access_token,@refresh_token,@expires_at_utc,getdate(),@updated_at_utc)
end
GO
