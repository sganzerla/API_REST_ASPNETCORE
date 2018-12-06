using System;
using Microsoft.AspNetCore.Mvc;

namespace API_REST_ASPNETCORE.Controllers
{
    [Route("api/[controller]")]   
    public class CalculadoraController : ControllerBase
    {
        // GET api/values/sum/5/4
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
           
                return  BadRequest("Invalid Input");
         
        }

        // GET api/values/substraction/5/5
        [HttpGet("substraction/{firstNumber}/{secondNumber}")]
        public IActionResult Substraction(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");

        }

        // GET api/values/division/5/5
        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");

        }

        // GET api/values/multiplication/5/5
        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");

        }

        // GET api/values/media/5/5
        [HttpGet("square-root/{firstNumber}")]
        public IActionResult SquareRoot(string firstNumber)
        {

            if (IsNumeric(firstNumber) )
            {
                var sum = Math.Sqrt((Double)ConvertToDecimal(firstNumber));
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");

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