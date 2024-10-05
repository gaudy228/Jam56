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
    private void Start()
    {
        _move = _Player.GetComponent<Move>();
        _startSpeed = _speed;
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
            if(_Wood != null)
            {
                DragWood();
            }
            

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
            _isClimb = true;
            _speed = _speedWood;
            _rbWood.velocity = new Vector2(_speedWood * _move._HorizontalMove, _rbWood.velocity.y);
            
        }
        else
        {
            _speed = _startSpeed;
            _rbWood.velocity = new Vector2(0, _rbWood.velocity.y);
            _isClimb = false;

        }
       
    }
}
