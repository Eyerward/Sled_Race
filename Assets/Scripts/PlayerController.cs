using DG.Tweening;
using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float glideSpeed = 0;
    public float glideAcceleration = 0.01f;
    [SerializeField] GameObject endLine;
    //[SerializeField] FixedJoystick joystick;
    Rigidbody rb;
    Vector3 gliding = new Vector3(0, 0, 1);
    GameManager gameManager;
    float distance = 0;
    bool alive = true;
    bool debuger = true;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }
    /**********START**********/
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
        glideSpeed = 0;
        transform.DOMoveZ(transform.position.z + 5, 0.5f, false)
            .SetEase(Ease.OutBack);
        FindObjectOfType<GameManager>().Die();
    }

    public void Win()
    {
        alive = false;
        glideSpeed = 0;

    }

    /**********UPDATE**********/
    void Update()
    {
        // Distance entre le player et la ligne d'arrivée
        GetDistance();

        // Peut servir à afficher un message au bout d'une certaine distance
        if (distance <= 2 && debuger)
        {
            Debug.Log("Ping - Pong");
            debuger = false;
        }

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
