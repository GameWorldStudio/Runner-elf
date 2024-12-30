using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;

    public float speed = 1;
    // Start is called before the first frame update
    void Update()
    {
        animator.speed = speed;
    }

}
