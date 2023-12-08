ALTER VIEW [dbo].[VWJobPostCandidateDetail]  
  AS  
  (  
     SELECT a.JobPostId, a.JobPostStatus, a.JPCreatedBy,  
           Isnull(jp.CandidateAssigned,0) AS CandidateAssigned,
			Isnull(jp.ValidatedBySPOC,0) AS ValidatedBySPOC,
			Isnull(jp.CandidateRejectedBySPOC,0) AS CandidateRejectedBySPOC,
			Isnull(jp.TurnUps,0) AS TurnUps,
			Isnull(jp.InterviewScheduled,0) AS InterviewScheduled,
			Isnull(jp.SecondRoundSheduled,0) AS SecondRoundSheduled,
			Isnull(jp.FinalRoundScheduled,0) AS FinalRoundScheduled,
			Isnull(jp.InterviewRejected,0) AS InterviewRejected,
			Isnull(jp.CandidateShortlisted,0) AS CandidateShortlisted,
			Isnull(jp.CandidateSelected,0) AS CandidateSelected,
			Isnull(jp.DocumentationPending,0) AS DocumentationPending,
			Isnull(jp.CandidateJoined,0) AS CandidateJoined,
			Isnull(jp.CandidateNotJoined,0) AS CandidateNotJoined,
			Isnull(jp.CandidateBackOut,0) AS CandidateBackOut,
			Isnull(jp.NRC,0) AS NRC
     FROM JobPostDetail a   
      LEFT OUTER JOIN (  
					     SELECT JobPostId,    
							SUM(CASE WHEN  CandidateAssigned = 1 THEN 1 ELSE 0 END ) AS CandidateAssigned,
							SUM(CASE WHEN  ValidatedBySPOC = 1 THEN 1 ELSE 0 END ) AS ValidatedBySPOC,
							SUM(CASE WHEN  CandidateRejectedBySPOC = 1 THEN 1 ELSE 0 END ) AS CandidateRejectedBySPOC,
							SUM(CASE WHEN  TurnUps = 1 THEN 1 ELSE 0 END ) AS TurnUps,
							SUM(CASE WHEN  InterviewScheduled = 1 THEN 1 ELSE 0 END ) AS InterviewScheduled,
							SUM(CASE WHEN  SecondRoundSheduled = 1 THEN 1 ELSE 0 END ) AS SecondRoundSheduled,
							SUM(CASE WHEN  FinalRoundScheduled = 1 THEN 1 ELSE 0 END ) AS FinalRoundScheduled,
							SUM(CASE WHEN  InterviewRejected = 1 THEN 1 ELSE 0 END ) AS InterviewRejected,
							SUM(CASE WHEN  CandidateShortlisted = 1 THEN 1 ELSE 0 END ) AS CandidateShortlisted,
							SUM(CASE WHEN  CandidateSelected = 1 THEN 1 ELSE 0 END ) AS CandidateSelected,
							SUM(CASE WHEN  DocumentationPending = 1 THEN 1 ELSE 0 END ) AS DocumentationPending,
							SUM(CASE WHEN  CandidateJoined = 1 THEN 1 ELSE 0 END ) AS CandidateJoined,
							SUM(CASE WHEN  CandidateNotJoined = 1 THEN 1 ELSE 0 END ) AS CandidateNotJoined,
							SUM(CASE WHEN  CandidateBackOut = 1 THEN 1 ELSE 0 END ) AS CandidateBackOut,
							SUM(CASE WHEN  NRC = 1 THEN 1 ELSE 0 END ) AS NRC
						  FROM   
							   JobPostCandidateDetail jprc  INNER JOIN JPCAStatusDetail jpst ON (jprc.JPCAId=jpst.JPCAId)
						  GROUP BY  JobPostId    
                 ) jp ON a.JobPostId=jp.JobPostId 
 )  


