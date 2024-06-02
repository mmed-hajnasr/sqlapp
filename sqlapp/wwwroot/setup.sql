IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Products'))
BEGIN

CREATE TABLE Products
(
     ProductID int,
     ProductName varchar(1000),
     Quantity int
)

INSERT INTO Products VALUES (1, 'tiles', 100)
INSERT INTO Products VALUES (9, 'pre-prod', 130)
INSERT INTO Products VALUES (2, 'chairs', 200)
INSERT INTO Products VALUES (3, 'tables', 300)
INSERT INTO Products VALUES (4, 'brooms', 400)
INSERT INTO Products VALUES (5, 'toilets', 500)
END

