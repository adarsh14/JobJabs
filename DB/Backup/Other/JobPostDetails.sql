   Create Table JobPostDetail ( 
JobPostId int null ,
ClientId int null ,
ClientLocationId int null ,
JobTitle varchar(250) null ,
JobLocation varchar(250) null ,
JobCTC varchar(100) null ,
CompanyDescription varchar(max) null ,
JobDescription varchar(max) null ,
Qualification varchar(max) null ,
AdditionalInformation varchar(max) null ,
Industry varchar(250) null ,
IndustryId int null ,
Functional varchar(250) null ,
FunctionalId int null ,
ExperienceLevel int null ,
TypeOfEmployment int null ,
JDFileName varchar(100) null ,
ChecklistFileName varchar(100) null ,
JobPostStatus int null ,
JPCreatedBy int null ,
JPCreatedOn datetime null ,
JPUpdatedBy int null ,
JPUpdatedOn datetime null 
)
GO

ALTER Procedure tb_JobPostDetail
( 
   @QueryType int=0,
	@JobPostId int =0,
	@ClientId int =0,
	@ClientLocationId int =0,
	@JobTitle varchar(250) ='',
	@JobLocation varchar(250) ='',
	@JobCTC varchar(100) ='' ,
	@CompanyDescription varchar(max) ='',
	@JobDescription varchar(max) ='',
	@Qualification varchar(max) ='',
	@AdditionalInformation varchar(max) ='',
	@Industry varchar(250) ='',
	@IndustryId int =0,
	@Functional varchar(250) ='',
	@FunctionalId int =0,
	@ExperienceLevel int =0,
	@TypeOfEmployment int =0,
	@JDFileName varchar(100) ='',
	@ChecklistFileName varchar(100) ='',
	@JobPostStatus int =0,
	@JPCreatedBy int =0
)
  AS 
BEGIN
    IF(@QueryType=1)
	  BEGIN 
	    SELECT @JobPostId=ISNULL(MAX(JobPostId),0) +1 FROM JobPostDetail
	    INSERT INTO JobPostDetail (JobPostId,ClientId,ClientLocationId,JobTitle,JobLocation,JobCTC, CompanyDescription,JobDescription,Qualification,
		AdditionalInformation,Industry,IndustryId,Functional,FunctionalId,ExperienceLevel,TypeOfEmployment,JDFileName,ChecklistFileName,
		JobPostStatus,JPCreatedBy,JPCreatedOn) 
             VALUES (@JobPostId,@ClientId,@ClientLocationId,@JobTitle,@JobLocation,@JobCTC,@CompanyDescription,@JobDescription,@Qualification,
			 @AdditionalInformation,@Industry,@IndustryId,@Functional,@FunctionalId,@ExperienceLevel,@TypeOfEmployment,@JDFileName,@ChecklistFileName,
			 @JobPostStatus,@JPCreatedBy,GETDATE()) 
		 SELECT *   FROM JobPostDetail  WHERE JobPostId=@JobPostId
   	 END
   
   IF(@QueryType=2) 
      BEGIN 
	    UPDATE JobPostDetail SET 
	          ClientId=@ClientId,
			  ClientLocationId=@ClientLocationId,
			  JobTitle=@JobTitle,
			  JobLocation=@JobLocation,
			  JobCTC=@JobCTC,
			  CompanyDescription=@CompanyDescription,
			  JobDescription=@JobDescription,
			  Qualification=@Qualification,
			  AdditionalInformation=@AdditionalInformation,
			  Industry=@Industry,
			  IndustryId=@IndustryId,
			  Functional=@Functional,
			  FunctionalId=@FunctionalId,
			  ExperienceLevel=@ExperienceLevel,
			  TypeOfEmployment=@TypeOfEmployment,
			  JDFileName=@JDFileName,
			  ChecklistFileName=@ChecklistFileName,
			  JobPostStatus=@JobPostStatus,
			  JPUpdatedBy=@JPCreatedBy,
			  JPUpdatedOn=GETDATE()
       WHERE JobPostId=@JobPostId
	   SELECT *   FROM JobPostDetail  WHERE JobPostId=@JobPostId
   END

 
    IF(@QueryType =3)
	  BEGIN
         SELECT * FROM JobPostDetail  WHERE JobPostId=@JobPostId
      END

	IF(@QueryType=4)
     BEGIN
		 SELECT *, b.LocationName as ClientLocation, c.CompanyName as ClientName
		 --,(SELECT COUNT(1) FROM CompanyLocationDetail WHERE CompanyId= a.CompanyId AND CompLocStatus=1) AS TotalLocation
		 FROM JobPostDetail a 
		      INNER JOIN CompanyLocationDetail b on (a.ClientLocationId=b.CompLocId)
		      INNER JOIN CompanyDetail c on (b.CompanyId=c.CompanyId)
		 WHERE JobPostStatus in (0,1) 
	 END



  IF(@QueryType=5)
     BEGIN
		 Update JobPostDetail SET JobPostStatus=@JobPostStatus,  JPUpdatedBy=@JPCreatedBy, JPUpdatedOn=GetDate()  WHERE JobPostId=@JobPostId
    END
END
GO


CREATE TABLE [dbo].[JobPostFranchiseDetail](
    [JobPostId] [int] NOT NULL,
    [FranchiseId] [int] NOT NULL,
	[JPFAStatus] [int] NULL,
	[JPFACreatedBy] [int] NULL,
	[JPFACreatedOn] [datetime] NULL,
	[JPFAUpdatedBy] [int] NULL,
	[JPFAUpdatedOn] [datetime] NULL
)
GO


ALTER Procedure [dbo].[tb_JobPostFranchiseDetail]
(
@QueryType int=0,
@JobPostId int=0,
@FranchiseId int=0,
@JPFACreatedBy int=0
) 
AS
 BEGIN
    IF(@QueryType=1)
	  BEGIN 
		 IF NOT EXISTS(SELECT 1 FROM JobPostFranchiseDetail WHERE JobPostId= @JobPostId AND FranchiseId=@FranchiseId )
			 BEGIN
				INSERT INTO JobPostFranchiseDetail(JobPostId, FranchiseId, JPFAStatus, JPFACreatedBy,JPFACreatedOn)
				VALUES (@JobPostId, @FranchiseId, 1, @JPFACreatedBy,GETDATE())
			 END
	     ELSE
		   BEGIN
				UPDATE [JobPostFranchiseDetail] 
				   SET JPFAStatus=1,
					   JPFAUpdatedBy=@JPFACreatedBy,
					   JPFAUpdatedOn = GetDate()
			    WHERE  JobPostId= @JobPostId AND FranchiseId=@FranchiseId
			 END
      END

  IF(@QueryType=2)
	  BEGIN 
	    UPDATE JobPostFranchiseDetail SET [JPFAStatus]=0,  JPFAUpdatedBy=@JPFACreatedBy, JPFAUpdatedOn = GetDate()
		 WHERE JobPostId = @JobPostId
     END

   IF(@QueryType=3)
	  BEGIN 
	     SELECT a.FranchiseId, FranchiseName,(CASE WHEN ISNULL(b.FranchiseId,0) = 0 THEN 'false' ELSE 'true' END) as Checked
		 FROM FranchiseDetail a
		      LEFT OUTER JOIN JobPostFranchiseDetail b ON (a.FranchiseId=b.FranchiseId AND b.JPFAStatus=1 AND b.JobPostId=JobPostId)
		 WHERE a.FranchiseStatus=1 AND a.FranchiseId NOT IN
		 (
		    SELECT FranchiseId FROM JobPostFranchiseDetail WHERE JobPostId != @JobPostId AND JobPostId != 0
		 )
      END
 END
GO



CREATE TABLE [dbo].[JobPostRecruiterDetail](
    [JobPostId] [int] NOT NULL,
    [RecruiterId] [int] NOT NULL,
	[FranchiseId] [int] NOT NULL,
	[JPRCStatus] [int] NULL,
	[JPRCCreatedBy] [int] NULL,
	[JPRCCreatedOn] [datetime] NULL,
	[JPRCUpdatedBy] [int] NULL,
	[JPRCUpdatedOn] [datetime] NULL
)
GO


ALTER Procedure [dbo].[tb_JobPostRecruiterDetail]
(
@QueryType int=0,
@JobPostId int=0,
@RecruiterId int=0,
@FranchiseId int=0,
@JPRCCreatedBy int=0
) 
AS
 BEGIN
    IF(@QueryType=1)
	  BEGIN 
		 IF NOT EXISTS(SELECT 1 FROM JobPostRecruiterDetail WHERE JobPostId= @JobPostId AND RecruiterId=@RecruiterId )
			 BEGIN
				INSERT INTO JobPostRecruiterDetail(JobPostId,RecruiterId,FranchiseId,JPRCStatus,JPRCCreatedBy,JPRCCreatedOn)
				 VALUES(@JobPostId,@RecruiterId,@FranchiseId,1,@JPRCCreatedBy,GETDATE())
			 END
	     ELSE
		   BEGIN
				UPDATE [JobPostRecruiterDetail] 
				   SET JPRCStatus=1,
					   JPRCUpdatedBy=@JPRCCreatedBy,
					   JPRCUpdatedOn = GetDate()
			    WHERE  JobPostId= @JobPostId AND RecruiterId=@RecruiterId
			 END
      END

  IF(@QueryType=2)
	  BEGIN 
	    UPDATE JobPostRecruiterDetail SET [JPRCStatus]=0,  JPRCUpdatedBy=@JPRCCreatedBy, JPRCUpdatedOn = GetDate()
		 WHERE JobPostId = @JobPostId AND RecruiterId=@RecruiterId
     END

   IF(@QueryType=3)
	  BEGIN 
	     SELECT a.UserId, a.Firstname, a.LastName, (CASE WHEN ISNULL(c.FranchiseId,0) = 0 THEN 'false' ELSE 'true' END) as Checked
		 FROM UserDetail a
		      INNER JOIN FranchiseUserDetail b on (a.UserId = b.UserId AND b.FranchiseId = @FranchiseId)
		      LEFT OUTER JOIN JobPostRecruiterDetail c ON (a.UserId=c.RecruiterId  AND c.JPRCStatus=1 AND c.JobPostId=JobPostId)
		 WHERE a.Status=1 AND a.UserType=4 AND a.UserId NOT IN
		 (
		    SELECT RecruiterId FROM JobPostRecruiterDetail  WHERE JobPostId != @JobPostId AND JobPostId != 0
		 )
      END
 END
GO


