drop Procedure Get_JobTitleLocByUserType
GO

-------------Used in [Report_CandidateDetail] Procedure ---------------------
CREATE PROCEDURE Get_JobLocByClientAndUserType(
	@RecruiterId int=0,
    @FranchiseId int=0,
	@SpocAdminId int=0,
	@ClientId int=0
)
AS
  BEGIN
     IF(@RecruiterId > 0)
	   BEGIN
		  SELECT DISTINCT JobLocation as StringValue, JobLocation as [Value], JobLocation as [Text] 
		  FROM JobPostDetail a
		       INNER JOIN JobPostRecruiterDetail b on (a.JobPostId=b.JobPostId)
		  WHERE b.RecruiterId=@RecruiterId  AND a.ClientId=@ClientId
	   END
	ELSE IF(@FranchiseId > 0)
	   BEGIN
		  SELECT DISTINCT JobLocation as StringValue, JobLocation as [Value], JobLocation as [Text] 
		  FROM JobPostDetail a
		  INNER JOIN JobPostFranchiseDetail b on (a.JobPostId=b.JobPostId)
		  WHERE b.FranchiseId=@FranchiseId AND a.ClientId=@ClientId
	   END
	ELSE IF(@SpocAdminId > 0)
	   BEGIN
		   SELECT DISTINCT JobLocation as StringValue, JobLocation as [Value], JobLocation as [Text] 
		  FROM  JobPostDetail a
		  WHERE a.JPCreatedBy=@SpocAdminId AND a.ClientId=@ClientId
	   END
	 ELSE
	   BEGIN
		  SELECT DISTINCT JobLocation as StringValue, JobLocation as [Value], JobLocation as [Text] 
		 FROM  JobPostDetail a
		 WHERE a.ClientId=@ClientId
	   END
   END



