using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float turnSpeed = 45f;
    private float speed = 30f;
    public Canvas canvas;
    public float stopPositionZ = 158f;
    public float decelerationDistance = 10f;
    private float targetSpeed;
    public float minSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);
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
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }
        else {
            SceneManager.LoadScene("Intro");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Obstacle")) {
            Time.timeScale = 0;
            GameOver();
        }
    }

    void GameOver() {
        SceneManager.LoadScene("Intro");
    }
}
