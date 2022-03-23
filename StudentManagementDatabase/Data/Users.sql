--INSERT INTO [Users] (FirstName, LastName, Email, [Role])
--VALUES
--('Hakob', 'Aghajanyan', 'hakob.aghajanyan@ysu.am', 'student'),
--('Lilit', 'Hakobyan', 'lilit.hakobyan@ysu.am', 'student'),
--('Aram', 'Karapetyan','aram.karapetyan@ysu.am', 'student'),
--('Anahit', 'Martirosyan', 'anahit.martirosyan@ysu.am', 'professor'),
--('Vazgeb','Babayan','vazgen.babayan@ysu.am', 'student'),
--('Samvel', 'Khahcatryan', 'samvel.khachatryan@ysu.am','professor'),
--('Arsen', 'Abgaryan', 'arsen.abgaryan@ysu.am','professor')

MERGE [Users] AS tgt  
    USING (SELECT * FROM (
    VALUES
    ('Hakob', 'Aghajanyan', 'hakob.aghajanyan@ysu.am', 'student'),
    ('Lilit', 'Hakobyan', 'lilit.hakobyan@ysu.am', 'student'),
     ('Aram', 'Karapetyan','aram.karapetyan@ysu.am', 'student'),
    ('Anahit', 'Martirosyan', 'anahit.martirosyan@ysu.am', 'professor'),
    ('Vazgeb','Babayan','vazgen.babayan@ysu.am', 'student'),
    ('Samvel', 'Khahcatryan', 'samvel.khachatryan@ysu.am','professor'),
    ('Arsen', 'Abgaryan', 'arsen.abgaryan@ysu.am','professor')
     ) as src (FirstName,LastName, Email, [Role])) as stds
    ON (tgt.Email = stds.Email)  
    WHEN MATCHED THEN
        UPDATE SET tgt.FirstName = stds.FirstName, tgt.LastName = stds.LastName, tgt.[Role] = stds.[Role]  
    WHEN NOT MATCHED THEN  
        INSERT (FirstName,LastName, Email, [Role])  
        VALUES (stds.FirstName, stds.LastName, stds.Email, stds.[Role]);  