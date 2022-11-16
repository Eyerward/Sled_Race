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
        distance = Mathf.Floor(distance);
    }
    // Update is called once per frame
    void Update()
    {
        // Distance entre le player et la ligne d'arriv�e
        GetDistance();
        // transform.Translate( gliding * glideSpeed * Time.deltaTime);
        glideSpeed += glideAcceleration;

        // Va chercher la fonction du Game Manager et transforme la distance en chaine de caract�re
        FindObjectOfType<GameManager>().DistanceToString(distance);


    }
    private void FixedUpdate()
    {
        rb.velocity = gliding * glideSpeed ;
    }


}
