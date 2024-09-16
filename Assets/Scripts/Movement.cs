using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizontalInput;
    private float turnSpeed = 7.5f;
    private float speed = 15f;
    public float minSpeed = 0f;
    public float stopPositionZ = 170f;
    public float decelerationDistance = 10f;
    private float targetSpeed;
    // Start is called before the first frame update
    void Start()
    {
        targetSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToEnd = stopPositionZ - transform.position.z;

        if (distanceToEnd <= decelerationDistance)
        {
            targetSpeed = Mathf.Lerp(minSpeed, speed, distanceToEnd / decelerationDistance);
        }

        if(transform.position.z < stopPositionZ) {
            horizontalInput = Input.GetAxis("Horizontal");

            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }
        else {
            Debug.Log("Pausing the car, mission complete");
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Obstacle")) {
            Debug.Log("Game Over!");
            Time.timeScale = 0f;
        }
    }
}
