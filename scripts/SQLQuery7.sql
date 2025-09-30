CREATE PROCEDURE sp_ValidateUser
    @username VARCHAR(50),
    @password VARCHAR(50)
AS
BEGIN
    SELECT fullname FROM tbUser WHERE username = @username AND password = @password;
END;