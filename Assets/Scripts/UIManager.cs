using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public GameObject ConterPanel, ResumePanel, MenuPanel, StatsPanel, pausedBtn,TimePanael;
    //  public PlayerShoot Player;
    public int Counter = 10;
    public int Attempts = 0;
    public PlayerShoot playerShoot;
    public Text CounterTxt;
    public circleSpawnner circleSpawnner;


    public bool _isPlay = false;
    public bool _isDead = false;


    public float EachCircleTime = 60f;
    public Text TimerTxt;
    public float FixValueForTimer = 0.007333f;


    //for timer
    public float m_Time;
    public float pointIncreasedPerSec;

    public int hours = 0;
    public float minute = 0;

  

    public bool timerActive = false;
    public float timeStart;
    public AudioSource PlayerDeadSound;


    private void Start()
    {

        PlayerDeadSound = GetComponent<AudioSource>();

        //for time
        m_Time = 60f;
        pointIncreasedPerSec = .4f;
        //for time
        //  GlobalVariables.Totaltime =Time.timeSinceLevelLoad;

        // MenuPanel.SetActive(true);
        //ConterPanel.SetActive(false);
        ResumePanel.SetActive(false);
        StatsPanel.SetActive(false);
        MenuPanel.SetActive(true);
        _isPlay = false;
        _isDead = false;

        PlayerPrefs.GetInt("CircleCounter", 0);


    }

    // Update is called once per frame
    private void Update()
    {
        if (timerActive)
        {
            timeStart += Time.deltaTime;
            Debug.Log("timeStart " + timeStart);
        }

        GameOverScreen();
        if (_isDead == true)
        {
            PlayerDeadSound.Play();
            //  Timer();
        }
    }

    private void FixedUpdate()
    {
        if (_isPlay == true && _isDead == false)
        {
            //  Timer();
            m_Time -= pointIncreasedPerSec * Time.deltaTime;
            TimerTxt.text = ""+ (int)m_Time;
            if (m_Time <= 0)
            {
                _isDead = true;
                _isPlay = false;
                GameOverScreen();
                Debug.Log("GAme Khatam");
            }
        }
        // GlobalVariables.Totaltime = (int)Time.timeSinceLevelLoad;
        //  Debug.Log("time" + GlobalVariables.Totaltime);

    }

    public void Timer()
    {
        EachCircleTime -= Time.deltaTime - FixValueForTimer/** -.5F*/;
        //  EachCircleTime += 0.036666f /** -.5F*/;
        TimerTxt.text = Mathf.Round(EachCircleTime).ToString();
        if (EachCircleTime <= 0)
        {
            EachCircleTime = 0;
            if (EachCircleTime == 0)
            {
                _isDead = true;
            }
        }
        // Debug.Log("Time "+ EachCircleTime);
    }
    public void PlayBtn()
    {
        Attempts++;
        PlayerPrefs.SetInt("Attempts", Attempts);
        Debug.Log("My Attempt " + Attempts);
        MenuPanel.SetActive(false);
        _isPlay = true;
        pausedBtn.SetActive(true);

        //for current stats reset
        circleSpawnner.Current_t = 0;
        GlobalVariables.CurrentTotalBallFired = 0;
        GlobalVariables.C_circleCount = 0;
        GlobalVariables.C_Hours = 0;
        GlobalVariables.C_Mints = 0;
        GlobalVariables.C_Sec = 0;
        GlobalVariables.CurrentpowerUpCount = 0;
        PlayerPrefs.SetInt("C-TotalBallfire", GlobalVariables.CurrentTotalBallFired);
        PlayerPrefs.SetInt("C-CircleCounter", GlobalVariables.C_circleCount);//for current stats
        PlayerPrefs.GetInt("C-PowerUpCount", GlobalVariables.CurrentpowerUpCount);
        PlayerPrefs.GetInt("C-hours", GlobalVariables.C_Hours);
        PlayerPrefs.GetInt("C-mints", GlobalVariables.C_Mints);
        PlayerPrefs.GetInt("C-Sec", GlobalVariables.C_Sec);

    }

    public void GameOverScreen()
    {
        StartCoroutine(GameOverWaitTime());
    }

    public void PausePanel()
    {
        Time.timeScale = 1;
        ResumePanel.SetActive(false);

    }

    public void ResumeBtn()
    {
        Time.timeScale = 1;
        ConterPanel.SetActive(false);


    }
    public void CounterScreen()
    {
        Counter--;


        if (Counter == 0)
        {
            //text setactive == false
            CounterTxt.text = Counter.ToString();
            Debug.Log("Counter " + Counter);
        }


        // SceneManager.LoadScene(0);
    }
    public void PauseBtn()
    {
        Time.timeScale = 0;
        ResumePanel.SetActive(true);
    }


    public void RestartBtn()
    {
        // ConterPanel.SetActive(false);
        //MenuPanel.SetActive(true);
        SceneManager.LoadScene(0);

    }

    public void ShowStats()
    {
        StatsPanel.SetActive(true);
        TimePanael.SetActive(false);
    }

    public void CloseStats()
    {
        StatsPanel.SetActive(false);
        TimePanael.SetActive(true);
    }

    public void QuitBtn(){
        Application.Quit();
        }


    IEnumerator GameOverWaitTime()
    {
       
        if (_isDead == true)
        {
            yield return new WaitForSeconds(.7f);
           // Debug.Log("its game Over");
            ConterPanel.SetActive(true);
            pausedBtn.SetActive(false);

            _isDead = false;
        }

    }
}
