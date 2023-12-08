ALTER PROCEDURE [dbo].[Report_CandidateDetail](
      @QueryType int =0,
	  @RecruiterId int=0,
	  @FranchiseId int=0,
	  @SpocAdminId int=0,
	  @CompanyId int=0,
	  @JobPostId int=0,
	  @JobLocation varchar(100) ='',
	  @JPCAStatus int=-1,
	  @FromDate DateTime = null,
	  @ToDate DateTime=null
	)
	AS
	  BEGIN
	    IF(@QueryType=2)
	      BEGIN
			  DECLARE @QType varchar(100)
			  SET @QType = 'z'
			  IF OBJECT_ID('tempdb..#TEMP') IS NOT NULL DROP TABLE #TEMP
			  IF OBJECT_ID('tempdb..#TEMP2') IS NOT NULL DROP TABLE #TEMP2
    	  
		       SELECT TOP 1 JPCAId,CandidateId,  @QType  as QueryType  INTO #TEMP  
			   FROM VW_JPCADetail  
			   SELECT * INTO #TEMP2 FROM #TEMP 
			   DELETE FROM #TEMP2
			   DECLARE @cntr int
			   SET @cntr=0

		   IF( @RecruiterId > 0) 
			 BEGIN
				  INSERT INTO #TEMP2 SELECT JPCAId,CandidateId, 'r' FROM VW_JPCADetail  
									 WHERE RecruiterId=@RecruiterId  AND JobPostId=(CASE WHEN @JobPostId > 0 THEN @JobPostId ELSE JobPostId END)
									 AND JobLocation=(CASE WHEN @JobLocation !=''  THEN @JobLocation ELSE JobLocation END)
									 AND CompanyId=(CASE WHEN @CompanyId >0  THEN @CompanyId ELSE CompanyId END) 
				  DELETE FROM #TEMP
				  INSERT INTO #TEMP SELECT * FROM #TEMP2
				  DELETE FROM #TEMP2
			END
		  ELSE IF( @FranchiseId > 0) 
			   BEGIN
				   INSERT INTO #TEMP2 SELECT JPCAId,CandidateId, 'f' FROM VW_JPCADetail  
									 WHERE FranchiseId=@FranchiseId  AND JobPostId=(CASE WHEN @JobPostId > 0 THEN @JobPostId ELSE JobPostId END)
									 AND JobLocation=(CASE WHEN @JobLocation !=''  THEN @JobLocation ELSE JobLocation END)
									 AND CompanyId=(CASE WHEN @CompanyId >0  THEN @CompanyId ELSE CompanyId END) 
				  INSERT INTO #TEMP SELECT * FROM #TEMP2
				  DELETE FROM #TEMP2
			   END
		  ELSE IF( @SpocAdminId > 0) 
			   BEGIN
				   INSERT INTO #TEMP2 SELECT JPCAId,CandidateId,'sp' FROM VW_JPCADetail  
									 WHERE SpocAdminId=@SpocAdminId  AND JobPostId=(CASE WHEN @JobPostId > 0 THEN @JobPostId ELSE JobPostId END)
									 AND JobLocation=(CASE WHEN @JobLocation !=''  THEN @JobLocation ELSE JobLocation END)
									 AND CompanyId=(CASE WHEN @CompanyId >0  THEN @CompanyId ELSE CompanyId END) 
				  DELETE FROM #TEMP
				  INSERT INTO #TEMP SELECT * FROM #TEMP2
				  DELETE FROM #TEMP2
			   END
	     ELSE
		    BEGIN
				   INSERT INTO #TEMP2 SELECT JPCAId,CandidateId, 'su' FROM VW_JPCADetail  
									 WHERE JobPostId=(CASE WHEN @JobPostId > 0 THEN @JobPostId ELSE JobPostId END)
									 AND JobLocation=(CASE WHEN @JobLocation !=''  THEN @JobLocation ELSE JobLocation END)
									 AND CompanyId=(CASE WHEN @CompanyId >0 THEN @CompanyId ELSE CompanyId END) 
				  DELETE FROM #TEMP
				  INSERT INTO #TEMP SELECT * FROM #TEMP2
				  DELETE FROM #TEMP2
				  
			   END


		   IF(@JPCAStatus > -1) 
			 BEGIN
				  INSERT INTO #TEMP2 SELECT a.JPCAId,CandidateId,QueryType + '-sts' FROM #TEMP a
				                           INNER JOIN VW_JPCAStatusDetail b ON (a.JPCAId=b.JPCAId)
									 WHERE b.JPCAStatus=(CASE WHEN @JPCAStatus > -1 THEN @JPCAStatus ELSE b.JPCAStatus END)
									       AND b.StatusVal=(CASE WHEN @JPCAStatus > -1 THEN 1 ELSE b.StatusVal END)
				  DELETE FROM #TEMP
				  INSERT INTO #TEMP SELECT * FROM #TEMP2
				  DELETE FROM #TEMP2
			END

			 IF(@FromDate IS NOT NULL OR @ToDate IS NOT NULL) 
			 BEGIN
			      IF @FromDate=null
				     SET @FromDate=GetDATE()-1000

				  IF @ToDate=null
				     SET @ToDate=GetDATE()

				  INSERT INTO #TEMP2 SELECT a.JPCAId,CandidateId,QueryType + '-date' FROM #TEMP a
				                           INNER JOIN VW_JPCAStatusDetail b ON (a.JPCAId=b.JPCAId)
									 WHERE b.DateVal  between @FromDate and @ToDate
				  DELETE FROM #TEMP
				  INSERT INTO #TEMP SELECT * FROM #TEMP2
				  DELETE FROM #TEMP2
			END


		--IF( @FromDate != null AND @JPCAStatus = -1)
		--   BEGIN
		--          INSERT INTO #TEMP2 SELECT a.JPCAId,QueryType + '-date both' FROM #TEMP a
		--		                           INNER JOIN VW_CandidatesReport b ON (a.JPCAId=b.JPCAId)
		--							WHERE  CandidateAssignedDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE GETDATE() + 100 END)
		--								OR	ValidatedBySPOCDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE ValidatedBySPOCDate END)
		--								OR	CandidateRejectedBySPOCDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE CandidateRejectedBySPOCDate END)
		--								OR	TurnUpDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE TurnUpDate END)
		--								OR	InterviewScheduledDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE InterviewScheduledDate END)
		--								OR	SecondRoundSheduledDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE SecondRoundSheduledDate END)
		--								OR	FinalRoundScheduledDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE FinalRoundScheduledDate END)
		--								OR	InterviewRejectedDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE InterviewRejectedDate END)
		--								OR	CandidateShortlistedDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE CandidateShortlistedDate END)
		--								OR	CandidateSelectedDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE CandidateSelectedDate END)
		--								OR	DocumentationPendingDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE DocumentationPendingDate END)
		--								OR	CandidateJoinedDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE CandidateJoinedDate END)
		--								OR	CandidateNotJoinedDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE CandidateNotJoinedDate END)
		--								OR	CandidateBackOutDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE CandidateBackOutDate END)
		--								OR	NRCDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE NRCDate END)
		--		  DELETE FROM #TEMP
		--		  INSERT INTO #TEMP SELECT * FROM #TEMP2
		--		  DELETE FROM #TEMP2
		--   END

		--IF( @ToDate != null)
		--   BEGIN
		--          INSERT INTO #TEMP2 SELECT a.JPCAId,QueryType + '-date Todate' FROM #TEMP a
		--		                           INNER JOIN VW_CandidatesReport b ON (a.JPCAId=b.JPCAId)
		--							WHERE  CandidateAssignedDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE CandidateAssignedDate END)
		--								OR	ValidatedBySPOCDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE ValidatedBySPOCDate END)
		--								OR	CandidateRejectedBySPOCDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE CandidateRejectedBySPOCDate END)
		--								OR	TurnUpDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE TurnUpDate END)
		--								OR	InterviewScheduledDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE InterviewScheduledDate END)
		--								OR	SecondRoundSheduledDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE SecondRoundSheduledDate END)
		--								OR	FinalRoundScheduledDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE FinalRoundScheduledDate END)
		--								OR	InterviewRejectedDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE InterviewRejectedDate END)
		--								OR	CandidateShortlistedDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE CandidateShortlistedDate END)
		--								OR	CandidateSelectedDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE CandidateSelectedDate END)
		--								OR	DocumentationPendingDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE DocumentationPendingDate END)
		--								OR	CandidateJoinedDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE CandidateJoinedDate END)
		--								OR	CandidateNotJoinedDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE CandidateNotJoinedDate END)
		--								OR	CandidateBackOutDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE CandidateBackOutDate END)
		--								OR	NRCDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE NRCDate END)
		--		  DELETE FROM #TEMP
		--		  INSERT INTO #TEMP SELECT * FROM #TEMP2
		--		  DELETE FROM #TEMP2
		--   END
	   
      SELECT DISTINCT a.*,b.QueryType
			 FROM VW_CandidatesReport a  INNER JOIN #TEMP b ON (a.CandidateId=b.CandidateId)

	  IF OBJECT_ID('tempdb..#TEMP') IS NOT NULL DROP TABLE #TEMP
	  IF OBJECT_ID('tempdb..#TEMP2') IS NOT NULL DROP TABLE #TEMP2
   END
 END








