using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public float speed;
    public Vector3[] positions;

    private int currentTarget;
    private bool _stopPlatform;
    private bool _parentE = false;
    private bool _parentP = false;
    private void Update()
    {
        if (!_stopPlatform)
        {
            transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget], speed * Time.deltaTime);
        }
        
        

        if (transform.position == positions[currentTarget])
        {
            StartCoroutine(RealodingPlatforms());
            if (currentTarget < positions.Length - 1)
            {
                currentTarget++;
            }
            else
            {
                currentTarget = 0;
            }
        }
        
    }
    IEnumerator RealodingPlatforms()
    {
        _stopPlatform = true;
        yield return new WaitForSeconds(0.7f);
        _stopPlatform = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.transform.parent.parent = transform;
           
        }
        else if (collision.gameObject.CompareTag("Player") )
        {

            collision.gameObject.transform.parent = transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.transform.parent.parent = null;
        }
        else if (collision.gameObject.CompareTag("Player") )
        {
            collision.gameObject.transform.parent = null;
        }

    }
}
