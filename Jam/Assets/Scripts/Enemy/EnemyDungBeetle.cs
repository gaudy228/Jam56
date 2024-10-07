using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDungBeetle : EnemyBehaviour
{
    [SerializeField] private float _dopJumpForce;
    public bool _isParent;
    [SerializeField] private int _countPoop;
    
    public bool _PlantGrowing = false;
    [SerializeField] private GameObject _poop;
    private Animator _anim;
    private bool _localPScale;
    private void Start()
    {
        _anim = GetComponentInParent<Animator>();
    }
    void Update()
    {
        if (_isParent )
        {
            _localPScale = true;
            _Player.GetComponent<SpriteRenderer>().enabled = false;
            Move();
            RidePoop();
            _anim.SetFloat("Run", Mathf.Abs(_HorizontalMoveE));
            if(_countPoop == 0)
            {
                
                Jump();
                if (Input.GetKey(KeyCode.Space) && _isGround)
                {
                    _anim.SetTrigger("JumpT");

                }
            }
            if (Input.GetKey(KeyCode.D))
            {

                transform.parent.localScale = new Vector3(1.3f, 1.3f, 1);
            }
            if (Input.GetKey(KeyCode.A))
            {

                transform.parent.localScale = new Vector3(-1.3f, 1.3f, 1);
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
    private void RidePoop()
    {
        if(_countPoop == 0 )
        {
            
            _anim.SetBool("PoopLB", false);
            _anim.SetBool("PoopMB", false);
            _anim.SetBool("PoopHB", false);
        }
        if (_countPoop == 1)
        {
            _anim.SetTrigger("PoopLT");
            _anim.SetBool("PoopLB", true);
            _anim.SetBool("PoopMB", false);
            _anim.SetBool("PoopHB", false);
        }
        if (_countPoop == 2 )
        {
            _anim.SetTrigger("PoopMT");
            _anim.SetBool("PoopLB", false);
            _anim.SetBool("PoopMB", true);
            _anim.SetBool("PoopHB", false);
        }
        if (_countPoop == 3)
        {
            _anim.SetTrigger("PoopHT");
            _anim.SetBool("PoopLB", false);
            _anim.SetBool("PoopMB", false);
            _anim.SetBool("PoopHB", true);
        }

        if(Input.GetKeyDown(KeyCode.F) && _countPoop == 3 && _Plant)
        {
            _countPoop = 0;   
            _PlantGrowing = true;
        }
       

    }

    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Poop"))
        {
            _countPoop++;
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("Floor"))
        {
            _anim.SetTrigger("IsGroung");
        }
    }
   
}
