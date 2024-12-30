using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AObjectMovement : MonoBehaviour
{

    [SerializeField]
    protected FloatValueSO fieldSpeedSO;

    protected float speed;

    public FloatValueSO coeffSpeedSO;

    protected float coeffSpeed;

    protected void OnEnable()
    {
        fieldSpeedSO.onValueChange += OnFieldSpeedChange;

        speed = fieldSpeedSO.Value;
        coeffSpeed = coeffSpeedSO.Value;
    }

    protected void OnDisable()
    {
        fieldSpeedSO.onValueChange -= OnFieldSpeedChange;
       // coeffSpeedSO.onValueChange -= OnCoeffSpeedChange;
    }
    protected void OnDestroy()
    {
        fieldSpeedSO.onValueChange -= OnFieldSpeedChange;
      //  coeffSpeedSO.onValueChange -= OnCoeffSpeedChange;
    }
    // Update is called once per frame
    protected void Update()
    {
    
        transform.position -= new Vector3(0, speed * coeffSpeed * Time.deltaTime, 0);

        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
    protected void OnFieldSpeedChange(float value)
    {
        speed = value;
    }

    protected void OnCoeffSpeedChange(float value)
    {
        coeffSpeed = value;
    }
}
