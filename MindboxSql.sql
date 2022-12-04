--Не запускал, ибо нет развернутого MS SQL под рукой
CREATE TABLE Product
(
    Id int NOT NULL PRIMARY KEY,
    Title VARCHAR(1000) NOT NULL
);

CREATE TABLE Category
(
    Id int NOT NULL PRIMARY KEY,
    Description VARCHAR(1000) NOT NULL
);

CREATE TABLE ProductCategory
(
    ProductId int NOT NULL REFERENCES Product(Id),
    CategoryId int NOT NULL REFERENCES Category(Id),
    CONSTRAINT ProductCategory
           PRIMARY KEY (ProductId, CategoryId)
);

SELECT
    Product.Title,
    Category.Description
FROM Product
    LEFT JOIN ProductCategory on ProductCategory.ProductId = Product.Id
    LEFT JOIN Category on Category.Id = ProductCategory.CategoryId
