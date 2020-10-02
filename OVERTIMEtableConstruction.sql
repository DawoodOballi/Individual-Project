DROP TABLE Overtime;
CREATE TABLE Overtime(
[User ID] INT,
[Day] NVARCHAR(40),
[Number of hours] INT,
[Start time] TIME,
dtStart_ddmmmyyyy as (REPLACE(CONVERT(VARCHAR(20), [Start time], 100), '', ''))
);

INSERT INTO Overtime ([Day], [Number of hours], [Start time]) 
VALUES 
('Monday', '4', '14:00'),
('Monday', '4', '22:00'),
('Monday', '8', '9:00'),
('Monday', '4', '11:00'),
('Monday', '12', '8:00'),
('Monday', '4', '1:00'),
('Monday', '6', '3:00'),
('Monday', '4', '6:00'),
('Monday', '8', '10:00'),

('Tuesday', '4', '14:00'),
('Tuesday', '4', '22:00'),
('Tuesday', '8', '9:00'),
('Tuesday', '4', '11:00'),
('Tuesday', '12', '8:00'),
('Tuesday', '4', '1:00'),
('Tuesday', '6', '3:00'),
('Tuesday', '4', '6:00'),
('Tuesday', '8', '10:00'),

('Wednesday', '4', '14:00'),
('Wednesday', '4', '22:00'),
('Wednesday', '8', '9:00'),
('Wednesday', '4', '11:00'),
('Wednesday', '12', '8:00'),
('Wednesday', '4', '1:00'),
('Wednesday', '6', '3:00'),
('Wednesday', '4', '6:00'),
('Wednesday', '8', '10:00'),

('Thursday', '4', '14:00'),
('Thursday', '4', '22:00'),
('Thursday', '8', '9:00'),
('Thursday', '4', '11:00'),
('Thursday', '12', '8:00'),
('Thursday', '4', '1:00'),
('Thursday', '6', '3:00'),
('Thursday', '4', '6:00'),
('Thursday', '8', '10:00'),

('Friday', '4', '14:00'),
('Friday', '4', '22:00'),
('Friday', '8', '9:00'),
('Friday', '4', '11:00'),
('Friday', '12', '8:00'),
('Friday', '4', '1:00'),
('Friday', '6', '3:00'),
('Friday', '4', '6:00'),
('Friday', '8', '10:00');

SELECT * FROM Overtime;