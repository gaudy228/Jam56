
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
    //private void Start()
    //{
    //    _rb.velocity = new Vector2(0, 0);
    //}
    void Update()
    {
        if (_isParent)
        {
            Move();
            //Jump();
            Fly();
            _rb.gravityScale = 8;
            if(_startDied)
            {
                StartCoroutine(TimeDie());
                _startDied = false;
            }
            
        }
        else
        {
            _rb.velocity = new Vector2(0, 0);
            _rb.gravityScale = 0;
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
        yield return new WaitForSeconds(2f);
        _transformation._inBody = false;
        _Player.transform.parent = null;
        _transformation._canTransformBeforDieKhruch = true;
        _rb.velocity = new Vector2(0, 0);
        Instantiate(_prefabParent, _sppParent.transform.position, _sppParent.transform.rotation);
        Destroy(_parent);
        
        
    }
}
