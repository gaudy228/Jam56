using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaterMeter : EnemyBehaviour
{
    
    public bool _isParent;
    private Animator _anim;
    private bool _localPScale;
    [SerializeField] private float _jumpWaterForce;
    
    private void Start()
    {
        _anim = GetComponentInParent<Animator>();
    }
    void Update()
    {
        if (_isParent)
        {
            Move();
            Jump();
            JumpWater();
            _Player.GetComponent<SpriteRenderer>().enabled = false;
            if (Input.GetKey(KeyCode.D))
            {

                transform.parent.localScale = new Vector3(1.3f, 1.3f, 1);
            }
            if (Input.GetKey(KeyCode.A))
            {

                transform.parent.localScale = new Vector3(-1.3f, 1.3f, 1);
            }
            if (Input.GetKey(KeyCode.Space) && _isGround)
            {
                _anim.SetTrigger("JumpT");

            }
            _anim.SetFloat("Run", Mathf.Abs(_HorizontalMoveE));
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

    private void JumpWater()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isWater && !_isGround)
        {
            _rb.velocity = new Vector2(0, 0);
            _rb.AddForce(new Vector2(_rb.velocity.x, _jumpWaterForce), ForceMode2D.Impulse);
            _anim.SetTrigger("JumpT");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Floor") || col.gameObject.CompareTag("Water"))
        {
            _anim.SetTrigger("IsGroung");
        }
    }
}
