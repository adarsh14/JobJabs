
ALTER VIEW [dbo].[VWJPRecruiterCandidateDetail]  
  AS  
  (  
     SELECT a.JobPostId, a.JobPostStatus, f.FranchiseId, f.RecruiterId , g.Firstname + ' ' + g.Lastname as RecruiterName,  
             Isnull(rc.CandidateAssigned,0) ASCandidateAssigned,
			Isnull(rc.ValidatedBySPOC,0) ASValidatedBySPOC,
			Isnull(rc.CandidateRejectedBySPOC,0) ASCandidateRejectedBySPOC,
			Isnull(rc.ResumeSentToHR,0) ASResumeSentToHR,
			Isnull(rc.InterviewScheduled,0) ASInterviewScheduled,
			Isnull(rc.SecondRoundSheduled,0) ASSecondRoundSheduled,
			Isnull(rc.FinalRoundScheduled,0) ASFinalRoundScheduled,
			Isnull(rc.InterviewRejected,0) ASInterviewRejected,
			Isnull(rc.CandidateShortlisted,0) ASCandidateShortlisted,
			Isnull(rc.CandidateSelected,0) ASCandidateSelected,
			Isnull(rc.DocumentationPending,0) ASDocumentationPending,
			Isnull(rc.CandidateJoined,0) ASCandidateJoined,
			Isnull(rc.CandidateNotJoined,0) ASCandidateNotJoined,
			Isnull(rc.CandidateBackOut,0) ASCandidateBackOut
     FROM JobPostDetail a   
       INNER JOIN JobPostRecruiterDetail f ON (a.JobPostId=f.JobPostId AND f.JPRCStatus=1)  
       INNER JOIN UserDetail g ON (f.RecruiterId=g.UserId)  
       LEFT OUTER JOIN (  
					     SELECT JobPostId, FranchiseId, RecruiterId,    
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
						  GROUP BY  JobPostId, FranchiseId, RecruiterId    
                 ) rc ON a.JobPostId=rc.JobPostId AND f.FranchiseId=rc.FranchiseId AND f.RecruiterId=rc.RecruiterId  
 )

