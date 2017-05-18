
/*
	Busqueda de usuario por usuario y clave
*/
--CREATE  
ALTER PROCEDURE dbo.Find_User
@userName VARCHAR(100),
@password VARCHAR(100)
AS
BEGIN
	
	SELECT 
			id_User,
			Username ,
			LastName ,
			FirstName ,
			SurName,
			Identification ,
			23 as myVariable
	FROM 
			dbo.Users 
	WHERE 
			userName = @userName 
			AND password= @password
	
END