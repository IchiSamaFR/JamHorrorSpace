using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displacement : MonoBehaviour
{
    public float WalkSpeed = 1f;
    public float RunSpeed = 2.8f;
    public float speed = 5f;
    public float Acceleration = 0.15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        Movement();
    }

    public void Movement() {
        if (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("a"))
        {
            if (Input.GetKeyDown(KeyCode.LeftShift)) {
                speed += RunSpeed * Acceleration * Time.fixedDeltaTime;
                speed = Mathf.Clamp(speed, 0, RunSpeed);
            } else {
                speed += WalkSpeed * Acceleration * Time.fixedDeltaTime;
                speed = Mathf.Clamp(speed, 0, WalkSpeed);
            }
            print(speed);
            if (Input.GetKey("w")) {
                transform.position += new Vector3(0, 0, 1) * speed;
            } else if (Input.GetKey("s")) {
                transform.position -= new Vector3(0, 0, 1) * speed;
            } else if (Input.GetKey("d")) {
                transform.position += new Vector3(1, 0, 0) * speed;
            } else if (Input.GetKey("a")) {
                transform.position -= new Vector3(1, 0, 0) * speed;
            }
        }
        else {
            speed = 0;
        }
    }
}
