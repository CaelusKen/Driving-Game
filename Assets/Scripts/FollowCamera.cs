using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0,5,-7);
    private float smoothSpeed = 0.125f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        Vector3 desiredPosition = player.transform.TransformDirection(offset);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, smoothSpeed);
    }
}
