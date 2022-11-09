using DG.Tweening;
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
    [SerializeField] GameObject endLine;
    //[SerializeField] FixedJoystick joystick;
    Rigidbody rb;
    Vector3 gliding = new Vector3(0, 0, 1);
    GameManager gameManager;
    float distance = 0;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
   
        
    }
    
    public void GetDistance()
    {
        distance = Vector3.Distance(transform.position, endLine.transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        GetDistance();
        // transform.Translate( gliding * glideSpeed * Time.deltaTime);
        glideSpeed += glideAcceleration;
        FindObjectOfType<GameManager>().DistanceToString(distance);


    }
    private void FixedUpdate()
    {
        rb.velocity = gliding * glideSpeed ;
    }


}
