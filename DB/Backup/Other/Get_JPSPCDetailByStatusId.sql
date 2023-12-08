CREATE PROCEDURE Get_JPSPCDetailByStatusId
(
@SpocAdminId int,
@JobPostStatus int,
@JPCAStatus int 
)
AS
 BEGIN
	  SELECT a.JobPostId,a.JobPostStatus,a.JPCreatedBy, d.FranchiseId, e.FranchiseName,  
				 Isnull(fa.CandidateCount,0) AS CandidateCount
	  FROM JobPostDetail a   
		   INNER JOIN JobPostFranchiseDetail d ON (a.JobPostId=d.JobPostId AND d.JPFAStatus=1 )  
		   INNER JOIN FranchiseDetail e ON (d.FranchiseId=e.FranchiseId)  
		   LEFT OUTER JOIN (  
							SELECT JobPostId, FranchiseId,    
								SUM(CASE WHEN  JPCAStatus = @JPCAStatus THEN 1 ELSE 0 END ) AS CandidateCount
							FROM   
								 JobPostCandidateDetail jpfa  
							GROUP BY  JobPostId, FranchiseId   
					) fa ON a.JobPostId=fa.JobPostId AND e.FranchiseId=fa.FranchiseId  
	 WHERE a.JPCreatedBy=@SpocAdminId AND a.JobPostStatus=@JobPostStatus
END

