using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private double totalCookies = 0;
    [SerializeField] private double cookiesPerSecond = 0;

    [SerializeField] private double cookiesPerClick = 1;
    [SerializeField] private double clickMultiplier = 1;
    public List<Upgrade> upgrades;

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

    public double TotalCookies
    {
        get { return totalCookies; }
        set { totalCookies = value; }
    }
    public double CookiesPerSecond{
        get { return cookiesPerSecond; }
        set { cookiesPerSecond = value; }
    }



    private void Start()
    {
        totalCookies = Convert.ToDouble(PlayerPrefs.GetString("ClickCount", "0"));
        // UpdateText();
        print("Loaded!");
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("ClickCount", totalCookies.ToString());
        print("Saved!");
    }

        void Update()
    {
        // Generar puntos por segundo
        totalCookies += cookiesPerSecond * Time.deltaTime;
    }

    public void AddCookies(int amount)
    {
        totalCookies += amount;
    }

    public void BuyUpgrade(Upgrade upgrade)
    {
        if (totalCookies >= upgrade.cost)
        {
            totalCookies -= upgrade.cost;
            cookiesPerSecond += upgrade.cookiesPerSecond;
            upgrades.Add(upgrade);
        }
    }

    public void OnClick()
    {
        totalCookies += clickMultiplier;
        // UpdateText();
        print(totalCookies);
    }


    // private void UpdateText()
    // {
    //     if (totalCookies < 1000)
    //     {
    //         clickCountText.text = totalCookies.ToString();
    //         return;
    //     }
    //     // thousand
    //     else if (totalCookies >= 1000 && totalCookies < 1000000)
    //     {
    //         convertedCount = clickCount / 1000;
    //         clickCountText.text = convertedCount.ToString("F2") + "K";
    //         return;
    //     }
    //     // million
    //     else if (totalCookies >= 1000000 && totalCookies < 1000000000)
    //     {
    //         convertedCount = totalCookies / 1000000;
    //         clickCountText.text = convertedCount.ToString("F2") + "M";
    //         return;
    //     }

    //     // billion
    //     else if (totalCookies >= 1000000000 && totalCookies < 1000000000000)
    //     {
    //         convertedCount = clickCount / 1000000000;
    //         clickCountText.text = convertedCount.ToString("F2") + "B";
    //         return;
    //     }

    //     // trillion
    //     else if (totalCookies >= 1000000000000 && totalCookies < 1000000000000000)
    //     {
    //         convertedCount = clickCount / 1000000000000;
    //         clickCountText.text = convertedCount.ToString("F2") + "T";
    //         return;
    //     }

    //     // quadrillion
    //     else if (clickCount >= 1000000000000000 && clickCount < 1000000000000000000)
    //     {
    //         convertedCount = clickCount / 1000000000000000;
    //         clickCountText.text = convertedCount.ToString("F2") + "Qa";
    //         return;
    //     }

    // }

}
