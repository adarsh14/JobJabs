ALTER PROCEDURE [dbo].[Report_CandidateDetailFilter](
      @QueryType int =0,
	  @RecruiterId int=0,
	  @FranchiseId int=0,
	  @SpocAdminId int=0,
	  @CompanyId int=0,
	  @JobPostId int=0,
	  @JobLocation varchar(100) =''
	)
	AS
	  BEGIN
	     IF(@QueryType=1)
	      BEGIN
			  EXECUTE dbo.Get_FranchiseByUserType @RecruiterId,@FranchiseId,@SpocAdminId
		  END

	  IF(@QueryType=2)
	      BEGIN
			  EXECUTE dbo.Get_ClientsByUserType	@RecruiterId,@FranchiseId,@SpocAdminId
		  END

    IF(@QueryType=3)
	      BEGIN
			  EXECUTE dbo.Get_JobLocByClientAndUserType	@RecruiterId,@FranchiseId,@SpocAdminId,@CompanyId
		  END
	
	IF(@QueryType=4)
	      BEGIN
			  EXECUTE dbo.Get_JobTitleByJobLocAndUserType @RecruiterId,@FranchiseId,@SpocAdminId,@CompanyId,@JobLocation
		  END
 END








