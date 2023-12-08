ALTER Procedure tb_JobPostDetail
( 
   @QueryType int=0,
	@JobPostId int =0,
	@ClientId int =0,
	@ClientLocationId int =0,
	@JobTitle varchar(250) ='',
	@JobLocation varchar(250) ='',
	@JobCTC varchar(100) ='' ,
	@CompanyDescription varchar(max) ='',
	@JobDescription varchar(max) ='',
	@Qualification varchar(max) ='',
	@AdditionalInformation varchar(max) ='',
	@Industry varchar(250) ='',
	@IndustryId int =0,
	@Functional varchar(250) ='',
	@FunctionalId int =0,
	@ExperienceLevel int =0,
	@TypeOfEmployment int =0,
	@JDFileName varchar(100) ='',
	@ChecklistFileName varchar(100) ='',
	@JobPostStatus int =0,
	@JPCreatedBy int =0
)
  AS 
BEGIN
    IF(@QueryType=1)
	  BEGIN 
	    SELECT @JobPostId=ISNULL(MAX(JobPostId),0) +1 FROM JobPostDetail
	    INSERT INTO JobPostDetail (JobPostId,ClientId,ClientLocationId,JobTitle,JobLocation,JobCTC, CompanyDescription,JobDescription,Qualification,
		AdditionalInformation,Industry,IndustryId,Functional,FunctionalId,ExperienceLevel,TypeOfEmployment,JDFileName,ChecklistFileName,
		JobPostStatus,JPCreatedBy,JPCreatedOn) 
             VALUES (@JobPostId,@ClientId,@ClientLocationId,@JobTitle,@JobLocation,@JobCTC,@CompanyDescription,@JobDescription,@Qualification,
			 @AdditionalInformation,@Industry,@IndustryId,@Functional,@FunctionalId,@ExperienceLevel,@TypeOfEmployment,@JDFileName,@ChecklistFileName,
			 @JobPostStatus,@JPCreatedBy,GETDATE()) 
		 SELECT *   FROM JobPostDetail  WHERE JobPostId=@JobPostId
   	 END
   
   IF(@QueryType=2) 
      BEGIN 
	    UPDATE JobPostDetail SET 
	          ClientId=@ClientId,
			  ClientLocationId=@ClientLocationId,
			  JobTitle=@JobTitle,
			  JobLocation=@JobLocation,
			  JobCTC=@JobCTC,
			  CompanyDescription=@CompanyDescription,
			  JobDescription=@JobDescription,
			  Qualification=@Qualification,
			  AdditionalInformation=@AdditionalInformation,
			  Industry=@Industry,
			  IndustryId=@IndustryId,
			  Functional=@Functional,
			  FunctionalId=@FunctionalId,
			  ExperienceLevel=@ExperienceLevel,
			  TypeOfEmployment=@TypeOfEmployment,
			  JDFileName=@JDFileName,
			  ChecklistFileName=@ChecklistFileName,
			  JobPostStatus=@JobPostStatus,
			  JPUpdatedBy=@JPCreatedBy,
			  JPUpdatedOn=GETDATE()
       WHERE JobPostId=@JobPostId
	   SELECT *   FROM JobPostDetail  WHERE JobPostId=@JobPostId
   END

 
    IF(@QueryType =3)
	  BEGIN
         SELECT * FROM JobPostDetail  WHERE JobPostId=@JobPostId
      END

	IF(@QueryType=4)
     BEGIN
		 SELECT *, b.LocationName as ClientLocation, c.CompanyName as ClientName
		 --,(SELECT COUNT(1) FROM CompanyLocationDetail WHERE CompanyId= a.CompanyId AND CompLocStatus=1) AS TotalLocation
		 FROM JobPostDetail a 
		      INNER JOIN CompanyLocationDetail b on (a.ClientLocationId=b.CompLocId)
		      INNER JOIN CompanyDetail c on (b.CompanyId=c.CompanyId)
		 WHERE JobPostStatus in (0,1) AND a.JPCreatedBy=@JPCreatedBy
	 END

  IF(@QueryType=41)
     BEGIN
		 SELECT *, b.LocationName as ClientLocation, c.CompanyName as ClientName
		 FROM JobPostDetail a 
		      INNER JOIN CompanyLocationDetail b on (a.ClientLocationId=b.CompLocId)
		      INNER JOIN CompanyDetail c on (b.CompanyId=c.CompanyId)
		 WHERE JobPostStatus=@JobPostStatus 
		 ORDER BY a.JobPostId DESC
	 END

  IF(@QueryType=5)
     BEGIN
		 Update JobPostDetail SET JobPostStatus=@JobPostStatus,  JPUpdatedBy=@JPCreatedBy, JPUpdatedOn=GetDate()  WHERE JobPostId=@JobPostId
    END
END

