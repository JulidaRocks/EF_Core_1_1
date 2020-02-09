using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly BBBankContext _bBBankContext;

        public WeatherForecastController(BBBankContext bBBankContext)
        {
            _bBBankContext = bBBankContext;
        }

        [HttpGet]
        public async Task<Account> Get()
        {
            List<Account> accounts = await _bBBankContext.Accounts
                .Include(account => account.User)
                .ToListAsync();
            return accounts.FirstOrDefault();
        }
    }
}
