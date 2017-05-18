DECLARE @username VARCHAR(100) = 'admin';

IF NOT EXISTS(SELECT * FROM Users where Username = @username)
BEGIN
	INSERT INTO Users 
	(
		UserName,
		Password,
		FirstName,
		SurName,
		LastName,
		Identification
	)
	VALUES
	(
		'admin',
		'root',
		'Super',
		'Adm',
		'Administrator',
		'007'
	)
END

SELECT * FROM Users