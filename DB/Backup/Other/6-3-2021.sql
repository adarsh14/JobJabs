

CREATE TABLE [dbo].[BlogPostDetail](
	[BlogPostId] [int] NULL,
	[BPHeader] varchar(200) NULL,
	[BPText] nvarchar(max)  NULL,
	[BPFileName] [varchar](100) NULL,
	[BPStatus] [int] NULL,
	[BPCreatedBy] [int] NULL,
	[BPCreatedOn] [datetime] NULL,
	[BPUpdatedBy] [int] NULL,
	[BPUpdatedOn] [datetime] NULL
) 

GO



ALTER Procedure [dbo].[tb_BlogPostDetail]
( 
	@QueryType int=0,
	@BlogPostId int=0,
	@BPHeader varchar(200)='',
	@BPText nvarchar(max)=null,
	@BPFileName varchar(100)='',
	@BPStatus int=0,
	@BPCreatedBy int=0

)
  AS 
BEGIN
    IF(@QueryType=1)
	  BEGIN 
	     SELECT @BlogPostId=ISNULL(MAX(BlogPostId),0) +1 FROM BlogPostDetail
	     INSERT INTO BlogPostDetail(BlogPostId,BPHeader,BPText,BPFileName,BPStatus,BPCreatedBy,BPCreatedOn) 
	     VALUES(@BlogPostId,@BPHeader,@BPText,@BPFileName,0,@BPCreatedBy,GETDATE())
		 SELECT *   FROM BlogPostDetail  WHERE BlogPostId=@BlogPostId
   	 END
   
   IF(@QueryType=2) 
      BEGIN 
	    UPDATE BlogPostDetail SET 
               BPHeader=(CASE WHEN  @BPHeader != '' THEN @BPHeader ELSE BPHeader END),
			   BPText=@BPText,
               BPFileName=(CASE WHEN  @BPFileName != '' THEN @BPFileName ELSE BPFileName END),
               BPUpdatedBy=(CASE WHEN  @BPCreatedBy != 0 THEN @BPCreatedBy ELSE BPCreatedBy END),
			   BPUpdatedOn=GetDate()
        WHERE BlogPostId=@BlogPostId
	    SELECT *   FROM BlogPostDetail  WHERE BlogPostId=@BlogPostId
   END

 
    IF(@QueryType =3)
	  BEGIN
         SELECT *   FROM BlogPostDetail  WHERE BlogPostId=@BlogPostId
      END

	IF(@QueryType=4)
     BEGIN
		  SELECT *   FROM BlogPostDetail  
		  WHERE BPStatus in (0,1) 
	 END

   IF(@QueryType=41)
     BEGIN
		  SELECT *   FROM BlogPostDetail  
		  WHERE BPStatus=@BPStatus
	 END

  IF(@QueryType=5)
     BEGIN
		 Update BlogPostDetail SET BPStatus=@BPStatus,  BPUpdatedBy=@BPCreatedBy, BPUpdatedOn=GetDate()  WHERE BlogPostId=@BlogPostId
    END
END

GO





