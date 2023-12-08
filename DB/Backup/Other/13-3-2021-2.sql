
        CREATE TABLE [dbo].[JPCAStatusDetail]
		(
			[JPCAId] [int] NOT NULL,
			[CandidateAssigned] [int] NULL DEFAULT 0,
			[CandidateAssignedDate] [DateTime] NULL,
            [ValidatedBySPOC] [int] NULL DEFAULT 0,
			[ValidatedBySPOCDate] [DateTime] NULL,
			[CandidateRejectedBySPOC] [int] NULL DEFAULT 0,
			[CandidateRejectedBySPOCDate] [DateTime] NULL,
            [ResumeSentToHR] [int] NULL DEFAULT 0,
			[ResumeSentToHRDate] [DateTime] NULL,
            [InterviewScheduled] [int] NULL DEFAULT 0,
			[InterviewScheduledDate] [DateTime] NULL,
            [SecondRoundSheduled] [int] NULL DEFAULT 0,
			[SecondRoundSheduledDate] [DateTime] NULL,
            [FinalRoundScheduled] [int] NULL DEFAULT 0,
			[FinalRoundScheduledDate][DateTime] NULL,
            [InterviewRejected] [int] NULL DEFAULT 0,
			[InterviewRejectedDate] [DateTime] NULL,
            [CandidateShortlisted] [int] NULL DEFAULT 0,
			[CandidateShortlistedDate] [DateTime] NULL,
            [CandidateSelected] [int] NULL DEFAULT 0,
			[CandidateSelectedDate] [DateTime] NULL,
            [DocumentationPending] [int] NULL DEFAULT 0,
			[DocumentationPendingDate] [DateTime] NULL,
            [CandidateJoined] [int] NULL DEFAULT 0,
			[CandidateJoinedDate] [DateTime] NULL,
            [CandidateNotJoined] [int] NULL DEFAULT 0,
			[CandidateNotJoinedDate] [DateTime] NULL,
			[CandidateBackOut] [int] NULL DEFAULT 0,
			[CandidateBackOutDate] [DateTime] NULL
        ) 
		GO

ALTER Procedure [dbo].[tb_JobPostCandidateDetail]
(
@QueryType int=0,
@JPCAId int=0,
@JobPostId int=0,
@CandidateId int=0,
@RecruiterId int=0,
@FranchiseId int=0,
@JPCAStatus int=0,
@JPCACreatedBy int=0,
@StatusDate DateTime= NULL
) 
AS
 BEGIN
    IF(@QueryType=1)
	  BEGIN 
		 IF NOT EXISTS(SELECT 1 FROM JobPostCandidateDetail WHERE JobPostId= @JobPostId AND CandidateId=@CandidateId AND RecruiterId = @RecruiterId AND FranchiseId=@FranchiseId)
			 BEGIN
			    SELECT @JPCAId = ISNULL(MAX(JPCAId),0)+ 1 FROM JobPostCandidateDetail 
				INSERT INTO JobPostCandidateDetail(JPCAId,JobPostId, CandidateId,RecruiterId, FranchiseId, JPCAStatus, JPCACreatedBy,JPCACreatedOn)
				VALUES (@JPCAId,@JobPostId, @CandidateId, @RecruiterId, @FranchiseId, 0, @JPCACreatedBy,GETDATE())
				 EXECUTE [tb_JPCAStatusDetail] 5,@JPCAId,@JPCAStatus,@StatusDate
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
	     SELECT @JPCAId = JPCAId FROM JobPostCandidateDetail 
		 WHERE JobPostId= @JobPostId AND CandidateId=@CandidateId AND RecruiterId = @RecruiterId AND FranchiseId=@FranchiseId
		 Update JobPostCandidateDetail SET JPCAStatus=@JPCAStatus,  JPCAUpdatedBy=JPCACreatedBy, JPCAUpdatedOn=GETDATE()  
		 WHERE JPCAId=@JPCAId
		 EXECUTE [tb_JPCAStatusDetail] 5,@JPCAId,@JPCAStatus,@StatusDate
    END
 END
GO

ALTER Procedure [dbo].[tb_JPCAStatusDetail]
(
@QueryType int=0,
@JPCAId int=0,
@JPCAStatus int=0,
@StatusDate DateTime= NULL
) 
AS
 BEGIN
    IF(@QueryType=1)
	  BEGIN 
		 INSERT INTO JPCAStatusDetail(JPCAId,CandidateAssigned,CandidateAssignedDate)
		 VALUES (@JPCAId,@JPCAStatus,@StatusDate)
	  END

  IF(@QueryType=5)
     BEGIN
        
		 IF(@JPCAStatus=1)
			BEGIN 
			   UPDATE JPCAStatusDetail  SET  ValidatedBySPOC=1, ValidatedBySPOCDate=@StatusDate 
			   WHERE JPCAId=@JPCAId 
		   END

	    IF(@JPCAStatus=2)
		   BEGIN 
		       UPDATE JPCAStatusDetail SET CandidateRejectedBySPOC=1, CandidateRejectedBySPOCDate=@StatusDate 
			   WHERE JPCAId=@JPCAId 
		END

	   IF(@JPCAStatus=3)
		   BEGIN 
		       UPDATE JPCAStatusDetail SET ResumeSentToHR=1, ResumeSentToHRDate=@StatusDate
			   WHERE JPCAId=@JPCAId 
		   END

	   IF(@JPCAStatus=4)
		  BEGIN 
		       UPDATE JPCAStatusDetail SET InterviewScheduled=1, InterviewScheduledDate=@StatusDate
			   WHERE JPCAId=@JPCAId 
		  END

	   IF(@JPCAStatus=5)
		   BEGIN 
		        UPDATE JPCAStatusDetail SET SecondRoundSheduled=1,SecondRoundSheduledDate=@StatusDate
		        WHERE JPCAId=@JPCAId 
		   END

	   IF(@JPCAStatus=6)
		   BEGIN 
		        UPDATE JPCAStatusDetail	 SET FinalRoundScheduled=1, FinalRoundScheduledDate=@StatusDate
		        WHERE JPCAId=@JPCAId 
		   END

	   IF(@JPCAStatus=7)
		   BEGIN 
		        UPDATE JPCAStatusDetail	 SET InterviewRejected=1, InterviewRejectedDate=@StatusDate
		        WHERE JPCAId=@JPCAId 
		   END

	   IF(@JPCAStatus=8)
		  BEGIN 
		        UPDATE JPCAStatusDetail SET CandidateShortlisted=1, CandidateShortlistedDate=@StatusDate
		        WHERE JPCAId=@JPCAId 
		   END

	   IF(@JPCAStatus=9)
		  BEGIN 
		        UPDATE JPCAStatusDetail SET CandidateSelected=1, CandidateSelectedDate=@StatusDate
		        WHERE JPCAId=@JPCAId 
		  END

	   IF(@JPCAStatus=10)
		  BEGIN 
		        UPDATE JPCAStatusDetail SET DocumentationPending=1, DocumentationPendingDate=@StatusDate
		        WHERE JPCAId=@JPCAId 
		  END

	    IF(@JPCAStatus=11)
	  	   BEGIN 
		        UPDATE JPCAStatusDetail SET CandidateJoined=1, CandidateJoinedDate=@StatusDate
		        WHERE JPCAId=@JPCAId 
		   END

  	   IF(@JPCAStatus=12)
		   BEGIN 
		        UPDATE JPCAStatusDetail	 SET CandidateNotJoined=1, CandidateNotJoinedDate=@StatusDate
		        WHERE JPCAId=@JPCAId 
		   END

	    IF(@JPCAStatus=13)
		   BEGIN 
		       UPDATE JPCAStatusDetail SET CandidateBackOut=1, CandidateBackOutDate=@StatusDate
		       WHERE JPCAId=@JPCAId 
		   END

   END
 END
 GO

   INSERT INTO JPCAStatusDetail(JPCAId)
  SELECT JPCAId FROM JobPostCandidateDetail
  GO

    UPDATE im SET CandidateAssigned = 1, CandidateAssignedDate=JPCACreatedon
  FROM JPCAStatusDetail im JOIN JobPostCandidateDetail gm   ON im.JPCAId = gm.JPCAId 
  GO
  
  UPDATE im SET ValidatedBySPOC = 1, ValidatedBySPOCDate=JPCAUPdatedon
  FROM JPCAStatusDetail im JOIN JobPostCandidateDetail gm   ON im.JPCAId = gm.JPCAId 
  WHERE JPCAStatus=1
  GO

    
  UPDATE im SET CandidateRejectedBySPOC=1, CandidateRejectedBySPOCDate=JPCAUPdatedon
  FROM JPCAStatusDetail im JOIN JobPostCandidateDetail gm   ON im.JPCAId = gm.JPCAId 
  WHERE (JPCAStatus=2 or JPCAStatus=3)
  GO