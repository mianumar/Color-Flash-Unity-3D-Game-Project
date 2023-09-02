using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForSound : MonoBehaviour
{
    AudioSource CollectDiamondSFx;
    // Start is called before the first frame update
    void Start()
    {
        CollectDiamondSFx = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
            {
            CollectDiamondSFx.Play();


        }
    }
}
