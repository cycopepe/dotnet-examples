USE tododb
GO

IF OBJECT_ID('Project', 'U') IS NOT NULL
  DROP TABLE Project
GO

CREATE TABLE Project
(
	ProjectId int NOT NULL,
	ProjectName nvarchar(200) NOT null
    CONSTRAINT ProjectPk PRIMARY KEY (ProjectId)
)
GO

IF OBJECT_ID('Task', 'U') IS NOT NULL
  DROP TABLE Task
GO

CREATE TABLE Task
(
	TaskId int NOT null,
	TaskName nvarchar(500) NOT null,
	TaskDescription nvarchar(Max) null,
	TaskStatus int NOT null,
	TaskProject int NOT null,
	CONSTRAINT TaskPk PRIMARY KEY (TaskId)
)
GO

IF OBJECT_ID('TaskStatus', 'U') IS NOT NULL
  DROP TABLE TaskStatus
GO

CREATE TABLE TaskStatus
(
	TaskStatusId int NOT null,
	TaskStatusName nvarchar(50) NOT null
    CONSTRAINT TaskStatusPk PRIMARY KEY (TaskStatusId)
)
GO

-- Add a new CHECK CONSTRAINT to the table
ALTER TABLE Task
	ADD CONSTRAINT TaskStatusFK FOREIGN	KEY (TaskStatus) REFERENCES	TaskStatus(TaskStatusId)
GO

ALTER TABLE Task
	ADD CONSTRAINT TaskProjectFK FOREIGN KEY (TaskProject) REFERENCES Project(ProjectId)
GO