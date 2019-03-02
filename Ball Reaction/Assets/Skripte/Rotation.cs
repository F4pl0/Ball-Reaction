using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float kolkoPivota = 0.013f;
    public float trenutnaRotacija = 0.0f;
    public bool levaStrana = true;
	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (levaStrana)
        {
            if(trenutnaRotacija > -1)
            {
                trenutnaRotacija -= kolkoPivota;
                //updaj poziciju
                transform.Rotate(Vector3.forward * 100 * trenutnaRotacija * Time.deltaTime);
            }
            else
            {
                levaStrana = false;
            }
        }
        else
        {
            if (trenutnaRotacija < 1)
            {
                trenutnaRotacija += kolkoPivota;
                //updaj poziciju
                transform.Rotate(Vector3.forward*100 * trenutnaRotacija * Time.deltaTime);
                print(trenutnaRotacija);
            }
            else
            {
                levaStrana = true;
            }
        }
    }

}
