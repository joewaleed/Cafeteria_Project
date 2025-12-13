Delete from Users
DBCC CHECKIDENT ('Users', RESEED, 0);
go
Delete from Cat
DBCC CHECKIDENT ('Cat', RESEED, 0);
go
Delete from Invoice
DBCC CHECKIDENT ('Invoice', RESEED, 0);
go
Delete from Item
DBCC checkident('Item', Reseed,0);
go
Delete from ItemPerInvoice
DBCC checkident('ItemPerInvoice', Reseed,0);
select * from Users
