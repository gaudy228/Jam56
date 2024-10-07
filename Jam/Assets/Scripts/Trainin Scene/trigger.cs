using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public GameObject obj;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Player"))
        {
            obj.SetActive(false);
        }
    }
}
