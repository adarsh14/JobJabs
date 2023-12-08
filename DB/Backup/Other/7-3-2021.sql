ALTER PROCEDURE [dbo].[Report_CandidateDetail](
      @QueryType int =0,
	  @RecruiterId int=0,
	  @FranchiseId int=0,
 	  @SpocAdminId int=0,
	  @CompanyId int=0,
	  @JobPostId int=0,
	  @JobLocation varchar(100) ='',
	  @JPCAStatus int=0,
	  @FromDate DateTime = null,
	  @ToDate DateTime=null
	)
	AS
	  BEGIN
	    IF(@QueryType=2)
	      BEGIN
		      EXECUTE dbo.Get_JobTitleLocByUserType	@RecruiterId,@FranchiseId,@SpocAdminId,@CompanyId
			  EXECUTE dbo.Get_ClientsByUserType	@RecruiterId,@FranchiseId,@SpocAdminId
		  END

	    IF(@QueryType=2)
	      BEGIN
			  DECLARE @QType varchar(100)
			  SET @QType = 'z'
			  IF OBJECT_ID('tempdb..#TEMP') IS NOT NULL DROP TABLE #TEMP
			  IF OBJECT_ID('tempdb..#TEMP2') IS NOT NULL DROP TABLE #TEMP2
    	  
		       SELECT TOP 1 JPCAId,  @QType  as QueryType  INTO #TEMP  
			   FROM VW_CandidatesReport  
			   SELECT * INTO #TEMP2 FROM #TEMP 
			   DELETE FROM #TEMP2
			   DECLARE @cntr int
			   SET @cntr=0

		   IF( @RecruiterId > 0) 
			 BEGIN
				  INSERT INTO #TEMP2 SELECT JPCAId, 'r' FROM VW_CandidatesReport  
									 WHERE RecruiterId=@RecruiterId  AND JobPostId=(CASE WHEN @JobPostId > 0 THEN @JobPostId ELSE JobPostId END)
									 AND JobLocation=(CASE WHEN @JobLocation !=''  THEN @JobLocation ELSE JobLocation END)
									 AND CompanyId=(CASE WHEN @CompanyId !=''  THEN @CompanyId ELSE CompanyId END) 
				  DELETE FROM #TEMP
				  INSERT INTO #TEMP SELECT * FROM #TEMP2
				  DELETE FROM #TEMP2
			END
		  ELSE IF( @FranchiseId > 0) 
			   BEGIN
				   INSERT INTO #TEMP2 SELECT JPCAId, 'f' FROM VW_CandidatesReport  
									 WHERE FranchiseId=@FranchiseId  AND JobPostId=(CASE WHEN @JobPostId > 0 THEN @JobPostId ELSE JobPostId END)
									 AND JobLocation=(CASE WHEN @JobLocation !=''  THEN @JobLocation ELSE JobLocation END)
									 AND CompanyId=(CASE WHEN @CompanyId !=''  THEN @CompanyId ELSE CompanyId END) 
				  INSERT INTO #TEMP SELECT * FROM #TEMP2
				  DELETE FROM #TEMP2
			   END
		  ELSE IF( @SpocAdminId > 0) 
			   BEGIN
				   INSERT INTO #TEMP2 SELECT JPCAId,'sp' FROM VW_CandidatesReport  
									 WHERE SpocAdminId=@SpocAdminId  AND JobPostId=(CASE WHEN @JobPostId > 0 THEN @JobPostId ELSE JobPostId END)
									 AND JobLocation=(CASE WHEN @JobLocation !=''  THEN @JobLocation ELSE JobLocation END)
									 AND CompanyId=(CASE WHEN @CompanyId !=''  THEN @CompanyId ELSE CompanyId END) 
				  DELETE FROM #TEMP
				  INSERT INTO #TEMP SELECT * FROM #TEMP2
				  DELETE FROM #TEMP2
			   END
	     ELSE
		    BEGIN
				   INSERT INTO #TEMP2 SELECT JPCAId, 'su' FROM VW_CandidatesReport  
									 WHERE JobPostId=(CASE WHEN @JobPostId > 0 THEN @JobPostId ELSE JobPostId END)
									 AND JobLocation=(CASE WHEN @JobLocation !=''  THEN @JobLocation ELSE JobLocation END)
									 AND CompanyId=(CASE WHEN @CompanyId !=''  THEN @CompanyId ELSE CompanyId END) 
				  DELETE FROM #TEMP
				  INSERT INTO #TEMP SELECT * FROM #TEMP2
				  DELETE FROM #TEMP2
			   END


		   IF(@JPCAStatus > -1) 
			 BEGIN
				  INSERT INTO #TEMP2 SELECT a.JPCAId,QueryType + '-sts' FROM #TEMP a
				                           INNER JOIN VW_CandidatesReport b ON (a.JPCAId=b.JPCAId)
									WHERE CandidateAssigned=(CASE WHEN @JPCAStatus = 0 THEN 1 ELSE CandidateAssigned END)
											AND ValidatedBySPOC=(CASE WHEN @JPCAStatus = 1 THEN 1 ELSE ValidatedBySPOC END)
											AND CandidateRejectedBySPOC=(CASE WHEN @JPCAStatus = 2 THEN 1 ELSE CandidateRejectedBySPOC END)
											AND ResumeSentToHR=(CASE WHEN @JPCAStatus = 3 THEN 1 ELSE ResumeSentToHR  END)
											AND InterviewScheduled=(CASE WHEN @JPCAStatus = 4 THEN 1 ELSE InterviewScheduled END)
											AND SecondRoundSheduled=(CASE WHEN @JPCAStatus = 5 THEN 1 ELSE SecondRoundSheduled END)
											AND FinalRoundScheduled=(CASE WHEN @JPCAStatus = 6 THEN 1 ELSE FinalRoundScheduled END)
											AND InterviewRejected=(CASE WHEN @JPCAStatus = 7 THEN 1 ELSE InterviewRejected END)
											AND CandidateShortlisted=(CASE WHEN @JPCAStatus = 8 THEN 1 ELSE CandidateShortlisted END)
											AND CandidateSelected=(CASE WHEN @JPCAStatus = 9 THEN 1 ELSE CandidateSelected END)
											AND DocumentationPending=(CASE WHEN @JPCAStatus = 10 THEN 1 ELSE DocumentationPending END)
											AND CandidateJoined=(CASE WHEN @JPCAStatus = 11 THEN 1 ELSE CandidateJoined END)
											AND CandidateNotJoined=(CASE WHEN @JPCAStatus = 12 THEN 1 ELSE CandidateNotJoined END)
											AND CandidateBackOut=(CASE WHEN @JPCAStatus = 13 THEN 1 ELSE CandidateBackOut END)
				  DELETE FROM #TEMP
				  INSERT INTO #TEMP SELECT * FROM #TEMP2
				  DELETE FROM #TEMP2
			END

		IF( @FromDate != null)
		   BEGIN
		          INSERT INTO #TEMP2 SELECT a.JPCAId,QueryType + '-date both' FROM #TEMP a
				                           INNER JOIN VW_CandidatesReport b ON (a.JPCAId=b.JPCAId)
									WHERE  CandidateAssignedDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE CandidateAssignedDate END)
										AND	ValidatedBySPOCDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE ValidatedBySPOCDate END)
										AND	CandidateRejectedBySPOCDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE CandidateRejectedBySPOCDate END)
										AND	ResumeSentToHRDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE ResumeSentToHRDate END)
										AND	InterviewScheduledDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE InterviewScheduledDate END)
										AND	SecondRoundSheduledDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE SecondRoundSheduledDate END)
										AND	FinalRoundScheduledDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE FinalRoundScheduledDate END)
										AND	InterviewRejectedDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE InterviewRejectedDate END)
										AND	CandidateShortlistedDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE CandidateShortlistedDate END)
										AND	CandidateSelectedDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE CandidateSelectedDate END)
										AND	DocumentationPendingDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE DocumentationPendingDate END)
										AND	CandidateJoinedDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE CandidateJoinedDate END)
										AND	CandidateNotJoinedDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE CandidateNotJoinedDate END)
										AND	CandidateBackOutDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE CandidateBackOutDate END)
				  DELETE FROM #TEMP
				  INSERT INTO #TEMP SELECT * FROM #TEMP2
				  DELETE FROM #TEMP2
		   END

		IF( @ToDate != null)
		   BEGIN
		          INSERT INTO #TEMP2 SELECT a.JPCAId,QueryType + '-date Todate' FROM #TEMP a
				                           INNER JOIN VW_CandidatesReport b ON (a.JPCAId=b.JPCAId)
									WHERE  CandidateAssignedDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE CandidateAssignedDate END)
										AND	ValidatedBySPOCDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE ValidatedBySPOCDate END)
										AND	CandidateRejectedBySPOCDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE CandidateRejectedBySPOCDate END)
										AND	ResumeSentToHRDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE ResumeSentToHRDate END)
										AND	InterviewScheduledDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE InterviewScheduledDate END)
										AND	SecondRoundSheduledDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE SecondRoundSheduledDate END)
										AND	FinalRoundScheduledDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE FinalRoundScheduledDate END)
										AND	InterviewRejectedDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE InterviewRejectedDate END)
										AND	CandidateShortlistedDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE CandidateShortlistedDate END)
										AND	CandidateSelectedDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE CandidateSelectedDate END)
										AND	DocumentationPendingDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE DocumentationPendingDate END)
										AND	CandidateJoinedDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE CandidateJoinedDate END)
										AND	CandidateNotJoinedDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE CandidateNotJoinedDate END)
										AND	CandidateBackOutDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE CandidateBackOutDate END)
				  DELETE FROM #TEMP
				  INSERT INTO #TEMP SELECT * FROM #TEMP2
				  DELETE FROM #TEMP2
		   END
	   
      SELECT *
			 FROM VW_CandidatesReport a  INNER JOIN #TEMP b ON (a.JPCAId=b.JPCAId)

	  IF OBJECT_ID('tempdb..#TEMP') IS NOT NULL DROP TABLE #TEMP
	  IF OBJECT_ID('tempdb..#TEMP2') IS NOT NULL DROP TABLE #TEMP2
   END
 END

