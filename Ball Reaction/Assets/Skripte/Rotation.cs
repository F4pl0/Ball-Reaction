using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
    
    public float scaler = 100;
    public bool levaStrana = false;
	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = this.transform.localEulerAngles.z;
        if (angle > 180)
        {
            angle = -360 + angle;
        }

        if (levaStrana)
        {
            if(angle < 60)
            {
                //updaj poziciju
                transform.Rotate(Vector3.forward * scaler * Time.deltaTime);
            }
            else
            {
                levaStrana = false;
            }
        }
        else
        {
            if (angle > -60)
            {
                //updaj poziciju
                transform.Rotate(Vector3.forward * -scaler * Time.deltaTime);
            }
            else
            {
                levaStrana = true;
            }
        }
    }

}
