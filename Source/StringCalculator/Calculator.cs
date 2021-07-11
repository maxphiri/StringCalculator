using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            var delimiters = new List<char> { ',', '\n' };

            if (numbers.Contains("//"))
            {
                var customSplit = numbers.Replace("//", string.Empty).Split('\n', 2);

                if (customSplit[0].Contains("["))
                {
                    var multiDelimiter = customSplit[0].Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string splitChar in multiDelimiter)
                    {
                        delimiters.AddRange(splitChar.ToCharArray());
                    }
                }
                else
                {
                    var customDelimiter = customSplit[0].SingleOrDefault();
                    delimiters.Add(customDelimiter);
                }

                numbers = customSplit[1];
            }

            var splitNumbers = numbers
                                .Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .Where(x => x < 1000)
                                .ToList();

            var negativeNumbers = splitNumbers.Where(x => x < 0).ToList();

            if (negativeNumbers.Any())
            {
                throw new Exception("Negative numbers not allowed: " + string.Join(",",negativeNumbers));
            }

            return splitNumbers.Sum();
        }
    }
}
