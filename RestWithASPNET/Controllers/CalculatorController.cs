using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }            

            return BadRequest("Invalid Input");
        }

        [HttpGet]
        [Route("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet]
        [Route("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet]
        [Route("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet]
        [Route("squareRoot/{number}")]
        public IActionResult SquareRoot(string number)
        {
            if (IsNumeric(number))
            {
                var sum = Math.Sqrt((double)ConvertToDecimal(number));

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string number)
        {
            if (decimal.TryParse(number, out decimal value))
                return value;

            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out double number);
            
            return isNumber;
        }
    }
}
