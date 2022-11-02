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
    Rigidbody rb;
    Vector3 gliding = new Vector3(0, 0, 1);

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

        rb.velocity = new Vector3(0, 0, glideSpeed);


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // You successfully hi
        if (Physics.Raycast(ray, out hit))
        {
            // Find the direction to move in
            Vector3 pos3d = hit.point - transform.position;

            // Make it so that its only in x and y axis
            pos3d.y = 1; // No vertical movement
            pos3d.z = 1; // No forward movement

            GameObject.Find("Player").transform.position = pos3d;
        }
    }

    
}
