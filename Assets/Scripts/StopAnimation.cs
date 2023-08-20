using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimation : MonoBehaviour
{
     public GameObject Rotater;
     public Animator RotatorAnim;
     public circleSpawnner circleSpawnner;
     public GameObject[] AllTriangles;
   // public GameObject playerShoot;
     public GameObject player;
     public int Tlength;
   // public  int THit;

    // Start is called before the first frame update
    void Start()
    { 
        //for (int i = 0; i < AllTriangles.Length; i++)
        //{
        //    if (AllTriangles[i].GetComponent<Renderer>().material.color == playerShoot.gameObject.GetComponent<MeshRenderer>().material.color)
        //    {
        //        Debug.Log("its run");
        //        ///  circleSpawnner.SpawnCircle();
        //        RotatorAnim.SetBool("StopAnim", true);
        //    }
        //}
    }

    void Update()
    {
    }

    public void CheckColor()
    {
         Tlength = AllTriangles.Length;
        for (int i = 0; i < AllTriangles.Length; i++)
        {
            
            //if (i != 6)
            //{
                Debug.Log("Lenth: " + Tlength);
                if (AllTriangles[i].GetComponent<MeshRenderer>().sharedMaterial.color != player.GetComponent<MeshRenderer>().sharedMaterial.color)
                {
                    Debug.Log("this is all triangles");
                    return;
                }
            else
            {
                Debug.Log("Same");
            }
            //}
            //else
            //{

            //    Debug.Log("color ture");
            //    if (i == (Tlength -1))
            //    {
            //        Debug.Log("SAme color ture");
            //        if (AllTriangles[i].GetComponent<MeshRenderer>().sharedMaterial.color == player.GetComponent<MeshRenderer>().sharedMaterial.color)
            //        {
            //            Debug.Log("SAme color");
            //        }


            //    }

            //}


            //if (AllTriangles[Tlength - 1].GetComponent<MeshRenderer>().sharedMaterial.color == player.GetComponent<MeshRenderer>().sharedMaterial.color)
            //{
            //    Debug.Log("Spawn New Object");
            //}
        }
    }


}
