ALTER VIEW [dbo].[VWJobPostCandidateDetail]  
  AS  
  (  
     SELECT a.JobPostId, a.JobPostStatus, a.JPCreatedBy,  
           Isnull(jp.CandidateAssigned,0) ASCandidateAssigned,
			Isnull(jp.ValidatedBySPOC,0) ASValidatedBySPOC,
			Isnull(jp.CandidateRejectedBySPOC,0) ASCandidateRejectedBySPOC,
			Isnull(jp.ResumeSentToHR,0) ASResumeSentToHR,
			Isnull(jp.InterviewScheduled,0) ASInterviewScheduled,
			Isnull(jp.SecondRoundSheduled,0) ASSecondRoundSheduled,
			Isnull(jp.FinalRoundScheduled,0) ASFinalRoundScheduled,
			Isnull(jp.InterviewRejected,0) ASInterviewRejected,
			Isnull(jp.CandidateShortlisted,0) ASCandidateShortlisted,
			Isnull(jp.CandidateSelected,0) ASCandidateSelected,
			Isnull(jp.DocumentationPending,0) ASDocumentationPending,
			Isnull(jp.CandidateJoined,0) ASCandidateJoined,
			Isnull(jp.CandidateNotJoined,0) ASCandidateNotJoined,
			Isnull(jp.CandidateBackOut,0) ASCandidateBackOut
     FROM JobPostDetail a   
      LEFT OUTER JOIN (  
					     SELECT JobPostId,    
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
							   JobPostCandidateDetail jprc  INNER JOIN JPCAStatusDetail jpst ON (jprc.JPCAId=jpst.JPCAId)
						  GROUP BY  JobPostId    
                 ) jp ON a.JobPostId=jp.JobPostId 
 )  

