----------------Used In  VIEW VW_JPCAStatusDetail-----------------------------

    CREATE FUNCTION fnJPCAStatus 
    (  
       @Name varchar(100)
    )  
    RETURNS VARCHAR(10)  
    AS  
        BEGIN 
		  DECLARE @Retn varchar(10)
		  If @Name='CandidateAssigned'	OR @Name='CandidateAssignedDate'
			SET @Retn= '0'
		 If @Name='ValidatedBySPOC'	OR @Name='ValidatedBySPOCDate'
		     SET @Retn= '1'
		 If @Name='CandidateRejectedBySPOC'	OR @Name='CandidateRejectedBySPOCDate'
		    SET @Retn= '2'
		 If @Name='TurnUps'	OR @Name='	TurnUpDate'
			SET @Retn= '3'
		 If @Name='InterviewScheduled'	OR @Name='InterviewScheduledDate'
			 SET @Retn= '4'
		 If @Name='SecondRoundSheduled'	OR @Name='SecondRoundSheduledDate'
			 SET @Retn= '5'
		 If @Name='FinalRoundScheduled'	OR @Name='FinalRoundScheduledDate'
			 SET @Retn= '6'
		 If @Name='InterviewRejected'	OR @Name='InterviewRejectedDate'
			 SET @Retn= '7'
		 If @Name='CandidateShortlisted'	OR @Name='CandidateShortlistedDate'
			 SET @Retn= '8'
		 If @Name='CandidateSelected'	OR @Name='CandidateSelectedDate'
			 SET @Retn= '9'
		 If @Name='DocumentationPending'	OR @Name='DocumentationPendingDate'
			 SET @Retn= '10'
		 If @Name='CandidateJoined'	OR @Name='CandidateJoinedDate'
			 SET @Retn= '11'
		 If @Name='CandidateNotJoined'	OR @Name='CandidateNotJoinedDate'
			 SET @Retn= '12'
		 If @Name='CandidateBackOut'	OR @Name='CandidateBackOutDate'
			 SET @Retn= '13'
		 If @Name='NRC'	OR @Name='NRCDate'
		   SET @Retn= '14'
 
       RETURN @Retn
	END  
----------------Used In  VIEW VW_JPCAStatusDetail-----------------------------