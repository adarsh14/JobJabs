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

	  IF(@QueryType=32)
     BEGIN
		 SELECT a.*
		 FROM FranchiseDetail a 
		 INNER JOIN  FranchiseUserDetail b on (a.FranchiseId=b.FranchiseId)
		 WHERE b.UserId=@UserId
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
		Update FranchiseDetail SET FranchiseStatus=@FranchiseStatus,  FranchiseUpdatedBy=@FranchiseCreatedBy, FranchiseUpdatedOn=GetDate() 
		WHERE FranchiseId=@FranchiseId
		SELECT TOP 1 @UserId=a.UserId FROM  FranchiseUserDetail a INNER JOIN UserDetail b on (a.UserId =b.UserId)
		WHERE FranchiseId=@FranchiseId AND b.UserType=3
		Update UserDetail SET Status=1,  UpdatedBy=@FranchiseCreatedBy, UpdatedOn=GetDate() WHERE UserId=@UserId
    END
END

