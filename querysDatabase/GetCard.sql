CREATE PROCEDURE GetCard 
    @AccountID int
AS
BEGIN
    SELECT
		Card.Client_Name,
		Card.Client_Name,
		Card.CVV,
		Card.Expire_Date,
		Card.Spending_Limit
    FROM
        (
            SELECT
				A.Account_Id,
				A.Balance,
				C.Card_Nr,
				C.Client_Name,
				C.CVV,
				C.Expire_Date,
				C.Spending_Limit
            FROM
                Accounts AS A
            INNER JOIN
                Cards AS C ON A.Card_Id = C.Card_Id
        ) AS Card
    WHERE
        Account_Id = @AccountID;
END;


@AcountID