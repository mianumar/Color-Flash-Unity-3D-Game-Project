using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GlobalVariables
{
    public static Color C;
    public static int circleCount;
    public static int powerUpCount;
    public static float Totaltime = 0;
    public static int TotalBallFired;
    public static int Hours;
    public static int Mints;
    public static int Sec;
    public static int Points;
   // public static float t;

    //for currentStats
    public static int C_circleCount;
    public static int CurrentpowerUpCount;
   // public static float Totaltime;
    public static int CurrentTotalBallFired;
    public static int C_Hours;
    public static int C_Mints;
    public static int C_Sec;

}

public class BallSpawnner : MonoBehaviour
{
    public AudioSource _HitFx;
   
    public GameObject Ball;
    public PlayerShoot playerShoot;
  
    public  circleSpawnner circleSpawnner;
    public UIManager UIManager;
  
   public GameObject NewBall;
    bool _isShoot = true;
    public int TimePerSec;


  
    public Text TotaltimeTxt;
    public Text TotalBallFiredTxt;
    public Text circleCountTxt;
    public Text powerUpCountTxt;
    public Text pointsTxt;
    public Text C_HoursValue;
    public Text C_MintsValue;
    public Text C_SecValue;


    public Text HoursValue;
    public Text MintsValue;
    public Text SecValue;


    //for current game stats
    public Text CurrentTotaltimeTxt;
    public Text CurrentTotalBallFiredTxt;
    public Text CurrentcircleCountTxt;
    public Text CurrentpowerUpCountTxt;
    


    private void Awake()
    {
        GlobalVariables.C = Random.ColorHSV(0f, .9f, .3f, 1f, 0.5f, 1f);
    }
    // Start is called before the first frame update
    void Start()
    {
        _HitFx = GetComponent<AudioSource>();
         TimePerSec = 1;
        SpawnBalls();
        //PlayerPrefs.SetInt("Sec", 0);
        //PlayerPrefs.SetInt("mints", 0);

        GlobalVariables.TotalBallFired = PlayerPrefs.GetInt("TotalBallfire");
       // GlobalVariables.Totaltime = PlayerPrefs.GetFloat("m_TotalTime");
        GlobalVariables.Hours = PlayerPrefs.GetInt("hours");
        GlobalVariables.Mints = PlayerPrefs.GetInt("mints");
        GlobalVariables.Sec = PlayerPrefs.GetInt("Sec");
        GlobalVariables.powerUpCount = PlayerPrefs.GetInt("PowerUpCount");
      //  GlobalVariables.circleCount = PlayerPrefs.GetInt("CircleCounter");
        GlobalVariables.Points = PlayerPrefs.GetInt("Starpoints");

        TotalBallFiredTxt.text ="" +(int) GlobalVariables.TotalBallFired;
        circleCountTxt.text ="" + (int)GlobalVariables.circleCount;
        powerUpCountTxt.text ="" +(int)GlobalVariables.powerUpCount;
        //  TotaltimeTxt.text ="" +(int)GlobalVariables.Hours + ":Hours  "+ (int)GlobalVariables.Mints + ":mints   " + (int)GlobalVariables.Sec + ":sec";
        HoursValue.text = "" + (int)GlobalVariables.Hours;
        MintsValue.text ="" + (int)GlobalVariables.Mints;
        SecValue.text ="" + (int)GlobalVariables.Sec;
        pointsTxt.text = "  "+GlobalVariables.Points;


        //for current stats
        GlobalVariables.CurrentpowerUpCount = PlayerPrefs.GetInt("C-PowerUpCount");
        GlobalVariables.C_circleCount = PlayerPrefs.GetInt("C-CircleCounter");
        GlobalVariables.CurrentTotalBallFired = PlayerPrefs.GetInt("C-TotalBallfire",0);
        GlobalVariables.C_Hours = PlayerPrefs.GetInt("C-hours");
        GlobalVariables.C_Mints = PlayerPrefs.GetInt("C-mints");
        GlobalVariables.C_Sec = PlayerPrefs.GetInt("C-Sec");

        CurrentTotalBallFiredTxt.text = "" + (int)GlobalVariables.CurrentTotalBallFired;
        CurrentcircleCountTxt.text = "" + (int)GlobalVariables.C_circleCount;
        CurrentpowerUpCountTxt.text = "" + (int)GlobalVariables.CurrentpowerUpCount;
      //  CurrentTotaltimeTxt.text =(int)GlobalVariables.C_Hours + ":Hours  "  + (int)GlobalVariables.C_Mints + ":mints  " + (int)GlobalVariables.C_Sec + ":Sec ";
        C_HoursValue.text = ""+(int)GlobalVariables.C_Hours;
        C_MintsValue.text = "" + (int)GlobalVariables.C_Mints;
        C_SecValue.text = "" + (int)GlobalVariables.C_Sec;


    //  Ball.GetComponent<MeshRenderer>().sharedMaterial.color = /*Mycolor*/ Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    //  Ball.GetComponent<MeshRenderer>().sharedMaterial.color = Color.white;

        // Instantiate(Ball, transform.position, transform.rotation);
    }

private void Update()
    {
        pointsTxt.text = " " + GlobalVariables.Points;
    }
    public  void SpawnBalls()
    {
        NewBall = Instantiate(Ball, transform.position, transform.rotation);
        NewBall.GetComponent<MeshRenderer>().material.color = GlobalVariables.C;
  
    }

  public  IEnumerator SpawnBallTime()
    {
        yield return new WaitForSeconds(0.3f);
        SpawnBalls();
            _isShoot = true;


    }
    public void BallShoot()
    {
        if (/*Input.GetButtonDown("Fire1") &&*/ UIManager._isPlay == true && _isShoot == true)
        {
            _isShoot = false;
            _HitFx.Play();
            GlobalVariables.TotalBallFired++;
            GlobalVariables.CurrentTotalBallFired++;
            Debug.Log("Ball Fired " + playerShoot.BallFired);
            PlayerPrefs.SetInt("TotalBallfire",GlobalVariables.TotalBallFired);
            PlayerPrefs.SetInt("C-TotalBallfire", GlobalVariables.CurrentTotalBallFired);

            NewBall.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 350f));
            StartCoroutine(SpawnBallTime());

          //  playerShoot.Player.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        }
    }

}

