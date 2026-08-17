using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ExitGame);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}