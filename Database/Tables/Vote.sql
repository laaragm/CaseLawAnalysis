CREATE TABLE [dbo].[Vote]
(
	[ID] BIGINT IDENTITY (1,1) NOT NULL,
    [Text] NVARCHAR(MAX) NULL,
	[JudmentDocument] BIGINT NULL,
	CONSTRAINT [PK_Vote] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_Vote_JudmentDocument] FOREIGN KEY ([JudmentDocument]) REFERENCES [JudmentDocument] ([ID]),
)
