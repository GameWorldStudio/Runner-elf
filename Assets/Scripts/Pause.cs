using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    InputMaster input;
    private bool pause = false;

    [SerializeField]
    private BoolValueSO gameEnd;

    [SerializeField]
    private Canvas canvasPause;

    private void Awake()
    {
        input = new InputMaster();
    }

    private void OnEnable()
    {
        input.Enable();
        gameEnd.onValueChange += OnGameEnd;
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void OnDestroy()
    {
        input.Disable();
        input.Game.Pause.performed -= OnPauseChange;
    }
    // Start is called before the first frame update
    void Start()
    {
        input.Game.Pause.performed += OnPauseChange;
    }

    public void OnGameEnd(bool value)
    {
        if (value)
        {
            canvasPause.GetComponent<CanvasGroup>().blocksRaycasts = false;

        }
    }

    public void OnPauseChange(InputAction.CallbackContext context)
    {
        pause = !pause;
        canvasPause.GetComponent<CanvasGroup>().alpha = pause ? 1 : 0;
        canvasPause.GetComponent<CanvasGroup>().interactable = true;
        Time.timeScale = pause ? 0 : 1;
    }

    public void Continue()
    {
        
        OnPauseChange(new InputAction.CallbackContext());
        canvasPause.GetComponent<CanvasGroup>().interactable = false;
    }

    public void Quit()
    {
        SceneManager.LoadScene(1);
    }
}
