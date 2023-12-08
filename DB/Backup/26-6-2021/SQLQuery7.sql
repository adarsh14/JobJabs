----------------Used In  PROCEDURE [dbo].[Report_CandidateDetail]-------
CREATE VIEW VW_JPCADetail
 AS  
  (  
      SELECT  b.JPCAId,b.CandidateId, b.JobPostId, b.FranchiseId,b.RecruiterId,b.JPCAStatus,e.JobLocation,
	         e.JPCreatedBy as SpocAdminId, f.CompanyId
     FROM    JobPostCandidateDetail b 
			 INNER JOIN FranchiseDetail c ON (b.FranchiseId=c.FranchiseId)
	         INNER JOIN UserDetail d on (b.RecruiterId=d.UserId)
			 INNER JOIN JobPostDetail e on (b.JobPostId=e.JobPostId)
			 INNER JOIN CompanyLocationDetail f on (e.ClientLocationId=f.CompLocId)  
             INNER JOIN CompanyDetail g on (f.CompanyId=g.CompanyId)  
			 
)  
  ----------------Used In  PROCEDURE [dbo].[Report_CandidateDetail]-------





