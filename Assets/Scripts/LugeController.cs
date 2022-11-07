using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LugeController : MonoBehaviour
{
    [SerializeField] LayerMask runwayLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Jump()
    {
        GameObject luge = GameObject.Find("Luge");
        transform.DOMoveY(luge.transform.position.y + 10, 1f, false)
            .SetEase(Ease.OutQuad);
        transform.DORotate(new Vector3(360, luge.transform.eulerAngles.y, luge.transform.eulerAngles.z), 1f, RotateMode.FastBeyond360)
            .SetDelay(0.1f)
            .SetEase(Ease.Linear);
        transform.DOMoveY(luge.transform.position.y, 2f, false)
            .SetDelay(1f)
            .SetEase(Ease.OutBounce);
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
        }
    }
}
