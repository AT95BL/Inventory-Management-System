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