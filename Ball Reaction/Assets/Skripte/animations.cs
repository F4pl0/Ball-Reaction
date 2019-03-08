using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations : MonoBehaviour
{
    public int animation = 0;
    public GameObject eksplozija;
    void Update()
    {
        if(animation == 1)
        {
            pucTopAnim();
        }
        else
        {
            stopTopAnim();
        }
    }
    public void pucTopAnim()
    {
        eksplozija.SetActive(true);
        GetComponent<Animator>().SetBool("puca", true);
        animation = 1;
    }
    public void stopTopAnim()
    {
        eksplozija.SetActive(false);
        GetComponent<Animator>().SetBool("puca", false);
    }
}
