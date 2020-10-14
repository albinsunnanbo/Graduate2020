using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduateDotNet2020.Utilities
{
    public class FizzBuzz
    {
        public IEnumerable<string> Generate()
        {
            for (int i = 1; true; i++)
            {
                if (i % 15 == 0)
                {
                    yield return "FizzBuzz";
                }
                else if (i % 3 == 0)
                {
                    yield return "Fizz";
                }
                else if (i % 5 == 0)
                {
                    yield return "Buzz";
                }
                else
                {
                    yield return i.ToString();
                }
            }
        }
    }
}
