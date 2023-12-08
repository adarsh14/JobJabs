CREATE procedure [dbo].[Authenication_User]
(
@QueryType int=1,
@UserName varchar(12)='',
@Password varchar(500)=''
)
as
BEGIN
    IF(@QueryType=1) --- Check if Username and Password exists
      BEGIN
	    IF EXISTS (SELECT 1 FROM [UserDetail] WHERE UserName=@UserName AND Password=@Password And Status=1 )
	      BEGIN
		      SELECT 1 As LoginStatus,* FROM [UserDetail] WHERE UserName=@UserName AND Password=@Password And Status=1 
		 END
	   ELSE
	     BEGIN
		     SELECT 2 As LoginStatus
		 END
      END
END

