
using UnityEngine;


public class Grasshopper : EnemyBehaviour
{
    [SerializeField] private float _dopJumpForce;
    public bool _isParent;
    private Animator _anim;
    private bool _localPScale;
    // Update is called once per frame
    private void Start()
    {
        _anim = GetComponentInParent<Animator>();
    }
    void Update()
    {
        if(_isParent)
        {
            _localPScale = true;
            Move();
            Jump();
            DopJump();
            _Player.GetComponent<SpriteRenderer>().enabled = false;
            _anim.SetFloat("Run", Mathf.Abs(_HorizontalMoveE));
            if (Input.GetKey(KeyCode.D))
            {
                
                transform.parent.localScale = new Vector3(1.875f, 2.2579f, 1);
            }
            if (Input.GetKey(KeyCode.A))
            {
                
                transform.parent.localScale = new Vector3(-1.875f, 2.2579f, 1);
            }
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
                _localPScale = false;
            }
            
            _Player.GetComponent<SpriteRenderer>().enabled = true;
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
            _anim.SetTrigger("JumpT");
        }

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            _anim.SetTrigger("IsGroung");
        }
    }



}
