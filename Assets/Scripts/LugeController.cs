using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LugeController : MonoBehaviour
{
    [SerializeField] LayerMask runwayLayerMask;
    GameManager gameManager;
    PlayerController playerController;
    CameraBehavior cameraBehavior;
    Bonus bonus;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerController = FindObjectOfType<PlayerController>();
        cameraBehavior = FindObjectOfType<CameraBehavior>();
        bonus = FindObjectOfType<Bonus>();
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
        transform.DORotate(new Vector3(360, luge.transform.eulerAngles.y, luge.transform.eulerAngles.z), 1.5f, RotateMode.FastBeyond360)
            .SetDelay(0.1f)
            .SetEase(Ease.OutBack);
        transform.DOMoveY(luge.transform.position.y, 3f, false)
            .SetDelay(1f)
            .SetEase(Ease.OutBounce);
    }
    void Win()
    {
        gameManager.Win();
        playerController.Win();
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Save the info
        RaycastHit hit;

        // You successfully hit
        if (Physics.Raycast(ray, out hit, 100, runwayLayerMask))
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
            bonus.SpringFX();
            //trigger.GetComponent<BonusAnim>().SpringFX();
        }

        if (trigger.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<PlayerController>().Die();
        }

        if (trigger.gameObject.CompareTag("EndLine"))
        {
            Win();
        }
    }


}
