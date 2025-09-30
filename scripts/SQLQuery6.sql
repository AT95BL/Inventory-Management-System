CREATE PROCEDURE sp_GetProductQuantity
    @pid INT
AS
BEGIN
    SELECT pqty FROM tbProduct WHERE pid = @pid;
END;