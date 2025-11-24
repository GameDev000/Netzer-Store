using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int money = 0;
    public TextMeshProUGUI moneyText;

    private void Awake()
    {
        Instance = this;
    }

    public void AddMoney(int amount)
    {
        money += amount;

        if (moneyText != null)
        {
            moneyText.text = "Money: " + money;
        }
    }
}
