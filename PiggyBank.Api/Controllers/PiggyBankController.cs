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
        /// <returns>Return true if a piggy bank was successfully created, or else it returns false</returns>
        [HttpPost("CreatePiggyBank", Name = "Create Piggy Bank")]
        public Task<bool> CreatePiggyBank(CreatePiggyBank piggyBank)
        {
            return _services.CreatePiggyBank(piggyBank);
        }

        /// <summary>
        /// This endpoint deletes a piggy bank
        /// </summary>
        /// <param name="piggyBankId">Guid id of a piggy bank you want to delete</param>
        /// <returns>Return true if a piggy bank was successfully deleted, or else it returns false</returns>
        [HttpPatch("DeletePiggyBank", Name = "Delete Piggy Bank")]
        public Task<bool> DeletePiggyBank(Guid piggyBankId)
        {
            return _services.DeletePiggyBank(piggyBankId);
        }

        /// <summary>
        /// This endpoint gets all active piggy banks,
        /// </summary>
        /// <returns>A list of all piggy banks </returns>
        [HttpGet("GetPiggyBanks", Name = "Get Piggy Banks")]
        public Task<List<PiggyBankDetails>> GetPiggyBanks()
        {
            return _services.GetPiggyBanks();
        }

        /// <summary>
        /// This endpoit updates piggy bank details
        /// </summary>
        /// <param name="piggyBank">Guid of a piggy bank and updated name</param>
        /// <returns>Return updated piggy bank details</returns>
        [HttpPatch("UpdatePiggyBank", Name = "Update Piggy Bank")]
        public Task<PiggyBankDetails> UpdatePiggyBank(UpdatePiggyBank piggyBank)
        {
            return _services.UpdatePiggyBank(piggyBank);
        }
    }
}
