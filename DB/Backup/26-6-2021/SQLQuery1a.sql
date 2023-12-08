DECLARE @FromDate2 DateTime ,  @ToDate2 DateTime
SET @FromDate2=GetDate()-30
SET @ToDate2=GetDate()

Execute [Report_CandidateDetail] 
      @QueryType =4,
	  @RecruiterId =0,
	  @FranchiseId =0,
 	  @SpocAdminId =0,
	  @CompanyId =2,
	  @JobPostId =0,
	  @JobLocation  ='',
	  @JPCAStatus=0,
	  @FromDate = @FromDate2,
	  @ToDate=@ToDate2