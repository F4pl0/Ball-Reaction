using UnityEngine;
using System.Collections;

public class KameraFollow : MonoBehaviour
{

    public GameObject objectToFollow;
    public GameObject trackObj;
    public bool enabled = false;
    bool tracking = false;

    public float speed = 2.0f;

    void Update()
    {
        if (enabled)
        {
            if (!tracking)
            {
                float interpolation = speed * Time.deltaTime;

                Vector3 position = this.transform.position;
                position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y, interpolation);
                //position.x = Mathf.Lerp(0, 0, 0);

                this.transform.position = position;

            }
            else
            {
                float interpolation = speed * Time.deltaTime;

                Vector3 position = this.transform.position;
                position.y = Mathf.Lerp(this.transform.position.y, trackObj.transform.position.y, interpolation);
                position.x = Mathf.Lerp(this.transform.position.x, trackObj.transform.position.x, interpolation);

                this.transform.position = position;
            }
            
        }
        }
    public void track(GameObject obj)
    {
        
        //tracking = true;
        this.trackObj = obj;
        this.GetComponent<Camera>().orthographicSize = 3;
        
    }
    public void stopTrack()
    {
        
        tracking = false;
        this.GetComponent<Camera>().orthographicSize = 5;
        this.gameObject.transform.Translate(new Vector2(0, this.gameObject.transform.position.y));
        
    }
}