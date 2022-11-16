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
    [SerializeField] GameObject endLine;
    //[SerializeField] FixedJoystick joystick;
    Rigidbody rb;
    Vector3 gliding = new Vector3(0, 0, 1);
    GameManager gameManager;
    float distance = 0;
    bool alive = true;



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

    public void Die()
    {
        alive = false;
        glideSpeed = Mathf.Lerp(glideSpeed, 0, 1);
        FindObjectOfType<GameManager>().Die();
    }

    // Update is called once per frame
    void Update()
    {
        // Distance entre le player et la ligne d'arrivée
        GetDistance();

        // Va chercher la fonction du Game Manager et transforme la distance en chaine de caractère
        FindObjectOfType<GameManager>().DistanceToString(distance);

        // transform.Translate( gliding * glideSpeed * Time.deltaTime);
        if (alive)
        {
            glideSpeed += glideAcceleration;
        }


    }
    private void FixedUpdate()
    {
        rb.velocity = gliding * glideSpeed;
    }


}
