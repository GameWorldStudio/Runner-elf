using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{


    [SerializeField]
    private BoolValueSO gameEnd;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameEnd.Value = true;
            Debug.Log("Perdu !");
        }
        
    }
}
