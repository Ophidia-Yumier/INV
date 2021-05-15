	-- УДАЛЕНИЕ БАЗЫ И ТАБЛИЦ

USE MASTER;
DROP DATABASE [INVENTORY];

-----------------------------------------------------------------------------------
	-- СОЗДАНИЕ БАЗЫ

USE MASTER
CREATE DATABASE [INVENTORY]

-----------------------------------------------------------------------------------
	-- СОЗДАНИЕ ТАБЛИЦ


USE [INVENTORY];
CREATE TABLE [INV_USERS]
(
	[ID_INV_USERS]			INTEGER			NOT NULL IDENTITY (1,1),
	[LOGIN_INV_USERS]		VARCHAR(100)	NOT NULL,
	[PASSWORD_INV_USERS]	VARCHAR(100)	NOT NULL

	PRIMARY KEY ([ID_INV_USERS])
);

-----------------------------------------------------------------------------------

USE [INVENTORY];
CREATE TABLE [INV_FLOORS]
(
	[ID_INV_FLOORS]					INTEGER			NOT NULL IDENTITY (1,1),
	[NUMBER_INV_FLOORS]				VARCHAR(10)		NOT NULL,
	[SHORT_NAME_INV_FLOORS]			VARCHAR(50)		NOT NULL,
	[FULL_NAME_INV_FLOORS]			VARCHAR(100),
    [DESCRIPTION_NAME_INV_FLOORS]	VARCHAR(500),
	[HELP_NAME_INV_FLOORS]			VARCHAR(2000),
	[NOTE_INV_FLOORS]				VARCHAR(500),
	[LOG_INV_FLOORS]				VARCHAR(100)

	PRIMARY KEY ([ID_INV_FLOORS])
);

-----------------------------------------------------------------------------------

USE [INVENTORY]
CREATE TABLE [INV_ROOM_TYPES]
(
	[ID_INV_ROOM_TYPES]					INTEGER			NOT NULL IDENTITY (1,1),
	[SHORT_NAME_INV_ROOM_TYPES]			VARCHAR(50)		NOT NULL,
	[FULL_NAME_INV_ROOM_TYPES]			VARCHAR(100),
    [DESCRIPTION_NAME_INV_ROOM_TYPES]	VARCHAR(500),
	[HELP_NAME_INV_ROOM_TYPES]			VARCHAR(2000),
	[NOTE_INV_ROOM_TYPES]				VARCHAR(500),
	[LOG_INV_ROOM_TYPES]				VARCHAR(100)

	PRIMARY KEY ([ID_INV_ROOM_TYPES])
);

-----------------------------------------------------------------------------------

USE [INVENTORY]
CREATE TABLE [INV_ROOMS]
(
	[ID_INV_ROOMS]					INTEGER			NOT NULL IDENTITY (1,1),
	[NUMBER_INV_ROOMS]				VARCHAR(10)		NOT NULL,
	[SHORT_NAME_INV_ROOMS]			VARCHAR(50)		NOT NULL,
	[FULL_NAME_INV_ROOMS]			VARCHAR(100),
    [DESCRIPTION_NAME_INV_ROOMS]	VARCHAR(500),
	[HELP_NAME_INV_ROOMS]			VARCHAR(2000),
	[NOTE_INV_ROOMS]				VARCHAR(500),
	[FLOOR_INV_ROOMS_ID]			INTEGER			NOT NULL,
	[TYPE_INV_ROOMS_ID]				INTEGER			NOT NULL,
	[LOG_INV_ROOMS]					VARCHAR(100)

	PRIMARY KEY ([ID_INV_ROOMS]),
	FOREIGN KEY ([FLOOR_INV_ROOMS_ID]) REFERENCES [INV_FLOORS]		([ID_INV_FLOORS]),
	FOREIGN KEY ([TYPE_INV_ROOMS_ID])	REFERENCES [INV_ROOM_TYPES] ([ID_INV_ROOM_TYPES])
);

-----------------------------------------------------------------------------------
-----------------------------------------------------------------------------------
-----------------------------------------------------------------------------------

	-- ТРИГЕРЫ ДЛЯ ЛОГОВ НА АПДЕЙТ

USE [INVENTORY]
GO
CREATE OR ALTER TRIGGER [INV_FLOORS_LOG_UPDATE]
ON [INV_FLOORS]
AFTER UPDATE
AS
UPDATE [INV_FLOORS]
SET [LOG_INV_FLOORS] = ('TestLogin' + '_' + 'U' + '_' + CONVERT(varchar,SYSDATETIME()))
WHERE [ID_INV_FLOORS] = (SELECT [ID_INV_FLOORS] FROM inserted)

-----------------------------------------------------------------------------------

USE [INVENTORY]
GO
CREATE OR ALTER TRIGGER [INV_ROOM_TYPES_LOG_UPDATE]
ON [INV_ROOM_TYPES]
AFTER UPDATE
AS
UPDATE [INV_ROOM_TYPES]
SET [LOG_INV_ROOM_TYPES] = ('TestLogin' + '_' + 'U' + '_' + CONVERT(varchar,SYSDATETIME()))
WHERE [ID_INV_ROOM_TYPES] = (SELECT [ID_INV_ROOM_TYPES] FROM inserted)

-----------------------------------------------------------------------------------

USE [INVENTORY]
GO
CREATE OR ALTER TRIGGER [INV_ROOMS_LOG_UPDATE]
ON [INV_ROOMS]
AFTER UPDATE
AS
UPDATE [INV_ROOMS]
SET [LOG_INV_ROOMS] = ('TestLogin' + '_' + 'U' + '_' + CONVERT(varchar,SYSDATETIME()))
WHERE [ID_INV_ROOMS] = (SELECT [ID_INV_ROOMS] FROM inserted)

-----------------------------------------------------------------------------------
-----------------------------------------------------------------------------------
-----------------------------------------------------------------------------------

	-- ТРИГЕРЫ ДЛЯ ЛОГОВ НА ИНСЕРТ

USE [INVENTORY]
GO
CREATE OR ALTER TRIGGER [INV_FLOORS_LOG_INSERT]
ON [INV_FLOORS]
AFTER INSERT
AS
DISABLE TRIGGER [INV_FLOORS_LOG_UPDATE] ON [INV_FLOORS];
UPDATE [INV_FLOORS]
SET [LOG_INV_FLOORS] = ('TestLogin' + '_' + 'I' + '_' + CONVERT(varchar,SYSDATETIME()))
WHERE [ID_INV_FLOORS] = (SELECT [ID_INV_FLOORS] FROM inserted);
ENABLE TRIGGER [INV_FLOORS_LOG_UPDATE] ON [INV_FLOORS]

-----------------------------------------------------------------------------------

USE [INVENTORY]
GO
CREATE OR ALTER TRIGGER [INV_ROOM_TYPES_LOG_INSERT]
ON [INV_ROOM_TYPES]
AFTER INSERT
AS
DISABLE TRIGGER [INV_ROOM_TYPES_LOG_UPDATE] ON [INV_ROOM_TYPES];
UPDATE [INV_ROOM_TYPES]
SET [LOG_INV_ROOM_TYPES] = ('TestLogin' + '_' + 'I' + '_' + CONVERT(varchar,SYSDATETIME()))
WHERE [ID_INV_ROOM_TYPES] = (SELECT [ID_INV_ROOM_TYPES] FROM inserted);
ENABLE TRIGGER [INV_ROOM_TYPES_LOG_UPDATE] ON [INV_ROOM_TYPES]

-----------------------------------------------------------------------------------

USE [INVENTORY]
GO
CREATE OR ALTER TRIGGER [INV_ROOMS_LOG_INSERT]
ON [INV_ROOMS]
AFTER INSERT
AS
DISABLE TRIGGER [INV_ROOMS_LOG_UPDATE] ON [INV_ROOMS];
UPDATE [INV_ROOMS]
SET [LOG_INV_ROOMS] = ('TestLogin' + '_' + 'I' + '_' + CONVERT(varchar,SYSDATETIME()))
WHERE [ID_INV_ROOMS] = (SELECT [ID_INV_ROOMS] FROM inserted);
ENABLE TRIGGER [INV_ROOMS_LOG_UPDATE] ON [INV_ROOMS]

-----------------------------------------------------------------------------------
-----------------------------------------------------------------------------------
-----------------------------------------------------------------------------------

	-- ВНЕСЕНИЕ ДАННЫХ ДЛЯ ТЕСТА

INSERT INTO [INV_USERS] ([LOGIN_INV_USERS],[PASSWORD_INV_USERS]) 
VALUES ('TESTLOGIN',
		'TESTLOGIN');

-----------------------------------------------------------------------------------

INSERT INTO [INV_FLOORS] ([NUMBER_INV_FLOORS],[SHORT_NAME_INV_FLOORS],[FULL_NAME_INV_FLOORS],
							[DESCRIPTION_NAME_INV_FLOORS],[HELP_NAME_INV_FLOORS],[NOTE_INV_FLOORS]) 
VALUES ('F1',
		'Первый этаж',
		'Первый этаж здания',
		'Первый этаж тестового здания',
		'Первый этаж тестового здания, используется под основные помещения, лифты, склады, офисы, важнее этажей выше и необходимо в каждом здании',
		'Тестовое примечание об этаже №1');

		INSERT INTO [INV_FLOORS] ([NUMBER_INV_FLOORS],[SHORT_NAME_INV_FLOORS],[FULL_NAME_INV_FLOORS],
							[DESCRIPTION_NAME_INV_FLOORS],[HELP_NAME_INV_FLOORS],[NOTE_INV_FLOORS]) 
VALUES ('F2',
		'Второй этаж',
		'Второй этаж здания',
		'Второй этаж тестового здания',
		'Второй этаж тестового здания, используется под более важные помещения, лифты, офисы, залы заседаний и прочего, довольно важное',
		'Тестовое примечание об этаже №2');

-----------------------------------------------------------------------------------

		INSERT INTO [INV_ROOM_TYPES] ([SHORT_NAME_INV_ROOM_TYPES],[FULL_NAME_INV_ROOM_TYPES],
							[DESCRIPTION_NAME_INV_ROOM_TYPES],[HELP_NAME_INV_ROOM_TYPES],[NOTE_INV_ROOM_TYPES]) 
VALUES ('Тип №1',
		'Тестовый тип помещения №1',
		'Тестовый тип помещения №1 для теста',
		'Тестовый тип помещения №1 для проведения теста в программе',
		'Тестовое примечание о типе помещения №1');

				INSERT INTO [INV_ROOM_TYPES] ([SHORT_NAME_INV_ROOM_TYPES],[FULL_NAME_INV_ROOM_TYPES],
							[DESCRIPTION_NAME_INV_ROOM_TYPES],[HELP_NAME_INV_ROOM_TYPES],[NOTE_INV_ROOM_TYPES]) 
VALUES ('Тип №2',
		'Тестовый тип помещения №2',
		'Тестовый тип помещения №2 для теста',
		'Тестовый тип помещения №2 для проведения теста в программе',
		'Тестовое примечание о типе помещения №2');

-----------------------------------------------------------------------------------

		INSERT INTO [INV_ROOMS] ([NUMBER_INV_ROOMS],[SHORT_NAME_INV_ROOMS],[FULL_NAME_INV_ROOMS],
							[DESCRIPTION_NAME_INV_ROOMS],[HELP_NAME_INV_ROOMS],[NOTE_INV_ROOMS],[FLOOR_INV_ROOMS_ID],[TYPE_INV_ROOMS_ID]) 
VALUES ('F2R01',
		'Тестовый кабинет 1',
		'Тестовый кабинет F2R1',
		'Тестовый кабинет F2R1 для теста',
		'Тестовый кабинет F2R1 для теста в программе',
		'Тестовое примечание о кабинете',
		2,
		2);

				INSERT INTO [INV_ROOMS] ([NUMBER_INV_ROOMS],[SHORT_NAME_INV_ROOMS],[FULL_NAME_INV_ROOMS],
							[DESCRIPTION_NAME_INV_ROOMS],[HELP_NAME_INV_ROOMS],[NOTE_INV_ROOMS],[FLOOR_INV_ROOMS_ID],[TYPE_INV_ROOMS_ID]) 
VALUES ('F2R02',
		'Тестовый кабинет 2',
		'Тестовый кабинет F2R2',
		'Тестовый кабинет F2R2 для теста',
		'Тестовый кабинет F2R2 для теста в программе',
		'Тестовое примечание о кабинете',
		1,
		1);

-----------------------------------------------------------------------------------

SELECT * FROM [INV_FLOORS]
SELECT * FROM [INV_ROOM_TYPES]
SELECT * FROM [INV_ROOMS]

-----------------------------------------------------------------------------------
-----------------------------------------------------------------------------------
-----------------------------------------------------------------------------------
DELETE FROM [INV_ROOMS] WHERE [ID_INV_ROOMS]	 = 1;

DELETE FROM [INV_FLOORS] WHERE [ID_INV_FLOORS] = 1;
DELETE FROM [INV_FLOORS] WHERE [ID_INV_FLOORS] = 2;

DELETE FROM [INV_ROOM_TYPES] WHERE [ID_INV_ROOM_TYPES]	 = 1;

-----------------------------------------------------------------------------------

		INSERT INTO [INV_ROOMS] ([NUMBER_INV_ROOMS],[SHORT_NAME_INV_ROOMS],[FULL_NAME_INV_ROOMS],
							[DESCRIPTION_NAME_INV_ROOMS],[HELP_NAME_INV_ROOMS],[NOTE_INV_ROOMS],[FLOOR_INV_ROOMS_ID],[TYPE_INV_ROOMS_ID]) 
VALUES ('F2R0',
		'Тестовый кабинет',
		'Тестовый кабинет F2R0',
		'Тестовый кабинет F2R0 для теста',
		'Тестовый кабине F2R0 для теста в программе',
		'Тестовое примечание об этаже №2',
		3,
		2);

-----------------------------------------------------------------------------------

SELECT [LOGIN_INV_USERS] FROM [INV_USERS] WHERE ([PASSWORD_INV_USERS] = 'TEST1' AND [LOGIN_INV_USERS] = 'TEST1')