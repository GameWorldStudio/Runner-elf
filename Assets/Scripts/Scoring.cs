using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Scoring : MonoBehaviour
{

    [SerializeField]
    private FloatValueSO bestScoreSO;

    [SerializeField]
    private IntValueSO maxCadeauSO;
    // Start is called before the first frame update

    [SerializeField]
    private float coeffMeter;
    [SerializeField]
    FloatValueSO meterTraveledSO;

    [SerializeField]
    IntValueSO giftObtainedSO;

    [SerializeField]
    FloatValueSO fieldSpeedSO;
    [SerializeField]
    BoolValueSO GameEndedSO;

    [SerializeField]
    private BoolValueSO gameStart;

    [SerializeField]
    private LeaderBoard leaderBoard;

    // Start is called before the first frame update
    void Start()
    {

        meterTraveledSO.Value = 0;
        giftObtainedSO.Value = 0;
        LoadBestScore();

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameEndedSO.Value && gameStart.Value)
        {
            meterTraveledSO.Value += coeffMeter * fieldSpeedSO.Value * Time.deltaTime;
        }
 
    }

    public void LoadBestScore()
    {
        float bestScore = PlayerPrefs.GetFloat("bestScore", 0);
        int maxCadeau = PlayerPrefs.GetInt("maxCadeau", 0);
        bestScoreSO.Value = bestScore;
        maxCadeauSO.Value = maxCadeau;
    }

    public void UpdateBestScore()
    {
        LoadBestScore();

        if(bestScoreSO.Value < meterTraveledSO.Value)
        {
            bestScoreSO.Value = meterTraveledSO.Value;
            PlayerPrefs.SetFloat("bestScore", meterTraveledSO.Value);
            
           StartCoroutine(leaderBoard.SubmitScoreRoutineMeter(Mathf.FloorToInt(meterTraveledSO.Value)));
        }

        if(maxCadeauSO.Value < giftObtainedSO.Value)
        {
            maxCadeauSO.Value = giftObtainedSO.Value;
            PlayerPrefs.SetInt("maxCadeau", giftObtainedSO.Value);
           StartCoroutine(leaderBoard.SubmitScoreRoutineGift(giftObtainedSO.Value));
        }

     
        PlayerPrefs.Save();
  
    }
}
