CREATE TABLE [dbo].[Customer](
     [custid] [int] IDENTITY(1,1) NOT NULL,
	 [custname] [varchar](50) NOT NULL,
	 [custemail] [varchar](50) NOT NULL,
	 [custaddress] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED
	 (
	 [custid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
go

Create procedure [dbo].[AddNewcustDetails]  
(  
   @Name varchar (50),  
   @email varchar (50),  
   @Address varchar (50)  
)  
as  
begin  
   Insert into Customer values(@Name,@email,@Address)  
End
go

CREATE Procedure [dbo].[GetAllCustDetails]    
as    
begin    
   select id as custId,Name,email,Address from Customer   
End
go

Create procedure [dbo].[UpdateCustDetails]  
(  
   @Custid int,  
   @Name varchar (50),  
   @email varchar (50),  
   @Address varchar (50)  
)  
as  
begin  
   Update Customer   
   set @Name =@Name,  
   @email=@email,  
   @Address=@Address  
   where  id = @Custid    
End 
go


Create procedure [dbo].[DeleteCustById]  
(  
   @CustId int  
)  
as  
begin  
   Delete from Customer where Id=@custId  
End


