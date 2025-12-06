Create database CafeteriaDB
GO
USE CafeteriaDB
GO
CREATE TABLE Users(
	UserID int primary key IDENTITY(1,1) NOT NULL,
	UserName varchar(50) NOT NULL,
	UserGender varchar(6) NOT NULL,
	UserPass varchar(25) NOT NULL,
	UserPhone varchar(15) NULL unique,
	UserAddress varchar(150) NOT NULL,
	isAdmin bit Not Null
)
Go
CREATE TABLE Item(
	ItemCode int primary key IDENTITY(1,1) NOT NULL,
	ItemName varchar(50) NOT NULL,
	ItemPrice money NOT NULL,
	ItemCat int NOT NULL foreign key references Cat(CatCode) 
	on delete cascade on update cascade
)
GO
CREATE TABLE Cat(
	CatCode int primary key IDENTITY(1,1) NOT NULL,
	CatName varchar(50) unique NOT NULL,
	CatDesc varchar(100) NULL,
)
GO
CREATE TABLE Invoice(
	InvoiceID int primary key IDENTITY(1,1) NOT NULL,
	UserID int foreign key references Users(UserID)
	on delete cascade on update cascade,
	InvoiceDate date NOT NULL default getdate(),
	InvoiceAmount int NOT NULL,
)
GO
Create Table ItemPerInvoice(
itemCode int foreign key refrences item(ItemCode),
invoiceCode int foreign key refrences Invoice(InvoiceID)
)
GO

/*Commands for Categories(Cat) Table*/
select * from Cat

Insert into Cat values ('{NameTB.Text}','{DescriptionTB.Text}')

Update Cat set CatName = '{NameTB.Text}' , CatDesc = '{DescriptionTB.Text}' where CatCode = {key}

Delete from Cat where CatCode = {key}

/*Commands for Item Table*/
select itemCode, ItemName,cast(round(ItemPrice, 2) as decimal(10, 2)) as ItemPrice,ItemCat ,CatName from Item join cat on Item.ItemCat = Cat.CatCode

Update Item set ItemName = '{NameTB.Text}',ItemPrice = {double.Parse(PriceTB.Text)},ItemCat = {int.Parse(CategoriesCB.SelectedValue.ToString())} where ItemCode = {key}

Delete from Item where ItemCode = {key}

/*Commands for Users table*/
Insert into Users values ('{NameTB.Text}','{GenderCB.SelectedText}','{PasswordTB.Text}','{PhoneTB.Text}','{AddressTB.Text}')

Update Users set UserName = '{NameTB.Text}',UserGender = '{GenderCB.SelectedItem.ToString().ToLower()}', UserPass = '{PasswordTB.Text}',UserPhone = '{PhoneTB.Text}',UserAddress = '{AddressTB.Text}' where UserID = {key}

