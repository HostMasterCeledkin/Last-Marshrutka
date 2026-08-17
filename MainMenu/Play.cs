using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlayGame);
    }

    void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}