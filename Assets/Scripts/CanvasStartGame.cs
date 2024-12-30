using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasStartGame : MonoBehaviour
{

    [SerializeField]
    private BoolValueSO gameStart;
    // Start is called before the first frame update
    void Start()
    {
        gameStart.onValueChange += OnGameStart;
    //   DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        gameStart.onValueChange -= OnGameStart;
    }

    public void OnGameStart(bool value)
    {
        if(value)
            gameObject.SetActive(false);
    }

}
