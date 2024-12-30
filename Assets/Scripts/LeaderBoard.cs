using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
    string leaderboardMeterID = "metersleaderboards";

    public TextMeshProUGUI playerNames;
    public TextMeshProUGUI playerScores;

    string leaderboardGiftID = "giftleaderboards";

    public TextMeshProUGUI playerNamesGift;
    public TextMeshProUGUI playerScoresGift;
    // Start is called before the first frame update


    public IEnumerator SubmitScoreRoutineMeter(int scoreToUpload)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");

        if (PlayerPrefs.HasKey("PlayerName"))
        {
            LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardMeterID, (response) =>
            {
                if (response.success)
                {
                    Debug.Log("Successfully uploaded score");
                    done = true;
                }
                else
                {
                    Debug.Log("Failed" + response.text);
                    done = true;
                }
            });
            yield return new WaitWhile(() => done == false);
        }
    }

    public IEnumerator SubmitScoreRoutineGift(int scoreToUpload)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");

        if (PlayerPrefs.HasKey("PlayerName"))
        {
            LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardGiftID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Successfully uploaded score");
                done = true;
            }
            else
            {
                Debug.Log("Failed" + response.text);
                done = true;
            }
        });
            yield return new WaitWhile(() => done == false);
        }
    }

    public IEnumerator FetchTopHighscoresRoutine()
    {
        Debug.Log("Start");
        bool done = false;
        LootLockerSDKManager.GetScoreList(leaderboardMeterID.ToString(), 20, 0, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Sucess");
                string tempPlayerNames = "";
                string tempPlayerScores = "";

                LootLockerLeaderboardMember[] members = response.items;

                if (members != null && members.Length > 0)
                {
                    for (int i = 0; i < members.Length; i++)
                    {
                        tempPlayerNames += members[i].rank + ". ";
                        if (members[i].player.name != "")
                        {
                            tempPlayerNames += members[i].player.name;
                        }
                        else
                        {
                            tempPlayerNames += members[i].player.id;
                        }
                        tempPlayerScores += members[i].score + "\n";
                        tempPlayerNames += "\n";
                    }

                }
                done = true;
                playerNames.text = tempPlayerNames;
                playerScores.text = tempPlayerScores;
            }
            else
            {
                Debug.Log("Failed" + response.text);
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    public IEnumerator FetchTopHighscoresRoutineGift()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreList(leaderboardGiftID.ToString(), 20, 0, (response) =>
        {
            if (response.success)
            {
                string tempPlayerNames = "";
                string tempPlayerScores = "";

                LootLockerLeaderboardMember[] members = response.items;
                if (members != null && members.Length > 0)
                {
                    for (int i = 0; i < members.Length; i++)
                    {
                        tempPlayerNames += members[i].rank + ". ";
                        if (members[i].player.name != "")
                        {
                            tempPlayerNames += members[i].player.name;
                        }
                        else
                        {
                            tempPlayerNames += members[i].player.id;
                        }
                        tempPlayerScores += members[i].score + "\n";
                        tempPlayerNames += "\n";
                    }
                }
                done = true;
                playerNamesGift.text = tempPlayerNames;
                playerScoresGift.text = tempPlayerScores;
            }
            else
            {
                Debug.Log("Failed" + response.text);
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}