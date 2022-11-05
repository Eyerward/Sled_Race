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
    //[SerializeField] FixedJoystick joystick;
    Rigidbody rb;
    Vector3 gliding = new Vector3(0, 0, 1);
    
    

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
    }
    private void FixedUpdate()
    {
        rb.velocity = gliding * glideSpeed ;
    }


}
