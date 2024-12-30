using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    [SerializeField]
    private BoolValueSO gameStart;

    [SerializeField]
    private BoolValueSO gameEnd;

    [SerializeField]
    private Canvas canvasEnd;

    [SerializeField]
    private Scoring score;
        
    public void EndGame(bool value)
    {
        if (value)
        {
            Time.timeScale = 0.0f;
            canvasEnd.GetComponent<CanvasGroup>().interactable = true;
            canvasEnd.GetComponent<CanvasGroup>().alpha = 1;
            score.UpdateBestScore();
        }
    }

    public void Retry()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(buildIndex);
    }

    public void StartGame()
    {
        gameStart.Value = true;
        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameEnd.onValueChange += EndGame;
    
        gameEnd.Value = false;

        gameStart.Value = false;


    }

    private void OnDestroy()
    {
        gameEnd.onValueChange -= EndGame;

    }



}
