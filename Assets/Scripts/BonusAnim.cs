using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusAnim : MonoBehaviour
{
    //[SerializeField] GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpringFX()
    {
        transform.DOMoveY(transform.position.y + 2, 1f, false)
            .SetEase(Ease.OutElastic);
        Debug.Log("#PEPOUZE");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
