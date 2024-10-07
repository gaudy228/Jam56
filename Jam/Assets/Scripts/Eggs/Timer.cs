using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float maxTime = 10f;
    private float currTime;
    private TextMeshPro count;
    private bool endTimer = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(!endTimer)
        {
            currTime += Time.deltaTime;
        }
        if (endTimer)
        {
            count.text = currTime.ToString();
        }
        

    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            endTimer = true;
        }
        
    }
}
