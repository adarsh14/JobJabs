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
		       UPDATE JPCAStatusDetail SET TurnUps=1, TurnUpDate=@StatusDate
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

