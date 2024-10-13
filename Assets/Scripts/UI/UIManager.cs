using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text cookiesText;

    public GameManager gameManager;

    void Update()
    {
        cookiesText.text = "Cookies: " + gameManager.TotalCookies.ToString();
    }
}