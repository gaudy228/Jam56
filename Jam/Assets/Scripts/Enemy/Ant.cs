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
    private bool _BehinAnim = false;
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
            if(!_isClimb)
            {
                
                Jump();

            }
            Move();
           
            DragWood();

            _anim.SetFloat("Run", Mathf.Abs(_HorizontalMoveE));

        }
        else
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            
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
        _BehinAnim = false;
        _canMoveE = false;
        yield return new WaitForSeconds(0.3f);
        _BehinAnim = true;
        _canMoveE = true;
    }
}
