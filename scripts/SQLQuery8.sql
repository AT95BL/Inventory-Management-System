CREATE PROCEDURE sp_GetAllUsers
AS
BEGIN
    SELECT username, fullname, password, phone FROM tbUser;
END;