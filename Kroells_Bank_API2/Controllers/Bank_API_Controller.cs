﻿using Azure.Core;
using Kroells_Bank_API.Models;
using Kroells_Bank_API2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Kroells_Bank_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Bank_API_Controller : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KroellsBankContext _context;
        private readonly IConfiguration _configuration;

        public Bank_API_Controller(ILogger<HomeController> logger, KroellsBankContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("FetchProfile")]
        public async Task<ActionResult<ClientInformation>> FetchProfile([FromQuery] ClientInformationDTO request)
        {

            _logger.LogInformation("API FetchProfile request received.");

            var clientInformationList = await _context.ClientInformation.
                FromSqlRaw("EXEC GetClientInformation @Client_Id",
                new SqlParameter("@Client_Id", request.Client_Id))
                .ToListAsync();

            var ClientInformation = clientInformationList.FirstOrDefault(); // Use FirstOrDefault() instead of [0].

            return Ok(ClientInformation);
        }

        [HttpPost("MakeTransfer")]
        public ActionResult<string> MakeTransfer([FromQuery] TransferDTO request)
        {
            _logger.LogInformation("API MakeTransfer request received.");

            try
            {

                // Define the SQL command to execute the stored procedure
                var sql = "EXEC Transfer @SenderID, @ReceiverCardNumber, @TransferAmount";

                // Execute the SQL command using Database.ExecuteSqlRaw
                var senderIdParam = new SqlParameter("@SenderID", request.SenderID);
                var transferAmountParam = new SqlParameter("@TransferAmount", request.Amount);
                var receiverCardNumberParam = new SqlParameter("@ReceiverCardNumber", request.ReciverCardNumber);

                _context.Database.ExecuteSqlRaw(sql, senderIdParam, transferAmountParam, receiverCardNumberParam);

                    return Ok($"Transfer completed.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error making transfer: {ex.Message}");
                return BadRequest("Transfer failed.");
            }
        }

        [HttpPost("GetTransactions")]
        public async Task<ActionResult<Transaction>> GetTransactions([FromQuery] int AccountID)
        {
            _logger.LogInformation("API GetTransactions request received.");


            var TransActionsList = await _context.Transactions.
                FromSqlRaw("EXEC GetCard @AccountID",
                new SqlParameter("@AccountID", AccountID))
                .ToListAsync();
        
            return Ok(TransActionsList);

        }

        [HttpPost("GetCard")]
        public async Task<ActionResult<Transaction>> GetCard([FromQuery] int AccountID)
        {
            _logger.LogInformation("API GetTransactions request received.");


            var CardInfoList = await _context.CardInfo.
                FromSqlRaw("EXEC GetCard @AccountID",
                new SqlParameter("@AccountID", AccountID))
                .ToListAsync();

            var CardInfo = CardInfoList.FirstOrDefault(); // Use FirstOrDefault() instead of [0].

            return Ok(CardInfo);

        }


    }
}


