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
		 Update JobPostCandidateDetail SET JPCAStatus=@JPCAStatus,  JPCAUpdatedBy=@JPCACreatedBy, JPCAUpdatedOn=GETDATE()  
		 WHERE JPCAId=@JPCAId
		 EXECUTE [tb_JPCAStatusDetail] 5,@JPCAId,@JPCAStatus,@StatusDate
    END
 END

