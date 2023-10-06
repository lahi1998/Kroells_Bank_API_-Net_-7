CREATE PROCEDURE GetTransactions 
    @AccountID INT
AS
BEGIN
    -- Get the Transactions related to the account
    SELECT *
    FROM Transactions
    WHERE Account_Id = @AccountID;
END;
