using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runway : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject endLine;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z + 50 < endLine.transform.position.z)
        {
            if (transform.position.z <= player.transform.position.z - 20)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 120);
            }
            if (transform.position.z >= endLine.transform.position.z)
            {
                Destroy(gameObject);
            }
        }

    }
}
