using Microsoft.AspNetCore.Mvc;
using PiggyBank.Shared.DTOs.PiggyBank;
using PiggyBank.Shared.Services;

namespace PiggyBank.Api.Controllers
{
    /// <summary>
    /// Endpoints for piggy bank
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PiggyBankController : ControllerBase, IPiggyBankServices
    {
        private readonly IPiggyBankServices _services;

        public PiggyBankController(IPiggyBankServices services)
        {
            _services = services;
        }

        /// <summary>
        /// This endpoint creates a new piggy bank
        /// </summary>
        /// <param name="piggyBank">Piggy bank name</param>
        /// <returns></returns>
        [HttpPost("CreatePiggyBank", Name = "Create Piggy Bank")]
        public Task<bool> CreatePiggyBank(CreatePiggyBank piggyBank)
        {
            return _services.CreatePiggyBank(piggyBank);
        }

        /// <summary>
        /// This endpoint deletes a piggy bank
        /// </summary>
        /// <param name="piggyBankId">Guid id of a piggy bank you want to delete</param>
        /// <returns></returns>
        [HttpPatch("DeletePiggyBank", Name = "Delete Piggy Bank")]
        public Task<bool> DeletePiggyBank(Guid piggyBankId)
        {
            return _services.DeletePiggyBank(piggyBankId);
        }

        /// <summary>
        /// This endpoint gets all active piggy banks,
        /// with an optional parametee to include deleted piggy banks
        /// </summary>
        /// <param name="includeDeleted">Set to true if you want to include deleted piggy banks</param>
        /// <returns></returns>
        [HttpGet("GetPiggyBanks", Name = "Get Piggy Banks")]
        public Task<List<PiggyBankDetails>> GetPiggyBanks(bool includeDeleted = false)
        {
            return _services.GetPiggyBanks(includeDeleted);
        }
    }
}
