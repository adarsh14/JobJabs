ALTER Table JPCACommentDetail
Add JPCAId int

GO

UPDATE
    a
SET
    a.JPCAId=b.JPCAId
FROM 
    JPCACommentDetail a
    INNER JOIN [JobPostCandidateDetail] b
        ON (a.JPCAJobPostId=b.JobPostId AND a.JPCAFranchiseId=b.FranchiseId AND a.JPCARecruiterId=b.RecruiterId AND a.JPCACandidateId=b.CandidateId)
GO


