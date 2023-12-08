ALTER Table [JPCAStatusDetail]
Add [NRC] [int] NULL DEFAULT 0
GO

ALTER Table [JPCAStatusDetail]
Add		[NRCDate] [DateTime] NULL
GO

ALTER Procedure [dbo].[tb_JPCAStatusDetail]
(
@QueryType int=0,
@JPCAId int=0,
@JPCAStatus int=0,
@StatusDate DateTime= NULL
) 
AS
 BEGIN
    IF(@QueryType=1)
	  BEGIN 
		 INSERT INTO JPCAStatusDetail(JPCAId,CandidateAssigned,CandidateAssignedDate)
		 VALUES (@JPCAId,@JPCAStatus,@StatusDate)
	  END

  IF(@QueryType=5)
     BEGIN
        
		 IF(@JPCAStatus=1)
			BEGIN 
			   UPDATE JPCAStatusDetail  SET  ValidatedBySPOC=1, ValidatedBySPOCDate=@StatusDate 
			   WHERE JPCAId=@JPCAId 
		   END

	    IF(@JPCAStatus=2)
		   BEGIN 
		       UPDATE JPCAStatusDetail SET CandidateRejectedBySPOC=1, CandidateRejectedBySPOCDate=@StatusDate 
			   WHERE JPCAId=@JPCAId 
		END

	   IF(@JPCAStatus=3)
		   BEGIN 
		       UPDATE JPCAStatusDetail SET ResumeSentToHR=1, ResumeSentToHRDate=@StatusDate
			   WHERE JPCAId=@JPCAId 
		   END

	   IF(@JPCAStatus=4)
		  BEGIN 
		       UPDATE JPCAStatusDetail SET InterviewScheduled=1, InterviewScheduledDate=@StatusDate
			   WHERE JPCAId=@JPCAId 
		  END

	   IF(@JPCAStatus=5)
		   BEGIN 
		        UPDATE JPCAStatusDetail SET SecondRoundSheduled=1,SecondRoundSheduledDate=@StatusDate
		        WHERE JPCAId=@JPCAId 
		   END

	   IF(@JPCAStatus=6)
		   BEGIN 
		        UPDATE JPCAStatusDetail	 SET FinalRoundScheduled=1, FinalRoundScheduledDate=@StatusDate
		        WHERE JPCAId=@JPCAId 
		   END

	   IF(@JPCAStatus=7)
		   BEGIN 
		        UPDATE JPCAStatusDetail	 SET InterviewRejected=1, InterviewRejectedDate=@StatusDate
		        WHERE JPCAId=@JPCAId 
		   END

	   IF(@JPCAStatus=8)
		  BEGIN 
		        UPDATE JPCAStatusDetail SET CandidateShortlisted=1, CandidateShortlistedDate=@StatusDate
		        WHERE JPCAId=@JPCAId 
		   END

	   IF(@JPCAStatus=9)
		  BEGIN 
		        UPDATE JPCAStatusDetail SET CandidateSelected=1, CandidateSelectedDate=@StatusDate
		        WHERE JPCAId=@JPCAId 
		  END

	   IF(@JPCAStatus=10)
		  BEGIN 
		        UPDATE JPCAStatusDetail SET DocumentationPending=1, DocumentationPendingDate=@StatusDate
		        WHERE JPCAId=@JPCAId 
		  END

	    IF(@JPCAStatus=11)
	  	   BEGIN 
		        UPDATE JPCAStatusDetail SET CandidateJoined=1, CandidateJoinedDate=@StatusDate
		        WHERE JPCAId=@JPCAId 
		   END

  	   IF(@JPCAStatus=12)
		   BEGIN 
		        UPDATE JPCAStatusDetail	 SET CandidateNotJoined=1, CandidateNotJoinedDate=@StatusDate
		        WHERE JPCAId=@JPCAId 
		   END

	    IF(@JPCAStatus=13)
		   BEGIN 
		       UPDATE JPCAStatusDetail SET CandidateBackOut=1, CandidateBackOutDate=@StatusDate
		       WHERE JPCAId=@JPCAId 
		   END

		  IF(@JPCAStatus=14)
		   BEGIN 
		       UPDATE JPCAStatusDetail SET NRC=1, NRCDate=@StatusDate
		       WHERE JPCAId=@JPCAId 
		   END

   END
 END
 GO


 ALTER VIEW VW_CandidatesReport
 AS  
  (  
      SELECT  a.*,b.JPCAId, b.JobPostId, b.FranchiseId,b.RecruiterId,b.JPCAStatus,c.FranchiseName, d.Firstname + ' ' + d.Lastname as RecruiterName,
              e.JobTitle,e.JobLocation, e.ClientLocationId, e.JPCreatedBy as SpocAdminId, f.CompanyId, f.LocationName as ClientLocation, g.CompanyName as ClientName,
			Isnull(h.CandidateAssigned,0) AS CandidateAssigned,
			Isnull(h.ValidatedBySPOC,0) AS ValidatedBySPOC,
			Isnull(h.CandidateRejectedBySPOC,0) AS CandidateRejectedBySPOC,
			Isnull(h.ResumeSentToHR,0) AS ResumeSentToHR,
			Isnull(h.InterviewScheduled,0) AS InterviewScheduled,
			Isnull(h.SecondRoundSheduled,0) AS SecondRoundSheduled,
			Isnull(h.FinalRoundScheduled,0) AS FinalRoundScheduled,
			Isnull(h.InterviewRejected,0) AS InterviewRejected,
			Isnull(h.CandidateShortlisted,0) AS CandidateShortlisted,
			Isnull(h.CandidateSelected,0) AS CandidateSelected,
			Isnull(h.DocumentationPending,0) AS DocumentationPending,
			Isnull(h.CandidateJoined,0) AS CandidateJoined,
			Isnull(h.CandidateNotJoined,0) AS CandidateNotJoined,
			Isnull(h.CandidateBackOut,0) AS CandidateBackOut,
			Isnull(h.NRC,0) AS NRC,
			CandidateAssignedDate,
			ValidatedBySPOCDate,
			CandidateRejectedBySPOCDate,
			ResumeSentToHRDate,
			InterviewScheduledDate,
			SecondRoundSheduledDate,
			FinalRoundScheduledDate,
			InterviewRejectedDate,
			CandidateShortlistedDate,
			CandidateSelectedDate,
			DocumentationPendingDate,
			CandidateJoinedDate,
			CandidateNotJoinedDate,
			CandidateBackOutDate,
			NRCDate
     FROM  CandidateDetail a INNER JOIN JobPostCandidateDetail b on (a.CandidateId=b.CandidateId)
			 INNER JOIN FranchiseDetail c ON (b.FranchiseId=c.FranchiseId)
	         INNER JOIN UserDetail d on (b.RecruiterId=d.UserId)
			 INNER JOIN JobPostDetail e on (b.JobPostId=e.JobPostId)
			 INNER JOIN CompanyLocationDetail f on (e.ClientLocationId=f.CompLocId)  
             INNER JOIN CompanyDetail g on (f.CompanyId=g.CompanyId)  
			 INNER JOIN JPCAStatusDetail h on (b.JPCAId=h.JPCAId)
)  
  GO

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
											AND NRC=(CASE WHEN @JPCAStatus = 14 THEN 1 ELSE NRC END)
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
										AND	NRCDate >= (CASE WHEN @FromDate != null THEN @FromDate ELSE NRCDate END)
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
										AND	NRCDate <= (CASE WHEN @ToDate != null THEN @ToDate ELSE NRCDate END)
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
 GO

 ALTER VIEW [dbo].[VWJobPostCandidateDetail]  
  AS  
  (  
     SELECT a.JobPostId, a.JobPostStatus, a.JPCreatedBy,  
           Isnull(jp.CandidateAssigned,0) AS CandidateAssigned,
			Isnull(jp.ValidatedBySPOC,0) AS ValidatedBySPOC,
			Isnull(jp.CandidateRejectedBySPOC,0) AS CandidateRejectedBySPOC,
			Isnull(jp.ResumeSentToHR,0) AS ResumeSentToHR,
			Isnull(jp.InterviewScheduled,0) AS InterviewScheduled,
			Isnull(jp.SecondRoundSheduled,0) AS SecondRoundSheduled,
			Isnull(jp.FinalRoundScheduled,0) AS FinalRoundScheduled,
			Isnull(jp.InterviewRejected,0) AS InterviewRejected,
			Isnull(jp.CandidateShortlisted,0) AS CandidateShortlisted,
			Isnull(jp.CandidateSelected,0) AS CandidateSelected,
			Isnull(jp.DocumentationPending,0) AS DocumentationPending,
			Isnull(jp.CandidateJoined,0) AS CandidateJoined,
			Isnull(jp.CandidateNotJoined,0) AS CandidateNotJoined,
			Isnull(jp.CandidateBackOut,0) AS CandidateBackOut,
			Isnull(jp.NRC,0) AS NRC
     FROM JobPostDetail a   
      LEFT OUTER JOIN (  
					     SELECT JobPostId,    
							SUM(CASE WHEN  CandidateAssigned = 1 THEN 1 ELSE 0 END ) AS CandidateAssigned,
							SUM(CASE WHEN  ValidatedBySPOC = 1 THEN 1 ELSE 0 END ) AS ValidatedBySPOC,
							SUM(CASE WHEN  CandidateRejectedBySPOC = 1 THEN 1 ELSE 0 END ) AS CandidateRejectedBySPOC,
							SUM(CASE WHEN  ResumeSentToHR = 1 THEN 1 ELSE 0 END ) AS ResumeSentToHR,
							SUM(CASE WHEN  InterviewScheduled = 1 THEN 1 ELSE 0 END ) AS InterviewScheduled,
							SUM(CASE WHEN  SecondRoundSheduled = 1 THEN 1 ELSE 0 END ) AS SecondRoundSheduled,
							SUM(CASE WHEN  FinalRoundScheduled = 1 THEN 1 ELSE 0 END ) AS FinalRoundScheduled,
							SUM(CASE WHEN  InterviewRejected = 1 THEN 1 ELSE 0 END ) AS InterviewRejected,
							SUM(CASE WHEN  CandidateShortlisted = 1 THEN 1 ELSE 0 END ) AS CandidateShortlisted,
							SUM(CASE WHEN  CandidateSelected = 1 THEN 1 ELSE 0 END ) AS CandidateSelected,
							SUM(CASE WHEN  DocumentationPending = 1 THEN 1 ELSE 0 END ) AS DocumentationPending,
							SUM(CASE WHEN  CandidateJoined = 1 THEN 1 ELSE 0 END ) AS CandidateJoined,
							SUM(CASE WHEN  CandidateNotJoined = 1 THEN 1 ELSE 0 END ) AS CandidateNotJoined,
							SUM(CASE WHEN  CandidateBackOut = 1 THEN 1 ELSE 0 END ) AS CandidateBackOut,
							SUM(CASE WHEN  NRC = 1 THEN 1 ELSE 0 END ) AS NRC
						  FROM   
							   JobPostCandidateDetail jprc  INNER JOIN JPCAStatusDetail jpst ON (jprc.JPCAId=jpst.JPCAId)
						  GROUP BY  JobPostId    
                 ) jp ON a.JobPostId=jp.JobPostId 
 )  
 GO

 ALTER PROCEDURE Get_JobTitleLocByUserType(
	@RecruiterId int=0,
    @FranchiseId int=0,
	@SpocAdminId int=0,
	@JobPostId int=0,
	@ClientId int=0
)
AS
  BEGIN
     IF(@RecruiterId > 0)
	   BEGIN
	      SELECT DISTINCT a.JobPostId as [Value],JobTitle as [Text] 
		  FROM JobPostDetail a
		       INNER JOIN JobPostRecruiterDetail b on (a.JobPostId=b.JobPostId)
		  WHERE b.RecruiterId=@RecruiterId  AND a.ClientId=(CASE WHEN @ClientId > 0 THEN @ClientId ELSE ClientId END)

		  SELECT DISTINCT JobLocation as [Text] 
		  FROM JobPostDetail a
		       INNER JOIN JobPostRecruiterDetail b on (a.JobPostId=b.JobPostId)
		  WHERE b.RecruiterId=@RecruiterId  AND a.ClientId=(CASE WHEN @ClientId > 0 THEN @ClientId ELSE ClientId END)
	   END
	ELSE IF(@FranchiseId > 0)
	   BEGIN
	      SELECT DISTINCT a.JobPostId as [Value],JobTitle as [Text] 
		  FROM JobPostDetail a
		  INNER JOIN JobPostFranchiseDetail b on (a.JobPostId=b.JobPostId)
		  WHERE b.FranchiseId=@FranchiseId AND a.ClientId=(CASE WHEN @ClientId > 0 THEN @ClientId ELSE ClientId END)

		  SELECT DISTINCT JobLocation as [Text] 
		  FROM JobPostDetail a
		  INNER JOIN JobPostFranchiseDetail b on (a.JobPostId=b.JobPostId)
		  WHERE b.FranchiseId=@FranchiseId AND a.ClientId=(CASE WHEN @ClientId > 0 THEN @ClientId ELSE ClientId END)
	   END
	ELSE IF(@SpocAdminId > 0)
	   BEGIN
	      SELECT DISTINCT a.JobPostId as [Value],JobTitle as [Text] 
		  FROM  JobPostDetail a
		  WHERE a.JPCreatedBy=@SpocAdminId AND a.ClientId=(CASE WHEN @ClientId > 0 THEN @ClientId ELSE ClientId END)

		   SELECT DISTINCT JobLocation as [Text] 
		  FROM  JobPostDetail a
		  WHERE a.JPCreatedBy=@SpocAdminId AND a.ClientId=(CASE WHEN @ClientId > 0 THEN @ClientId ELSE ClientId END)
	   END
	 ELSE
	   BEGIN
	     SELECT DISTINCT a.JobPostId as [Value],JobTitle as [Text] 
		 FROM  JobPostDetail a
		 WHERE a.ClientId=(CASE WHEN @ClientId > 0 THEN @ClientId ELSE ClientId END)

		  SELECT DISTINCT JobLocation as [Text] 
		 FROM  JobPostDetail a
		 WHERE a.ClientId=(CASE WHEN @ClientId > 0 THEN @ClientId ELSE ClientId END)
	   END
   END

   





