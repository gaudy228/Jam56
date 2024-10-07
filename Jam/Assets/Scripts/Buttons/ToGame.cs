using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToPlay()
    {
        SceneManager.LoadScene(1);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ToTraining()
    {
        SceneManager.LoadScene(2);
    }
}
