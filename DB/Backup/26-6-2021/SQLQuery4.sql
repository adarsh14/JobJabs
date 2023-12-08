-------------Used in [Report_CandidateDetail] Procedure ---------------------
ALTER PROCEDURE Get_ClientsByUserType(
	@RecruiterId int=0,
    @FranchiseId int=0,
	@SpocAdminId int=0
)
AS
  BEGIN
     IF(@RecruiterId > 0)
	   BEGIN
	      SELECT DISTINCT CompanyId as [Value], CompanyName as [Text]
		  FROM CompanyDetail a INNER JOIN  JobPostDetail b ON (a.CompanyId=b.ClientId)
		       INNER JOIN JobPostRecruiterDetail c on (b.JobPostId=c.JobPostId)
		  WHERE c.RecruiterId=@RecruiterId
	   END
	ELSE IF(@FranchiseId > 0)
	   BEGIN
	      SELECT DISTINCT CompanyId as [Value], CompanyName as [Text]
		  FROM CompanyDetail a INNER JOIN  JobPostDetail b ON (a.CompanyId=b.ClientId)
		       INNER JOIN JobPostFranchiseDetail c on (b.JobPostId=c.JobPostId)
		  WHERE c.FranchiseId=@FranchiseId
	   END
	ELSE IF(@SpocAdminId > 0)
	   BEGIN
	      SELECT DISTINCT CompanyId as [Value], CompanyName as [Text]
		  FROM CompanyDetail a INNER JOIN  JobPostDetail b ON (a.CompanyId=b.ClientId)
		  WHERE b.JPCreatedBy=@SpocAdminId
	   END
	 ELSE
	   BEGIN
	     SELECT DISTINCT CompanyId as [Value], CompanyName as [Text]
		 FROM CompanyDetail 
	   END
   END


