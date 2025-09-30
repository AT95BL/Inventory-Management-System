-------------------------------------------
-- NAPOMENA: CREATE TABLE izjave za tbUser, tbProduct i tbOrder
-- nisu uključene. Ova skripta kreira samo triggere i procedure.
-------------------------------------------


-- 1. TRIGGERS (Trigeri)

-- Trigger za smanjenje količine proizvoda (pqty) nakon unosa (INSERT) nove narudžbine u tbOrder
CREATE TRIGGER trg_DecreaseProductQuantity
ON tbOrder
AFTER INSERT
AS
BEGIN
    UPDATE tbProduct
    SET pqty = pqty - I.qty
    FROM tbProduct P
    INNER JOIN INSERTED I ON P.pid = I.pid;
END;
GO

-- Trigger za povećanje količine proizvoda (pqty) nakon brisanja (DELETE) narudžbine iz tbOrder
CREATE TRIGGER trg_IncreaseProductQuantity
ON tbOrder
AFTER DELETE
AS
BEGIN
    UPDATE tbProduct
    SET pqty = pqty + D.qty
    FROM tbProduct P
    INNER JOIN DELETED D ON P.pid = D.pid;
END;
GO

-------------------------------------------
-- 2. STORED PROCEDURES (Pohranjene procedure)

-- Procedura za unos novog korisnika u tbUser
CREATE PROCEDURE sp_InsertUser
    @username VARCHAR(50),
    @fullname VARCHAR(100),
    @password VARCHAR(50),
    @phone VARCHAR(20)
AS
BEGIN
    INSERT INTO tbUser(username, fullname, password, phone)
    VALUES (@username, @fullname, @password, @phone);
END;
GO

-- Procedura za ažuriranje postojećeg korisnika u tbUser
CREATE PROCEDURE sp_UpdateUser
    @username VARCHAR(50),
    @fullname VARCHAR(100),
    @password VARCHAR(50),
    @phone VARCHAR(20)
AS
BEGIN
    UPDATE tbUser
    SET fullname = @fullname,
        password = @password,
        phone = @phone
    WHERE username = @username;
END;
GO

-- Procedura za proveru korisničkog imena i lozinke (validacija)
CREATE PROCEDURE sp_ValidateUser
    @username VARCHAR(50),
    @password VARCHAR(50)
AS
BEGIN
    SELECT fullname FROM tbUser WHERE username = @username AND password = @password;
END;
GO

-- Procedura za dohvaćanje svih korisnika iz tbUser
CREATE PROCEDURE sp_GetAllUsers
AS
BEGIN
    SELECT username, fullname, password, phone FROM tbUser;
END;
GO

-- Procedura za dohvaćanje količine proizvoda (pqty) na osnovu ID-a proizvoda (pid)
CREATE PROCEDURE sp_GetProductQuantity
    @pid INT
AS
BEGIN
    SELECT pqty FROM tbProduct WHERE pid = @pid;
END;
GO