using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseElevator : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CloseDoors();
        }
    }

    private void CloseDoors()
    {
        gameObject.GetComponent<Animator>().Play("ElevatorClose");
    }
}
