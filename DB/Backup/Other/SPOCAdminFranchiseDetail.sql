
CREATE TABLE [dbo].[SPOCAdminFranchiseDetail](
    [SPOCAdminId] [int] NOT NULL,
    [FranchiseId] [int] NOT NULL,
	[SPFAStatus] [int] NULL,
	[SPFACreatedBy] [int] NULL,
	[SPFACreatedOn] [datetime] NULL,
	[SPFAUpdatedBy] [int] NULL,
	[SPFAUpdatedOn] [datetime] NULL
)
GO


ALTER Procedure [dbo].[tb_SPOCAdminFranchiseDetail]
(
@QueryType int=1,
@SPOCAdminId int=0,
@FranchiseId int=0,
@SPFACreatedBy int=0
) 
AS
 BEGIN
    IF(@QueryType=1)
	  BEGIN 
		 IF NOT EXISTS(SELECT 1 FROM SPOCAdminFranchiseDetail WHERE FranchiseId=@FranchiseId )
			 BEGIN
				INSERT INTO [SPOCAdminFranchiseDetail] (SPOCAdminId,FranchiseId,SPFAStatus,SPFACreatedBy,SPFACreatedOn)
				VALUES (@SPOCAdminId,@FranchiseId,1,@SPFACreatedBy,GETDATE())
			 END
	     ELSE
		   BEGIN
				UPDATE [SPOCAdminFranchiseDetail] 
				   SET SPOCAdminId = @SPOCAdminId,
					   SPFAStatus=1,
					   SPFAUpdatedBy=@SPFACreatedBy,
					   SPFAUpdatedOn = GetDate()
					WHERE FranchiseId = @FranchiseId
			 END
      END

  IF(@QueryType=2)
	  BEGIN 
	    UPDATE SPOCAdminFranchiseDetail SET [SPFAStatus]=0 , SPOCAdminId=0,  SPFAUpdatedBy=@SPFACreatedBy, SPFAUpdatedOn = GetDate()
		WHERE SPOCAdminId=@SPOCAdminId
     END

   IF(@QueryType=3)
	  BEGIN 
	     SELECT a.FranchiseId, FranchiseName,(CASE WHEN ISNULL(b.FranchiseId,0) = 0 THEN 'false' ELSE 'true' END) as Checked
		 FROM FranchiseDetail a
		      LEFT OUTER JOIN SPOCAdminFranchiseDetail b ON (a.FranchiseId=b.FranchiseId AND b.SPFAStatus=1 AND b.SPOCAdminId=@SPOCAdminId)
		 WHERE a.FranchiseStatus=1 AND a.FranchiseId NOT IN
		 (
		    SELECT FranchiseId FROM SPOCAdminFranchiseDetail WHERE SPOCAdminId != @SPOCAdminId AND SPOCAdminId != 0
		 )
      END
 END
GO


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
GO
ALTER Procedure [dbo].[tb_FranchiseDetail]
(
@QueryType int=1,
@FranchiseId int=0,
@UserId int=0,
@FranchiseName varchar(150)='',
@Address1 varchar(1000)='',
@Address2 varchar(1000)='',
@Area varchar(100)='',
@Pincode varchar(10)='',
@City varchar(100)='',
@State varchar(100)='',
@FranchisePhone1 varchar(12)='',
@FranchisePhone2 varchar(12)='',
@FranchiseEmail varchar(100)='',
@FranchiseStatus int=0,
@FranchiseCreatedBy int=0
)
 AS
  BEGIN
    IF(@QueryType=1)
	  BEGIN 
	    SELECT @FranchiseId=ISNULL(MAX(FranchiseId),0)+1   FROM FranchiseDetail 
	    INSERT INTO FranchiseDetail(FranchiseId,FranchiseName,Address1,Address2,Area,Pincode,City,State,FranchisePhone1,FranchisePhone2,FranchiseEmail,FranchiseStatus,FranchiseCreatedBy,FranchiseCreatedOn)
            VALUES( @FranchiseId,@FranchiseName,@Address1,@Address2,@Area,@Pincode,@City,@State,@FranchisePhone1,@FranchisePhone2,@FranchiseEmail,@FranchiseStatus,@FranchiseCreatedBy, GetDate())
       INSERT INTO [FranchiseUserDetail] (FranchiseId,UserId)
	        VALUES (@FranchiseId,@UserId)
	 END
   
   IF(@QueryType=2) 
      BEGIN 
	   UPDATE FranchiseDetail SET 
				FranchiseName=(CASE WHEN  @FranchiseName != '' THEN @FranchiseName ELSE FranchiseName END),
				Address1=(CASE WHEN  @Address1 != '' THEN @Address1 ELSE Address1 END),
				Address2=(CASE WHEN  @Address2 != '' THEN @Address2 ELSE Address2 END),
				Area=(CASE WHEN  @Area != '' THEN @Area ELSE Area END),
				Pincode=(CASE WHEN  @Pincode != '' THEN @Pincode ELSE Pincode END),
				City=(CASE WHEN  @City != '' THEN @City ELSE City END),
				State=(CASE WHEN  @State != '' THEN @State ELSE State END),
				FranchisePhone1=(CASE WHEN  @FranchisePhone1 != '' THEN @FranchisePhone1 ELSE FranchisePhone1 END),
				FranchisePhone2=(CASE WHEN  @FranchisePhone2 != '' THEN @FranchisePhone2 ELSE FranchisePhone2 END),
				FranchiseEmail=(CASE WHEN  @FranchiseEmail != '' THEN @FranchiseEmail ELSE FranchiseEmail END),
				FranchiseUpdatedBy=(CASE WHEN  @FranchiseCreatedBy != 0 THEN @FranchiseCreatedBy ELSE FranchiseUpdatedBy END),
				FranchiseUpdatedOn=GetDate()
		WHERE  FranchiseId=@FranchiseId
	   SELECT *   FROM FranchiseDetail  WHERE FranchiseId=@FranchiseId
   END

 
    IF(@QueryType =3)
	  BEGIN
         SELECT * FROM FranchiseDetail  WHERE FranchiseId=@FranchiseId
      END

	  IF(@QueryType=31)
     BEGIN
		 SELECT a.*
		 FROM UserDetail a 
		 INNER JOIN  FranchiseUserDetail b on (a.UserId=b.UserId)
		 INNER JOIN FranchiseDetail  c on (b.FranchiseId =c.FranchiseId)
		 WHERE c.FranchiseId=@FranchiseId AND a.UserType=4
	 END
	  
	IF(@QueryType=4)
     BEGIN
		 SELECT a.FranchiseId, a.FranchiseName, c.Firstname, c.Lastname, c.Username, a.Area, a.City, a.State,a.FranchiseStatus,
		 (SELECT COUNT(1) FROM FranchiseUserDetail d
		 INNER JOIN UserDetail e on (d.UserId =e.UserId)
		 WHERE d.FranchiseId=a.FranchiseId AND e.Status=1) as TotalActiveUser
		 FROM FranchiseDetail a 
		 INNER JOIN  FranchiseUserDetail b on (a.FranchiseId=b.FranchiseId)
		 INNER JOIN UserDetail c on (b.UserId =c.UserId)
		 WHERE FranchiseStatus in (0,1) AND c.UserType=3
	 END

  IF(@QueryType=5)
     BEGIN
		 Update FranchiseDetail SET FranchiseStatus=@FranchiseStatus,  FranchiseUpdatedBy=@FranchiseCreatedBy, FranchiseUpdatedOn=GetDate() WHERE FranchiseId=@FranchiseId
    END
END
GO

