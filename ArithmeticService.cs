using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ArithmeticOperation
{
    public class ArithmeticService
    {
        public ResponseResult PerformArithmeticOperation(ArithmeticDTO input)
        {
            string result = DetectOperator(input.operation_type);
            if (result==Operators.Addition.ToString())
            {
                return new ResponseResult
                {
                    operation_type = Operators.Addition.ToString(),
                    result = input.x + input.y,
                    slackUsername = "DamoFC"
                };

            }
            if (result==(Operators.Subtraction.ToString()))
            {
                return new ResponseResult
                {
                    operation_type = Operators.Subtraction.ToString(),
                    result = input.x - input.y,
                    slackUsername = "DamoFC"
                };

            }
            if (result==(Operators.Multiplication.ToString()))
            {
                return new ResponseResult
                {
                    operation_type = Operators.Multiplication.ToString(),
                    result = input.x * input.y,
                    slackUsername = "DamoFC"
                };

            }
            if (result==(Operators.Division.ToString()))
            {
                return new ResponseResult
                {
                    operation_type = Operators.Division.ToString(),
                    result = input.x / input.y,
                    slackUsername = "DamoFC"
                };

            }
            else
            {
                throw new Exception("Invalid / Unrecognized operator ");
            }
        }


        private static string DetectOperator(string word)
        {

            var response = string.Empty;
            var list = new List<string>(new string[] { "add", "addition", "plus", "+", "sum", "total",
                "subtract", "subtraction", "minus","-","difference","differ", "take away", "deduct","deduction",
                "multiply", "*","product", "by", "times", "divide","division", "fraction" });
            var AdditionOperator = new List<string>(new string[] { "add", "addition", "plus", "+", "sum", "total", });
            var SubtractionOperator = new List<string>(new string[] { "subtraction","subtract", "minus", "-","differ", "difference", "take away", "deduction","deduct", });
            var MultiplicationOperator = new List<string>(new string[] { "product", "by", "times", "*", "multiply" });
            var DivisionOperator = new List<string>(new string[] { "divide", "division", "fraction" });




            string[] seperator = new string[] { ",", ".", "!", "\\", " ", "\'s" };
            var words = word.ToLower().Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            List<string> wordList = new List<string>(words);
            var common= list.Intersect(wordList);

            //var matched = wordList.Where(keyword =>
            //Regex.IsMatch(, Regex.Escape(keyword), RegexOptions.IgnoreCase));

            foreach (string item in common)
            {
                //var matched = list.Where(keyword =>
                 //Regex.IsMatch(item, Regex.Escape(keyword), RegexOptions.IgnoreCase));

                if (AdditionOperator.Exists(i => i.Equals(item)))
                {
                    response = "Addition";
                    break;
                }
                else if (SubtractionOperator.Exists(i => i.Equals(item)))
                {
                    response = "Subtraction";
                    break;
                }
                else if (MultiplicationOperator.Exists(i => i.Equals(item)))
                {
                    response = "Multiplication";
                    break;
                }
                else if (DivisionOperator.Exists(i => i.Equals(item)))
                {
                    response = "Division";
                    break;
                }
                else
                {
                    response = "Invalid / Unrecognized operator ";
                }

            }
            return response;
        }   
    }
}