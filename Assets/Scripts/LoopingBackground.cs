using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    [SerializeField]
    private FloatValueSO backgroundSpeedSO;

    [SerializeField]
    private BoolValueSO gameStart;

    private float backgroundSpeed;

    private void Start()
    {
        backgroundSpeed = backgroundSpeedSO.Value;
        backgroundSpeedSO.onValueChange += OnBackGroundSpeedChange;
    }

    private void OnDisable()
    {
        backgroundSpeedSO.onValueChange -= OnBackGroundSpeedChange;
    }

    private void OnDestroy()
    {
        backgroundSpeedSO.onValueChange -= OnBackGroundSpeedChange;
    }


    [SerializeField]
    private Renderer backgroundRenderer;
    // Update is called once per frame
    void Update()
    {
        if(gameStart.Value)
            backgroundRenderer.material.mainTextureOffset += new Vector2(0f, backgroundSpeed * Time.deltaTime);

    }

    private void OnBackGroundSpeedChange(float value)
    {
        backgroundSpeed = value;
    }
}
