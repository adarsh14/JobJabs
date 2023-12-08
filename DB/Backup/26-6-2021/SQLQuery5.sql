
----------------Used In  PROCEDURE [dbo].[Report_CandidateDetail]-------
ALTER VIEW VW_CandidatesReport
 AS  
  (  
      SELECT  a.*,c.FranchiseName, d.Firstname + ' ' + d.Lastname as RecruiterName
      FROM  CandidateDetail a INNER JOIN JobPostCandidateDetail b on (a.CandidateId=b.CandidateId)
			 INNER JOIN FranchiseDetail c ON (b.FranchiseId=c.FranchiseId)
	         INNER JOIN UserDetail d on (b.RecruiterId=d.UserId)
)  
----------------Used In  PROCEDURE [dbo].[Report_CandidateDetail]-------


