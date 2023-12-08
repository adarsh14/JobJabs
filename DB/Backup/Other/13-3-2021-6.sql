ALTER PROCEDURE [dbo].[Get_JobPostDetail](
      @QueryType int =0,
	  @JobPostId int=0,
	  @FranchiseId int=0,
	  @RecruiterId int=0,
	  @SpocAdminId int=0,
	  @JobPostStatus int=0,
	  @JPCAStatus int=0
	)
	AS
   BEGIN
	    IF(@QueryType=1)
	      BEGIN
			   IF( @RecruiterId > 0) 
				   BEGIN
					  SELECT * FROM VWJobPostDetail a INNER JOIN JobPostRecruiterDetail b ON (a.JobPostId=b.JobPostId AND b.JPRCStatus=1)
					  WHERE RecruiterId=@RecruiterId AND a.JobPostStatus=@JobPostStatus
					  EXECUTE dbo.Get_JPRCDetailByStatusId @RecruiterId,@JobPostStatus, @JPCAStatus 
					END
			  ELSE IF( @FranchiseId > 0) 
				   BEGIN
					  SELECT * FROM VWJobPostDetail a INNER JOIN JobPostFranchiseDetail b ON (a.JobPostId=b.JobPostId AND b.JPFAStatus=1 )  
				      WHERE  FranchiseId=@FranchiseId AND JobPostStatus=@JobPostStatus
					  EXECUTE dbo.Get_JPFCDetailByStatusId @FranchiseId,@JobPostStatus, @JPCAStatus 
				   END
			 ELSE IF( @SpocAdminId > 0) 
				   BEGIN
				        SELECT * FROM VWJobPostDetail WHERE JPCreatedBy=@SpocAdminId AND JobPostStatus=@JobPostStatus
					    EXECUTE dbo.Get_JPSPCDetailByStatusId @SpocAdminId,@JobPostStatus, @JPCAStatus 
				   END
			  ELSE IF( @JobPostStatus > 0) 
				   BEGIN
					   SELECT * FROM VWJobPostDetail a WHERE a.JobPostStatus=@JobPostStatus
					  EXECUTE dbo.Get_JPSACDetailByStatusId @JobPostStatus, @JPCAStatus 
				   END
			  ELSE IF( @JobPostId > 0) 
				   BEGIN
					   SELECT * FROM VWJobPostDetail a WHERE a.JobPostId=@JobPostId
					   SELECT * FROM [VWJobPostCandidateDetail] WHERE JobPostId=@JobPostId
				   END
         END

		IF(@QueryType=2)
	      BEGIN
			   SELECT COUNT(1) FROM [VWJobPostCandidateDetail] a WHERE a.JPCreatedBy=@SpocAdminId AND a.JobPostStatus=1 AND a.CandidateAssigned > 0
         END
   END


