USE AppApi
GO

INSERT INTO Regions (Id,Code,Name,RegionImageUrl) VALUES (NEWID(),'R001','North Region','https://example.com/images/north-region.jpg')

SELECT *
FROM Regions;