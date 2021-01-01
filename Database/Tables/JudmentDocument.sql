CREATE TABLE [dbo].[JudmentDocument]
(
	[ID] BIGINT NOT NULL PRIMARY KEY,
    [ProcessNumber] BIGINT NULL,
    [JudmentText] NVARCHAR(MAX) NULL,
    [DecisionText] NVARCHAR(MAX) NULL,
    [Report] BIGINT NULL,
    [Minister] BIGINT NULL,
    [MinisterName] NVARCHAR(MAX) NULL,
    [RawText] NVARCHAR(MAX) NULL,
    CONSTRAINT [FK_JudmentDocument_Report] FOREIGN KEY ([Report]) REFERENCES [Report] ([ID]),
    CONSTRAINT [FK_JudmentDocument_Minister] FOREIGN KEY ([Minister]) REFERENCES [Minister] ([ID])
)
