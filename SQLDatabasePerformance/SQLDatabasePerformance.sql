USE master
GO

CREATE DATABASE PerformanceDB
GO

USE PerformanceDB
GO

CREATE TABLE Logs(
  LogId int NOT NULL IDENTITY, 
  LogText nvarchar(300),
  LogDate datetime
  )
  --Task 1

  INSERT INTO Logs(LogDate, LogText) 
  VALUES ('1990-01-01', 'Sample log ');

  DECLARE @Counter int = 0
WHILE (SELECT COUNT(*) FROM Logs) < 1000000
BEGIN
  INSERT INTO Logs(LogDate, LogText)
  SELECT DATEADD(MONTH, @Counter + 3, LogDate), LogText + 
  CONVERT(varchar, @Counter)
  FROM Logs
  SET @Counter = @Counter + 1
END

CHECKPOINT; DBCC DROPCLEANBUFFERS;


SELECT LogText FROM Logs WHERE LogDate 
		BETWEEN CONVERT(datetime, '1990-01-01') AND 
		CONVERT(datetime, '1995-01-01'); 


--Task 2

CREATE INDEX IDX_OnLogsDateColumn ON Logs(LogDate);

CHECKPOINT; DBCC DROPCLEANBUFFERS; 

SELECT LogText FROM Logs WHERE LogDate 
		BETWEEN CONVERT(datetime, '2013-07-19 11:59:21') AND 
		CONVERT(datetime, '2013-07-19 11:59:25');

--Task 3

CREATE FULLTEXT CATALOG LogsFullTextForLogText
WITH ACCENT_SENSITIVITY = OFF
	
CREATE FULLTEXT INDEX ON Logs(LogText)
KEY INDEX PK_Logs
ON LogsFullTextForLogText
WITH CHANGE_TRACKING AUTO

CHECKPOINT; DBCC DROPCLEANBUFFERS;
--Search from full text
SELECT * FROM Logs
WHERE LogText LIKE '% 1256789'

CHECKPOINT; DBCC DROPCLEANBUFFERS;
--Search from full text
SELECT * FROM Logs
WHERE CONTAINS(LogText,'1256789')