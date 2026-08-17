using UnityEngine;
using TMPro;

public class MoneySystem : MonoBehaviour
{
    public static MoneySystem instance;


    [Header("Money")]
    public int money = 500;


    [Header("UI")]
    public TMP_Text moneyText;


    void Awake()
    {
        instance = this;
    }


    void Start()
    {
        UpdateUI();
    }



    public void AddMoney(int amount)
    {
        money += amount;

        UpdateUI();

        Debug.Log("Получено: " + amount);
    }



    public bool SpendMoney(int amount)
    {
        if(money >= amount)
        {
            money -= amount;

            UpdateUI();

            return true;
        }

        Debug.Log("Недостаточно денег");

        return false;
    }



    void UpdateUI()
    {
        if(moneyText != null)
        {
            moneyText.text = money + " Ruble ";
        }
    }
}