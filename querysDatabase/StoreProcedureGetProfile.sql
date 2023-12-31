USE [Kroells_Bank]
GO
/****** Object:  StoredProcedure [dbo].[GetClientInformation]    Script Date: 10-10-2023 19:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetClientInformation]
    @Client_Id INT
AS
BEGIN
    SELECT
        CV.Client_Id,
        CV.Client_Name,
        CV.Income,
        CV.Job_Name,
        CV.Zip_Code,
        CV.City,
        CV.Street,
        CV.House_Nr
    FROM
        (
            SELECT
                C.Client_Id,
                C.Client_Name,
                J.Income,
                J.Job_Name,
                A.Zip_Code,
                A.City,
                A.Street,
                A.House_Nr
            FROM
                Clients AS C
            INNER JOIN
                Client_Job AS CJ ON C.Client_Id = CJ.Client_Id
            INNER JOIN
                Jobs AS J ON CJ.Job_Id = J.Job_Id
            LEFT JOIN
                CPRs AS CPR ON C.Client_Id = CPR.Client_Id
            LEFT JOIN
                Addresses AS A ON CPR.Address_Id = A.Address_Id
        ) AS CV
    WHERE
        CV.Client_Id = @Client_Id;
END;
