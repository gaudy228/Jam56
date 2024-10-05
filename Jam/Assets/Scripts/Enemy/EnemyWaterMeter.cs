using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaterMeter : EnemyBehaviour
{
    
    public bool _isParent;
   
    [SerializeField] private float _jumpWaterForce;
    // Update is called once per frame
    void Update()
    {
        if (_isParent)
        {
            Move();
            Jump();
            JumpWater();

        }
        else
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y) ;
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

    private void JumpWater()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isWater && !_isGround)
        {
            _rb.velocity = new Vector2(0, 0);
            _rb.AddForce(new Vector2(_rb.velocity.x, _jumpWaterForce), ForceMode2D.Impulse);
           
        }
    }
    

}
