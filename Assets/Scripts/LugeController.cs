using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LugeController : MonoBehaviour
{
    [SerializeField] LayerMask runwayLayerMask;

    bool willJump = true;
    float chrono = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Jump()
    {
        GameObject luge = GameObject.Find("Luge");
        //luge.transform.position = new Vector3(luge.transform.position.x, luge.transform.position.y, luge.transform.position.z);
        transform.DOMove(new Vector3(luge.transform.position.x, 10, luge.transform.position.z), 3f)
            .SetEase(Ease.OutQuad);
        transform.DORotate(360, 1f, RotateMode.Fast);
        transform.DOMove(new Vector3(luge.transform.position.x, 0.5f, luge.transform.position.z), 3f)
            .SetDelay(3f)
            .SetEase(Ease.OutBounce);
    }

    // Update is called once per frame
    void Update()
    {

        chrono += Time.deltaTime;

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

        if (chrono > 10 && willJump)
        {
            Debug.Log("Jump");
            willJump = false;
            Jump();
        }
    }
}
