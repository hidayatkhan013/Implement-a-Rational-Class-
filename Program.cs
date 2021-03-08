using System;

namespace Rational
{
    class Rational  //A number that can be written in form of p/q like 4/5 or 5/1 etc
    {
        //Auto Implemented property with private setters
        public int Denominator { private set; get; }
        public int Numerator { private set; get; }
        //Constructor as required, two optional paramertes
        public Rational(int numerator = 0, int denominator = 1) //Constructor
        {
            Denominator = denominator;
            Numerator = numerator;
        }
        //Overrides string method of object class and returns Rational number in p/q form
        public override string ToString()
        {
            return String.Format("{0}/{1}", Numerator, Denominator);
        }
        //Adds a given rational number to the current object
        public void IncreaseBy(Rational other)
        {
            //For a/b + c/d
            //if b and d are same
            if (this.Denominator == other.Denominator)
            {
                this.Numerator += other.Numerator;  //add a and c denominator remains same
            }
            else //if b and d are not equal
            {
                // add like this --- (a*d) + (b*c) / b*d
                int x = (this.Numerator * other.Denominator) + (this.Denominator * other.Numerator); //numerator
                int y = this.Denominator * other.Denominator; //denominator
                int gcd = 1;
                // Reduce it to the simplest form by using gcd.
                for (int i = 1; i <= x && i <= y; ++i)
                {
                    if (x % i == 0 && y % i == 0)
                        gcd = i;
                }
                //Simplify by dividing them with their GCD
                this.Numerator = x / gcd;   //new numerator
                this.Denominator = y / gcd; //new denominator
            }
        }
        //Subtracts a given rational number from the current object
        public void DecreaseBy(Rational other)
        {
            //Same as increase by
            if (this.Denominator == other.Denominator)
            {
                this.Numerator -= other.Numerator;
            }
            else
            {
                //Just that this time there is a subtract sign instead of +
                int x = (this.Numerator * other.Denominator) - (this.Denominator * other.Numerator);
                int y = this.Denominator * other.Denominator;
                int gcd = 1;
                for (int i = 1; i <= x && i <= y; ++i)
                {
                    if (x % i == 0 && y % i == 0)
                        gcd = i;
                }
                this.Numerator = x / gcd;
                this.Denominator = y / gcd;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Rational exp1 = new Rational();  // Object with 0 Arguments
            Rational exp2 = new Rational(5);  // Object with 1 Argument
            Rational exp3 = new Rational(7, 3);  // Object with 2 Arguments

            //Displaying Rational Numbers
            Console.WriteLine("First Number: {0}", exp1);
            Console.WriteLine("Seond Number: {0}", exp2);
            Console.WriteLine("Third Number: {0}", exp3);

            //Increasing exp1 by exp2
            exp1.IncreaseBy(exp2);
            Console.WriteLine("First Number After Increasing: {0}", exp1);

            //Decreasing exp2 by exp3
            exp2.DecreaseBy(exp3);
            Console.WriteLine("Second Number After Decreasing: {0}", exp2);


        }
    }
}
