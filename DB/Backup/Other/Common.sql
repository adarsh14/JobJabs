 Create Table ExperienceLevelDetail
 ( 
ExperienceLevelId int null ,
ExperienceLevel varchar(250) null ,
ExpLevelStatus int null ,
ExpLevelCreatedBy int null ,
ExpLevelCreatedOn datetime null ,
ExpLevelUpdatedBy int null ,
ExpLevelUpdatedOn datetime null 
)
GO


Create Procedure tb_ExperienceLevelDetail
( 
    @QueryType int=0,
	@ExperienceLevelId int=0,
	@ExperienceLevel varchar(250)='',
	@ExpLevelStatus int=0,
	@ExpLevelCreatedBy int=0
)
  AS 
BEGIN
	IF(@QueryType=4)
     BEGIN
		 SELECT *
		 FROM ExperienceLevelDetail 
		 WHERE ExpLevelStatus=1 
	 END
END
GO


INSERT INTO ExperienceLevelDetail VALUES(1,'Associate',1,1,GETDATE(),null,null);
GO
INSERT INTO ExperienceLevelDetail VALUES(2,'Director',1,1,GETDATE(),null,null);
GO
INSERT INTO ExperienceLevelDetail VALUES(3,'Entry Level',1,1,GETDATE(),null,null);
GO
INSERT INTO ExperienceLevelDetail VALUES(4,'Executive',1,1,GETDATE(),null,null);
GO
INSERT INTO ExperienceLevelDetail VALUES(5,'Internship',1,1,GETDATE(),null,null);
GO
INSERT INTO ExperienceLevelDetail VALUES(6,'Mid Senior Level',1,1,GETDATE(),null,null);
GO
INSERT INTO ExperienceLevelDetail VALUES(7,'Not Applicable',1,1,GETDATE(),null,null);
GO



 Create Table EmploymentTypeDetail
 ( 
EmploymentTypeId int null ,
EmploymentType varchar(250) null ,
EmpTypeStatus int null ,
EmpTypeCreatedBy int null ,
EmpTypeCreatedOn datetime null ,
EmpTypeUpdatedBy int null ,
EmpTypeUpdatedOn datetime null 
)
GO

Create Procedure tb_EmploymentTypeDetail
( 
	@QueryType int=0,
	@EmploymentTypeId int=0,
	@EmploymentType varchar(250)='',
	@EmpTypeStatus int=0,
	@EmpTypeCreatedBy int=0
)
  AS 
BEGIN
	IF(@QueryType=4)
     BEGIN
		 SELECT *
		 FROM EmploymentTypeDetail 
		 WHERE EmpTypeStatus=1 
	 END
END
GO



INSERT INTO EmploymentTypeDetail VALUES(1,'Part-Time',1,1,GETDATE(),null,null);
GO
INSERT INTO EmploymentTypeDetail VALUES(2,'Contract',1,1,GETDATE(),null,null);
GO
INSERT INTO EmploymentTypeDetail VALUES(3,'Full-Time',1,1,GETDATE(),null,null);
GO
INSERT INTO EmploymentTypeDetail VALUES(4,'Interim',1,1,GETDATE(),null,null);
GO