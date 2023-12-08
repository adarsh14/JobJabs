ALTER Procedure [dbo].[tb_UserDetail]
(
@QueryType int=1,
@UserId int=0,
@UserName varchar(50)='',
@Password varchar(500)='',
@Firstname varchar(100)='',
@Lastname varchar(100)='',
@Phone1 varchar(12)='',
@Phone2 varchar(12)='',
@Email varchar(100)='',
@GenderId int=0,
@UserType int=0,
@IsPasswordValidated int=0,
@Status int=0,
@CreatedBy int=0
)
 AS
  BEGIN
    IF(@QueryType=1)
	  BEGIN 
		   IF NOT EXISTS(SELECT 1 FROM UserDetail WHERE UserName=@UserName)
			 BEGIN
				SELECT @UserId=ISNULL(MAX(UserId),0)+1   FROM UserDetail 
				INSERT INTO UserDetail(UserId,UserName,Password,Firstname,Lastname,Phone1,Phone2,Email,GenderId,UserType,IsPasswordValidated,Status,CreatedBy,CreatedOn)
				Values(@UserId,@UserName,@Password,@Firstname,@Lastname,@Phone1,@Phone2,@Email,@GenderId,@UserType,0,0,@CreatedBy,GetDate())
				SELECT * FROM UserDetail  WHERE UserId=@UserId
			 END
		   ELSE
			BEGIN
			  SELECT 0 as UserId
			END
     END
   
   IF(@QueryType=2) 
      BEGIN 
	    UPDATE UserDetail SET 
				Firstname=(CASE WHEN  @Firstname != '' THEN @Firstname ELSE Firstname END),
				Lastname=(CASE WHEN  @Lastname != '' THEN @Lastname ELSE Lastname END),
				Phone1=(CASE WHEN  @Phone1 != '' THEN @Phone1 ELSE Phone1 END),
				Phone2=(CASE WHEN  @Phone2 != '' THEN @Phone2 ELSE Phone2 END),
				Email=(CASE WHEN  @Email != '' THEN @Email ELSE Email END),
				GenderId=(CASE WHEN  @GenderId != 0 THEN @GenderId ELSE GenderId END),
				UpdatedBy=(CASE WHEN  @CreatedBy != 0 THEN @CreatedBy ELSE UpdatedBy END),
				UpdatedOn=GetDate()
		WHERE  UserId=@UserId
	   SELECT *   FROM UserDetail  WHERE UserId=@UserId
   END

    IF(@QueryType=21) 
      BEGIN 
	    UPDATE UserDetail SET 
		       Password=@Password,
			   IsPasswordValidated=1
		WHERE  UserId=@UserId
   END
 
    IF(@QueryType =3)
	  BEGIN
         SELECT * FROM UserDetail WHERE UserId=@UserId
      END

	IF(@QueryType=4)
     BEGIN
		 SELECT *,
		     (SELECT COUNT(1) FROM SPOCAdminFranchiseDetail WHERE SPFAStatus=1 AND SPOCAdminId=UserDetail.UserId) as TotalAssignedFranchise
		 FROM UserDetail WHERE UserType=@UserType AND Status in (0,1)
	 END

  IF(@QueryType=5)
     BEGIN
		 Update UserDetail SET Status=@Status,  UpdatedBy=@CreatedBy, UpdatedOn=GetDate() WHERE UserId=@UserId
    END
END

