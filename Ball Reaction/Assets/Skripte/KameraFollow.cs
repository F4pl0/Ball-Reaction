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
            float interpolation = speed * Time.deltaTime;
            Vector3 position = this.transform.position;
            if (objectToFollow != null)
            {
                position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y, interpolation);
                this.transform.position = position;
            }
        }
    }
}