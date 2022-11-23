using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void JumpEffect()
    {
        transform.DOMoveY(transform.position.y + 7, 1f).SetEase(Ease.OutSine);
        transform.DOMoveY(transform.position.y, 2f).SetDelay(1f).SetEase(Ease.InOutBack);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
