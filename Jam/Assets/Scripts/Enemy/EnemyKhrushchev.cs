
using System.Collections;
using UnityEngine;


public class EnemyKhrushchev : EnemyBehaviour
{
    public bool _isParent;
    private float _VerticalMove;
    private bool _startDied =true;
    [SerializeField] private GameObject _parent;
    [SerializeField] private GameObject _prefabParent;
    [SerializeField] private Transform _sppParent;
    
  
    void Update()
    {
        if (_isParent)
        {
            _Player.GetComponent<SpriteRenderer>().enabled = false;
            Move();
            //Jump();
            Fly();
            _rb.gravityScale = 8;
            if(_startDied)
            {
                StartCoroutine(TimeDie());
                _startDied = false;
            }
            if (Input.GetKey(KeyCode.D))
            {

                transform.parent.localScale = new Vector3(1.1f, 0.9f, 1);
            }
            if (Input.GetKey(KeyCode.A))
            {

                transform.parent.localScale = new Vector3(-1.1f, 0.9f, 1);
            }

        }
        else
        {
            _rb.gravityScale = 0;
            _rb.velocity = new Vector2(0, 0);
            
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
    

    private void Fly()
    {
        _VerticalMove = Input.GetAxisRaw("Vertical");

        _rb.velocity = new Vector2(_rb.velocity.x, _speed * _VerticalMove);
    }
    IEnumerator TimeDie()
    {
        _rb.velocity = new Vector2(0, 0);
        _Player.transform.localScale = new Vector3(1, 1, 1);
        _Player.GetComponent<SpriteRenderer>().enabled = true;
        
        yield return new WaitForSeconds(2f);
        
        _transformation._inBody = false;
        _Player.transform.parent = null;
        _transformation._canTransformBeforDieKhruch = true;
        
       
        Instantiate(_prefabParent, _sppParent.transform.position, _sppParent.transform.rotation);
        Destroy(_parent);
        
        
    }
}
