ALTER PROCEDURE [dbo].[Get_JobPostDetail](
      @QueryType int =0,
	  @JobPostId int=0,
	  @FranchiseId int=0,
	  @RecruiterId int=0,
	  @SpocAdminId int=0,
	  @JobPostStatus int=0
	)
	AS
   BEGIN
	    IF(@QueryType=1)
	      BEGIN
			   IF( @RecruiterId > 0) 
				   BEGIN
					  SELECT * FROM VWJobPostDetail a INNER JOIN JobPostRecruiterDetail b ON (a.JobPostId=b.JobPostId AND b.JPRCStatus=1)
					  WHERE RecruiterId=@RecruiterId AND a.JobPostStatus=@JobPostStatus
					  SELECT * FROM [VWJPRecruiterCandidateDetail] WHERE RecruiterId=@RecruiterId AND JobPostStatus=@JobPostStatus
					END
			  ELSE IF( @FranchiseId > 0) 
				   BEGIN
					  SELECT * FROM VWJobPostDetail a INNER JOIN JobPostFranchiseDetail b ON (a.JobPostId=b.JobPostId AND b.JPFAStatus=1 )  
				      WHERE  FranchiseId=@FranchiseId AND JobPostStatus=@JobPostStatus
					  SELECT * FROM [VWJPFranchiseCandidateDetail] WHERE FranchiseId=@FranchiseId AND JobPostStatus=@JobPostStatus
				   END
			 ELSE IF( @SpocAdminId > 0) 
				   BEGIN
				      SELECT * FROM VWJobPostDetail WHERE JPCreatedBy=@SpocAdminId AND JobPostStatus=@JobPostStatus
					  SELECT * FROM [VWJPFranchiseCandidateDetail] WHERE JPCreatedBy=@SpocAdminId AND JobPostStatus=@JobPostStatus
				   END
			  ELSE IF( @JobPostStatus > 0) 
				   BEGIN
					   SELECT * FROM VWJobPostDetail a WHERE a.JobPostStatus=@JobPostStatus
					   SELECT * FROM [VWJobPostCandidateDetail] WHERE JobPostStatus=@JobPostStatus 
				   END
			  ELSE IF( @JobPostId > 0) 
				   BEGIN
					   SELECT * FROM VWJobPostDetail a WHERE a.JobPostId=@JobPostId
					   SELECT * FROM [VWJobPostCandidateDetail] WHERE JobPostId=@JobPostId
				   END
         END

		IF(@QueryType=2)
	      BEGIN
			   SELECT COUNT(1) FROM VWJobPostDetail a WHERE a.JPCreatedBy=@SpocAdminId AND a.JobPostStatus=@JobPostStatus  ---AND a.JPCANew > 0
         END
   END

   