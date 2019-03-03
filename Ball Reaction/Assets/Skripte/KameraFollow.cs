using UnityEngine;
using System.Collections;

public class KameraFollow : MonoBehaviour
{

    public GameObject objectToFollow;
    public bool enabled = false;

    public float speed = 2.0f;

    void Update()
    {
        if (enabled)
        {
            float interpolation = speed * Time.deltaTime;

            Vector3 position = this.transform.position;
            position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y, interpolation);
            position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);

            this.transform.position = position;
        }
    }
}