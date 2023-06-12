using System;
using System.Numerics;

public static class NumberFormatter
{
    public static string FormatNumber(BigInteger number)
    {
        if (number < 0)
            return "-" + FormatNumber(-number);

        string suffix = "";

        if (number >= BigInteger.Pow(10, 6))
        {
            double magnitude = Math.Log10((double)number);

            if (magnitude >= 33)
            {
                suffix = " Nonillion";
                number = BigInteger.Divide(number, BigInteger.Pow(10, 33));
            }
            else if (magnitude >= 30)
            {
                suffix = " Octillion";
                number = BigInteger.Divide(number, BigInteger.Pow(10, 30));
            }
            else if (magnitude >= 27)
            {
                suffix = " Septillion";
                number = BigInteger.Divide(number, BigInteger.Pow(10, 27));
            }
            else if (magnitude >= 24)
            {
                suffix = " Sextillion";
                number = BigInteger.Divide(number, BigInteger.Pow(10, 24));
            }
            else if (magnitude >= 21)
            {
                suffix = " Quintillion";
                number = BigInteger.Divide(number, BigInteger.Pow(10, 21));
            }
            else if (magnitude >= 18)
            {
                suffix = " Quadrillion";
                number = BigInteger.Divide(number, BigInteger.Pow(10, 18));
            }
            else if (magnitude >= 15)
            {
                suffix = " Trillion";
                number = BigInteger.Divide(number, BigInteger.Pow(10, 15));
            }
            else if (magnitude >= 12)
            {
                suffix = " Billion";
                number = BigInteger.Divide(number, BigInteger.Pow(10, 12));
            }
            else if (magnitude >= 6)
            {
                suffix = " Million";
                number = BigInteger.Divide(number, BigInteger.Pow(10, 6));
            }

            // Format the number with one significant digit before the million mark
            return string.Format("{0:N1}{1}", (double)number / Math.Pow(10, (int)Math.Floor(magnitude) - 5), suffix);
        }

        // Format the number with one significant digit before the million mark
        return number.ToString("N1");
    }
}
