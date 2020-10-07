CREATE TABLE [dbo].[Admins] (
    [Admin ID]    INT           IDENTITY (1, 1) NOT NULL,
    [Admin Name]  NVARCHAR (40) NULL,
    [User ID]     INT           NULL,
    [Overtime ID] INT           NULL,
    PRIMARY KEY CLUSTERED ([Admin ID] ASC),
    CONSTRAINT [FK_AdminUsers_UserID] FOREIGN KEY ([User ID]) REFERENCES [dbo].[Users] ([User ID]),
    CONSTRAINT [FK_AdminOvertime_OvertimeID] FOREIGN KEY ([Overtime ID]) REFERENCES [dbo].[Overtime] ([Overtime ID])
);

