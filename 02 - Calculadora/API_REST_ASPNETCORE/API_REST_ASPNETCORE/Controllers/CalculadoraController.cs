using System;
using Microsoft.AspNetCore.Mvc;

namespace API_REST_ASPNETCORE.Controllers
{
    [Route("api/[controller]")]   
    public class CalculadoraController : ControllerBase
    {
        // GET api/values/5
        [HttpGet("{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
           
                return  BadRequest("Invalid Input");
         
        }

        private Decimal ConvertToDecimal(string number)
        {
            decimal b;
            if (Decimal.TryParse(number, out b))
            {
                return b;
            }
            return 0;
        }

        private bool IsNumeric(string s)
        {
            float output;
            return float.TryParse(s, out output);
        }

    }
}