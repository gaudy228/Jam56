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
    private void Start()
    {
        
    }
    void Update()
    {
        if (_isParent )
        {
            Move();
            RidePoop();
            if(_countPoop == 0)
            {
                Jump();
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
    private void RidePoop()
    {
        if(_countPoop == 0 && _poop != null)
        {
            _poop.transform.localScale = new Vector2(0, 0);
        }
        if (_countPoop == 1 && _poop != null)
        {
            _poop.transform.localScale = new Vector2(0.5f, 0.5f);
        }
        if (_countPoop == 2 && _poop != null)
        {
            _poop.transform.localScale = new Vector2(0.7f, 0.7f);
        }
        if (_countPoop == 3 && _poop != null)
        {
            _poop.transform.localScale = new Vector2(1, 1);
        }

        if(Input.GetKeyDown(KeyCode.F) && _countPoop == 3 && _Plant)
        {
            _countPoop = 0;
            
            _poop.transform.parent = null;
            _PlantGrowing = true;
            Destroy(_poop);
            _Player.transform.parent = transform.parent;
        }
       

    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Poop"))
        {
            _countPoop++;
            Destroy(collision.gameObject);
        }
    }
   
}
