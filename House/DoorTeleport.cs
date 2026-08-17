using UnityEngine;

public class DoorTeleport : MonoBehaviour
{
    public Transform teleportPoint;

    private bool playerNear = false;
    private Transform player;

    private void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            CharacterController cc = player.GetComponent<CharacterController>();

            if (cc != null)
                cc.enabled = false;

            player.position = teleportPoint.position;
            player.rotation = teleportPoint.rotation;

            if (cc != null)
                cc.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
            player = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
            player = null;
        }
    }
}