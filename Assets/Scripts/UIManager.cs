using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Runtime.CompilerServices;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField]


    private void OnGUI()
    {
        scoreDisplay.text = GameManager.Instance.ScoreDisplay();
    }
}
