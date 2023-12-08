ALTER PROCEDURE Get_JPFCDetailByStatusId
(
@FranchiseId int,
@JobPostStatus int,
@JPCAStatus int 
)
AS
 BEGIN
	  SELECT  a.JobPostId, a.JobPostStatus, b.FranchiseId, b.RecruiterId , c.Firstname + ' ' + c.Lastname as RecruiterName,    
				 Isnull(fa.CandidateCount,0) AS CandidateCount
	  FROM JobPostDetail a   
	        INNER JOIN JobPostRecruiterDetail b ON (a.JobPostId=b.JobPostId AND b.JPRCStatus=1 )  
		    INNER JOIN UserDetail c ON (b.RecruiterId=c.UserId)  
		   LEFT OUTER JOIN
		     (  
						SELECT JobPostId,  FranchiseId, RecruiterId,    
								SUM(CASE WHEN  JPCAStatus = @JPCAStatus THEN 1 ELSE 0 END ) AS CandidateCount
						FROM   
								 JobPostCandidateDetail jpfa  
					    WHERE FranchiseId=@FranchiseId
					    GROUP BY  JobPostId, FranchiseId, RecruiterId  
			) fa ON a.JobPostId=fa.JobPostId AND b.FranchiseId=fa.FranchiseId AND b.RecruiterId=fa.RecruiterId 
	 WHERE b.FranchiseId=@FranchiseId AND a.JobPostStatus=@JobPostStatus
 END