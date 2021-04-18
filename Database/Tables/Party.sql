CREATE TABLE [dbo].[Party]
(
	[ID] BIGINT IDENTITY (1,1) NOT NULL,
    [Name] NVARCHAR(MAX) NULL, 
    [Type] NVARCHAR(MAX) NULL,
    [JudmentDocument] BIGINT NULL,
    CONSTRAINT [PK_Party] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_Party_JudmentDocument] FOREIGN KEY ([JudmentDocument]) REFERENCES [JudmentDocument] ([ID]),
)
