using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject luge;
    [SerializeField] GameObject endLine;
    [SerializeField] TextMesh txtDistance;
    PlayerController playerController;

    float distance = 0;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        txtDistance.text = distance.ToString();
    }

    public void Win()
    {
        txtDistance.gameObject.SetActive(false);
        Invoke("Restart", 4f);
    }

    public void Die()
    {
        VivaItalia();
        Invoke("Restart", 2f);
    }

    void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void DistanceToString(float distance)
    {
        txtDistance.text = distance.ToString();
    }

    void VivaItalia()
    {
        Debug.Log("Pasta !");
    }

}
