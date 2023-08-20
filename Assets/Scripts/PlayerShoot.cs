using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public GameObject Star;
    public int StarCounter = 0;
    public int BallFired = 0;
    public bool _isdead = false;
    public  StopAnimation stopAnimation;
  
    public  Rigidbody Rb;
    public GameObject Target, Player;
    public GameObject Splash;
  
    public  BallSpawnner ballSpawnner;
    public circleSpawnner circleSpawnner;
    public UIManager UIManager;
    public int Health = 1;
    public int hit = 0;
    public GameObject CircleParent;

    public ChildGet childGet;
    public int Checking = 0;

    public AudioSource m_Audio;
    //public AudioClip StarCollect;
    //public AudioClip ColorCricle_Collect;
    //public AudioClip Slow_timer_Collect;
    void Start()
    {
       // StarCollect = Resources.Load<AudioClip>("StarCollect");
        m_Audio = GetComponent<AudioSource>();

        _isdead = false;


        //GlobalVariables.powerUpCount = PlayerPrefs.GetInt("StarCount", 0);
        //GlobalVariables.circleCount = PlayerPrefs.GetInt("CircleCounter");
        //circleCountTxt.text = "2. Total Circle : " + GlobalVariables.circleCount;
        //powerUpCountTxt.text = "3. Collect Power ups : " + GlobalVariables.powerUpCount;

        Rb = GetComponent<Rigidbody>();

        circleSpawnner = GameObject.Find("Circle- Spawner").gameObject.GetComponent<circleSpawnner>();

        UIManager = GameObject.Find("UI-Manager").gameObject.GetComponent<UIManager>();
        // childGet.OneTriangleColor();
        //  childGet.ForChild = GetComponent<ChildGet>().Childs;
        childGet = circleSpawnner.newCircle2.GetComponentInChildren<ChildGet>();
      //  childGet.OneTriangleColor();
        // ballSpawnner.Ball.GetComponent<MeshRenderer>().sharedMaterial.color = /*Mycolor*/ Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);


    }
  private void Update()
    {
      //  BallShoot();
        if (Health == 0){
           // RestartGame();
        }
    }

    //public void BallShoot()
    //{
    //    if (Input.GetButtonDown("Fire1") && UIManager._isPlay == true)
    //    {
    //        BallFired++;
    //    Debug.Log("Ball Fired " + BallFired);
    //    Rb.AddForce(new Vector3(0, 0, 100f));
    //    StartCoroutine(ballSpawnner.SpawnBallTime());

    //        // GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
           // ballSpawnner.SpawnBalls();
            //Health--;
            Debug.Log("its End");

        }

        if (collision.gameObject.tag == "target") // collision to circle and change color of a part of circle
        {
           
            if (Player.GetComponent<MeshRenderer>().material.color == collision.gameObject.GetComponent<Renderer>().material.color)  // Check Circle material Are equal to ball Material
            {
                collision.gameObject.GetComponent<Renderer>().sharedMaterial.color = Color.red;
                //  ballSpawnner.health = 0;
                Health = 0;
                Debug.Log("Player Health " + Health);
                UIManager._isPlay = false;
              //  Debug.Log("health is " + ballSpawnner.health);
              UIManager._isDead = true;
                
                Debug.Log("GAME OVER");
               

                //  ConterPanelScreen();
                //  RestartGame();
            }
            else
            {
                collision.gameObject.GetComponent<Renderer>().sharedMaterial.color = Player.GetComponent<Renderer>().sharedMaterial.color;

              //  stopAnimation.CheckColor();
            }
           
            //circleSpawnner.hit++;

            //if (circleSpawnner.hit == 8)
            //{
           Debug.Log("First Child " + childGet.ForChild.Length  );
          for (int i = 0; i < childGet.ForChild.Length; i++)
           {
              if(childGet.ForChild[i].GetComponent<Renderer>().material.color == Player.GetComponent<Renderer>().material.color)
               {
                    Checking ++;
                    if(Checking >= childGet.ForChild.Length)
                    {
                        //ballSpawnner.Ball.GetComponent<MeshRenderer>().sharedMaterial.color = ballSpawnner.color;
                        GlobalVariables.C = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                       // ballSpawnner.color = Color.green/*Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f)*/;
                       //childGet.OneTriangleColor();
                        circleSpawnner.SpawnCircle();
                        GlobalVariables.circleCount++;
                        GlobalVariables.C_circleCount++;
                     // PlayerPrefs.SetInt("CircleCounter", GlobalVariables.circleCount);

                      PlayerPrefs.SetInt("C-CircleCounter", GlobalVariables.C_circleCount);//for current stats

                        Debug.Log("circle counter " + GlobalVariables.circleCount);


                        Debug.Log("Circle spwan and hit " + circleSpawnner.hit);
                       Checking = 0;
                    }   
               }
            }
                circleSpawnner.hit = 0;
               Destroy(gameObject);
        }
       
    }

   // Color Mycolor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Star")
        {
           // m_Audio.Play();
            Debug.Log("Star Destroy");
            GlobalVariables.Points ++;
            PlayerPrefs.SetInt("Starpoints", GlobalVariables.Points);
            Destroy(other.gameObject);
          
            //  StartCoroutine(TimeSlow());
            // StartCoroutine(TimeFreez());

            //   UIManager.pointIncreasedPerSec = .3f;
            // Debug.Log("pointIncreasedPerSec " + UIManager.pointIncreasedPerSec);
            // Debug.Log("Starpoints " + GlobalVariables.Points);

            //   GlobalVariables.circleCount++;
          
            GlobalVariables.powerUpCount++;
            GlobalVariables.CurrentpowerUpCount++;
          //  PlayerPrefs.SetInt("PowerUpCount",GlobalVariables.powerUpCount);

            // color ful circle on star collect
            #region Full circle color work
            //for (int i = 0; i < childGet.ForChild.Length; i++)
            //{
            //    childGet.ForChild[i].GetComponent<Renderer>().material.color = Player.GetComponent<Renderer>().material.color;

            //        Checking++;
            //        if (Checking >= childGet.ForChild.Length)
            //        {
            //            //ballSpawnner.Ball.GetComponent<MeshRenderer>().sharedMaterial.color = ballSpawnner.color;
            //            GlobalVariables.C = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            //            // ballSpawnner.color = Color.green/*Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f)*/;
            //            //childGet.OneTriangleColor();
            //            circleSpawnner.SpawnCircle();
            //            Debug.Log("Circle spwan and hit " + circleSpawnner.hit);
            //            Checking = 0;
            //        }

            //}
            ////circleSpawnner.hit = 0;
            //Destroy(gameObject);
            #endregion
        }


        if (other.gameObject.tag == "Slow Time")
        {
            GlobalVariables.powerUpCount++;
            GlobalVariables.CurrentpowerUpCount++;

            //m_Audio.Play();
        }

       



        if (other.gameObject.tag == "Full Color")
        {
           // m_Audio.Play();
            #region Full circle color work
            for (int i = 0; i < childGet.ForChild.Length; i++)
            {
                childGet.ForChild[i].GetComponent<Renderer>().material.color = Player.GetComponent<Renderer>().material.color;

                Checking++;
                if (Checking >= childGet.ForChild.Length)
                {
                    //ballSpawnner.Ball.GetComponent<MeshRenderer>().sharedMaterial.color = ballSpawnner.color;
                    GlobalVariables.C = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                    // ballSpawnner.color = Color.green/*Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f)*/;
                    //childGet.OneTriangleColor();
                    circleSpawnner.SpawnCircle();
                    GlobalVariables.circleCount++;
                    GlobalVariables.C_circleCount++;
                    Debug.Log("Circle spwan and hit " + circleSpawnner.hit);
                    Checking = 0;
                }

            }
            Destroy(gameObject);
            GlobalVariables.powerUpCount++;
            GlobalVariables.CurrentpowerUpCount++;
            //circleSpawnner.hit = 0;
            #endregion
        }
        PlayerPrefs.SetInt("PowerUpCount", GlobalVariables.powerUpCount);
        PlayerPrefs.SetInt("C-PowerUpCount", GlobalVariables.CurrentpowerUpCount);
    }

   
    IEnumerator TimeSlow()
    {
        UIManager.pointIncreasedPerSec = .15f;
        yield return new WaitForSeconds(2f);
        UIManager.pointIncreasedPerSec = .4f;

    }
    IEnumerator TimeFreez()
    {
        UIManager.pointIncreasedPerSec = 0f;
        Debug.Log("time frez");
        Debug.Log("pointIncreasedPerSec " + UIManager.pointIncreasedPerSec);
        yield return new WaitForSeconds(2f);
        Debug.Log("time release");
        Debug.Log("pointIncreasedPerSec " + UIManager.pointIncreasedPerSec);
        UIManager.pointIncreasedPerSec = .4f;

    }



    void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    void ConterPanelScreen()
    {
      //  ConterPanel.SetActive(true);
    }
}
