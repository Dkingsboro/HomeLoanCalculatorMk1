namespace HomeLoanCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Loan h1 = new HomeLoan(5, 3.87, 0, 55000);
            Console.WriteLine(h1 + "\n");

            HomeLoan hl1 = new HomeLoan("Colonial", 2750, 20, 3.95, "Amanada", 0, 255000);
            Console.WriteLine(hl1);
        }
    }
}