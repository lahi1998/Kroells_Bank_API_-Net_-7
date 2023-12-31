USE [Kroells_Bank]
GO
/****** Object:  StoredProcedure [dbo].[Transfer]    Script Date: 04-10-2023 11:54:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Transfer] 
    @SenderID INT,
    @ReceiverCardNumber INT,
    @TransferAmount DECIMAL(18, 2)
AS
BEGIN
    BEGIN TRANSACTION; 

    -- Declare variables to hold sender's and receiver's balances
    DECLARE @SenderBalance DECIMAL(18, 2);
    DECLARE @SenderLimit DECIMAL(18, 2);
    DECLARE @SenderCardID INT;
    DECLARE @ReceiverBalance DECIMAL(18, 2);
    DECLARE @ReceiverCard_Id INT;
    DECLARE @ReceiverID INT;

    -- Get the current balances for the sender and receiver and the limit for sender
    SELECT @SenderBalance = Balance, @SenderCardID = Card_Id
    FROM Accounts
    WHERE Account_Id = @SenderID;

    SELECT @SenderLimit = Spending_Limit
    FROM Cards
    WHERE Card_Id = @SenderCardID;

    SELECT @ReceiverCard_Id = Card_Id
    FROM Cards
    WHERE Card_Nr = @ReceiverCardNumber;

    SELECT @ReceiverID = Account_Id
    FROM Accounts
    WHERE Card_Id = @ReceiverCard_Id;

	SELECT @ReceiverBalance = Balance
    FROM Accounts
    WHERE Account_Id = @ReceiverID;

    -- Check if the sender has sufficient Spending_Limit for the transfer
    IF @SenderLimit >= @TransferAmount
    BEGIN

        -- Update the sender's balance by subtracting the transfer amount
        UPDATE Accounts
        SET Balance = @SenderBalance - @TransferAmount
        WHERE Account_Id = @SenderID;

        -- Update the receiver's balance by adding the transfer amount
        UPDATE Accounts
        SET Balance = @ReceiverBalance + @TransferAmount
        WHERE Account_Id = @ReceiverID;

        -- Insert a record into the TransactionHistory table to track the transfer
        INSERT INTO Transactions(Account_Id, Amount, Date_Time)
        VALUES ( @ReceiverID, @TransferAmount, GETDATE());

        -- Insert a record into the TransactionHistory table to track the transfer
        INSERT INTO Transactions(Account_Id, Amount, Date_Time)
        VALUES ( @SenderID, -@TransferAmount, GETDATE());

        COMMIT; -- Commit the transaction
    END
    ELSE
    BEGIN
        ROLLBACK; -- Rollback the transaction if the sender doesn't have sufficient balance
    END
END;
