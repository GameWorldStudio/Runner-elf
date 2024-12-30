using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSpeed : MonoBehaviour
{

    [SerializeField]
    public float defaultSpeed = 0.05f;

    [SerializeField]
    private FloatValueSO fieldSpeed;

    [SerializeField]
    private float coeffSpeed = 0.1f;

    private int maxSpeed = 1;

    [SerializeField]
    private FloatValueSO meters;

    private MovePlayer player;

    private int nextMeters = 50;

    private void Start()
    {
       fieldSpeed.Value = defaultSpeed;

       player = FindObjectOfType<MovePlayer>();

        meters.onValueChange += OnMetersChange;
    }

    private void OnDestroy()
    {
        meters.onValueChange -= OnMetersChange;
    }

    public void OnMetersChange(float value)
    {
        Debug.Log("Change meter");
        if((int)value >= nextMeters)
        {
            Debug.Log("Change level");
            fieldSpeed.Value += coeffSpeed;
            player.SetAnimatorSpeed(1 + fieldSpeed.Value);

            nextMeters += 100;
            if (fieldSpeed.Value >= maxSpeed)
            {
                Debug.Log("Max level meter");
                fieldSpeed.Value = maxSpeed;
                meters.onValueChange -= OnMetersChange;
            }
        }
    }
}
