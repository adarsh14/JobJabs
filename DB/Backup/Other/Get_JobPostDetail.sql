
ALTER PROCEDURE [dbo].[Get_JobPostDetail](
      @QueryType int =0,
	  @JobPostId int=0,
	  @FranchiseId int=0,
	  @RecruiterId int=0,
	  @JobPostStatus int=0
	)
	AS
	  BEGIN
	    IF(@QueryType=1)
	      BEGIN
			  DECLARE @QType varchar(100)
			  SET @QType = 'z'
			  IF OBJECT_ID('tempdb..#TEMP') IS NOT NULL DROP TABLE #TEMP
			  IF OBJECT_ID('tempdb..#TEMP2') IS NOT NULL DROP TABLE #TEMP2
    	  
			   SELECT Top 1 *, @QType  as QueryType  INTO #TEMP  
			   FROM VWJobPostDetail
			   SELECT * INTO #TEMP2 FROM #TEMP 
			   DELETE FROM #TEMP2
			   DECLARE @cntr int
			   SET @cntr=0
	  	 
		   IF( @RecruiterId > 0) 
			   BEGIN
				  INSERT INTO #TEMP2 SELECT *, @QType  as QueryType
	                                  FROM VWJobPostDetail a WHERE a.RecruiterId=@RecruiterId
				  SET @cntr=1
				  UPDATE #TEMP2 SET QueryType = QueryType + ',a'
				  DELETE FROM #TEMP
				  INSERT INTO #TEMP SELECT * FROM #TEMP2
				  DELETE FROM #TEMP2
				END
		  ELSE IF( @FranchiseId > 0) 
			   BEGIN
				   INSERT INTO #TEMP2 SELECT  *, @QType  as QueryType
	                                  FROM VWJobPostDetail a WHERE a.FranchiseId=@FranchiseId
				  SET @cntr=1
				  UPDATE #TEMP2 SET QueryType = QueryType + ',b'
				  DELETE FROM #TEMP
				  INSERT INTO #TEMP SELECT * FROM #TEMP2
				  DELETE FROM #TEMP2
			   END

	   IF( @JobPostStatus >0) 
		   BEGIN
		      IF(@cntr=0)
			    BEGIN
				  INSERT INTO #TEMP2 SELECT  *, @QType  as QueryType
	                                 FROM VWJobPostDetail a WHERE a.JobPostStatus=@JobPostStatus
					SET @cntr=1
				END
			 ELSE
			   BEGIN
			      INSERT INTO #TEMP2 SELECT * FROM #TEMP  WHERE JobPostStatus=@JobPostStatus
			   END
			   
			   UPDATE #TEMP2 SET QueryType = QueryType + ',j'
			   DELETE FROM #TEMP
			  INSERT INTO #TEMP SELECT * FROM #TEMP2
			  DELETE FROM #TEMP2
		  END

	  IF( @JobPostId >0) 
		   BEGIN
		      IF(@cntr=0)
			    BEGIN
				  INSERT INTO #TEMP2 SELECT  *, @QType  as QueryType
	                                 FROM VWJobPostDetail a WHERE a.JobPostId=@JobPostId
					SET @cntr=1
				END
			 ELSE
			   BEGIN
			      INSERT INTO #TEMP2 SELECT * FROM #TEMP  WHERE JobPostId=@JobPostId
			   END
			   
			   UPDATE #TEMP2 SET QueryType = QueryType + ',h'
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


