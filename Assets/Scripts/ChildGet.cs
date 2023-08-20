using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildGet : MonoBehaviour
{
    public GameObject[] Childs;

    public int ChildLength;
    public GameObject[] ForChild;
  //  public GameObject[] ColorTriangle;
    public BallSpawnner ballSpawnner;
   //public  PlayerShoot PlayerShoot;
    

    private void Start()
    {
        ballSpawnner = GameObject.Find("Ball-SpawnPoint").gameObject.GetComponent<BallSpawnner>();
        //  OneTriangleColor();
        //   ChildLength = Random.Range(0, 6);

        //   ForChild = GetComponent<ChildGet>().Childs;

        //   Debug.Log("First Child " + ForChild[ChildLength]);
        //  ballSpawnner = GameObject.Find("Ball-SpawnPoint").gameObject.GetComponent<BallSpawnner>();
        //ForChild[1].GetComponent<MeshRenderer>().material.color = ballSpawnner.NewBall.GetComponent<Renderer>().sharedMaterial.color;
        // OneTriangleColor();
        ForChild = GetComponent<ChildGet>().Childs;
    }


    public void OneTriangleColor()
    {
       // ChildLength = Random.Range(0,2);

        ForChild = GetComponent<ChildGet>().Childs;

        Debug.Log("First Child " + ForChild[ChildLength]);
        Debug.Log("First Child " + ForChild.Length);

        //if (ChildLength % 2 == 1)
        //{
        //    ForChild[1].GetComponent<MeshRenderer>().material.color = ballSpawnner.NewBall.GetComponent<Renderer>().sharedMaterial.color;

        //}

        for (int i = 0; i < ForChild.Length; i++)
        {
            ChildLength = Random.Range(0, ForChild.Length);
            if (ChildLength % 2 == 0)
            {
                Debug.Log("CONDITION TRUE");
                
               // ForChild[i].GetComponent<MeshRenderer>().material.color = ballSpawnner.NewBall.GetComponent<Renderer>().sharedMaterial.color;
               // ForChild[i].GetComponent<MeshRenderer>().material.color = ballSpawnner.color;
            }
        }

    }
}
