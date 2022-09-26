using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class YearsScrollText : MonoBehaviour
{

    public TextMeshProUGUI tmp;
    public Scrollbar sb;

    private int year;

    void Update()
    {
        year = 1000 + ((int)(sb.value * 10) * 100);
        tmp.text = "Year: " + year.ToString();
    }

    
}
