using Microsoft.AspNetCore.Mvc;
using PiggyBank.Shared.DTOs.PiggyBank;
using PiggyBank.Shared.DTOs.PiggyBankTransaction;
using PiggyBank.Shared.Services;

namespace PiggyBank.Api.Controllers
{
    /// <summary>
    /// Endpoints for piggy bank transactions
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PiggyBanyTransactionController : ControllerBase, IPiggyBankTransactionServices
    {
        private readonly IPiggyBankTransactionServices _services;

        public PiggyBanyTransactionController(IPiggyBankTransactionServices services)
        {
            _services = services;
        }

        /// <summary>
        /// This endpoint creates a new transaction for a piggy bank
        /// Required parameters are type of transaction (withdrawal or deposit), 
        /// transaction value/amount 
        /// and the coresponding piggy bank id (GUID)
        /// </summary>
        /// <param name="piggyBankTransaction">Details of the piggy bank transaction</param>
        /// <returns></returns>
        [HttpPost("CreatePiggyBankTransaction", Name = "Create Piggy Bank Transaction")]
        public Task<bool> CreatePiggyBankTransaction(CreatePiggyBankTransaction piggyBankTransaction)
        {
            return _services.CreatePiggyBankTransaction(piggyBankTransaction);
        }

        /// <summary>
        /// This endpoint gets all transactions for a piggy bank
        /// </summary>
        /// <param name="piggyBankId">The id (GUID) of a piggy bank</param>
        /// <returns></returns>
        [HttpGet("GetPiggyBankTransactions", Name = "Get Piggy Bank Transactions")]
        public Task<List<PiggyBankTransactionDetails>> GetPiggyBankTransactions(Guid piggyBankId)
        {
            return _services.GetPiggyBankTransactions(piggyBankId);
        }
    }
}
