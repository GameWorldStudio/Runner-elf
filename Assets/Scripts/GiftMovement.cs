using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftMovement : AObjectMovement
{
    [SerializeField]
    IntValueSO gift;


    [SerializeField]
    private GameObject giftFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gift.Value++;
            GameObject fx = GameObject.Instantiate(giftFX, transform.position, transform.rotation);
            Destroy(fx, 0.5f);
            Destroy(this.gameObject);
        }
    }
}
