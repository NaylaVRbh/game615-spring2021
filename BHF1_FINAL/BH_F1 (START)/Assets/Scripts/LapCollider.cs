using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapCollider : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameManager.setLaps(1);
            gameManager.getLapsRemaining();
            gameManager.setLapsGUI();
            Destroy(this.gameObject);
        }
    }
}
