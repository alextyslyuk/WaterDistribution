using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterInGlasses
{
    public class Glass
    {
        public string name;

        public int minCapacity;
        public int maxCapacity;
        public int amount;
    }


    public class WaterDistribution
    {
        List<Glass> glassList = new List<Glass>();

        public bool IsPossibleToDistribute(IList<Glass> glassList, int amountToDistribute)
        {
            int waterRemain = amountToDistribute;

            foreach (Glass glass in glassList)
            {
                if (waterRemain < glass.minCapacity)
                {
                    continue;
                }

                if (waterRemain > glass.maxCapacity)
                {
                    glass.amount = glass.maxCapacity;
                    waterRemain = waterRemain - glass.maxCapacity;
                }
                else
                {
                    glass.amount = waterRemain;
                    waterRemain = 0;
                }

                if (waterRemain == 0)
                {
                    break;
                }

            }

            if (waterRemain == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        static void Main(string[] args)
        {
            int amountForDistribution = 0;

            Console.WriteLine("Enter count watre to distribute" + Environment.NewLine);
            if (!int.TryParse(Console.ReadLine(), out amountForDistribution))
            {
                return;
            }
            

            WaterDistribution waterdistribution = new WaterDistribution();

            Glass glass1 = new Glass() { name = "glass1", minCapacity = 20, maxCapacity = 100 };
            Glass glass2 = new Glass() { name = "glass1", minCapacity = 10, maxCapacity = 50 };
            Glass glass3 = new Glass() { name = "glass1", minCapacity = 0, maxCapacity = 20 };

            List<Glass> glassesList = new List<Glass>();
            glassesList.Add(glass1);
            glassesList.Add(glass2);
            glassesList.Add(glass3);

            if (waterdistribution.IsPossibleToDistribute(glassesList, amountForDistribution))
            {
                Console.WriteLine(string.Format("{0}{1}{0}", Environment.NewLine, "Possible"));

                foreach (Glass glass in glassesList)
                {
                    Console.WriteLine(string.Format("{0} {1}", glass.name, glass.amount));
                }
            }
            else
            {
                Console.WriteLine(string.Format("{0}{1}", Environment.NewLine, "Impsossible"));
            }

            Console.ReadKey();

        }
    }
}
