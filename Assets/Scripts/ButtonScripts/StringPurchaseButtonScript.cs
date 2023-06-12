using System.Globalization;
using System.Numerics;
using TMPro;
using UnityEngine;

public class StringPurchaseButtonScript : MonoBehaviour
{
    public BigInteger score = BigInteger.Parse("1330756719859999967813897518675");
    public TextMeshProUGUI scoreText;

    string[] suffixes = {
        "",
        " Thousand",
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
        " Unquardragintillion"
    };

    void FixedUpdate()
    {
        double scaledScore;
        int suffixIndex = 0;

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

        string suffix = suffixes[suffixIndex];

        string scoreFormatted;

        if (score < BigInteger.Pow(10, 6))
        {
            scoreFormatted = scaledScore.ToString("#,##0");
        }
        else
        {
            scoreFormatted = string.Format("{0:#,##0.00}", scaledScore);
        }

        scoreText.text = scoreFormatted + suffix;
    }
}