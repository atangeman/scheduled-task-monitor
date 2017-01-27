CREATE TABLE [dbo].[TaskInfo]
(
	 [TaskInfoId] INT NOT NULL PRIMARY KEY IDENTITY(0,1)
	,[TaskName] VARCHAR(30) NOT NULL
	,[TaskDescription] VARCHAR(50) NULL
	,[TaskGUID] VARCHAR(50) NOT NULL
	,[UserID] INT NOT NULL
	,[Date_Created] DateTime NOT NULL
)
