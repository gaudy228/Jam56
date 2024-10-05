
using UnityEngine;


public class Grasshopper : EnemyBehaviour
{
    [SerializeField] private float _dopJumpForce;
    public bool _isParent;

    // Update is called once per frame
    void Update()
    {
        if(_isParent)
        {   
            Move();
            Jump();
            DopJump();

        }
        else
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
        

        if(_Player.transform.parent == transform.parent)
        {
            _isParent = true;
        }
        else
        {
            _isParent = false;
        }
    }
    private void DopJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && minJamp && !_isGround)
        { 
            _rb.velocity = new Vector3(0, 0, 0);
            _rb.AddForce(new Vector2(_rb.velocity.x, _dopJumpForce), ForceMode2D.Impulse);
            minJamp = false;
        }

    }
        
        
   
        
}
