
 
 Create Table CandidateDetail
 ( 
CandidateId int null ,
FirstName varchar(100) null ,
LastName varchar(100) null ,
Location varchar(50) null ,
PhoneNumber varchar(15) null ,
Email varchar(50) null ,
Website varchar(100) null ,
CurrentPosition varchar(100) null ,
CurrentCompany varchar(100) null ,
TotalExperienceYear int null ,
TotalExperienceMonth int null ,
CurrentCTCCrore int null ,
CurrentCTCLakh int null ,
CurrentCTCThousand int null ,
NoticePeriod int null ,
ResumeFileName varchar(50),
CandidateStatus int null ,
CandidateCreatedBy int null ,
CandidateCreatedOn datetime null ,
CandidateUpdatedBy int null ,
CandidateUpdatedOn datetime null 
)
GO 

 ALTER Procedure tb_CandidateDetail
 ( 
    @QueryType int=0,
	@CandidateId int =0,
	@FirstName varchar(100) ='',
	@LastName varchar(100) ='',
	@Location varchar(50) ='',
	@PhoneNumber varchar(15) ='',
	@Email varchar(50) ='',
	@Website varchar(100) ='',
	@CurrentPosition varchar(100) ='',
	@CurrentCompany varchar(100) ='',
	@TotalExperienceYear int =0,
	@TotalExperienceMonth int =0,
	@CurrentCTCCrore int =0,
	@CurrentCTCLakh int =0,
	@CurrentCTCThousand int =0,
	@NoticePeriod int =0,
	@ResumeFileName varchar(50)='',
	@CandidateStatus int =0,
	@CandidateCreatedBy int =0
)
  AS 
BEGIN
    IF(@QueryType=1)
	  BEGIN 
	    SELECT @CandidateId=ISNULL(MAX(CandidateId),0) +1 FROM CandidateDetail
	   INSERT INTO CandidateDetail (CandidateId,FirstName,LastName,Location,PhoneNumber,Email,Website,CurrentPosition,CurrentCompany,TotalExperienceYear,TotalExperienceMonth,CurrentCTCCrore,CurrentCTCLakh,CurrentCTCThousand,NoticePeriod,ResumeFileName,CandidateStatus,CandidateCreatedBy,CandidateCreatedOn) 
       VALUES (@CandidateId,@FirstName,@LastName,@Location,@PhoneNumber,@Email,@Website,@CurrentPosition,@CurrentCompany,@TotalExperienceYear,@TotalExperienceMonth,@CurrentCTCCrore,@CurrentCTCLakh,@CurrentCTCThousand,@NoticePeriod,@ResumeFileName, 1,@CandidateCreatedBy,GETDATE()) 
   	  SELECT * FROM CandidateDetail WHERE CandidateId=@CandidateId
	END
   
   IF(@QueryType=2) 
      BEGIN 
	   UPDATE CandidateDetail SET 
	          FirstName=@FirstName,
	          LastName=@LastName,
			  Location=@Location,
			  PhoneNumber=@PhoneNumber, 
			  Email=@Email, 
			  Website=@Website, 
			  CurrentPosition=@CurrentPosition,
			  CurrentCompany=@CurrentCompany, 
			  TotalExperienceYear=@TotalExperienceYear,
			  TotalExperienceMonth=@TotalExperienceMonth,
			  CurrentCTCCrore=@CurrentCTCCrore,
			  CurrentCTCLakh=@CurrentCTCLakh,
			  CurrentCTCThousand=@CurrentCTCThousand,
			  NoticePeriod=@NoticePeriod,
			  CandidateUpdatedBy=@CandidateCreatedBy,
			  CandidateUpdatedOn=GETDATE()
       WHERE CandidateId=@CandidateId
	   SELECT *   FROM CandidateDetail  WHERE CandidateId=@CandidateId
   END

 
    IF(@QueryType =3)
	  BEGIN
         SELECT * FROM CandidateDetail  WHERE CandidateId=@CandidateId
      END

	IF(@QueryType=4)
     BEGIN
		 SELECT *
		 FROM CandidateDetail a 
		 WHERE CandidateStatus in (0,1) 
	 END

  IF(@QueryType=5)
     BEGIN
		 Update CandidateDetail SET CandidateStatus=@CandidateStatus,  CandidateUpdatedBy=@CandidateCreatedBy, CandidateUpdatedOn=GETDATE()   WHERE CandidateId=@CandidateId
    END
END
GO


 CREATE TABLE [dbo].[JobPostCandidateDetail](
    [JobPostId] [int] NOT NULL,
    [CandidateId] [int] NOT NULL,
	[RecruiterId]  [int] NULL,
    [FranchiseId]  [int] NULL,
	[JPCAStatus] [int] NULL,
	[JPCACreatedBy] [int] NULL,
	[JPCACreatedOn] [datetime] NULL,
	[JPCAUpdatedBy] [int] NULL,
	[JPCAUpdatedOn] [datetime] NULL
)
GO


ALTER Procedure [dbo].[tb_JobPostCandidateDetail]
(
@QueryType int=0,
@JobPostId int=0,
@CandidateId int=0,
@RecruiterId int=0,
@FranchiseId int=0,
@JPCAStatus int=0,
@JPCACreatedBy int=0
) 
AS
 BEGIN
    IF(@QueryType=1)
	  BEGIN 
		 IF NOT EXISTS(SELECT 1 FROM JobPostCandidateDetail WHERE JobPostId= @JobPostId AND CandidateId=@CandidateId AND RecruiterId = @RecruiterId AND FranchiseId=@FranchiseId)
			 BEGIN
				INSERT INTO JobPostCandidateDetail(JobPostId, CandidateId,RecruiterId, FranchiseId, JPCAStatus, JPCACreatedBy,JPCACreatedOn)
				VALUES (@JobPostId, @CandidateId, @RecruiterId, @FranchiseId, 0, @JPCACreatedBy,GETDATE())
			 END
	  END

 IF(@QueryType=4)
     BEGIN
		 SELECT *
		 FROM CandidateDetail a INNER JOIN JobPostCandidateDetail b on (a.CandidateId=b.CandidateId)
		 WHERE JobPostId=@JobPostId AND RecruiterId = @RecruiterId
	 END

  IF(@QueryType=41)
     BEGIN
		 SELECT *
		 FROM CandidateDetail a INNER JOIN JobPostCandidateDetail b on (a.CandidateId=b.CandidateId)
		 WHERE JobPostId=@JobPostId AND RecruiterId = @RecruiterId AND JPCAStatus=@JPCAStatus
	 END

  IF(@QueryType=5)
     BEGIN
		 Update JobPostCandidateDetail SET JPCAStatus=@JPCAStatus,  JPCAUpdatedBy=JPCACreatedBy, JPCAUpdatedOn=GETDATE()  
		 WHERE JobPostId= @JobPostId AND CandidateId=@CandidateId AND RecruiterId = @RecruiterId AND FranchiseId=@FranchiseId
    END
 END
GO