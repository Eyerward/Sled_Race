using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] GameObject platform;
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
            if (transform.position.z <= player.transform.position.z - 20)
            {
                float placement = Random.Range(-4f, 4f);
                placement = Mathf.Floor(placement);
                transform.position = new Vector3(placement, transform.position.y, transform.position.z + 300);
            }
            if (transform.position.z >= endLine.transform.position.z-50)
            {
                Destroy(gameObject);
            }
        }
    }
}
