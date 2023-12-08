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
	 IF(@QueryType=3)
	  BEGIN 
   	    SELECT JPCAComment FROM JPCACommentDetail WHERE [JPCAJobPostId]=@JobPostId AND [JPCACandidateId]=@CandidateId 
		         AND [JPCARecruiterId]=@RecruiterId AND [JPCAFranchiseId]=@FranchiseId
	END
END


