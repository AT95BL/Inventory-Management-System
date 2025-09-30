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