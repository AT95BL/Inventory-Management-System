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