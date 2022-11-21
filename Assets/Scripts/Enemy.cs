using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
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
        if (player.transform.position.z + 20 < endLine.transform.position.z)
        {
            if (transform.position.z <= player.transform.position.z)
            {
                float placement = Random.Range(-5f, 5f);
                placement = Mathf.Floor(placement);
                transform.position = new Vector3(placement, transform.position.y, player.transform.position.z + 20);
            }
        }
        
    }
}
