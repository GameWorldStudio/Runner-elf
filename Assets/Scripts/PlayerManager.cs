using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerManager : MonoBehaviour
{
    public LeaderBoard leaderboard;
    public TMP_InputField playerNameInputfield;
    public TextMeshProUGUI playerNameText;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetupRoutine());
    }

    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInputfield.text, (response) =>
        {
            if (response.success)
            {
                PlayerPrefs.SetString("PlayerName", playerNameInputfield.text);
                PlayerPrefs.Save();
                Debug.Log("Succesfully set player name");
                playerNameInputfield.transform.parent.gameObject.SetActive(false);
                playerNameText.transform.parent.gameObject.SetActive(true);
                playerNameText.text = PlayerPrefs.GetString("PlayerName");
            }
            else
            {
                Debug.Log("Could not set player name" + response.text);
            }
        });
    }

    IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();
        yield return leaderboard.FetchTopHighscoresRoutine();
        yield return leaderboard.FetchTopHighscoresRoutineGift();
    }

    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Player was logged in");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                PlayerPrefs.Save();
                if (PlayerPrefs.HasKey("PlayerName"))
                {
                    LootLockerSDKManager.SetPlayerName(PlayerPrefs.GetString("PlayerName"), (response) =>
                    {
                        if (response.success)
                        {
                            playerNameInputfield.transform.parent.gameObject.SetActive(false);
                            playerNameText.transform.parent.gameObject.SetActive(true);
                            playerNameText.text = PlayerPrefs.GetString("PlayerName");
                            Debug.Log("Succesfully set player name");
                        }
                        else
                        {
                            Debug.Log("Could not set player name" + response.text);
                        }
                    });
                }
                done = true;
            }
            else
            {
                Debug.Log("Could not start session");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

}