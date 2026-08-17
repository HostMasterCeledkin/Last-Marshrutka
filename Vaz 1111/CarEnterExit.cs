using UnityEngine;

public class CarEnterExit : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;

    public Rigidbody playerRigidbody;
    public Collider playerCollider;

    public GameObject playerModel;

    public MonoBehaviour firstPersonMovement;
    public MonoBehaviour jumpScript;
    public MonoBehaviour crouchScript;

    public Camera playerCamera;


    [Header("Car")]
    public MonoBehaviour carController;
    public Camera carCamera;


    [Header("Positions")]
    public Transform seatPosition;
    public Transform exitPosition;


    private bool playerNear = false;
    private bool isDriving = false;



    void Start()
    {
        carController.enabled = false;
        carCamera.enabled = false;

        playerCamera.enabled = true;

        if(playerModel != null)
            playerModel.SetActive(true);
    }



    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(playerNear && !isDriving)
            {
                EnterCar();
            }
            else if(isDriving)
            {
                ExitCar();
            }
        }
    }



    void EnterCar()
    {
        isDriving = true;

        Debug.Log("Enter car");


        // отключаем управление игроком
        firstPersonMovement.enabled = false;
        jumpScript.enabled = false;
        crouchScript.enabled = false;


        // отключаем физику игрока
        playerRigidbody.isKinematic = true;
        playerCollider.enabled = false;


        // скрываем игрока
        if(playerModel != null)
            playerModel.SetActive(false);


        // ставим игрока на сиденье
        player.transform.position = seatPosition.position;
        player.transform.rotation = seatPosition.rotation;


        // камеры
        playerCamera.enabled = false;
        carCamera.enabled = true;


        // включаем машину
        carController.enabled = true;
    }



    void ExitCar()
    {
        isDriving = false;

        Debug.Log("Exit car");


        // выключаем машину
        carController.enabled = false;
        carCamera.enabled = false;


        // ставим игрока возле двери
        player.transform.position = exitPosition.position;
        player.transform.rotation = exitPosition.rotation;


        // возвращаем игрока
        playerCollider.enabled = true;
        playerRigidbody.isKinematic = false;


        if(playerModel != null)
            playerModel.SetActive(true);


        firstPersonMovement.enabled = true;
        jumpScript.enabled = true;
        crouchScript.enabled = true;


        playerCamera.enabled = true;
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerNear = true;
            Debug.Log("Press E");
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerNear = false;
        }
    }
}