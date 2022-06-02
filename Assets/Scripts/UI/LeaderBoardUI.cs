using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardUI : MonoBehaviour
{

    public Text[] PlayerRankingText = new Text[10]; // 랭킹 텍스트 리스트

    private string convertName = "";
    private string _scoreInput = "10000000";

    public InputField NameRecordInputField;
    public Button RecordButton;


    private void Start()
    {
        NameRecordInputField.gameObject.SetActive(true);
        RecordButton.gameObject.SetActive(true);
    }

    private void Update()
    {
        // 고득점 표시
        for (int i = 0; i < Leaderboard.EntryCount; i++)
        {
            var entry = Leaderboard.GetEntry(i);
            if (entry.score == 10000000)
            {
                PlayerRankingText[i].text = "정보가 없습니다.";
            }
            else
            {
                PlayerRankingText[i].text = i + 1 + "등: " + entry.name + " / " + entry.score + "초";
            }
        }
        // 점수 확인을위한 인터페이스.
        _scoreInput = GameMainManager.WinnerTimer.ToString(); // 시간을 대입시키는 곳
        
    }

    public void OnClick()
    {
        convertName = NameRecordInputField.text;
        //PlayerPrefs.SetString("Nick", convertName);

        int score;
        int.TryParse(_scoreInput, out score);

        Leaderboard.Record(convertName, score);

        // 다음 입력 초기화
        convertName = "";
        _scoreInput = "10000000";

        NameRecordInputField.gameObject.SetActive(false);
        RecordButton.gameObject.SetActive(false);
    }

    public void GUIClear()
    {
        Leaderboard.Clear();
    }
}