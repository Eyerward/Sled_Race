using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float glideSpeed = 0;
    [SerializeField] float glideAcceleration = 0.01f;
    [SerializeField] float glideSpeedMax;
    [SerializeField] FixedJoystick joystick;
    Rigidbody rb;
    Vector3 gliding = new Vector3(0, 0, 1);
    Vector3 glideDirection;
    
    // Save the info
    RaycastHit hit;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
   
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate( gliding * glideSpeed * Time.deltaTime);
        glideSpeed += glideAcceleration;

        if (joystick.Direction.magnitude > 0)
        {
            glideDirection = new Vector3(joystick.Direction.x, 0, 0).normalized;
        }

        /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // You successfully hi
        if (Physics.Raycast(ray, out hit))
        {
            // Find the direction to move in
            Vector3 gliding = hit.point - rb.transform.position;
            Debug.Log(gliding.x);

            // Make it so that its only in x and y axis
            gliding.y = rb.transform.position.y; // No vertical movement
            gliding.z = rb.transform.position.z; // No forward movement

            GameObject.Find("Player").transform.position = gliding;
        }*/
    }
    private void FixedUpdate()
    {
        rb.velocity = (glideDirection * 3) * joystick.Direction.magnitude + gliding * glideSpeed;
    }


}
