ALTER PROCEDURE Get_JPRCDetailByStatusId
(
@RecruiterId int,
@JobPostStatus int,
@JPCAStatus int 
)
AS
 BEGIN
	  SELECT a.JobPostId, a.JobPostStatus, b.FranchiseId, b.RecruiterId , c.Firstname + ' ' + c.Lastname as RecruiterName,   
				 Isnull(rc.CandidateCount,0) AS CandidateCount
	  FROM JobPostDetail a   
		   INNER JOIN JobPostRecruiterDetail b ON (a.JobPostId=b.JobPostId AND b.JPRCStatus=1 )  
		     INNER JOIN UserDetail c ON (b.RecruiterId=c.UserId)  
		   LEFT OUTER JOIN (  
							SELECT JobPostId,  FranchiseId, RecruiterId,    
								SUM(CASE WHEN  JPCAStatus = @JPCAStatus THEN 1 ELSE 0 END ) AS CandidateCount
							FROM   
								 JobPostCandidateDetail jpfa  
							WHERE RecruiterId=@RecruiterId
							 GROUP BY  JobPostId, FranchiseId, RecruiterId    
					) rc ON a.JobPostId=rc.JobPostId AND b.FranchiseId=rc.FranchiseId AND b.RecruiterId=rc.RecruiterId  
	 WHERE b.RecruiterId=@RecruiterId AND a.JobPostStatus=@JobPostStatus
 END