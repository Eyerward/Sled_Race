using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LugeController : MonoBehaviour
{
    [SerializeField] LayerMask runwayLayerMask;
    [SerializeField] GameObject player;
    GameManager gameManager;
    PlayerController playerController;
    CameraBehavior cameraBehavior;
    bool alive = true ;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerController = FindObjectOfType<PlayerController>();
        cameraBehavior = FindObjectOfType<CameraBehavior>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    void Jump()
    {
        GameObject luge = GameObject.Find("Luge");
        transform.DOMoveY(luge.transform.position.y + 15, 1f, false)
            .SetEase(Ease.OutQuad);
        transform.DORotate(new Vector3(-360, luge.transform.eulerAngles.y, luge.transform.eulerAngles.z), 1.5f, RotateMode.FastBeyond360)
            .SetDelay(0.1f)
            .SetEase(Ease.OutBack);
        transform.DOMoveY(luge.transform.position.y, 3f, false)
            .SetDelay(1f)
            .SetEase(Ease.OutBounce);
    }
    void Win()
    {
        alive = false ;
        gameManager.Win();
        playerController.Win();
        transform.DOMove(new Vector3(0, 26, 1051), 2f, false)
            .SetEase(Ease.OutQuad);
        transform.DORotate(new Vector3(-37, 0, 0), 0.5f, RotateMode.Fast)
            .SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Save the info
        RaycastHit hit;

        // You successfully hit
        if (Physics.Raycast(ray, out hit, 100, runwayLayerMask) && alive)
        {
            // Find the direction to move in
            //Vector3 gliding = hit.point - rb.transform.position;

            float posX = hit.point.x;
            GameObject luge = GameObject.Find("Luge");
            luge.transform.position = new Vector3(posX, luge.transform.position.y, luge.transform.position.z);
        }

      
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Bonus"))
        { 
            Jump();
            cameraBehavior.JumpEffect();
            //trigger.GetComponent<BonusAnim>().SpringFX();
        }

        if (trigger.gameObject.CompareTag("Enemy"))
        {
            alive = false ;
            FindObjectOfType<PlayerController>().Die();
        }

        if (trigger.gameObject.CompareTag("EndLine"))
        {
            Win();
        }
    }


}
