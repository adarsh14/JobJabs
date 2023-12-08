------------------Used in Stored Procedure [Report_CandidateDetail]-----------------------------
ALTER PROCEDURE Get_FranchiseByUserType(
	@RecruiterId int=0,
    @FranchiseId int=0,
	@SpocAdminId int=0
)
AS
  BEGIN
     IF(@RecruiterId > 0)
	   BEGIN
	      SELECT DISTINCT a.FranchiseId as [Value], a.FranchiseName as [Text] 
		  FROM FranchiseDetail a
		       INNER JOIN FranchiseUserDetail b on (a.FranchiseId=b.FranchiseId)
			   INNER JOIN UserDetail c on (b.UserId =c.UserId)
		  WHERE b.UserId=@RecruiterId AND a.FranchiseStatus =1 AND c.Status=1
	   END
	ELSE IF(@FranchiseId > 0)
	   BEGIN
	    SELECT DISTINCT a.FranchiseId as [Value], a.FranchiseName as [Text] 
		  FROM FranchiseDetail a
		  WHERE a.FranchiseId=@FranchiseId  AND a.FranchiseStatus =1 
	   END
	ELSE IF(@SpocAdminId > 0)
	   BEGIN
	    SELECT DISTINCT a.FranchiseId as [Value], a.FranchiseName as [Text] 
		  FROM FranchiseDetail a
		       INNER JOIN SPOCAdminFranchiseDetail b on (a.FranchiseId=b.FranchiseId)
		  WHERE b.SPOCAdminId =@SpocAdminId AND b.SPFAStatus =1 AND a.FranchiseStatus =1  
	   END
	 ELSE
	   BEGIN
	     SELECT DISTINCT a.FranchiseId as [Value], a.FranchiseName as [Text] 
		  FROM FranchiseDetail a
		  WHERE a.FranchiseStatus =1  
	   END
   END




