using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject Djule;
    public GameObject colObj;
    public GameObject topExit;
    public GameObject gameover;
    public GameObject Top;
    public GameObject explosion;
    public Text ScoreTxt;
    public float exitForce = 10f;
    public AudioClip pucnjavaAudio;
    public AudioClip[] explozijeAudio;

    AudioSource audioSource;
    GameObject najviseDjule;
    bool waitingTap = false;
    animations topAnim;

    public List<GameObject> djulat;
    public List<GameObject> targetat;
    public KameraFollow kameraFollow;
    public bool playing = false;
    public float spawnFreq = 2;
    float genMax = 7;
    bool listeningForSpace = false;
    GameObject djuleObj, targetObj;
    public float maxHeight = 0;

    // Start is called before the first frame update
    void Start()
    {
        topAnim = Top.GetComponent<animations>();
        ScoreTxt.gameObject.SetActive(false);
        gameover.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > .5)
        {
            ScoreTxt.text = "Score: " + (int)maxHeight;
            if (Input.anyKeyDown || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space) && Time.timeSinceLevelLoad > 300)
            {
                if (!playing)
                {
                    ScoreTxt.gameObject.SetActive(true);
                    topAnim.animation = 1;
                    topAnim.pucTopAnim();
                    djulat.Add(Instantiate(Djule, topExit.transform.position, topExit.transform.rotation));
                    Rigidbody2D rigidbody2D;
                    rigidbody2D = djulat.ToArray()[djulat.ToArray().Length - 1].GetComponent<Rigidbody2D>();
                    djulat.ToArray()[djulat.ToArray().Length - 1].GetComponent<djuleScript>().cameraObject = this.gameObject;
                    rigidbody2D.velocity = djulat.ToArray()[djulat.ToArray().Length - 1].transform.up * exitForce;
                    playing = true;
                    kameraFollow.enabled = true;
                    audioSource.PlayOneShot(pucnjavaAudio, 1F);
                }
            }
            if (djulat.ToArray().Length > 0)
            {
                najviseDjule = djulat.ToArray()[0];
                for (int i = 0; i < djulat.ToArray().Length; i++)
                {
                    if (djulat.ToArray()[i] != null)
                    {
                        if (najviseDjule == null)
                        {
                            najviseDjule = djulat.ToArray()[i];
                        }
                        if (najviseDjule.transform.position.y < djulat.ToArray()[i].transform.position.y)
                        {
                            najviseDjule = djulat.ToArray()[i];
                        }
                    }
                }
                if (najviseDjule.transform.position.y > maxHeight)

                {
                    maxHeight = najviseDjule.transform.position.y;
                }
                if (najviseDjule.transform.position.y < maxHeight - 10)
                {
                    playing = false;
                    kameraFollow.enabled = false;
                    //GAME OVER
                    gameover.SetActive(true);
                    waitingTap = true;
                }
                kameraFollow.objectToFollow = najviseDjule;

            }
            if (Input.anyKeyDown || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) && Time.timeSinceLevelLoad > 300)
            {
                //Load scene
                if (waitingTap)
                {
                    SceneManager.LoadScene(1);
                }
            }
            for (int i = 0; i < targetat.ToArray().Length; i++)
            {
                if (targetat.ToArray()[i] != null)
                {
                    if (this.transform.position.y - 7 > targetat.ToArray()[i].transform.position.y)
                    {
                        Destroy(targetat.ToArray()[i]);
                    }
                }
            }
            while (this.transform.position.y + 40 > genMax)
            {
                targetat.Add(Instantiate(colObj, new Vector2(Random.Range(-2.5f, 2.5f), genMax), new Quaternion()));
                genMax += spawnFreq;
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.anyKeyDown || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began))
            {
                if (listeningForSpace)
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

                    audioSource.PlayOneShot(explozijeAudio[Random.Range(0, explozijeAudio.Length)], 1F);
                    //pop
                    djuleObj.GetComponent<Rigidbody2D>().velocity = new Vector2(djuleObj.GetComponent<Rigidbody2D>().velocity.x, 12);
                    Destroy(targetObj);

                    djulat.Add(Instantiate(Djule, djuleObj.transform.position, new Quaternion(0, 0, djuleObj.transform.rotation.z, djuleObj.transform.rotation.w)));
                    Instantiate(explosion, djuleObj.transform.position, new Quaternion(0, 0, djuleObj.transform.rotation.z, djuleObj.transform.rotation.w));
                    Rigidbody2D rigidbody2D;
                    rigidbody2D = djulat.ToArray()[djulat.ToArray().Length - 1].GetComponent<Rigidbody2D>();
                    djulat.ToArray()[djulat.ToArray().Length - 1].GetComponent<djuleScript>().cameraObject = this.gameObject;
                    rigidbody2D.velocity = new Vector2(djuleObj.GetComponent<Rigidbody2D>().velocity.x - 3, djuleObj.GetComponent<Rigidbody2D>().velocity.y + 3);

                    djulat.Add(Instantiate(Djule, djuleObj.transform.position, new Quaternion(0, 0, djuleObj.transform.rotation.z, djuleObj.transform.rotation.w)));
                    //Rigidbody2D rigidbody2D;
                    rigidbody2D = djulat.ToArray()[djulat.ToArray().Length - 1].GetComponent<Rigidbody2D>();
                    djulat.ToArray()[djulat.ToArray().Length - 1].GetComponent<djuleScript>().cameraObject = this.gameObject;
                    rigidbody2D.velocity = new Vector2(djuleObj.GetComponent<Rigidbody2D>().velocity.x + 3, djuleObj.GetComponent<Rigidbody2D>().velocity.y - 3);


                    unCollision();
                }
            }
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
