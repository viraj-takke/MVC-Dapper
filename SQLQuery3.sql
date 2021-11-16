CREATE TABLE [dbo].[Customer](
     [Id] [int] IDENTITY(1,1) NOT NULL,
	 [Name] [nvarchar](50) NOT NULL,
	 [Email] [nvarchar](50) NOT NULL,
	 [Address] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED
	 (
	 [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
go

Create procedure [dbo].[AddNewDetails]  
(  
   @Name nvarchar (50),  
   @Email nvarchar (50),  
   @Address nvarchar (50)  
)  
as  
begin  
   Insert into Customer values(@Name,@Email,@Address)  
End
go

CREATE Procedure [dbo].[GetAllDetails]    
as    
begin    
   select id as Id,Name,Email,Address from Customer   
End
go

Create procedure [dbo].[UpdateDetails]  
(  
   @Custid int,  
   @Name nvarchar (50),  
   @Email nvarchar (50),  
   @Address nvarchar (50)  
)  
as  
begin  
   Update Customer   
   set @Name =@Name,  
   @Email=@Email,  
   @Address=@Address  
   where  id = @Id    
End 
go


Create procedure [dbo].[DeleteById]  
(  
   @Id int  
)  
as  
begin  
   Delete from Customer where Id=@Id  
End


