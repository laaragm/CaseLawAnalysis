CREATE TABLE [dbo].[Report]
(
	[ID] BIGINT NOT NULL PRIMARY KEY, 
    [Text] NVARCHAR(MAX) NULL, 
    [Minister] BIGINT NULL, 
    CONSTRAINT [FK_Report_Minister] FOREIGN KEY ([Minister]) REFERENCES [Report]([ID])
)
