using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace AgeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {

            String ageString, size;
            String[] ageArray = { };
            String[] ageSplit;
            DateTime[] calculatedArray;
            int temp;
            int day, month, year;
            ArrayList siblingsList = new ArrayList();
            Console.Write("Please enter the number of siblings: ");
            size = Console.ReadLine();
            temp = int.Parse(size);
            if (int.Parse(size) < 0)
            {
                temp *= -1;
            }
            size = temp.ToString();


            ageArray = new String[int.Parse(size)];
            calculatedArray = new DateTime[int.Parse(size)];
            
            for (int i = 0; i< ageArray.Length; i++)
            {
                Console.Write("Please enter date of birth of sibling: ");
                ageArray[i] = Console.ReadLine();
            }


        for(int i = 0; i< ageArray.Length; i++)
            {
                ageString = ageArray[i];
                ageSplit = ageString.Split('-');
                day = int.Parse(ageSplit[0]);
                month = int.Parse(ageSplit[1]);
                year = int.Parse(ageSplit[2]);
                calculatedArray[i] = new DateTime(year, day, month);

            }

            Array.Sort(calculatedArray);


            for (int i = 0; i < calculatedArray.Length; i++)
            {
                Console.Write("Age of sibling {0} is: ", i+1);
                ageDifference(calculatedArray[i], DateTime.Now);
                Console.WriteLine();
            }

            for(int i=1; i<calculatedArray.Length; i++)
            {
                Console.Write("Difference between sibling {0} and {1} is: ", i,i+1);
                ageDifference(calculatedArray[i-1], calculatedArray[i]);
                Console.WriteLine();
            }

            Console.Read();
      


        }


        static void ageDifference(DateTime DateOfBirth, DateTime nextAge)
        {
            int NoOfDays, NoOfMonths, NoOfYears;

            NoOfDays = nextAge.Day - DateOfBirth.Day;
            NoOfMonths = nextAge.Month - DateOfBirth.Month;
            NoOfYears = nextAge.Year - DateOfBirth.Year;

            if (NoOfDays < 0)
            {
                NoOfDays += DateTime.DaysInMonth(nextAge.Year, nextAge.Month);
                NoOfMonths--;
            }

            if (NoOfMonths < 0)
            {
                NoOfMonths += 12;
                NoOfYears--;
            }

            Console.Write("{0} years {1} months {2} days", NoOfYears, NoOfMonths, NoOfDays);

        }

    }
}
