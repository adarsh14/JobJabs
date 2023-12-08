
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
    	  
			   SELECT Top 1 a.*,b.JobPostId, b.FranchiseId,b.RecruiterId,b.JPCAStatus, @QType  as QueryType  INTO #TEMP  
			   FROM CandidateDetail a INNER JOIN JobPostCandidateDetail b on (a.CandidateId=b.CandidateId)
			   SELECT * INTO #TEMP2 FROM #TEMP 
			   DELETE FROM #TEMP2
			   DECLARE @cntr int
			   SET @cntr=0

		   IF( @JobPostId > 0) 
			 BEGIN
				  INSERT INTO #TEMP2 SELECT a.*,b.JobPostId, b.FranchiseId,b.RecruiterId,b.JPCAStatus, @QType  as QueryType  
			                         FROM CandidateDetail a INNER JOIN JobPostCandidateDetail b on (a.CandidateId=b.CandidateId)
									 WHERE b.JobPostId=@JobPostId AND b.JPCAStatus=@JPCAStatus
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


