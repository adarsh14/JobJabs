ALTER VIEW VW_CandidatesReport
 AS  
  (  
      SELECT  a.*,b.JPCAId, b.JobPostId, b.FranchiseId,b.RecruiterId,b.JPCAStatus,c.FranchiseName, d.Firstname + ' ' + d.Lastname as RecruiterName,
              e.JobTitle,e.JobLocation, e.ClientLocationId, e.JPCreatedBy as SpocAdminId, f.CompanyId, f.LocationName as ClientLocation, g.CompanyName as ClientName,
			Isnull(h.CandidateAssigned,0) AS CandidateAssigned,
			Isnull(h.ValidatedBySPOC,0) AS ValidatedBySPOC,
			Isnull(h.CandidateRejectedBySPOC,0) AS CandidateRejectedBySPOC,
			Isnull(h.ResumeSentToHR,0) AS ResumeSentToHR,
			Isnull(h.InterviewScheduled,0) AS InterviewScheduled,
			Isnull(h.SecondRoundSheduled,0) AS SecondRoundSheduled,
			Isnull(h.FinalRoundScheduled,0) AS FinalRoundScheduled,
			Isnull(h.InterviewRejected,0) AS InterviewRejected,
			Isnull(h.CandidateShortlisted,0) AS CandidateShortlisted,
			Isnull(h.CandidateSelected,0) AS CandidateSelected,
			Isnull(h.DocumentationPending,0) AS DocumentationPending,
			Isnull(h.CandidateJoined,0) AS CandidateJoined,
			Isnull(h.CandidateNotJoined,0) AS CandidateNotJoined,
			Isnull(h.CandidateBackOut,0) AS CandidateBackOut,
			CandidateAssignedDate,
			ValidatedBySPOCDate,
			CandidateRejectedBySPOCDate,
			ResumeSentToHRDate,
			InterviewScheduledDate,
			SecondRoundSheduledDate,
			FinalRoundScheduledDate,
			InterviewRejectedDate,
			CandidateShortlistedDate,
			CandidateSelectedDate,
			DocumentationPendingDate,
			CandidateJoinedDate,
			CandidateNotJoinedDate,
			CandidateBackOutDate
     FROM  CandidateDetail a INNER JOIN JobPostCandidateDetail b on (a.CandidateId=b.CandidateId)
			 INNER JOIN FranchiseDetail c ON (b.FranchiseId=c.FranchiseId)
	         INNER JOIN UserDetail d on (b.RecruiterId=d.UserId)
			 INNER JOIN JobPostDetail e on (b.JobPostId=e.JobPostId)
			 INNER JOIN CompanyLocationDetail f on (e.ClientLocationId=f.CompLocId)  
             INNER JOIN CompanyDetail g on (f.CompanyId=g.CompanyId)  
			 INNER JOIN JPCAStatusDetail h on (b.JPCAId=h.JPCAId)
)  
  


