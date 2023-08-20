using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour
{
   // [SerializeField] GameObject Circle, CircleSpawnPoint;
    public int  hit = 0;
    circleSpawnner circleSpawnner;
    //Animation CircleAnim;
    //public GameObject CircleParent;

  
    //   public circleSpawnner newCircleTarget;
    // public int hit = 3;
    //  public Transform CircleParentTrans;

    // Start is called before the first frame update
    void Start()
    {
        circleSpawnner = GameObject.Find("Circle- Spawner").gameObject.GetComponent<circleSpawnner>();
        //  Instantiate(Circle, CircleSpawnPoint.transform.position, CircleSpawnPoint.transform.rotation);
        //  newCicle.transform.parent = CircleParentTrans;

        // allCircles = new List<GameObject>();   
    }

    // Update is called once per frame
    void Update()
    {
        //if (gameObject.transform.position == CircleParent.transform.position)
        //{
        //    CircleAnim.Stop();
        //}
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //hit++;
            //Debug.Log("hit " + hit);
            // gameObject.transform.position = new Vector3(0, transform.position.y - .5f, transform.position.z);
            // StartCoroutine(waitForCircle());



            // Instantiate(Circle, CircleSpawnPoint.transform.position, CircleSpawnPoint.transform.rotation).GetComponent<Renderer>().material.color = Color.white;
            /*  GameObject SpawnTarget =*/

            //for (int i = 0; i <allCircles.Count; i++)
            //{
            //    Vector3 pos = allCircles[i].transform.position;
            //    pos.y -= .5f;
            //    allCircles[i].transform.position = pos;

            //}
            // allCircles.Add[SpawnTarget];
        }

   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hit++;
            Debug.Log("hit " + hit);
            if(hit == 3)
            {
                circleSpawnner.SpawnCircle();
                hit = 0;
            }
        }


    }





}
