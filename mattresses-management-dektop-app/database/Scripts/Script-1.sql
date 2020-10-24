SELECT * FROM Products p WHERE p.Id IN 
 (
     SELECT mp.IdProduct FROM Mattress_Products mp WHERE mp.Id = 1
)