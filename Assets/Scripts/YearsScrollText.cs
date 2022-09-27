using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class YearsScrollText : MonoBehaviour
{

    public TextMeshProUGUI tmp; //Text above scrollbar
    public Scrollbar sb; //Scrollbar

    private int year;

    void Update()
    {
        //Change the text based on what the year is selected during game play
        year = 1000 + ((int)(sb.value * 10) * 100);
        tmp.text = "Year: " + year.ToString();
    }

    
}
