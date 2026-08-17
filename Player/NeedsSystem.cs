using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NeedsSystem : MonoBehaviour
{
    public static NeedsSystem instance;


    [Header("Needs (0-100)")]
    public float hunger = 100f;
    public float thirst = 100f;


    [Header("Drain per second")]
    // Голод до нуля примерно за 3 часа
    public float hungerDrain = 0.009f;

    // Жажда до нуля примерно за 1 час
    public float thirstDrain = 0.028f;


    [Header("UI")]
    public TMP_Text hungerText;
    public TMP_Text thirstText;



    void Awake()
    {
        instance = this;
    }



    void Update()
    {
        hunger -= hungerDrain * Time.deltaTime;
        thirst -= thirstDrain * Time.deltaTime;


        hunger = Mathf.Clamp(hunger, 0, 100);
        thirst = Mathf.Clamp(thirst, 0, 100);


        UpdateUI();


        if(hunger <= 0 || thirst <= 0)
        {
            Die();
        }
    }



    public void Eat(float amount)
    {
        hunger += amount;

        hunger = Mathf.Clamp(hunger, 0, 100);
    }



    public void Drink(float amount)
    {
        thirst += amount;

        thirst = Mathf.Clamp(thirst, 0, 100);
    }



    void UpdateUI()
    {
        if(hungerText != null)
        {
            hungerText.text = 
            "Голод: " + Mathf.RoundToInt(hunger);
        }


        if(thirstText != null)
        {
            thirstText.text =
            "Жажда: " + Mathf.RoundToInt(thirst);
        }
    }



    void Die()
    {
        Debug.Log("Игрок умер");

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}