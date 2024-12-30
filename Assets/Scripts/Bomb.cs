using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : AObjectMovement
{
    [SerializeField]
    private GameObject smokeFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameObject fx = GameObject.Instantiate(smokeFX, transform.position, transform.rotation);
            Destroy(fx, 0.5f);
            MovePlayer player = collision.GetComponent<MovePlayer>();
            player.CallFreeze();
            Destroy(gameObject);
        }
    }
}
