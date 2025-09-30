CREATE VIEW vw_OrderDetails AS
SELECT
    O.orderid,
    O.odate,
    O.pid,
    P.pname,
    O.cid,
    C.cname,
    O.qty,
    O.price,
    O.total
FROM tbOrder AS O
JOIN tbCustomer AS C ON O.cid = C.cid
JOIN tbProduct AS P ON O.pid = P.pid;