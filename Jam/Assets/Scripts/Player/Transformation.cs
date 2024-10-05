using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformation : MonoBehaviour
{
    private bool isTransformation = false;
    public bool _inBody = false;
    private GameObject enemy;
    private Rigidbody2D _rb;
    private Rigidbody2D _rbEnemy;
    private bool _canTransform = true;
    [HideInInspector] public bool _canTransformBeforDieKhruch = false;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Transform") && !_inBody)
        {
            isTransformation = true;
            enemy = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Transform") && !_inBody)
        {
            _rb.velocity = new Vector2(0, 0);
            isTransformation = false;
            transform.parent = null;
            enemy = null;
            _rb.gravityScale = 1;

        }
    }
    private void Update()
    {
        InOtherBody();

        if (_canTransformBeforDieKhruch)
        {
            _canTransformBeforDieKhruch = false;
            StartCoroutine(ReloadingTramsformBeforDieKhruch());
        }
    }
    private void InOtherBody()
    {
        if (Input.GetKey(KeyCode.E) && isTransformation && _canTransform && !_inBody)
        {
            _inBody = true;
            _rb.velocity = new Vector2(0, 0);
            
            transform.position = enemy.transform.position;

            transform.parent = enemy.transform;
            _rbEnemy = enemy.GetComponent<Rigidbody2D>();
            _rb.gravityScale = 0;
            StartCoroutine(ReloadingTramsform());
        }
        if (Input.GetKey(KeyCode.E) && isTransformation && _canTransform && _inBody)
        {
            _inBody = false;
            _rb.velocity = new Vector2(0, 0);
            _rbEnemy.velocity = new Vector2(0, 0);
            _rbEnemy = null;
            transform.parent = null;
            enemy = null;
            _rb.gravityScale = 1;
            StartCoroutine(ReloadingTramsform());
        }
        
        
        if(_inBody)
        {
            transform.position = enemy.transform.position;
        }
    }
    IEnumerator ReloadingTramsform()
    {
        _canTransform = false;
        yield return new WaitForSecondsRealtime(1f);
        _canTransform=true;
    }
    public IEnumerator ReloadingTramsformBeforDieKhruch()
    {
        _canTransform = false;
        yield return new WaitForSecondsRealtime(3f);
        _canTransform = true;
    }
}
