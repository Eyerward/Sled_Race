using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject luge;
    [SerializeField] GameObject endLine;
    [SerializeField] TextMesh txtDistance;

    float distance = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        txtDistance.text = distance.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void DistanceToString(float distance)
    {
        txtDistance.text = distance.ToString();
    }
}
