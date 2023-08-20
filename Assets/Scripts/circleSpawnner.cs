using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class circleSpawnner : MonoBehaviour
{
    [SerializeField]GameObject Circle, CircleSpawnPoint;
    public Transform CircleParentTrans,RotatationParent;
    public int hit = 0;
    public bool  _isStopRotation = false;
    public Animator RotatorAnim;
    public List<GameObject> AllCircles;
    public List<GameObject> AllStarSpawn;
    public GameObject Star;
    public int StarRandomPos;

    public BallSpawnner ballSpawnner;
    public GameObject playerShoot;
    public GameObject newCircle2;
    public  UIManager uIManager;
    public int RandomPart;
    public PlayerShoot PlayerCheck;

    float daynamicTime;
    public float MaxLimtTime = 2f;
   


    public GameObject[] PowerUps;
    public Camera m_Cam;
    public AudioSource _SpawnSound;
    // public AudioSource _DeadSound;
    //  public Color[] BackGround_Mat;
    //public Material[] BackGround_Mat;

    void Start()
    {
        _SpawnSound = GetComponent<AudioSource>();
       // _DeadSound = GetComponent<AudioSource>();
        Current_t = 0;


        newCircle2 =  Instantiate(Circle, CircleSpawnPoint.transform.position, CircleSpawnPoint.transform.rotation);

        for (int i = 0; i < newCircle2.GetComponent<ChildGet>().Childs.Length; i++)
        {
             int ChildLength = Random.Range(0, newCircle2.GetComponent<ChildGet>().Childs.Length);
            if (ChildLength % 2 == 0)
            {
                Debug.Log("CONDITION TRUE");

            }   
        }
        StartCoroutine(WaitingForBounce());
        newCircle2.transform.parent = CircleParentTrans.transform;
        //   newCircle2.GetComponent<ChildGet>();
        AllCircles.Add(newCircle2);

        //GameObject starPos = Instantiate(Star, AllStarSpawn[StarRandomPos].transform.position, transform.rotation);
        //starPos.transform.parent = newCircle2.transform;
        Time.timeScale = 1f;
        daynamicTime = Time.timeScale;
    }

   // int CC_Sec;
   public float Current_t;
    private void FixedUpdate()
    {
        if (uIManager._isPlay == true && uIManager._isDead == false )
        {
            //float CC_Sec = Time.time;
            //  GlobalVariables.Totaltime += CC_Sec;
            // GlobalVariables.Totaltime = Time.time;
            //   CC_Sec = (int)(GlobalVariables.Totaltime % 60);
            // GlobalVariables.Sec = GlobalVariables.C_Sec;
            //  GlobalVariables.Sec = (int)(GlobalVariables.Totaltime % 60);
            //GlobalVariables.Mints  = (int)((GlobalVariables.Totaltime / 60) % 60);
            //GlobalVariables.Hours = (int)((GlobalVariables.Totaltime / 3600) % 24);
            // Debug.Log("hour : " + GlobalVariables.Hours + " Min : " + GlobalVariables.Mints + " Sec " + GlobalVariables.Sec);



            //for current stats
       
            Current_t += Time.deltaTime;
            GlobalVariables.C_Sec = (int)(Current_t % 60);
            GlobalVariables.C_Mints = (int)((Current_t / 60) % 60);
            GlobalVariables.C_Hours = (int)((Current_t / 3600) % 24);
            Debug.Log("hour : " + GlobalVariables.C_Hours + " Min : " + GlobalVariables.C_Mints + " Sec " + GlobalVariables.C_Sec);
           
            //PlayerPrefs.SetInt("C-hours", GlobalVariables.C_Hours);
            //PlayerPrefs.SetInt("C-mints", GlobalVariables.C_Mints);
            //PlayerPrefs.SetInt("C-Sec", GlobalVariables.C_Sec);

        }
        if (uIManager._isDead == true)
        {
            //GlobalVariables.Sec += CC_Sec;
            Debug.Log("Current sec");
          //  _DeadSound.Play(); // Player deadth


            GlobalVariables.Hours += GlobalVariables.C_Hours;
           // GlobalVariables.Mints += GlobalVariables.C_Mints;
            GlobalVariables.Sec += GlobalVariables.C_Sec;
            if(GlobalVariables.Sec >= 60)
            {
                GlobalVariables.Sec = 0;
                GlobalVariables.Mints++;
            }
            if (GlobalVariables.Mints >= 60)
            {
                GlobalVariables.Mints = 0;
                GlobalVariables.Hours++;
            }

            PlayerPrefs.SetInt("hours", GlobalVariables.Hours);
            PlayerPrefs.SetInt("mints", GlobalVariables.Mints);
            PlayerPrefs.SetInt("Sec", GlobalVariables.Sec);

            // Current stats
            PlayerPrefs.SetInt("C-hours", GlobalVariables.C_Hours);
            PlayerPrefs.SetInt("C-mints", GlobalVariables.C_Mints);
            PlayerPrefs.SetInt("C-Sec", GlobalVariables.C_Sec);
            uIManager._isDead = false;
            Current_t = 0;
        }
     
    }
    public void SpawnCircle()
    {
      // int B_color =  Random.Range(0, BackGround_Mat.Length);
        m_Cam.backgroundColor = Random.ColorHSV(0f, .5f, 0f, .5f, 0.5f, .8f);
        uIManager.m_Time += 10f;
        _SpawnSound.Play();
            //uIManager.EachCircleTime += 20f;
            if (Time.timeScale >= MaxLimtTime)
            {
                Debug.Log("if Chala");
                Time.timeScale = MaxLimtTime;
            }
            else
            {
                daynamicTime += .15f;
                uIManager.FixValueForTimer += 0.0073f;
                Debug.Log("Else chala");
            }

            Time.timeScale = daynamicTime;
            Debug.Log("My Time Scale " + daynamicTime);
         
        for (int i = 0; i < AllCircles.Count; i++)
            {
                Vector2 CirclePos = AllCircles[i].transform.position;
                CirclePos.y -= .3f;
                AllCircles[i].transform.position = CirclePos;
                AllCircles[i].transform.rotation = Quaternion.identity;
            }
             newCircle2 = Instantiate(Circle, CircleSpawnPoint.transform.position, CircleSpawnPoint.transform.rotation);
        for (int i = 0; i < newCircle2.GetComponent<ChildGet>().Childs.Length; i++)
        {
            int ChildLength = Random.Range(0, newCircle2.GetComponent<ChildGet>().Childs.Length);
            if (ChildLength % 2 == 0)
            {
                Debug.Log("CONDITION TRUE");

                // ForChild[i].GetComponent<MeshRenderer>().material.color = ballSpawnner.NewBall.GetComponent<Renderer>().sharedMaterial.color;
                newCircle2.GetComponent<ChildGet>().Childs[i].GetComponent<MeshRenderer>().material.color = GlobalVariables.C;
            }
        }
        StartCoroutine(WaitingForBounce());
             newCircle2.transform.parent = CircleParentTrans.transform;

             AllCircles.Add(newCircle2);

             int  StarRandomPos = Random.Range(0, 2);
               if (StarRandomPos % 2 == 1)
            {
            int forPowerUps = Random.Range(0, PowerUps.Length);
            GameObject starPos = Instantiate(PowerUps[forPowerUps], AllStarSpawn[StarRandomPos].transform.position, transform.rotation);

             starPos.transform.parent = newCircle2.transform;

        }
           
        Debug.Log("its work");
        
        
    }
    IEnumerator WaitingForBounce()
    {
        yield return new WaitForSeconds(1f);
        newCircle2.GetComponent<Animator>().enabled = false;
    }


  
   

}
