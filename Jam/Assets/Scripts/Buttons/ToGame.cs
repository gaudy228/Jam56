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
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(2);
    }
    public void ToMenu()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
    public void ToTraining()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
}
