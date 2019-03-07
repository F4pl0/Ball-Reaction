using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class djuleScript : MonoBehaviour
{
    public float tilt = 0.2f;
    public GameObject cameraObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x+ Input.acceleration.x * tilt, transform.position.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0.3f;
        cameraObject.GetComponent<GameController>().Collision(this.gameObject, collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Time.timeScale = 1f;
        cameraObject.GetComponent<GameController>().unCollision();
    }
}
