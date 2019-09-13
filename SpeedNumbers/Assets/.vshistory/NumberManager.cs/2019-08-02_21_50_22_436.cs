using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberManager : MonoBehaviour
{
    public Image accepted_number;
    public Image declined_number;
    public Image usual_number;

    public static List<NumberButton> numbers = new List<NumberButton>();

    public static void ResetNumbers()
    {

    }
}
