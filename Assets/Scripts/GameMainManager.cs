using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMainManager : MonoBehaviour
{
    private Text PlayerOneScoreCountText; // 플레이어 1의 남은 공 표시하는 텍스트 UI
    private Text PlayerTwoScoreCountText; // 플레이어 2의 남은 공 표시하는 텍스트 UI

    public Text PlayerOneWin; // 플레이어 1의 승리 텍스트
    public Text PlayerTwoWin; // 플레이어 2의 승리 텍스트
    public Text PlayerOneDefeat; // 플레이어 1의 패배 텍스트
    public Text PlayerTwoDefeat; // 플레이어 2의 패배 텍스트
    public Text PlayerOneAllTimerText; // 플레이어 1의 화면에 표시하는 타이머
    public Text PlayerTwoAllTimerText; // 플레이어 2의 화면에 표시하는 타이머
    public Text PlayerOneTimerText; // 플레이어 1의 최종 타이머 기록
    public Text PlayerTwoTimerText; // 플레이어 2의 최종 타이머 기록
    public Text PlayerOneAddTimerText; // 플레이어 1의 추가 시간
    public Text PlayerTwoAddTimerText; // 플레이어 2의 추가 시간
    public Text StartCountdownText; // 시작시 카운트다운 텍스트

    public GameObject GoToLeaderBoard; // 게임 리더보드로 바로가기

    public GameObject PlayerOneDefeatPanel; // 플레이어 1의 패배시 반투명 판
    public GameObject PlayerTwoDefeatPanel; // 플레이어 2의 패배시 반투명 판
    public GameObject[] GameMap = new GameObject[Stage]; // 스테이지 별 모든 공 개수

    public AudioClip AC_Ding;
    public AudioSource AS_Ding;

    private float StartCountdown = 0.0f; // 시작시 카운트다운
    public static float PlayerOneTimer = 0.0f; // 플레이어 1 타이머
    public static float PlayerTwoTimer = 0.0f; // 플레이어 2 타이머
    public static int WinnerTimer = 0; // 승자 타이머

    public static int Stage; // 총 스테이지 수

    private int PlayerOneNowStage = 1; // 플래이어 1의 현재 스테이지
    private int PlayerTwoNowStage = 1; // 플래이어 2의 현재 스테이지
    private int PlayerOneScore; // 플레이어 1의 남은 공 개수
    private int PlayerTwoScore; // 플레이어 2의 남은 공 개수

    public int[] PlayerClear = new int[Stage]; // 스테이지 별 모든 공 개수

    public static bool PlayerOneTimerReset = false; // 플레이어 1의 캐릭터 위치 리셋, 시간 추가 작동
    public static bool PlayerTwoTimerReset = false; // 플레이어 2의 캐릭터 위치 리셋, 시간 추가 작동
    public static bool GamePulse = true; // 게임 일시정지 여부

    void ScoreCount(string NowPlayer)
    {
        if (NowPlayer == "PlayerOne")
        {
            PlayerOneScoreCountText.text = "남은 공: " + PlayerOneScore.ToString(); // 플레이어 1 스코어 UI 재설정
        }
        if (NowPlayer == "PlayerTwo")
        {
            PlayerTwoScoreCountText.text = "남은 공: " + PlayerTwoScore.ToString(); // 플레이어 2 스코어 UI 재설정
        }
    }

    void PlayerAddTimerTextReset()
    {
        if(PlayerOneTimerReset == true)
        {
            PlayerOneAddTimerText.gameObject.SetActive(false);
            PlayerOneTimerReset = false;
        }
        else if(PlayerTwoTimerReset == true)
        {
            PlayerTwoAddTimerText.gameObject.SetActive(false);
            PlayerTwoTimerReset = false;
        }
    }

    void Start()
    {
        StartCountdown = 0.0f;
        PlayerOneTimer = 0.0f;
        PlayerTwoTimer = 0.0f;
        WinnerTimer = 0;
        PlayerOneNowStage = 1;
        PlayerTwoNowStage = 1;

        PlayerOneScoreCountText = GameObject.Find("ScoreCountText_1").GetComponent<Text>(); //플레이어 1의 남은 공 표시하는 텍스트 UI 찾기
        PlayerTwoScoreCountText = GameObject.Find("ScoreCountText_2").GetComponent<Text>(); //플레이어 2의 남은 공 표시하는 텍스트 UI 찾기

        /*
        PlayerOneDefeatPanel = GameObject.Find("PlayerOneDefeatPanel");
        PlayerTwoDefeatPanel = GameObject.Find("PlayerTwoDefeatPanel");

        PlayerOneWin = GameObject.Find("PlayerOneWin").GetComponent<Text>(); //플레이어 1의 승리 텍스트 찾기
        PlayerTwoWin = GameObject.Find("PlayerTwoWin").GetComponent<Text>(); //플레이어 2의 승리 텍스트 찾기
        PlayerOneDefeat = GameObject.Find("PlayerOneDefeat").GetComponent<Text>(); //플레이어 1의 패배 텍스트 찾기
        PlayerTwoDefeat = GameObject.Find("PlayerTwoDefeat").GetComponent<Text>(); //플레이어 2의 패배 텍스트 찾기
        */

        Stage = 5+1; //스테이지 수(전체보다 항상 1개가 작음) + 기본 값

        PlayerOneScore = PlayerClear[PlayerOneNowStage]; // 플레이어 1의 남은 공 개수 초기화
        PlayerTwoScore = PlayerClear[PlayerTwoNowStage]; // 플레이어 2의 남은 공 개수 초기화

        ScoreCount("PlayerOne"); // 플레이어 1 스코어 UI 불러오기
        ScoreCount("PlayerTwo"); // 플레이어 2 스코어 UI 불러오기

        PlayerOneWin.gameObject.SetActive(false);
        PlayerTwoWin.gameObject.SetActive(false);
        PlayerOneDefeat.gameObject.SetActive(false);
        PlayerTwoDefeat.gameObject.SetActive(false);
        PlayerOneTimerText.gameObject.SetActive(false);
        PlayerTwoTimerText.gameObject.SetActive(false);
        PlayerOneAddTimerText.gameObject.SetActive(false);
        PlayerTwoAddTimerText.gameObject.SetActive(false);
        GoToLeaderBoard.SetActive(false);

        for (int i = 2; i <= Stage; i++)
        {
            GameMap[i].SetActive(false); //각 스테이지를 임시로 숨김
        }
        
        AS_Ding.clip = AC_Ding;
    }

    void Update()
    {
        StartCountdown += Time.deltaTime;

        if (StartCountdown <= 4.1f)
        {
            GamePulse = true;
            if (StartCountdown >= 0.0f && StartCountdown < 1.0f)
            {
                StartCountdownText.text = "3";
            }
            else if(StartCountdown >= 1.0f && StartCountdown < 2.0f)
            {
                StartCountdownText.text = "2";
            }
            else if(StartCountdown >= 2.0f && StartCountdown < 3.0f)
            {
                StartCountdownText.text = "1";
            }
            else if (StartCountdown >= 3.0f && StartCountdown < 4.0f)
            {
                StartCountdownText.text = "시작";
            }
            else if(StartCountdown >= 4.0f)
            {
                GamePulse = false;
                PlayerOneDefeatPanel.SetActive(false);
                PlayerTwoDefeatPanel.SetActive(false);
                StartCountdownText.gameObject.SetActive(false);
            }
        }
        if (GamePulse == false)
        {
            PlayerOneTimer += Time.deltaTime;
            PlayerTwoTimer += Time.deltaTime;
            PlayerOneAllTimerText.text = PlayerOneTimer.ToString("N1") + "초";
            PlayerTwoAllTimerText.text = PlayerTwoTimer.ToString("N1") + "초";
        }
    }

    void OnTriggerEnter(Collider other) // 공이 무언가에 닿을 경우
    {
        if (other.gameObject.CompareTag("Score")) // Score 태그를 가지고 있는 오브젝트일 경우
        {
            if (this.gameObject.name == "Player1 Ball")
            {
                PlayerOneScore--; // 남은 공 개수를 한개 줄임
                ScoreCount("PlayerOne"); // 스코어 UI 업데이트
                Destroy(other.gameObject); // 먹은 공은 파괴
                if (PlayerOneScore == 0) // 남은 공 개수가 0개가 될 경우
                {
                    if (PlayerOneNowStage != Stage)
                    {
                        GameMap[PlayerOneNowStage].SetActive(false); // 이전 스테이지 종료
                        PlayerOneNowStage++; // 다음 스테이지에 있는 것으로 하기 위해 변수 1 추가
                        GameMap[PlayerOneNowStage].SetActive(true); // 다음 스테이지 시작
                        PlayerOneScore = PlayerClear[PlayerOneNowStage]; // 플레이어 1의 남은 공 개수 초기화
                        this.transform.position = new Vector3(0, 5.0f, 0); // 플레이어 1 위치 초기화
                        ScoreCount("PlayerOne"); // 스코어 UI 업데이트
                    }
                    else if (PlayerOneNowStage == Stage) // 플레이어 1가 승리시 이벤트
                    {
                        PlayerOneWin.gameObject.SetActive(true);
                        PlayerTwoDefeat.gameObject.SetActive(true);
                        PlayerTwoDefeatPanel.SetActive(true);
                        PlayerOneTimerText.gameObject.SetActive(true);
                        PlayerOneTimerText.text = PlayerOneTimer.ToString("N2") + "초";
                        GamePulse = true;
                        GoToLeaderBoard.SetActive(true);
                        WinnerTimer = (int)PlayerOneTimer;
                    }
                }
            }
            if (this.gameObject.name == "Player2 Ball")
            {
                PlayerTwoScore--; // 남은 공 개수를 한개 줄임
                ScoreCount("PlayerTwo"); // 스코어 UI 업데이트
                Destroy(other.gameObject); // 먹은 공은 파괴
                if (PlayerTwoScore == 0) // 남은 공 개수가 0개가 될 경우
                {
                    if (PlayerTwoNowStage != Stage)
                    {
                        GameMap[PlayerTwoNowStage].SetActive(false); // 이전 스테이지 종료
                        PlayerTwoNowStage++; // 다음 스테이지에 있는 것으로 하기 위해 변수 1 추가
                        GameMap[PlayerTwoNowStage].SetActive(true); // 다음 스테이지 시작
                        PlayerTwoScore = PlayerClear[PlayerTwoNowStage]; // 플레이어 2의 남은 공 개수 초기화
                        this.transform.position = new Vector3(1000, 5.0f, 0); // 플레이어 2 위치 초기화
                        ScoreCount("PlayerTwo"); // 스코어 UI 업데이트
                    }
                    else if (PlayerTwoNowStage == Stage) // 플레이어 2가 승리시 이벤트
                    {
                        PlayerTwoWin.gameObject.SetActive(true);
                        PlayerOneDefeat.gameObject.SetActive(true);
                        PlayerOneDefeatPanel.SetActive(true);
                        PlayerTwoTimerText.gameObject.SetActive(true);
                        PlayerTwoTimerText.text = PlayerTwoTimer.ToString("N2") + "초";
                        GamePulse = true;
                        GoToLeaderBoard.SetActive(true);
                        WinnerTimer = (int)PlayerTwoTimer;
                    }
                }
            }
        }
        if (other.gameObject.CompareTag("DeathCrash")) // 낙사시 발생하는 이벤트
        {
            if (this.gameObject.name == "Player1 Ball")
            {
                PlayerOneAddTimerText.gameObject.SetActive(true); //시간 추가 알림을 활성화
                PlayerOneAddTimerText.text = "3.0초+"; //시간 추가 알림 텍스트를 3초 추가로 변경
                PlayerOneTimer += 3.0f; // 시간을 3초 추가
                AS_Ding.Play(); // 딩 효과음 발생
                this.transform.position = new Vector3(0, 5.0f, 0); // 플레이어 1 위치 초기화
                PlayerOneTimerReset = true; // 2초 후 초기화할때 필요한 변수 true
                Invoke("PlayerAddTimerTextReset", 1); // 2초 후 초기화
            }
            if (this.gameObject.name == "Player2 Ball")
            {
                PlayerTwoAddTimerText.gameObject.SetActive(true); //시간 추가 알림을 활성화
                PlayerTwoAddTimerText.text = "3.0초+"; //시간 추가 알림 텍스트를 3초 추가로 변경
                PlayerTwoTimer += 3.0f; // 시간을 3초 추가
                AS_Ding.Play(); // 딩 효과음 발생
                this.transform.position = new Vector3(1000, 5.0f, 0); // 플레이어 2 위치 초기화
                PlayerTwoTimerReset = true; // 2초 후 초기화할때 필요한 변수 true
                Invoke("PlayerAddTimerTextReset", 1); // 2초 후 초기화
            }
        }
        if (other.gameObject.CompareTag("DeathWall")) // 장애물에 닿았을 경우 발생하는 이벤트
        {
            if (this.gameObject.name == "Player1 Ball")
            {
                PlayerOneAddTimerText.gameObject.SetActive(true); //시간 추가 알림을 활성화
                PlayerOneAddTimerText.text = "1.0초+"; //시간 추가 알림 텍스트를 3초 추가로 변경
                PlayerOneTimer += 3.0f; // 시간을 3초 추가
                AS_Ding.Play(); // 딩 효과음 발생
                this.transform.position = new Vector3(0, 5.0f, 0); // 플레이어 1 위치 초기화
                PlayerOneTimerReset = true; // 2초 후 초기화할때 필요한 변수 true
                Invoke("PlayerAddTimerTextReset", 1); // 2초 후 초기화
            }
            if (this.gameObject.name == "Player2 Ball")
            {
                PlayerTwoAddTimerText.gameObject.SetActive(true); //시간 추가 알림을 활성화
                PlayerTwoAddTimerText.text = "1.0초+"; //시간 추가 알림 텍스트를 3초 추가로 변경
                PlayerTwoTimer += 1.0f; // 시간을 3초 추가
                AS_Ding.Play(); // 딩 효과음 발생
                this.transform.position = new Vector3(1000, 5.0f, 0); // 플레이어 2 위치 초기화
                PlayerTwoTimerReset = true; // 2초 후 초기화할때 필요한 변수 true
                Invoke("PlayerAddTimerTextReset", 1); // 2초 후 초기화
            }
        }
    }
}