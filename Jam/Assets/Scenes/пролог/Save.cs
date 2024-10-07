using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public int _a;
    public int _b;
    public Transform _camera;
    public Transform _T1;
    public Transform _T2;
    public Transform _T3;
    public Transform _T4;
    public Transform _T5;
    void Start()
    {
        _b = PlayerPrefs.GetInt("_b", _b);
        _a = _b;
        if(_a == 0)
        {
            transform.position = _T1.position;
            _camera.position = new Vector3 (_T1.position.x, _T1.position.y, -10);
        }
        if (_a == 1)
        {
            transform.position = _T2.position;
            _camera.position = new Vector3(_T2.position.x, _T2.position.y, -10);
        }
        if (_a == 2)
        {
            transform.position = _T3.position;
            _camera.position = new Vector3(_T3.position.x, _T3.position.y, -10);
        }
        if (_a == 3)
        {
            transform.position = _T4.position;
            _camera.position = new Vector3(_T4.position.x, _T4.position.y, -10);
        }
        if (_a == 4)
        {
            transform.position = _T5.position;
            _camera.position = new Vector3(_T5.position.x, _T5.position.y, -10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _b = _a;
        PlayerPrefs.SetInt("_b", _b);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("1"))
        {
            _a = 1;
        }
        if (collision.gameObject.CompareTag("2"))
        {
            _a = 2;
        }
        if (collision.gameObject.CompareTag("3"))
        {
            _a = 3;
        }
        if (collision.gameObject.CompareTag("4"))
        {
            _a = 4;
        }
    }
}
