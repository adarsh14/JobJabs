ALTER VIEW [dbo].[VWJPFranchiseCandidateDetail]  
  AS  
  (  
     SELECT a.JobPostId,a.JobPostStatus,a.JPCreatedBy, d.FranchiseId, e.FranchiseName,  
            Isnull(fa.CandidateAssigned,0) ASCandidateAssigned,
			Isnull(fa.ValidatedBySPOC,0) ASValidatedBySPOC,
			Isnull(fa.CandidateRejectedBySPOC,0) ASCandidateRejectedBySPOC,
			Isnull(fa.ResumeSentToHR,0) ASResumeSentToHR,
			Isnull(fa.InterviewScheduled,0) ASInterviewScheduled,
			Isnull(fa.SecondRoundSheduled,0) ASSecondRoundSheduled,
			Isnull(fa.FinalRoundScheduled,0) ASFinalRoundScheduled,
			Isnull(fa.InterviewRejected,0) ASInterviewRejected,
			Isnull(fa.CandidateShortlisted,0) ASCandidateShortlisted,
			Isnull(fa.CandidateSelected,0) ASCandidateSelected,
			Isnull(fa.DocumentationPending,0) ASDocumentationPending,
			Isnull(fa.CandidateJoined,0) ASCandidateJoined,
			Isnull(fa.CandidateNotJoined,0) ASCandidateNotJoined,
			Isnull(fa.CandidateBackOut,0) ASCandidateBackOut
     FROM JobPostDetail a   
       INNER JOIN JobPostFranchiseDetail d ON (a.JobPostId=d.JobPostId AND d.JPFAStatus=1 )  
       INNER JOIN FranchiseDetail e ON (d.FranchiseId=e.FranchiseId)  
       LEFT OUTER JOIN (  
                        SELECT JobPostId, FranchiseId,    
							SUM(CASE WHEN  CandidateAssigned = 1 THEN 1 ELSE 0 END ) AS CandidateAssigned,
							SUM(CASE WHEN  ValidatedBySPOC = 1 THEN 1 ELSE 0 END ) AS ValidatedBySPOC,
							SUM(CASE WHEN  CandidateRejectedBySPOC = 1 THEN 1 ELSE 0 END ) AS CandidateRejectedBySPOC,
							SUM(CASE WHEN  ResumeSentToHR = 1 THEN 1 ELSE 0 END ) AS ResumeSentToHR,
							SUM(CASE WHEN  InterviewScheduled = 1 THEN 1 ELSE 0 END ) AS InterviewScheduled,
							SUM(CASE WHEN  SecondRoundSheduled = 1 THEN 1 ELSE 0 END ) AS SecondRoundSheduled,
							SUM(CASE WHEN  FinalRoundScheduled = 1 THEN 1 ELSE 0 END ) AS FinalRoundScheduled,
							SUM(CASE WHEN  InterviewRejected = 1 THEN 1 ELSE 0 END ) AS InterviewRejected,
							SUM(CASE WHEN  CandidateShortlisted = 1 THEN 1 ELSE 0 END ) AS CandidateShortlisted,
							SUM(CASE WHEN  CandidateSelected = 1 THEN 1 ELSE 0 END ) AS CandidateSelected,
							SUM(CASE WHEN  DocumentationPending = 1 THEN 1 ELSE 0 END ) AS DocumentationPending,
							SUM(CASE WHEN  CandidateJoined = 1 THEN 1 ELSE 0 END ) AS CandidateJoined,
							SUM(CASE WHEN  CandidateNotJoined = 1 THEN 1 ELSE 0 END ) AS CandidateNotJoined,
							SUM(CASE WHEN  CandidateBackOut = 1 THEN 1 ELSE 0 END ) AS CandidateBackOut
						 FROM   
						     JobPostCandidateDetail jpfa  INNER JOIN JPCAStatusDetail jpst ON (jpfa.JPCAId=jpst.JPCAId)
					     GROUP BY  JobPostId, FranchiseId   
                ) fa ON a.JobPostId=fa.JobPostId AND e.FranchiseId=fa.FranchiseId  
)
				  
					   


