using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        public object Add(string numbers)
        {
            var delimeters = new List<char> { ',', '\n'};
            if (numbers.StartsWith("//"))
            {
                var splitOnFirstNewLine = numbers.Split(new[] { '\n'},2);
                var customDelimiter = splitOnFirstNewLine[0].Replace("//", String.Empty).Single();
                delimeters.Add(customDelimiter);
                numbers = splitOnFirstNewLine[1];
            }

            var splitNumbers = numbers
                .Split(delimeters.ToArray(),StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            var negativeNumbers = splitNumbers.Where(x => x < 0).ToList();
            //var negativeNumbers = new List<int>();
            //foreach (var potentiallyNegativeNumber in splitNumbers)
            //{
            //    if (potentiallyNegativeNumber < 0 )
            //    {
            //        negativeNumbers.Add(potentiallyNegativeNumber); 
            //    }
            //}
            if (negativeNumbers.Any())
            {
                throw new Exception("Negatives not allowed:" + string.Join(",", negativeNumbers));
            }

            return splitNumbers.Sum();
        }
    }
}
