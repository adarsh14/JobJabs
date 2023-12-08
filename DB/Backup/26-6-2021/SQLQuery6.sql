


----------------Used In  PROCEDURE [dbo].[Report_CandidateDetail]-------
CREATE VIEW VW_JPCAStatusDetail
 AS  
  (  
    SELECT tb1.JPCAId,tb1.JPCAStatus as JPCAStatus,tb1.StatusVal,tb2.DateVal
	FROM (
		 SELECT JPCAId,dbo.fnJPCAStatus(JPCAStatus) as JPCAStatus,StatusVal
		 FROM JPCAStatusDetail
			UNPIVOT
			(
				StatusVal
				FOR [JPCAStatus] IN ([CandidateAssigned], [ValidatedBySPOC], [CandidateRejectedBySPOC], [TurnUps], [InterviewScheduled], 
					[SecondRoundSheduled], [FinalRoundScheduled], [InterviewRejected], [CandidateShortlisted], [CandidateSelected],
					[DocumentationPending], [CandidateJoined], [CandidateNotJoined], [CandidateBackOut], [NRC])
			
			) AS P
		)tb1
     INNER JOIN
	 (
		 SELECT JPCAId,dbo.fnJPCAStatus(JPCADate) as JPCAStatus, DateVal
		 FROM JPCAStatusDetail
			   UNPIVOT
				(
					DateVal
					FOR [JPCADate] IN ([CandidateAssignedDate],[ValidatedBySPOCDate], [CandidateRejectedBySPOCDate], [TurnUpDate], [InterviewScheduledDate], [SecondRoundSheduledDate],
							[FinalRoundScheduledDate], [InterviewRejectedDate], [CandidateShortlistedDate], [CandidateSelectedDate], [DocumentationPendingDate], [CandidateJoinedDate], 
							[CandidateNotJoinedDate], [CandidateBackOutDate], [NRCDate])
				) AS P
     )tb2 ON (tb1.JPCAId=tb2.JPCAId AND  tb1.JPCAStatus=tb2.JPCAStatus)

)  
----------------Used In  PROCEDURE [dbo].[Report_CandidateDetail]-------





