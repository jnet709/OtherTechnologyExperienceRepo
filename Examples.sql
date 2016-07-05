Example 1: Select all records from the Contact table so that all first names starting with substring like ‘jo’:

Select * from Contact where FirstName like ‘jo%’

Example 2: I use MS SQL Server to add a new data table named "Contact"
	
	SET QUOTED_IDENTIFIER ON
	GO

	CREATE TABLE [dbo].[Contact](
		[ContactId] [bigint] IDENTITY(1,1) NOT NULL,
		[FirstName] [nvarchar](50) NOT NULL,
		[LastName] [nvarchar](50) NOT NULL,
		[Email] [nvarchar](100) NULL,
		[UpdatedDate] [datetime] NOT NULL,
		[AvatarId] [bigint] NULL,
	 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
	(
		ContactId ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GO

	ALTER TABLE [dbo].[Contact] ADD  DEFAULT (getdate()) FOR [UpdatedDate]
	GO

	ALTER TABLE [dbo].[Contact]  WITH CHECK ADD  CONSTRAINT [FK_Contact_AvatarId] FOREIGN KEY([AvatarId])
	REFERENCES [dbo].[Avatar] ([AvatarId])
	GO

	ALTER TABLE [dbo].[Contact] CHECK CONSTRAINT [FK_Contact_AvatarId]
	GO

Example 3: insert a column named “BirthDate” into existing table “Contact” (example 2). The value for that column is optional or nullable:

Alter table Contact add BirthDate datetime null
