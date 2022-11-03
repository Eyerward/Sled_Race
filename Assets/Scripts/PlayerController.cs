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
    [SerializeField] LayerMask runwayLayerMask;
    //[SerializeField] FixedJoystick joystick;
    Rigidbody rb;
    Vector3 gliding = new Vector3(0, 0, 1);
    Vector3 glideDirection;
    
    

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


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Save the info
        RaycastHit hit;

        // You successfully hit
        if (Physics.Raycast(ray,out hit, 100, runwayLayerMask))
        {
            // Find the direction to move in
            //Vector3 gliding = hit.point - rb.transform.position;

            float posX = hit.point.x;
            GameObject player = GameObject.Find("Player");
            player.transform.position = new Vector3(posX, player.transform.position.y, player.transform.position.z);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = gliding * glideSpeed ;
    }


}
