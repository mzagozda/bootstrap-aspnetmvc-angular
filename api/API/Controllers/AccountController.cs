using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/accounts")]   
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IAddressService _addressService;

        /// <summary>
           /* TODO
        - Create a REST API to get all the accounts
            For every account you need to use AddressService to load an address(City and PostCode)
            You can use AccountResponse class

        - Create a REST API to save an account
            Call BalanceChecker to verify if you can save
            You can use AccountRequest class as a payload
     */

        /// </summary>
        /// <param name="accountService">Instance of <see cref="AccountService/></param>
        /// <param name="addressService">Instance of <see cref="AddressService/></param>
        public AccountController(IAccountService accountService, IAddressService addressService)
        {
            _accountService = accountService;
            _addressService = addressService;
        }
        
        /// <summary>
        /// Returns all accounts
        /// </summary>
        /// <returns>List of <see cref="AccountResponse"/></returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountResponse>>> GetAccounts()
        {
            IEnumerable<AccountModel> accounts = await _accountService.GetAccountsAsync();
            List<AccountResponse> response = accounts.Select(account => new AccountResponse(account, _addressService.GetAddress(account).Result, _accountService.GetAccountType(account))).ToList();
            return Ok(response);
        }

        /// <summary>
        /// Creates new account
        /// </summary>
        /// <remarks>This return the right http code but does not provide valid location of new resource, as it is unsupported</remarks>
        /// <param name="request"></param>
        /// <returns>Newly created object <see cref="AccountResponse"/></returns>

        [HttpPost]
        //[IgnoreInvalidModelState]
        public async Task<ActionResult> CreateAccount([FromBody] AccountRequest request)
        {
            if (request == null) return new BadRequestResult();
            if (await _accountService.SaveAccountAsync(request) == false) return new BadRequestResult();
            AccountResponse response = new AccountResponse(request,  _addressService.GetAddress(request).Result, _accountService.GetAccountType(request));
            return CreatedAtAction(actionName: nameof(CreateAccount), routeValues: response, value: response);


        }


    }
}