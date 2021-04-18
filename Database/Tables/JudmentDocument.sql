CREATE TABLE [dbo].[JudmentDocument]
(
	[ID] BIGINT IDENTITY (1,1) NOT NULL,
    [ProcessNumber] BIGINT NULL,
    [JudmentText] NVARCHAR(MAX) NULL,
    [DecisionText] NVARCHAR(MAX) NULL,
    [ReportText] NVARCHAR(MAX) NULL,
    [Minister] BIGINT NULL,
    [MinisterName] NVARCHAR(MAX) NULL,
    [RawText] NVARCHAR(MAX) NULL,
    CONSTRAINT [PK_JudmentDocument] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_JudmentDocument_Minister] FOREIGN KEY ([Minister]) REFERENCES [Minister] ([ID])
)
