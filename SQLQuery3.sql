SELECT * FROM Overtime WHERE [Start time] = '14:00';
UPDATE Overtime SET [User ID] = 3 WHERE [Start time] = '14:00'; 
SELECT * FROM Overtime WHERE [Start time] = '14:00';

SELECT u.UserName, o.[User ID], o.[Start time], o.Day FROM Overtime o
INNER JOIN Users u ON u.[User ID] = o.[User ID]
WHERE o.[User ID] IS NOT NULL;


