using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float _speed;
    [SerializeField] public float _HorizontalMove;
    private Rigidbody2D _rb;

    [Header("Jump")]
    [SerializeField] private float _jumpForce;
    private bool _isGround;


    Transformation _transformation;

    private Animator _anim;

    [HideInInspector] public float _trWere;
     public bool _canMove = true;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _transformation = GetComponent<Transformation>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_canMove)
        {
            MovePlayer();
            JumpPlayer();

        }
        
        
    }
    private void MovePlayer() // тут типо перс перемещается
    {
        _HorizontalMove = Input.GetAxisRaw("Horizontal");
        _anim.SetFloat("Run", Mathf.Abs(_HorizontalMove));
        if (!_transformation._inBody)
        {
            
            //transform.position += new Vector3(_speed * _HorizontalMove, 0) * Time.deltaTime;
            //_rb.velocity = new Vector3(0, _rb.velocity.y, 0);
            _rb.velocity = new Vector2(_speed * _HorizontalMove, _rb.velocity.y);
            if (Input.GetKey(KeyCode.D))
            {
                _trWere = 1;
                transform.localScale = new Vector3(1, 1 , 1);
            }
            if(Input.GetKey(KeyCode.A))
            {
                _trWere = -1;
                transform.localScale = new Vector3(-1, 1, 1);
            }
        

        

        }
        if(_rb.velocity.y < 0)
        {
            _anim.SetBool("IsFly", true);
        }
       
        
    }
    private void JumpPlayer()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isGround && !_transformation._inBody)
        {
            _rb.velocity = new Vector2(0, 0);
            _rb.AddForce(new Vector2(_rb.velocity.x, _jumpForce), ForceMode2D.Impulse);
            _anim.SetTrigger("JumpT");
        }
    }





    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            _anim.SetTrigger("IsGroung");
            _anim.SetBool("IsFly", false);
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
            SceneManager.LoadScene(0);
            
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            _isGround = false;
        }
    }
}
