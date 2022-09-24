using System;
using System.Text;
using System.Collections.Generic;

class Student
{
    public String Name = "";
}
public enum Greetings
{
    Morning,
    Afternoon,
    Evening,
    Night
};

namespace Program1
{
    public class Program
    {
        // This is where your program starts
        static void Main(string[] args)
        {
            // Prompt the user to enter a name
            Console.WriteLine("Enter your name please");

            var nameInput = Console.ReadLine();
            if(nameInput == null)
            {
                throw new Exception("Input cannot be null");
            }
            string name = nameInput;

            #region Strings

            // String Comparisons
            Student s1 = new Student();
            s1.Name = "Jenny";

            Student s2 = new Student();
            s2.Name = s1.Name.ToUpper();
            Console.WriteLine("s1 - " + s1.Name + ", s2 - " + s2.Name);
            
            if (String.Compare(s1.Name, s2.Name, true) == 0)
            // true makes the comparison case-insensitive.
            {
                Console.WriteLine("Students 1 and 2 have the same name.");
            }


            // Substrings and String interpolation
            string companyName = "seismos";
            string formattedCompanyName = 
                char.ToUpper(companyName[0]).ToString() + companyName.Substring(1, companyName.Length - 1);
            Console.WriteLine($"The company's formatted name is {formattedCompanyName}");


            // Iterate through a string
            string food = "Cheeseburgers";
            foreach(char c in food)
            {
                Console.Write(c);
            }


            // Searching strings with IndexOf, IndexOfAny, LastIndexOf, LastIndexOfAny, Contains
            int indexOfLetterS = food.IndexOf('s');

            char[] charsToLookFor = {'a', 'b', 'c'};
            int indexOfFirstFound = food.IndexOfAny(charsToLookFor);
            // Another way to write the same statement
            int index = name.IndexOfAny(new char[] {'a', 'b', 'c'});

            if (food.Contains("ee"))
            {
                Console.WriteLine($"{food} contains ee");
            }

            
            // null or empty values
            bool notThere = string.IsNullOrEmpty(food);


            // trim whitespace (space, \t, \n)
            name = name.Trim();


            // Parse Numeric Inputs
            Console.WriteLine("Enter a number");
            var sInput = Console.ReadLine();
            string s = (sInput == null) ? "" : sInput;
            int n = Convert.ToInt32(s);
            // By contrast, tryparse will attempt to parse, and if there is an exception it will return false
            // The out keyword modifies the parameter n to be a reference to the variable itself rather than the value of n, thus the value of n can be changed within the actual variable.
            Int32.TryParse(s, out n);


            // Splitting strings
            char[] delimiters = {',', ' '};
            string[] segments = s.Split(delimiters);


            // Joining arrays into strings
            string[] brothers = {"Chuck", "Bob", "Steve", "Mike"};
            string theBrothers = string.Join(":", brothers);


            // Padding strings
            name = "Nick";
            string paddedName = name.PadRight(20);
            string leftPaddedName = name.PadLeft(20);


            // Replace substrings
            s = "Hello, world";
            s = s.Replace(',', '!');


            // Concatenate strings
            string greeting = String.Concat(s, " and Nick");


            // String Formatting
            // String.Format performs string interpolation in a different way than the $"{} method". Instead of referencing the value within the quotes, you reference the position of the argument in the String.Format call.
            String.Format("{0} times {1} equals {2}", 2, 5, 2 * 5);

            
            // String Format Specifiers
            // These work in both string interpolation methods
            // C - Currency (Currency symbol depends on region setting)
            string oneDollar = $"{1:C}"; // $1.00
            Console.WriteLine(oneDollar);

            // D - Decimal
            string oneTwoThree = $"{123:D5}"; // 00123

            // E - Exponential
            string exponent = $"{123.45:E}"; // 1.2345E+002

            // F - Fixed
            string fixedNumber = $"{123.4567:F2}"; // 123.45

            // N - Number
            string formattedNumber = $"{1234567.89:N}"; // 1,234,567.89
            string formattedNumber2 = $"{1234567.89:N1}"; // 1,234,567.8

            // X - Hexadecimal
            string hex = $"{123:X}"; // 0x7B

            // 0:00... - Padded zeros
            string paddedZeros = $"{123:0000.00}"; // 0123.00

            // 0:#... - Force blank characters
            string ignoredCharacters = $"{12.3456:##.#}";

            // % - Multiplies by 100 and adds a percent symbol
            string percentage = $"{0.123:#00.#%}"; // 12.3%


            // String Builders
            // Requires the System.Text 
            // Ordinary strings are immutable. Concatenating many strings will create a new string for every concatenation operation. This is inefficient. To create an efficient, mutable-like string, instantiate a String Builder
            StringBuilder builder = new StringBuilder("abc");
            builder.Append('c');
            builder.Append("de");
            builder.Append("f");
            string finalString = builder.ToString(); // abcdef

            // string builders also make it easier to modify strings
            StringBuilder sb = new StringBuilder("jones");
            sb[0] = char.ToUpper(sb[0]);
            Console.WriteLine(sb.ToString()); // Jones



            Console.Read();
            #endregion Strings
            #region Operators
            // Prefix vs Postfix operators
            // Prefix operators return the value after incrementation/decrementation
            int prefix = 1;
            Console.WriteLine(++prefix); // 2

            // Postfix operators return the value before the incrementation/decrementation
            int postfix = 1;
            Console.WriteLine(postfix--); // 1


            // float numbers should be carefully compared to avoid rounding errors. Computers only store an estimate of most floating point numbers, so you should consider using a margin of error when determining if two floats are equal.
            int f1 = 10/3;
            bool isEqual = (10 == f1 * 3); // false
            isEqual = (10 - (f1 * 3)) < 0.00001; // true


            // Logical Operators
            // ! not
            // & and
            // | or
            // ^ xor operator (exclusive or, one or the other but not both)
            // && and (short circuit)
            // || or (short circuit)


            // Typecasting
            // Implicit typecasting occurs when you are operating between two different types
            // Implicit typecasting only widens the scope of variables. It does not narrow scope
            double typecastedDouble = 5 + 6.0D; // The 5 is implicitly converted to a double
            Console.WriteLine(typecastedDouble); // 11.0

            // Explicit typecasting is used to narrow the scope of a variable and is done manually.
            int typecastedInt = 5 + (int)6.0D; // The 6.0 is explicitly converted to an int
            Console.WriteLine(typecastedInt); // 11

            // Operator overloading
            // When defining custom classes you can override the way some operators behave
            /*
            class AddOne
            {
                public int x;
                public static AddOne operator +(AddOne a, AddOne b) 
                // Instead of the normal plus operation, when an AddOne class is targeted, use this special method
                {
                    AddOne addOne = new AddOne();
                    addOne.x = a.x + b.x + 1;
                    return addOne;
                }
            }
            */
            #endregion Operators
            #region  Program Flow
            // Ternary Assignments can provide one-liner conditional assignments
            bool informal = true;
            name = informal ? "Chuck" : "Charles";
            
            // Switch statement
            n = 1;
            switch (n)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("This is the line of code that will fire");
                    break;
                case 2:
                    break;
            }
            string GreetString(Greetings value) => value switch
            {
                Greetings.Morning => "Good Morning!",
                Greetings.Afternoon => "Good Afternoon!",
                Greetings.Evening => "Good Evening!",
                Greetings.Night => "Good Night!",
                _ => "Not sure what time it is"
            };
            #endregion Program Flow

        }
    }
}