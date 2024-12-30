using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public CanvasGroup bestScore;

  public void Play()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LeaderBoard(bool open)
    {
        int alpha = open ? 1 : 0;
        bestScore.alpha = alpha;
        bestScore.interactable = open;
        bestScore.blocksRaycasts = open;
    }

    public void EraseData()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }


}
