using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathGround : MonoBehaviour
{
    [SerializeField] private Transform spawnLocation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Respawn the player at the specified spawn location
            other.gameObject.transform.position = spawnLocation.position;
        }
    }
}
