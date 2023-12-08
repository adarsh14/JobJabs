ALTER Table JobPostCandidateDetail
Add JPCAId Int 
GO

DECLARE @i INT = 0
UPDATE JobPostCandidateDetail
SET 
   @i = JPCAId = @i + 1
GO