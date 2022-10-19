USE TutorialDB
GO
IF NOT EXISTS (
 SELECT name
 FROM sys.databases
 WHERE name = N'TutorialDB'
)
 CREATE DATABASE [TutorialDB];
GO
IF SERVERPROPERTY('ProductVersion') > '12'
 ALTER DATABASE [TutorialDB] SET QUERY_STORE=ON;
GO

IF OBJECT_ID('dbo.Department', 'U') IS NOT NULL
 DROP TABLE dbo.Department
GO

CREATE TABLE dbo.Department
(
 ID int NOT NULL PRIMARY KEY,
 NAME VARCHAR(100) NOT NULL
);

INSERT INTO dbo.Department
 ([ID], [NAME])
VALUES
 (1, 'First'),
 (2, 'Second'),
 (3, 'Third')
GO

IF OBJECT_ID('dbo.Employee', 'U') IS NOT NULL
 DROP TABLE dbo.Employee
GO

CREATE TABLE dbo.Employee
(
    ID int NOT NULL PRIMARY KEY,
    DEPARTMENT_ID int NOT NULL,
    CHIEF_ID int NOT NULL,
    NAME VARCHAR(100) NOT NULL,
    SALARY int NOT NULL
);

INSERT INTO dbo.Employee
 ([ID], [DEPARTMENT_ID], [CHIEF_ID], [NAME], [SALARY])
VALUES
 (1, 1, 1, 'Роман', 60000),
 (2, 1, 1, 'Ровалий', 75000),
 (3, 1, 1, 'Алексей', 65000),
 (4, 2, 4, 'Алиса', 45000),
 (5, 2, 4, 'Ольга', 80000),
 (6, 2, 4, 'Рокан', 75000),
 (7, 3, 7, 'Рулий', 70000),
 (8, 3, 7, 'Роджер', 100000),
 (9, 3, 7, 'Мария', 40000)
GO

SELECT * FROM dbo.Department;
SELECT * FROM dbo.Employee;


--ЗАПРОСЫ
--1. Вывод сотрудника с максимальной заработной платой.
SELECT * FROM dbo.Employee
WHERE SALARY = (select MAX(SALARY) FROM dbo.Employee)

--2. Вывод отдела с самой высокой заработной платой между сотрудниками.
SELECT DEPARTMENT_ID
FROM dbo.Employee
WHERE SALARY = (select MAX(SALARY) from dbo.Employee); 

--3. Вывод отдела с самой высокой суммарной зарплатой сотрудников.
SELECT DEPARTMENT_ID, Sum(SALARY) AS [Sum-Salary] FROM dbo.Employee GROUP BY DEPARTMENT_ID
HAVING Sum(SALARY) >= ALL(
    SELECT Sum(SALARY) AS [Sum-Salary] FROM dbo.Employee GROUP BY DEPARTMENT_ID
);

--4. Вывод сотрудника, чье имя начинается на "Р" и заканчивается на "н".
SELECT * FROM dbo.Employee WHERE UPPER(NAME) like 'Р%н';