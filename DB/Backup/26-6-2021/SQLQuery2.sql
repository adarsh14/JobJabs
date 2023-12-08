
-------------Used in [Report_CandidateDetail] Procedure ---------------------
CREATE PROCEDURE Get_JobTitleByJobLocAndUserType(
	@RecruiterId int=0,
    @FranchiseId int=0,
	@SpocAdminId int=0,
	@ClientId int=0,
	@JobLocation varchar(100)=''
)
AS
  BEGIN
     IF(@RecruiterId > 0)
	   BEGIN
	      SELECT DISTINCT a.JobPostId as [Value],JobTitle as [Text] 
		  FROM JobPostDetail a
		       INNER JOIN JobPostRecruiterDetail b on (a.JobPostId=b.JobPostId)
		  WHERE b.RecruiterId=@RecruiterId AND a.ClientId=@ClientId AND a.JobLocation= @JobLocation
	   END
	ELSE IF(@FranchiseId > 0)
	   BEGIN
	      SELECT DISTINCT a.JobPostId as [Value],JobTitle as [Text] 
		  FROM JobPostDetail a
		  INNER JOIN JobPostFranchiseDetail b on (a.JobPostId=b.JobPostId)
		  WHERE b.FranchiseId=@FranchiseId AND a.ClientId=@ClientId AND a.JobLocation= @JobLocation
	   END
	ELSE IF(@SpocAdminId > 0)
	   BEGIN
	      SELECT DISTINCT a.JobPostId as [Value],JobTitle as [Text] 
		  FROM  JobPostDetail a
		  WHERE a.JPCreatedBy=@SpocAdminId AND a.ClientId=@ClientId AND a.JobLocation= @JobLocation
	   END
	 ELSE
	   BEGIN
	     SELECT DISTINCT a.JobPostId as [Value],JobTitle as [Text] 
		 FROM  JobPostDetail a
		 WHERE  a.ClientId=@ClientId AND a.JobLocation= @JobLocation	
	   END
   END



