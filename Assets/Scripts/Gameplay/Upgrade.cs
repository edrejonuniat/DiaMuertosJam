using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public string upgradeName;
    public int cost;
    public int cookiesPerSecond;

    public void ApplyUpgrade(GameManager gameManager)
    {
        // Implement the logic to apply the upgrade to the gameManager
        gameManager.BuyUpgrade(this);
    }
}