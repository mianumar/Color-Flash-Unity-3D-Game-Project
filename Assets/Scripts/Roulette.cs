using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    public float RotatePowerMax;
    public float RotatePowerMin;
    private float RotatePower;
    public float StopPower;

    private Rigidbody2D rbody;
    int inRotate;


    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        RotatePower = Random.Range(RotatePowerMin, RotatePowerMax);
    }

    float t;
    private void Update()
    {

        if (rbody.angularVelocity > 0)
        {
            rbody.angularVelocity -= StopPower * Time.deltaTime;

            rbody.angularVelocity = Mathf.Clamp(rbody.angularVelocity, 0, 1440);
        }

        if (rbody.angularVelocity == 0 && inRotate == 1)
        {
            t += 1 * Time.deltaTime;
            if (t >= 0.5f)
            {
                GetReward();

                inRotate = 0;
                t = 0;
            }
        }
    }


    public void Rotete()
    {
        if (inRotate == 0)
        {
            rbody.AddTorque(RotatePower);
            inRotate = 1;
        }
    }



    public void GetReward()
    {
        float rouletteAngle = transform.eulerAngles.z;

        if (rouletteAngle > 0 + 22 && rouletteAngle <= 45 + 22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 45);
            Win(15);
        }
        else if (rouletteAngle > 45 + 22 && rouletteAngle <= 90 + 22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 90);
            Win(30);
        }
        else if (rouletteAngle > 90 + 22 && rouletteAngle <= 135 + 22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 135);
            Win(0);
        }
        else if (rouletteAngle > 135 + 22 && rouletteAngle <= 180 + 22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 180);
            Win(50);
        }
        else if (rouletteAngle > 180 + 22 && rouletteAngle <= 225 + 22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 225);
            Win(100);
        }
        else if (rouletteAngle > 225 + 22 && rouletteAngle <= 270 + 22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 270);
            Win(0);
        }
        else if (rouletteAngle > 270 + 22 && rouletteAngle <= 315 + 22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 315);
            Win(5);
        }
        else if (rouletteAngle > 315 + 22 && rouletteAngle <= 360 + 22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 0);
            Win(10);
        }

    }


    public void Win(int Score)
    {
        Debug.Log(Score);
        RotatePower = Random.Range(RotatePowerMin, RotatePowerMax);
    }


}