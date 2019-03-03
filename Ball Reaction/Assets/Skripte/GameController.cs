using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Djule;
    public GameObject colObj;
    public GameObject topExit;
    public float exitForce = 10f;
    public List<GameObject> djulat;
    public KameraFollow kameraFollow;
    public bool playing = false;
    GameObject najviseDjule;
    public float spawnFreq = 2;
    float genMax = 7;
    bool listeningForSpace = false;
    GameObject djuleObj, targetObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !playing)
        {
            djulat.Add(Instantiate(Djule, topExit.transform.position, topExit.transform.rotation));
            Rigidbody2D rigidbody2D;
            rigidbody2D =  djulat.ToArray()[djulat.ToArray().Length-1].GetComponent<Rigidbody2D>();
            djulat.ToArray()[djulat.ToArray().Length - 1].GetComponent<djuleScript>().cameraObject = this.gameObject;
            rigidbody2D.velocity = djulat.ToArray()[djulat.ToArray().Length - 1].transform.up * exitForce;
            playing = true;
        }
        if (djulat.ToArray().Length > 0)
        {
            najviseDjule = djulat.ToArray()[0];
            for (int i = 0; i < djulat.ToArray().Length; i++)
            {
                if (djulat.ToArray()[i] != null)
                {
                    if(najviseDjule == null)
                    {
                        najviseDjule = djulat.ToArray()[i];
                    }
                    if (najviseDjule.transform.position.y < djulat.ToArray()[i].transform.position.y)
                    {
                        najviseDjule = djulat.ToArray()[i];
                    }
                }
            }
            kameraFollow.objectToFollow = najviseDjule;
            kameraFollow.enabled = true;
            
        }
        while (this.transform.position.y + 40 > genMax)
        {
            Instantiate(colObj, new Vector2(Random.Range(-2.5f, 2.5f), genMax), new Quaternion());
            genMax += spawnFreq;
        }

        if(listeningForSpace && Input.GetKeyDown(KeyCode.Space))
        {

            for (int i = 0; i < djulat.ToArray().Length; i++)
            {
                if (djulat.ToArray()[i] != null)
                {
                    if (djuleObj != djulat.ToArray()[i])
                    {
                        Destroy(djulat.ToArray()[i]);
                    }
                }
            }
            //pop
            djuleObj.GetComponent<Rigidbody2D>().velocity = new Vector2(djuleObj.GetComponent<Rigidbody2D>().velocity.x , 12);
            Destroy(targetObj);
               
            djulat.Add(Instantiate(Djule, djuleObj.transform.position, new Quaternion(0, 0, djuleObj.transform.rotation.z, djuleObj.transform.rotation.w)));
            Rigidbody2D rigidbody2D;
            rigidbody2D = djulat.ToArray()[djulat.ToArray().Length - 1].GetComponent<Rigidbody2D>();
            djulat.ToArray()[djulat.ToArray().Length - 1].GetComponent<djuleScript>().cameraObject = this.gameObject;
            rigidbody2D.velocity = new Vector2( djuleObj.GetComponent<Rigidbody2D>().velocity.x-3, djuleObj.GetComponent<Rigidbody2D>().velocity.y+3);

            djulat.Add(Instantiate(Djule, djuleObj.transform.position, new Quaternion(0, 0, djuleObj.transform.rotation.z, djuleObj.transform.rotation.w)));
            //Rigidbody2D rigidbody2D;
            rigidbody2D = djulat.ToArray()[djulat.ToArray().Length - 1].GetComponent<Rigidbody2D>();
            djulat.ToArray()[djulat.ToArray().Length - 1].GetComponent<djuleScript>().cameraObject = this.gameObject;
            rigidbody2D.velocity = new Vector2(djuleObj.GetComponent<Rigidbody2D>().velocity.x + 3, djuleObj.GetComponent<Rigidbody2D>().velocity.y - 3);


            unCollision();
        }
    }
    public void Collision(GameObject djuleObj, GameObject colObj)
    {
        listeningForSpace = true;
        this.djuleObj = djuleObj;
        this.targetObj = colObj;
    }
    public void unCollision()
    {
        listeningForSpace = false;
    }
}
