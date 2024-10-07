using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class Ant : EnemyBehaviour
{
    
    public bool _isParent;
    [SerializeField] private float _speedWood;
    private bool _isClimb = false;

    Move _move;
    private float _startSpeed;
    private Animator _anim;
    private bool _canMoveE = true;

    private bool _isClimpMoreFirst = false;
    
    private bool _localPScale;
    private void Start()
    {
        _move = _Player.GetComponent<Move>();
        _startSpeed = _speed;
        _anim = GetComponentInParent<Animator>();
    }
    void Update()
    {
        if (_isParent)
        {
            _Player.GetComponent<SpriteRenderer>().enabled = false;
            _localPScale = true;
            if (!_isClimb)
            {
                
                Jump();

            }
            if (Input.GetKey(KeyCode.D) && !_isWood && !Input.GetKey(KeyCode.LeftShift))
            {

                transform.parent.localScale = new Vector3(1.3f, 1.1f, 1);
            }
            if (Input.GetKey(KeyCode.A) && !_isWood && !Input.GetKey(KeyCode.LeftShift))
            {

                transform.parent.localScale = new Vector3(-1.3f, 1.1f, 1);
            }
            Move();
           
            DragWood();
            

            _anim.SetFloat("Run", Mathf.Abs(_HorizontalMoveE));
            if (Input.GetKey(KeyCode.Space) && _isGround)
            {
                _anim.SetTrigger("JumpT");

            }
        }
        else
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            if (_localPScale)
            {
                _Player.transform.localScale = new Vector3(1, 1, 1);
                _Player.GetComponent<SpriteRenderer>().enabled = true;
                _localPScale = false;
                _anim.SetFloat("Run", 0);
            }

            
        }


        if (_Player.transform.parent == transform.parent)
        {
            _isParent = true;
        }
        else
        {
            _isParent = false;
        }
        
        
    }
   private void DragWood()
   {
        if (_isWood  && Input.GetKey(KeyCode.LeftShift))
        {
            if (!_isClimpMoreFirst)
            {

                StartCoroutine(AnimBeg());
                _isClimpMoreFirst = true;

            }
            
            
            if (_canMoveE)
            {
                _isClimb = true;
                _speed = _speedWood;
                if (_rbWood != null)
                {
                    _rbWood.velocity = new Vector2(_speedWood * _HorizontalMoveE, _rbWood.velocity.y);
                }
                if(_HorizontalMoveE == 0)
                {
                    _anim.SetBool("Stop", true);
                }
                else
                {
                    _anim.SetBool("Stop", false);

                }
            } 
        }
        else if(!Input.GetKey(KeyCode.LeftShift) || !_isWood)
        {
            if (_isClimpMoreFirst)
            {
                StartCoroutine(AnimExit());
                _isClimpMoreFirst= false;
            }
            
            if (_canMoveE)
            {    _speed = _startSpeed;
                if(_rbWood != null)
                {
                    _rbWood.velocity = new Vector2(0, _rbWood.velocity.y);

                }
            
                _isClimb = false;

            }
            

        }
       
       
   }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            _anim.SetTrigger("IsGroung");
        }
    }
    private IEnumerator AnimExit()
    {
        _anim.SetTrigger("ExitT");
        _canMoveE = false;
        yield return new WaitForSeconds(0.2f);
        _canMoveE = true;
    }
    private IEnumerator AnimBeg()
    {
        _anim.SetTrigger("BeginT");
        
        _canMoveE = false;
        yield return new WaitForSeconds(0.3f);
        
        _canMoveE = true;
    }
}
