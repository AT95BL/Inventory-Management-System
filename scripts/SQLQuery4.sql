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