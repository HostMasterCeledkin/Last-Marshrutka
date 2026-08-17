using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public enum FoodType
    {
        Chips,
        Water
    }

    public FoodType foodType;


    public float hungerRestore = 25f;
    public float thirstRestore = 50f;



    public void Use()
    {
        if(foodType == FoodType.Chips)
        {
            NeedsSystem.instance.Eat(hungerRestore);

            Debug.Log("Чипсы съедены");
        }


        if(foodType == FoodType.Water)
        {
            NeedsSystem.instance.Drink(thirstRestore);

            Debug.Log("Вода выпита");
        }


        Destroy(gameObject);
    }
}