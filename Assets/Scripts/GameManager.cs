using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private double clickCount = 0;
    [SerializeField] private double clickMultiplier = 1;
    [SerializeField] private double convertedCount = 0;
    [SerializeField] private TMP_Text clickCountText;

    public static GameManager Singleton;

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start() {
        clickCount = Convert.ToDouble(PlayerPrefs.GetString("ClickCount", "0"));
        UpdateText();
        print("Loaded!");   
    }

    private void OnApplicationQuit() {
        PlayerPrefs.SetString("ClickCount", clickCount.ToString());
        print("Saved!");
    }

    public void OnClick()
    {
        clickCount += clickMultiplier;
        UpdateText();
        print(clickCount);
    }

    private void UpdateText()
    {
        if (clickCount < 1000)
        {
            clickCountText.text = clickCount.ToString();
            return;
        }
        // thousand
        else if (clickCount >= 1000 && clickCount < 1000000)
        {
            convertedCount = clickCount / 1000;
            clickCountText.text = convertedCount.ToString("F2") + "K";
            return;
        }
        // million
        else if (clickCount >= 1000000 && clickCount < 1000000000)
        {
            convertedCount = clickCount / 1000000;
            clickCountText.text = convertedCount.ToString("F2") + "M";
            return;
        }

        // billion
        else if (clickCount >= 1000000000 && clickCount < 1000000000000)
        {
            convertedCount = clickCount / 1000000000;
            clickCountText.text = convertedCount.ToString("F2") + "B";
            return;
        }

        // trillion
        else if (clickCount >= 1000000000000 && clickCount < 1000000000000000)
        {
            convertedCount = clickCount / 1000000000000;
            clickCountText.text = convertedCount.ToString("F2") + "T";
            return;
        }

        // quadrillion
        else if (clickCount >= 1000000000000000 && clickCount < 1000000000000000000)
        {
            convertedCount = clickCount / 1000000000000000;
            clickCountText.text = convertedCount.ToString("F2") + "Qa";
            return;
        }

    }

}
