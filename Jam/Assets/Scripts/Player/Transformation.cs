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
    private Animator _anim;
    Move _move;

    

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _move = GetComponent<Move>();
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
            _rb.gravityScale = 0;
            StartCoroutine(AmimVsel());
            _move._canMove = false;
            _rb.velocity = new Vector2(0, 0);
            
            StartCoroutine(ReloadingTramsform());
        }
        if (Input.GetKey(KeyCode.E) && isTransformation && _canTransform && _inBody)
        {
            
            StartCoroutine(AmimVausel());
            StartCoroutine(ReloadingTramsform());
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        
        
        if(_inBody && transform.parent == enemy.transform)
        {
            transform.position = enemy.transform.position;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        if(enemy == null)
        {
            _move._canMove = true;
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
    public IEnumerator AmimVausel()
    {
        _inBody = false;
        transform.parent = null;
        _rb.velocity = new Vector2(0, 0);
        transform.localPosition = new Vector3(transform.localPosition.x + 1.45f, transform.localPosition.y);
        _anim.SetTrigger("VauselT");
        _anim.SetBool("VauselB", true);
        _rb.gravityScale = 0;
        yield return new WaitForSecondsRealtime(1);
        
        _anim.SetBool("VauselB", false);
        
        if(enemy != null && _rbEnemy != null)
        {
            _rbEnemy.velocity = new Vector2(0, 0);
            _rbEnemy = null;
        
            enemy = null;

        }
        
        _rb.gravityScale = 1;
        _move._canMove = true;
    }
    private IEnumerator AmimVsel()
    {
        
        if (transform.position.x > enemy.transform.position.x)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, 1);
        }
        if (transform.position.x < enemy.transform.position.x)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, 1);
        }
       
        _anim.SetTrigger("VselT");
        _anim.SetBool("VselB", true);
        yield return new WaitForSecondsRealtime(1);
        _anim.SetBool("VselB", false);
        _inBody = true;
        _rb.velocity = new Vector2(0, 0);
         transform.parent = enemy.transform;
         _rbEnemy = enemy.GetComponent<Rigidbody2D>();
        transform.position = enemy.transform.position;
        transform.localScale = new Vector3(1, transform.localScale.y, 1);
    }
}
