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

        public bool CheckIteration(IList<Glass> glassList, int[] indexes, int amountToDistribute)
        {
            int waterRemain = amountToDistribute;

            foreach (var i in indexes)
            {
                var glass = glassList[i];
                if (glass.minCapacity <= waterRemain)
                {
                    glass.amount = glass.minCapacity;
                    waterRemain -= glass.minCapacity;
                }
            }

            foreach (var glass in glassList)
            {
                var additionalAmount = Math.Min(glass.maxCapacity - glass.amount, waterRemain);
                if (additionalAmount > 0)
                {
                    if (additionalAmount > glass.minCapacity - glass.amount)
                    {
                        glass.amount += additionalAmount;
                        waterRemain -= additionalAmount;
                    }
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

        public void ClearAmount(IList<Glass> glassList)
        {
            foreach (var glass in glassList)
                glass.amount = 0;
        }

        public bool IsPossibleToDistribute(IList<Glass> glassList, int amountToDistribute)
        {
            var permutations = Permutations.GetPer(
                Enumerable.Range(0, glassList.Count).ToArray());
            foreach (var permutation in permutations)
            {
                if (this.CheckIteration(glassList, permutation, amountToDistribute))
                {
                    return true;
                }
                this.ClearAmount(glassList);
            }
            return false;
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

            List<Glass> glassesList = new List<Glass>();
            glassesList.Add(new Glass() { name = "glass1", minCapacity = 20, maxCapacity = 21 });
            glassesList.Add(new Glass() { name = "glass2", minCapacity = 80, maxCapacity = 81 });
            glassesList.Add(new Glass() { name = "glass3", minCapacity = 100, maxCapacity = 100 });
            glassesList.Add(new Glass() { name = "glass4", minCapacity = 1000, maxCapacity = 1000 });

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
