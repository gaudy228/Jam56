using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [HideInInspector] public GameObject _Player;
    [HideInInspector] public Transformation _transformation;

    [Header("Move")]
    public float _speed;
    public float _HorizontalMoveE;
    [HideInInspector] public Rigidbody2D _rb;

    public float _jumpForce;
    [HideInInspector] public bool _Plant;
    public bool _isGround;
    [HideInInspector] public bool minJamp = false;
    [HideInInspector] public bool _isWater;
    [HideInInspector] public bool _isWood;
     public GameObject _Wood;
     public Rigidbody2D _rbWood;
    private void Awake()
    {
        _rb = GetComponentInParent<Rigidbody2D>();
        _Player = GameObject.FindWithTag("Player");
    }
    void Start()
    {
        
        
        _transformation = _Player.GetComponent<Transformation>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();

    }
    public void Move()
    { 
            _HorizontalMoveE = Input.GetAxisRaw("Horizontal");
            
            _rb.velocity = new Vector2(_speed * _HorizontalMoveE, _rb.velocity.y);
        
    }
    public void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && _isGround)
        {
            _rb.velocity = new Vector2(0, 0);
            _rb.AddForce(new Vector2(_rb.velocity.x, _jumpForce), ForceMode2D.Impulse);
            if (!minJamp)
            {
                minJamp = true;
            }
        }
        

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            _isGround = true;
        }
        if (col.gameObject.CompareTag("Water"))
        {
            _isWater = true;
        }
        if (col.gameObject.CompareTag("Wood"))
        {
            
            _isWood = true;
            _Wood = col.gameObject;
            _rbWood = col.gameObject.GetComponent<Rigidbody2D>();
        }
        if (col.gameObject.CompareTag("CountPoop"))
        {
            _Plant = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            _isGround = false;
        }
        if (col.gameObject.CompareTag("Water"))
        {
            _isWater = false;
        }
        if (col.gameObject.CompareTag("Wood"))
        {
           
            _isWood = false;
            _rbWood.velocity = new Vector2(0, _rbWood.velocity.y);
            _Wood = null;
            _rbWood = null;
        }
        if (col.gameObject.CompareTag("CountPoop"))
        {
            _Plant = false;
        }
    }
}
