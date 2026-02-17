/*
 * Module 04 - Exercise 00: Delegates & Lambdas
 * Implement: MathOperation delegate, lambdas, Func<>, Action<>
 */

// TODO: Define delegate MathOperation
// TODO: Implement Add, Subtract, Multiply
// TODO: Implement ApplyAndPrint

class Program
{
    static void Main(string[] args)
    {
        /* Uncomment when ready

        // Part 1: Named delegates
        ApplyAndPrint(10, 5, Add);
        ApplyAndPrint(10, 5, Subtract);

        // Part 2: Lambda
        MathOperation multiply = (a, b) => a * b;
        ApplyAndPrint(10, 5, multiply);

        // Part 3: Func<>
        Func<int, int, int> power = (baseNum, exp) =>
        {
            int result = 1;
            for (int i = 0; i < exp; i++) result *= baseNum;
            return result;
        };
        Console.WriteLine(power(2, 10));  // 1024

        Action<string> shout = msg => Console.WriteLine($"📢 {msg.ToUpper()}!");
        shout("hello world");
        */
    }
}
