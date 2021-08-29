using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api/accounttypes")]
    public class AccountTypeController : ControllerBase
    {
        /// <summary>
        /// Returns account types
        /// </summary>
        /// <returns>List of <see cref="AccountType"/></returns>
        [HttpGet]
        public ActionResult<IEnumerable<AccountType>> GetAccountTypes()
        {
            var result = Enum.GetValues(typeof(AccountType)).Cast<AccountType>().ToList();
            return Ok(result);
        }
    }
}