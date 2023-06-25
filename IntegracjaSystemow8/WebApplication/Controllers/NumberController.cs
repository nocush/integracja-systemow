using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberController : ControllerBase
    {
        private static readonly Random random = new Random();

        [HttpGet("random-prime")]
        [Authorize(Roles = "number")]
        public ActionResult<int> GetRandomPrimeNumber()
        {
            int[] primes = { 2, 3, 5, 7, 11, 13 };
            int randomIndex = random.Next(primes.Length);
            return Ok(primes[randomIndex]);
        }
    }
}