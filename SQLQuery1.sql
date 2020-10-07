DROP TABLE Admins;
CREATE TABLE Admins(
[Admin ID] INT IDENTITY (1,1) PRIMARY KEY,
[Admin Name] NVARCHAR(40),
[User ID] INT, 
FOREIGN KEY ([User ID]) REFERENCES Users([User ID]),
);

INSERT INTO Admins ([Admin Name]) 
VALUES ('Richard'),
('Nish'),
('Cathy');

SELECT * FROM Admins; 
