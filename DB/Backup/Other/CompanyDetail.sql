
CREATE TABLE [dbo].[CompanyDetail](
	[CompanyId] [int] NULL,
	[CompanyName] [varchar](150) NULL,
	[Address1] [varchar](1000) NULL,
	[Address2] [varchar](1000) NULL,
	[Area] [varchar](100) NULL,
	[Pincode] [varchar](10) NULL,
	[City]  [varchar](100) NULL,
	[State]  [varchar](100) NULL,
	[CompanyPhone1] [varchar](12) NULL ,
	[CompanyPhone2] [varchar](12) NULL,
	[CompanyEmail] [varchar](100) NULL,
	[CompanyStatus] [int] NULL,
	[CompanyCreatedBy] [int] NULL,
	[CompanyCreatedOn] [datetime] NULL,
	[CompanyUpdatedBy] [int] NULL,
	[CompanyUpdatedOn] [datetime] NULL
)
GO




CREATE Procedure [dbo].[tb_CompanyDetail]
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
		 SELECT *
		 FROM CompanyDetail a 
		 WHERE CompanyStatus in (0,1) 
	 END

  IF(@QueryType=5)
     BEGIN
		 Update CompanyDetail SET CompanyStatus=@CompanyStatus,  CompanyUpdatedBy=@CompanyCreatedBy, CompanyUpdatedOn=GetDate() WHERE CompanyId=@CompanyId
    END
END
GO


