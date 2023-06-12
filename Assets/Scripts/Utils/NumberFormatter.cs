using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public static class NumberFormatter
{
    private static string[] suffixes = {
        "",
        "",
        " Million",
        " Billion",
        " Trillion",
        " Quadrillion",
        " Quintillion",
        " Sextillion",
        " Septillion",
        " Octillion",
        " Nonillion",
        " Decillion",
        " Undecillion",
        " Duodecillion",
        " Tredecillion",
        " Quattordecillion",
        " Quindecillion",
        " Sexdecillion",
        " Septendecillion",
        " Octodecillion"  ,
        " Novemdecillion",
        " Vigintillion",
        " Unvigintillion",
        " Duovigintillion",
        " Trevigintillion",
        " Quattuorvigintillion",
        " Quinvigintillion",
        " Sexvigintillion",
        " Septenvigintillion",
        " Octovigintillion",
        " Novemvigintillion",
        " Trigintillion",
        " Untrigintillion",
        " Duotrigintillion",
        " Tretrigintillion",
        " Quarttourtrigintillion",
        " Quintrigintillion",
        " Sextrigintillion",
        " Septemtrigintillion",
        " Octotrigintillion",
        " Novemtrigintillion",
        " Quardragintillion",
        " Unquardragintillion",
        " Duoquardragintillion",
        " Triquardragintillion",
        " Quattuarquardragintillion",
        " Quinquardragintillion",
        " Sexquardragintillion",
        " Septenquardragintillion",
        " Octoquardragintillion",
        " Novemquardragintillion",
        " Quinquagintillion",
    };

    public static string FormatNumber(BigInteger score)
    {
        double scaledScore;
        var suffixIndex = 0;

        if (score < BigInteger.Pow(10, 6))
        {
            scaledScore = (double)score;
        }
        else
        {
            while (score >= BigInteger.Pow(10, (suffixIndex + 1) * 3) && suffixIndex < suffixes.Length - 1)
            {
                suffixIndex++;
            }

            scaledScore = (double)score / (double)BigInteger.Pow(10, suffixIndex * 3);
        }

        var suffix = suffixes[suffixIndex];

        string scoreFormatted;

        if (score < BigInteger.Pow(10, 6))
        {
            scoreFormatted = scaledScore.ToString("#,##0");
        }
        else
        {
            scoreFormatted = string.Format("{0:#,##0.00}", scaledScore);
        }

        return scoreFormatted + suffix;
    }
}
