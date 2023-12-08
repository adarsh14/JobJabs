ALTER PROCEDURE [dbo].[Get_CandidateDetail](
      @QueryType int =0,
	  @JobPostId int=0,
	  @FranchiseId int=0,
	  @RecruiterId int=0,
	  @JPCAStatus int=0
	)
	AS
	  BEGIN
	    IF(@QueryType=1)
	      BEGIN
			  DECLARE @QType varchar(100)
			  SET @QType = 'z'
			  IF OBJECT_ID('tempdb..#TEMP') IS NOT NULL DROP TABLE #TEMP
			  IF OBJECT_ID('tempdb..#TEMP2') IS NOT NULL DROP TABLE #TEMP2
    	  
			   SELECT Top 1 a.*,b.JobPostId, b.FranchiseId,  b.RecruiterId, b.JPCAStatus,c.FranchiseName, d.Firstname + ' ' + d.Lastname as RecruiterName,  @QType  as QueryType  INTO #TEMP  
			   FROM CandidateDetail a INNER JOIN JobPostCandidateDetail b on (a.CandidateId=b.CandidateId)
			   INNER JOIN FranchiseDetail c ON (b.FranchiseId=c.FranchiseId)
			   INNER JOIN UserDetail d on (b.RecruiterId=d.UserId)
			   SELECT * INTO #TEMP2 FROM #TEMP 
			   DELETE FROM #TEMP2
			   DECLARE @cntr int
			   SET @cntr=0

		   IF( @JobPostId > 0) 
			 BEGIN
				  INSERT INTO #TEMP2 SELECT a.*,b.JobPostId, b.FranchiseId,b.RecruiterId,b.JPCAStatus,c.FranchiseName, d.Firstname + ' ' + d.Lastname as RecruiterName,  @QType  as QueryType  
			                         FROM CandidateDetail a INNER JOIN JobPostCandidateDetail b on (a.CandidateId=b.CandidateId)
									 INNER JOIN FranchiseDetail c ON (b.FranchiseId=c.FranchiseId)
			                         INNER JOIN UserDetail d on (b.RecruiterId=d.UserId)
									 WHERE b.JobPostId=@JobPostId 
				  SET @cntr=1
				  UPDATE #TEMP2 SET QueryType = QueryType + ',a'
				  DELETE FROM #TEMP
				  INSERT INTO #TEMP SELECT * FROM #TEMP2
				  DELETE FROM #TEMP2
			END
	  	 
		   IF( @RecruiterId > 0) 
			   BEGIN
				  INSERT INTO #TEMP2 SELECT * FROM #TEMP  WHERE RecruiterId=@RecruiterId
				  SET @cntr=1
				  UPDATE #TEMP2 SET QueryType = QueryType + ',b'
				  DELETE FROM #TEMP
				  INSERT INTO #TEMP SELECT * FROM #TEMP2
				  DELETE FROM #TEMP2
				END
		  ELSE IF( @FranchiseId > 0) 
			   BEGIN
				  INSERT INTO #TEMP2 SELECT * FROM #TEMP WHERE FranchiseId=@FranchiseId
				  SET @cntr=1
				  UPDATE #TEMP2 SET QueryType = QueryType + ',c'
				  DELETE FROM #TEMP
				  INSERT INTO #TEMP SELECT * FROM #TEMP2
				  DELETE FROM #TEMP2
			   END

		   IF(@JPCAStatus > -1) 
			 BEGIN
				  INSERT INTO #TEMP2 SELECT * FROM #TEMP WHERE JPCAStatus=@JPCAStatus
				  SET @cntr=1
				  UPDATE #TEMP2 SET QueryType = QueryType + ',d'
				  DELETE FROM #TEMP
				  INSERT INTO #TEMP SELECT * FROM #TEMP2
				  DELETE FROM #TEMP2
			END
	   
      SELECT * FROM #TEMP 

	  IF OBJECT_ID('tempdb..#TEMP') IS NOT NULL DROP TABLE #TEMP
	  IF OBJECT_ID('tempdb..#TEMP2') IS NOT NULL DROP TABLE #TEMP2
   END
 END
 GO 

CREATE TABLE JPCACommentDetail(
JPCACommentId int Not null,
JPCAComment varchar(3000) Null,
JPCAStatus int null,
JPCAJobPostId int not null,
JPCACandidateId int not null,
JPCARecruiterId int not null,
JPCAFranchiseId int not null,
JPCACommentCreatedBy int null,
JPCACommentCreatedOn Datetime null,
JPCACommentUpdatedBy int null,
JPCACommentUpdatedOn Datetime null
)
GO

ALTER Procedure [dbo].[tb_JPCACommentDetail]
 ( 
   @QueryType int=0,
	@JPCACommentId int=0,
	@JPCAComment varchar(3000)='',
	@JPCAStatus int=0,
	@JobPostId int=0,
    @CandidateId int=0,
    @RecruiterId int=0,
    @FranchiseId int=0,
    @JPCACommentCreatedBy int=0
)
  AS 
BEGIN
    IF(@QueryType=1)
	  BEGIN 
	    SELECT @JPCACommentId=ISNULL(MAX(JPCACommentId),0) +1 FROM JPCACommentDetail
	    INSERT INTO JPCACommentDetail(JPCACommentId,JPCAComment,JPCAStatus, JPCAJobPostId, JPCACandidateId, JPCARecruiterId, JPCAFranchiseId, JPCACommentCreatedBy,JPCACommentCreatedOn)
		VALUES (@JPCACommentId,@JPCAComment,@JPCAStatus,@JobPostId, @CandidateId, @RecruiterId,@FranchiseId,@JPCACommentCreatedBy,GETDATE()) 
   	    SELECT * FROM JPCACommentDetail WHERE JPCACommentId=@JPCACommentId
	END
END

GO


