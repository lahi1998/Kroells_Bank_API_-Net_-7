USE [Kroells_Bank]
GO
/****** Object:  StoredProcedure [dbo].[GetUsername]    Script Date: 05-10-2023 13:06:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetUsername] 
    @Username varchar(50)
AS
BEGIN
    -- Get the user
    SELECT *
    FROM Clients
    WHERE Username = @Username;
END;
BEGIN
    SELECT
		LoginInfo.Account_Id,
		LoginInfo.Username,
		LoginInfo.PasswordHashed
    FROM
        (
            SELECT
				C.Username,
				C.PasswordHashed,
				C.Client_Id,
				CA.Account_Id
            FROM
                Clients AS C
            INNER JOIN
                Client_Account AS CA ON C.Client_Id = CA.Client_Id
        ) AS LoginInfo
    WHERE
        Username = @Username;
END;