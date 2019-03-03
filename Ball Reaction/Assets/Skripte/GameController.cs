using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Djule;
    public GameObject topExit;
    public float exitForce = 10f;
    public List<GameObject> djulat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            djulat.Add(Instantiate(Djule, topExit.transform.position, topExit.transform.rotation));
            Rigidbody2D rigidbody2D;
            rigidbody2D =  djulat.ToArray()[djulat.ToArray().Length-1].GetComponent<Rigidbody2D>();
            rigidbody2D.velocity = Vector2.up * exitForce;
        }
    }
}
