ALTER VIEW [dbo].[VWJPFranchiseCandidateDetail]  
  AS  
  (  
     SELECT a.JobPostId,a.JobPostStatus,a.JPCreatedBy, d.FranchiseId, e.FranchiseName,  
             Isnull(fa.CandidateAssigned,0) AS CandidateAssigned,
			Isnull(fa.ValidatedBySPOC,0) AS ValidatedBySPOC,
			Isnull(fa.CandidateRejectedBySPOC,0) AS CandidateRejectedBySPOC,
			Isnull(fa.ResumeSentToHR,0) AS ResumeSentToHR,
			Isnull(fa.InterviewScheduled,0) AS InterviewScheduled,
			Isnull(fa.SecondRoundSheduled,0) AS SecondRoundSheduled,
			Isnull(fa.FinalRoundScheduled,0) AS FinalRoundScheduled,
			Isnull(fa.InterviewRejected,0) AS InterviewRejected,
			Isnull(fa.CandidateShortlisted,0) AS CandidateShortlisted,
			Isnull(fa.CandidateSelected,0) AS CandidateSelected,
			Isnull(fa.DocumentationPending,0) AS DocumentationPending,
			Isnull(fa.CandidateJoined,0) AS CandidateJoined,
			Isnull(fa.CandidateNotJoined,0) AS CandidateNotJoined,
			Isnull(fa.CandidateBackOut,0) AS CandidateBackOut
     FROM JobPostDetail a   
       INNER JOIN JobPostFranchiseDetail d ON (a.JobPostId=d.JobPostId AND d.JPFAStatus=1 )  
       INNER JOIN FranchiseDetail e ON (d.FranchiseId=e.FranchiseId)  
       LEFT OUTER JOIN (  
                        SELECT JobPostId, FranchiseId,    
							SUM(CASE WHEN  JPCAStatus = 0 THEN 1 ELSE 0 END ) AS CandidateAssigned,
							SUM(CASE WHEN  JPCAStatus = 1 THEN 1 ELSE 0 END ) AS ValidatedBySPOC,
							SUM(CASE WHEN  JPCAStatus = 2 THEN 1 ELSE 0 END ) AS CandidateRejectedBySPOC,
							SUM(CASE WHEN  JPCAStatus = 3 THEN 1 ELSE 0 END ) AS ResumeSentToHR,
							SUM(CASE WHEN  JPCAStatus = 5 THEN 1 ELSE 0 END ) AS InterviewScheduled,
							SUM(CASE WHEN  JPCAStatus = 6 THEN 1 ELSE 0 END ) AS SecondRoundSheduled,
							SUM(CASE WHEN  JPCAStatus = 7 THEN 1 ELSE 0 END ) AS FinalRoundScheduled,
							SUM(CASE WHEN  JPCAStatus = 8 THEN 1 ELSE 0 END ) AS InterviewRejected,
							SUM(CASE WHEN  JPCAStatus = 9 THEN 1 ELSE 0 END ) AS CandidateShortlisted,
							SUM(CASE WHEN  JPCAStatus = 10 THEN 1 ELSE 0 END ) AS CandidateSelected,
							SUM(CASE WHEN  JPCAStatus = 1 THEN 1 ELSE 0 END ) AS DocumentationPending,
							SUM(CASE WHEN  JPCAStatus = 1 THEN 1 ELSE 0 END ) AS CandidateJoined,
							SUM(CASE WHEN  JPCAStatus = 1 THEN 1 ELSE 0 END ) AS CandidateNotJoined,
							SUM(CASE WHEN  JPCAStatus = 1 THEN 1 ELSE 0 END ) AS CandidateBackOut
						 FROM   
						     JobPostCandidateDetail jpfa  
					     GROUP BY  JobPostId, FranchiseId   
                ) fa ON a.JobPostId=fa.JobPostId AND e.FranchiseId=fa.FranchiseId  
)
				  
					   
select top 1 * from JobPostCandidateDetail

