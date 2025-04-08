USE FamilyTreeDB;

--����� ���� ����

 CREATE DATABASE FamilyDB

--����� ���� �����

  CREATE TABLE MyPerson(
   Person_Id INT PRIMARY KEY IDENTITY(1,1) ,
   Personal_Name VARCHAR(30),
   Family_Name VARCHAR(20),
   Gender VARCHAR(6) CHECK (Gender IN ('male' , 'female')) NOT NULL,
   Father_Id INT ,
   Mother_Id INT,
   Spouse_Id INT
)

--����� ���� �� �����
CREATE TABLE FamilyTree(
  Id INT PRIMARY KEY IDENTITY(1,1),
  Person_Id INT NOT NULL,FOREIGN KEY (Person_Id) REFERENCES MyPerson (Person_Id),
  Relative_Id INT NOT NULL,FOREIGN KEY (Relative_Id) REFERENCES MyPerson (Person_Id),
  Connection_Type VARCHAR(10) CHECK (Connection_Type IN ('father','mother','sister','brother','son','daughter','spouse_male','spouse_female')) NOT NULL
)

CREATE PROCEDURE BuildFamilyTree
AS
BEGIN
    -- ����� ��� ��� ��-�������
    UPDATE P2
    SET P2.Spouse_Id = P1.Person_Id
    FROM People P1
    JOIN People P2 ON P1.Spouse_Id = P2.Person_Id
    WHERE P2.Spouse_Id IS NULL;

    --  ����� ���� FamilyTree ���� �����
    DELETE FROM FamilyTree;

    --  ����� ���� ����� ����� ������

    -- ��
    INSERT INTO FamilyTree (Person_Id, Relative_Id, Connection_Type)
    SELECT Person_Id, Father_Id, '��'
    FROM People
    WHERE Father_Id IS NOT NULL;

    -- ��
    INSERT INTO FamilyTree (Person_Id, Relative_Id, Connection_Type)
    SELECT Person_Id, Mother_Id, '��'
    FROM People
    WHERE Mother_Id IS NOT NULL;

    -- �� ��� / �� ���
    INSERT INTO FamilyTree (Person_Id, Relative_Id, Connection_Type)
    SELECT Person_Id, Spouse_Id,
           CASE WHEN Gender = '���' THEN '�� ���' ELSE '�� ���' END
    FROM People
    WHERE Spouse_Id IS NOT NULL;

    -- �� / �� (������)
    INSERT INTO FamilyTree (Person_Id, Relative_Id, Connection_Type)
    SELECT Child.Person_Id, Parent.Person_Id,
           CASE WHEN Child.Gender = '���' THEN '��' ELSE '��' END
    FROM People AS Child
    JOIN People AS Parent
        ON Child.Father_Id = Parent.Person_Id OR Child.Mother_Id = Parent.Person_Id;

    -- ���� ������
    INSERT INTO FamilyTree (Person_Id, Relative_Id, Connection_Type)
    SELECT P1.Person_Id, P2.Person_Id,
           CASE WHEN P1.Gender = '���' THEN '��' ELSE '����' END
    FROM People AS P1
    JOIN People AS P2
        ON (P1.Father_Id IS NOT NULL AND P1.Father_Id = P2.Father_Id)
        OR (P1.Mother_Id IS NOT NULL AND P1.Mother_Id = P2.Mother_Id)
    WHERE P1.Person_Id <> P2.Person_Id;
END;
-- ���� ���������
EXEC BuildFamilyTree;

-- ���� ���� FamilyTree
SELECT * FROM FamilyTree;