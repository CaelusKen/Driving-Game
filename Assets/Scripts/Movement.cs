using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float turnSpeed = 45f;
    private float speed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput * 6);
            }
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Obstacle")) {
            Debug.Log("Game Over!");
            Time.timeScale = 0f;
        }
    }
}
