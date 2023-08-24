using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ScoreKill : MonoBehaviour
{
    public static int ScoreValue;
    TextMeshProUGUI Score;
    void Start()
    {
        Score=GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        Score.text=ScoreValue.ToString();
    }
}
