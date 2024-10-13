using System;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public GameManager gameManager;

    public void SaveGame()
    {
        PlayerPrefs.SetFloat("TotalCookies", (float)gameManager.TotalCookies);
        PlayerPrefs.SetFloat("CookiesPerSecond", (float)gameManager.CookiesPerSecond);
        // Guardar más datos según sea necesario.
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("TotalCookies"))
        {
            gameManager.TotalCookies = PlayerPrefs.GetFloat("TotalCookies");
            gameManager.CookiesPerSecond = PlayerPrefs.GetInt("CookiesPerSecond");
        }
    }
}