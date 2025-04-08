USE FamilyTreeDB;

--יצירת דאטה בייס

 CREATE DATABASE FamilyDB

--יצירת טבלת אנשים

  CREATE TABLE MyPerson(
   Person_Id INT PRIMARY KEY IDENTITY(1,1) ,
   Personal_Name VARCHAR(30),
   Family_Name VARCHAR(20),
   Gender VARCHAR(6) CHECK (Gender IN ('male' , 'female')) NOT NULL,
   Father_Id INT ,
   Mother_Id INT,
   Spouse_Id INT
)

--יצירת טבלת עץ משפחה
CREATE TABLE FamilyTree(
  Id INT PRIMARY KEY IDENTITY(1,1),
  Person_Id INT NOT NULL,FOREIGN KEY (Person_Id) REFERENCES MyPerson (Person_Id),
  Relative_Id INT NOT NULL,FOREIGN KEY (Relative_Id) REFERENCES MyPerson (Person_Id),
  Connection_Type VARCHAR(10) CHECK (Connection_Type IN ('father','mother','sister','brother','son','daughter','spouse_male','spouse_female')) NOT NULL
)

CREATE PROCEDURE BuildFamilyTree
AS
BEGIN
    -- השלמת בני זוג דו-כיוונית
    UPDATE P2
    SET P2.Spouse_Id = P1.Person_Id
    FROM People P1
    JOIN People P2 ON P1.Spouse_Id = P2.Person_Id
    WHERE P2.Spouse_Id IS NULL;

    --  ניקוי טבלת FamilyTree לפני מילוי
    DELETE FROM FamilyTree;

    --  הכנסת קשרי משפחה מדרגה ראשונה

    -- אב
    INSERT INTO FamilyTree (Person_Id, Relative_Id, Connection_Type)
    SELECT Person_Id, Father_Id, 'אב'
    FROM People
    WHERE Father_Id IS NOT NULL;

    -- אם
    INSERT INTO FamilyTree (Person_Id, Relative_Id, Connection_Type)
    SELECT Person_Id, Mother_Id, 'אם'
    FROM People
    WHERE Mother_Id IS NOT NULL;

    -- בן זוג / בת זוג
    INSERT INTO FamilyTree (Person_Id, Relative_Id, Connection_Type)
    SELECT Person_Id, Spouse_Id,
           CASE WHEN Gender = 'זכר' THEN 'בת זוג' ELSE 'בן זוג' END
    FROM People
    WHERE Spouse_Id IS NOT NULL;

    -- בן / בת (הילדים)
    INSERT INTO FamilyTree (Person_Id, Relative_Id, Connection_Type)
    SELECT Child.Person_Id, Parent.Person_Id,
           CASE WHEN Child.Gender = 'זכר' THEN 'בן' ELSE 'בת' END
    FROM People AS Child
    JOIN People AS Parent
        ON Child.Father_Id = Parent.Person_Id OR Child.Mother_Id = Parent.Person_Id;

    -- אחים ואחיות
    INSERT INTO FamilyTree (Person_Id, Relative_Id, Connection_Type)
    SELECT P1.Person_Id, P2.Person_Id,
           CASE WHEN P1.Gender = 'זכר' THEN 'אח' ELSE 'אחות' END
    FROM People AS P1
    JOIN People AS P2
        ON (P1.Father_Id IS NOT NULL AND P1.Father_Id = P2.Father_Id)
        OR (P1.Mother_Id IS NOT NULL AND P1.Mother_Id = P2.Mother_Id)
    WHERE P1.Person_Id <> P2.Person_Id;
END;
-- הרצת הפרוצדורה
EXEC BuildFamilyTree;

-- הצגת טבלת FamilyTree
SELECT * FROM FamilyTree;