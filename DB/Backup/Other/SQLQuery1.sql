ALTER PROCEDURE Get_JobTitleLocByUserType(
	@RecruiterId int=0,
    @FranchiseId int=0,
	@SpocAdminId int=0,
	@JobPostId int=0,
	@ClientId int=0
)
AS
  BEGIN
     IF(@RecruiterId > 0)
	   BEGIN
	      SELECT DISTINCT a.JobPostId as [Value],JobTitle as [Text] 
		  FROM JobPostDetail a
		       INNER JOIN JobPostRecruiterDetail b on (a.JobPostId=b.JobPostId)
		  WHERE b.RecruiterId=@RecruiterId  AND a.ClientId=(CASE WHEN @ClientId > 0 THEN @ClientId ELSE ClientId END)

		  SELECT DISTINCT JobLocation as StringValue, JobLocation as [Text] 
		  FROM JobPostDetail a
		       INNER JOIN JobPostRecruiterDetail b on (a.JobPostId=b.JobPostId)
		  WHERE b.RecruiterId=@RecruiterId  AND a.ClientId=(CASE WHEN @ClientId > 0 THEN @ClientId ELSE ClientId END)
	   END
	ELSE IF(@FranchiseId > 0)
	   BEGIN
	      SELECT DISTINCT a.JobPostId as [Value],JobTitle as [Text] 
		  FROM JobPostDetail a
		  INNER JOIN JobPostFranchiseDetail b on (a.JobPostId=b.JobPostId)
		  WHERE b.FranchiseId=@FranchiseId AND a.ClientId=(CASE WHEN @ClientId > 0 THEN @ClientId ELSE ClientId END)

		  SELECT DISTINCT JobLocation as StringValue, JobLocation as [Text] 
		  FROM JobPostDetail a
		  INNER JOIN JobPostFranchiseDetail b on (a.JobPostId=b.JobPostId)
		  WHERE b.FranchiseId=@FranchiseId AND a.ClientId=(CASE WHEN @ClientId > 0 THEN @ClientId ELSE ClientId END)
	   END
	ELSE IF(@SpocAdminId > 0)
	   BEGIN
	      SELECT DISTINCT a.JobPostId as [Value],JobTitle as [Text] 
		  FROM  JobPostDetail a
		  WHERE a.JPCreatedBy=@SpocAdminId AND a.ClientId=(CASE WHEN @ClientId > 0 THEN @ClientId ELSE ClientId END)

		   SELECT DISTINCT JobLocation as StringValue, JobLocation as [Text] 
		  FROM  JobPostDetail a
		  WHERE a.JPCreatedBy=@SpocAdminId AND a.ClientId=(CASE WHEN @ClientId > 0 THEN @ClientId ELSE ClientId END)
	   END
	 ELSE
	   BEGIN
	     SELECT DISTINCT a.JobPostId as [Value],JobTitle as [Text] 
		 FROM  JobPostDetail a
		 WHERE a.ClientId=(CASE WHEN @ClientId > 0 THEN @ClientId ELSE ClientId END)

		  SELECT DISTINCT JobLocation as StringValue, JobLocation as [Text] 
		 FROM  JobPostDetail a
		 WHERE a.ClientId=(CASE WHEN @ClientId > 0 THEN @ClientId ELSE ClientId END)
	   END
   END


