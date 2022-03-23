--INSERT INTO [Departments] (Title)
--VALUES
--('Physics'),
--('Chemistry'),
--('Info Tech'),
--('Low'),
--('Applied Maths')

MERGE [Departments] AS tgt  
    USING (SELECT * FROM (
    VALUES
    ('Physics'),
('Chemistry'),
('Info Tech'),
('Low'),
('Applied Maths')
     ) as src (Title)) as stds
    ON (tgt.Title = stds.Title)  
    WHEN NOT MATCHED THEN  
        INSERT (Title)  
        VALUES (stds.Title);