CREATE DATABASE Freelancing
GO

USE Freelancing
GO

CREATE TABLE UserRole (
	ID_Role INT PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
	RoleUser VARCHAR(100) NOT NULL
);
GO

CREATE TABLE UserTable (
	ID_User INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	LoginUser VARCHAR(100) NOT NULL,
	PasswordUser VARCHAR(100) NOT NULL,
	UserRole_ID INT NOT NULL REFERENCES UserRole(ID_Role) ON DELETE CASCADE
)
GO

CREATE TABLE Specialization (
	ID_Specialization INT PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
	NameSpecialization VARCHAR(100) NOT NULL
);
GO

CREATE TABLE ServiceTable (
	ID_Service INT PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
	NameService VARCHAR(100) NOT NULL,
	Specialization_ID INT NOT NULL REFERENCES Specialization(ID_Specialization) ON DELETE CASCADE
);
GO

CREATE TABLE StatusService (
	ID_StatusService INT PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
	ServiceStatus VARCHAR(100) NOT NULL
);
GO

CREATE TABLE Customer (
	ID_Customer INT PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
	FirstName VARCHAR(100) NOT NULL,
	SecondName VARCHAR(100) NOT NULL,
	MiddleName VARCHAR(100),
	UserID INT NOT NULL REFERENCES UserTable(ID_User) ON DELETE CASCADE,
	Service_ID INT NOT NULL REFERENCES ServiceTable(ID_Service) ON DELETE CASCADE
);
GO

CREATE TABLE Freelancer (
	ID_Freelancer INT PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
	FirstName VARCHAR(100) NOT NULL,
	SecondName VARCHAR(100) NOT NULL,
	MiddleName VARCHAR(100),
	ExperienceWork INT NOT NULL,
	UserID INT NOT NULL REFERENCES UserTable(ID_User) ON DELETE CASCADE,
	Service_ID INT NOT NULL REFERENCES ServiceTable(ID_Service) ON DELETE CASCADE
);
GO

CREATE TABLE Moderator (
	ID_Moderator INT PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
	FirstName VARCHAR(100) NOT NULL,
	SecondName VARCHAR(100) NOT NULL,
	MiddleName VARCHAR(100),
	UserID INT NOT NULL REFERENCES UserTable(ID_User) ON DELETE CASCADE
);
GO

CREATE TABLE Orders (
	ID_Orders INT PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
	NameOrder VARCHAR(100) NOT NULL,
	DesiredPrice DECIMAL NOT NULL,
	Freelancer_ID INT REFERENCES Freelancer(ID_Freelancer),
	Customer_ID INT NOT NULL REFERENCES Customer(ID_Customer),
	Moderator_ID INT REFERENCES Moderator(ID_Moderator),
	Service_ID INT NOT NULL REFERENCES ServiceTable(ID_Service) ON DELETE CASCADE,
	StatusService_ID INT NOT NULL REFERENCES StatusService(ID_StatusService) ON DELETE CASCADE
);
GO

--DROP TABLE Orders
--GO

INSERT INTO UserRole
VALUES
('Модератор'),
('Заказчик'),
('Фрилансер');
GO

INSERT INTO UserTable
VALUES
('admin', '123', 1),
('stepan', '1337', 2),
('saygex', '321', 3),
('moder338', '123', 1),
('lolnedota', '1337', 2),
('jaba', '321', 3),
('memedron', '123', 1),
('helper', '1337', 2),
('wannad13', '321', 3)
GO

INSERT INTO Specialization
VALUES
('Верстка'), -- сайт
('Базы данных'), -- программирование
('Логотипы') -- дизайн
GO

INSERT INTO ServiceTable
VALUES
('Сайт', 1),
('Программирование', 2),
('Дизайн', 3)
GO

INSERT INTO StatusService
VALUES
('На рассмотрении'),
('Взято в обработку'),
('Выполнено')
GO

INSERT INTO Customer 
VALUES
('Нинель', 'Коновалов', 'Тихонович', 2, 1),
('Вольдемар', 'Захаров', 'Авксентьевич', 5, 2),
('Станислав', 'Пестов', 'Андреевич', 8, 3)
GO

INSERT INTO Freelancer
VALUES
('Лука', 'Миронов', 'Пётрович', 5, 3, 1),
('Донат', 'Сафонов', 'Агафонович', 1, 6, 2),
('Дроздов', 'Артем', 'Валентинович', 12, 9, 3)
GO

INSERT INTO Moderator
VALUES
('Иннокентий', 'Красильников', 'Тарасович', 1),
('Людвиг', 'Лобанов', 'Леонидович', 4),
('Вадим', 'Кириллов', 'Миронович', 7)
GO

INSERT INTO Orders
VALUES 
('Нужна верстка сайта', 2000.00, 1, 1, 1, 1, 1),
('Нужно доделать БД', 10000.00, 2, 2, 2, 2, 1),
('Доработка логтипа (дизайн)', 2000.00, 3, 3, 3, 3, 1)
GO

-- USE master
--DROP DATABASE Freelancing
--GO