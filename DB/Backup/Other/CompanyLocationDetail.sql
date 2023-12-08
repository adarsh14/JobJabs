Drop table CompanyLocationDetail


CREATE TABLE [dbo].[CompanyLocationDetail](
	[CompLocId] [int] NOT NULL,
	[CompanyId]  [int] NOT NULL,
	[LocationName] [varchar](150) NOT NULL,
	[HRName] [varchar](150) NULL,
	[DOB] [DateTime] Null,
	[CompLocPhone1] [varchar](12) NULL ,
	[CompLocPhone2] [varchar](12) NULL,
	[CompLocEmail] [varchar](100) NULL,
	[CompLocAddress1] [varchar](1000) NULL,
	[CompLocAddress2] [varchar](1000) NULL,
	[CompLocArea] [varchar](100) NULL,
	[CompLocPincode] [varchar](10) NULL,
	[CompLocCity]  [varchar](100) NULL,
	[CompLocState]  [varchar](100) NULL,
	[CompLocStatus] [int] NULL,
	[CompLocCreatedBy] [int] NULL,
	[CompLocCreatedOn] [datetime] NULL,
	[CompLocUpdatedBy] [int] NULL,
	[CompLocUpdatedOn] [datetime] NULL
)
GO


CREATE Procedure [dbo].[tb_CompanyLocationDetail]
(
@QueryType int=1,
@CompLocId int=0,
@CompanyId int=0,
@LocationName varchar(150)='',
@HRName varchar(150)='',
@DOB datetime='08/11/2017',
@CompLocPhone1 varchar(12)='',
@CompLocPhone2 varchar(12)='',
@CompLocEmail varchar(100)='',
@CompLocAddress1 varchar(1000)='',
@CompLocAddress2 varchar(1000)='',
@CompLocArea varchar(100)='',
@CompLocPincode varchar(10)='',
@CompLocCity varchar(100)='',
@CompLocState varchar(100)='',
@CompLocStatus int=0,
@CompLocCreatedBy int=0
)
 AS
  BEGIN
    IF(@QueryType=1)
	  BEGIN 
	    SELECT @CompLocId=ISNULL(MAX(CompLocId),0)+1   FROM CompanyLocationDetail 
	    INSERT INTO CompanyLocationDetail(CompLocId,CompanyId,LocationName,HRName,DOB,CompLocPhone1,CompLocPhone2,CompLocEmail,CompLocAddress1,CompLocAddress2,
		            CompLocArea, CompLocPincode, CompLocCity, CompLocState, CompLocStatus, CompLocCreatedBy, CompLocCreatedOn)
             VALUES(@CompLocId,@CompanyId,@LocationName,@HRName, @DOB, @CompLocPhone1, @CompLocPhone2, @CompLocEmail, @CompLocAddress1, @CompLocAddress2,
                    @CompLocArea, @CompLocPincode, @CompLocCity, @CompLocState, 0, @CompLocCreatedBy, GETDATE() )
	 END
   
   IF(@QueryType=2) 
      BEGIN 
	    UPDATE CompanyLocationDetail SET 
				LocationName=(CASE WHEN  @LocationName != '' THEN @LocationName ELSE LocationName END),
				HRName=(CASE WHEN  @HRName != '' THEN @HRName ELSE HRName END),
				DOB=@DOB,
				CompLocPhone1=(CASE WHEN  @CompLocPhone1 != '' THEN @CompLocPhone1 ELSE CompLocPhone1 END),
				CompLocPhone2=(CASE WHEN  @CompLocPhone2 != '' THEN @CompLocPhone2 ELSE CompLocPhone2 END),
				CompLocEmail=(CASE WHEN  @CompLocEmail != '' THEN @CompLocEmail ELSE CompLocEmail END),
				CompLocAddress1=(CASE WHEN  @CompLocAddress1 != '' THEN @CompLocAddress1 ELSE CompLocAddress1 END),
				CompLocAddress2=(CASE WHEN  @CompLocAddress2 != '' THEN @CompLocAddress2 ELSE CompLocAddress2 END),
				CompLocArea=(CASE WHEN  @CompLocArea != '' THEN @CompLocArea ELSE CompLocArea END),
				CompLocPincode=(CASE WHEN  @CompLocPincode != '' THEN @CompLocPincode ELSE CompLocPincode END),
				CompLocCity=(CASE WHEN  @CompLocCity != '' THEN @CompLocCity ELSE CompLocCity END),
				CompLocState=(CASE WHEN  @CompLocState != '' THEN @CompLocState ELSE CompLocState END),
				CompLocStatus=(CASE WHEN  @CompLocStatus != 0 THEN @CompLocStatus ELSE CompLocStatus END),
				CompLocUpdatedBy=(CASE WHEN  @CompLocCreatedBy != 0 THEN @CompLocCreatedBy ELSE CompLocUpdatedBy END),
				CompLocUpdatedOn=GETDATE()
		WHERE  CompLocId=@CompLocId
	   SELECT *   FROM CompanyLocationDetail  WHERE CompLocId=@CompLocId
   END

 
    IF(@QueryType =3)
	  BEGIN
         SELECT *   FROM CompanyLocationDetail  WHERE CompLocId=@CompLocId
      END

	
	  
	IF(@QueryType=4)
     BEGIN
		 SELECT *  
		 FROM  CompanyLocationDetail 
		 WHERE CompanyId=@CompanyId AND CompLocStatus in (0,1)
	 END

  IF(@QueryType=5)
     BEGIN
		 Update CompanyLocationDetail SET CompLocStatus=@CompLocStatus,  CompLocUpdatedBy=@CompLocCreatedBy, CompLocUpdatedOn=GETDATE() 
		 WHERE CompLocId=@CompLocId
    END
END
GO

ALTER Procedure [dbo].[tb_CompanyDetail]
(
@QueryType int=1,
@CompanyId int=0,
@CompanyName varchar(150)='',
@Address1 varchar(1000)='',
@Address2 varchar(1000)='',
@Area varchar(100)='',
@Pincode varchar(10)='',
@City varchar(100)='',
@State varchar(100)='',
@CompanyPhone1 varchar(12)='',
@CompanyPhone2 varchar(12)='',
@CompanyEmail varchar(100)='',
@CompanyStatus int=0,
@CompanyCreatedBy int=0
)
 AS
  BEGIN
    IF(@QueryType=1)
	  BEGIN 
	    SELECT @CompanyId=ISNULL(MAX(CompanyId),0)+1   FROM CompanyDetail 
	    INSERT INTO CompanyDetail(CompanyId,CompanyName,Address1,Address2,Area,Pincode,City,State,CompanyPhone1,CompanyPhone2,CompanyEmail,CompanyStatus,CompanyCreatedBy,CompanyCreatedOn)
            VALUES( @CompanyId,@CompanyName,@Address1,@Address2,@Area,@Pincode,@City,@State,@CompanyPhone1,@CompanyPhone2,@CompanyEmail,@CompanyStatus,@CompanyCreatedBy, GetDate())
   	 END
   
   IF(@QueryType=2) 
      BEGIN 
	   UPDATE CompanyDetail SET 
				CompanyName=(CASE WHEN  @CompanyName != '' THEN @CompanyName ELSE CompanyName END),
				Address1=(CASE WHEN  @Address1 != '' THEN @Address1 ELSE Address1 END),
				Address2=(CASE WHEN  @Address2 != '' THEN @Address2 ELSE Address2 END),
				Area=(CASE WHEN  @Area != '' THEN @Area ELSE Area END),
				Pincode=(CASE WHEN  @Pincode != '' THEN @Pincode ELSE Pincode END),
				City=(CASE WHEN  @City != '' THEN @City ELSE City END),
				State=(CASE WHEN  @State != '' THEN @State ELSE State END),
				CompanyPhone1=(CASE WHEN  @CompanyPhone1 != '' THEN @CompanyPhone1 ELSE CompanyPhone1 END),
				CompanyPhone2=(CASE WHEN  @CompanyPhone2 != '' THEN @CompanyPhone2 ELSE CompanyPhone2 END),
				CompanyEmail=(CASE WHEN  @CompanyEmail != '' THEN @CompanyEmail ELSE CompanyEmail END),
				CompanyUpdatedBy=(CASE WHEN  @CompanyCreatedBy != 0 THEN @CompanyCreatedBy ELSE CompanyUpdatedBy END),
				CompanyUpdatedOn=GetDate()
		WHERE  CompanyId=@CompanyId
	   SELECT *   FROM CompanyDetail  WHERE CompanyId=@CompanyId
   END

 
    IF(@QueryType =3)
	  BEGIN
         SELECT * FROM CompanyDetail  WHERE CompanyId=@CompanyId
      END

	IF(@QueryType=4)
     BEGIN
		 SELECT *, (SELECT COUNT(1) FROM CompanyLocationDetail WHERE CompanyId= a.CompanyId AND CompLocStatus=1) AS TotalLocation
		 FROM CompanyDetail a 
		 WHERE CompanyStatus in (0,1) 
	 END

  IF(@QueryType=5)
     BEGIN
		 Update CompanyDetail SET CompanyStatus=@CompanyStatus,  CompanyUpdatedBy=@CompanyCreatedBy, CompanyUpdatedOn=GetDate() WHERE CompanyId=@CompanyId
    END
END
GO

