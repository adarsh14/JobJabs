ALTER VIEW [dbo].[VWJobPostDetail]
  AS
  (
       SELECT a.*, b.LocationName as ClientLocation, c.CompanyName as ClientName,d.FranchiseId, e.FranchiseName, f.RecruiterId , g.Firstname + ' ' + g.Lastname as RecruiterName,
	      Isnull(rc.RCCANew,0) as RCCANew, Isnull(rc.RCCAAccepted,0) as RCCAAccepted, Isnull(rc.RCCARejected,0) as RCCARejected, Isnull(rc.RCCAOnHold,0) as RCCAOnHold,
		  Isnull(fa.FACANew,0) as FACANew, Isnull(fa.FACAAccepted,0) as FACAAccepted, Isnull(fa.FACARejected,0) as FACARejected, Isnull(fa.FACAOnHold,0) as FACAOnHold,
		  Isnull(jp.JPCANew,0) as JPCANew, Isnull(jp.JPCAAccepted,0) as JPCAAccepted, Isnull(jp.JPCARejected,0) as JPCARejected, Isnull(jp.JPCAOnHold,0) as JPCAOnHold
	   FROM JobPostDetail a 
	          INNER JOIN CompanyLocationDetail b on (a.ClientLocationId=b.CompLocId)
		      INNER JOIN CompanyDetail c on (b.CompanyId=c.CompanyId)
		      LEFT OUTER JOIN JobPostFranchiseDetail d ON (a.JobPostId=d.JobPostId AND d.JPFAStatus=1 )
			  LEFT OUTER JOIN FranchiseDetail e ON (d.FranchiseId=e.FranchiseId)
			  LEFT OUTER JOIN JobPostRecruiterDetail f ON (a.JobPostId=f.JobPostId  AND d.FranchiseId=f.FranchiseId AND f.JPRCStatus=1)
			  LEFT OUTER JOIN UserDetail g ON (f.RecruiterId=g.UserId)
			  LEFT OUTER JOIN (
			    SELECT JobPostId, FranchiseId, RecruiterId,  
					SUM(CASE WHEN jprc.JPCAStatus=0 Then 1 ELSE 0 END) AS RCCANew,
					SUM(CASE WHEN jprc.JPCAStatus=1 Then 1 ELSE 0 END) AS RCCAAccepted,
					SUM(CASE WHEN jprc.JPCAStatus=2 Then 1 ELSE 0 END) AS RCCARejected,
					SUM(CASE WHEN jprc.JPCAStatus=3 Then 1 ELSE 0 END) AS RCCAOnHold
			    FROM 
				   JobPostCandidateDetail jprc
			    GROUP BY  JobPostId, FranchiseId, RecruiterId  
			  ) rc ON a.JobPostId=rc.JobPostId AND f.FranchiseId=rc.FranchiseId AND f.RecruiterId=rc.RecruiterId
			   LEFT OUTER JOIN (
			    SELECT JobPostId, FranchiseId,  
					SUM(CASE WHEN jpfa.JPCAStatus=0 Then 1 ELSE 0 END) AS FACANew,
					SUM(CASE WHEN jpfa.JPCAStatus=1 Then 1 ELSE 0 END) AS FACAAccepted,
					SUM(CASE WHEN jpfa.JPCAStatus=2 Then 1 ELSE 0 END) AS FACARejected,
					SUM(CASE WHEN jpfa.JPCAStatus=3 Then 1 ELSE 0 END) AS FACAOnHold
			    FROM 
				   JobPostCandidateDetail jpfa
			    GROUP BY  JobPostId, FranchiseId 
			  ) fa ON a.JobPostId=fa.JobPostId AND f.FranchiseId=fa.FranchiseId
			  LEFT OUTER JOIN (
			    SELECT JobPostId,  
					SUM(CASE WHEN jp.JPCAStatus=0 Then 1 ELSE 0 END) AS JPCANew,
					SUM(CASE WHEN jp.JPCAStatus=1 Then 1 ELSE 0 END) AS JPCAAccepted,
					SUM(CASE WHEN jp.JPCAStatus=2 Then 1 ELSE 0 END) AS JPCARejected,
					SUM(CASE WHEN jp.JPCAStatus=3 Then 1 ELSE 0 END) AS JPCAOnHold
			    FROM 
				   JobPostCandidateDetail jp
			    GROUP BY  JobPostId  
			  ) jp ON a.JobPostId=jp.JobPostId
	)



