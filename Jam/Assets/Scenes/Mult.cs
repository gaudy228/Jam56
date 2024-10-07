using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mult : MonoBehaviour
{
    public int _a = 0;
    public GameObject _E1;
    public GameObject _E2;
    public GameObject _E3;
    public GameObject _E4;
    public GameObject _E5;
    public GameObject _E6;
    public GameObject _E7;
    public GameObject _E8;
    public GameObject _E9;
    public GameObject _E10;
    void Start()
    {
        _E1.SetActive(true);
        _E2.SetActive(false);
        _E3.SetActive(false);
        _E4.SetActive(false);
        _E5.SetActive(false);
        _E6.SetActive(false);
        _E7.SetActive(false);
        _E8.SetActive(false);
        _E9.SetActive(false);
        _E10.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetMouseButtonDown(0))
        {
            _a++;
        }
       if(_a == 1)
       {
            _E1.SetActive(false);
            _E2.SetActive(true);
       }
       if(_a == 2)
       {
            _E2.SetActive(false);
            _E3.SetActive(true);
        }
       if(_a == 3)
       {
            _E3.SetActive(false);
            _E4.SetActive(true);
        }
        if (_a == 4)
        {
            _E4.SetActive(false);
            _E5.SetActive(true);
        }
        if (_a == 5)
        {
            _E5.SetActive(false);
            _E6.SetActive(true);
        }
        if (_a == 6)
        {
            _E6.SetActive(false);
            _E7.SetActive(true);
        }
        if (_a == 7)
        {
            _E7.SetActive(false);
            _E8.SetActive(true);
        }
        if (_a == 8)
        {
            _E8.SetActive(false);
            _E9.SetActive(true);
        }
        if (_a == 9)
        {
            _E9.SetActive(false);
            _E10.SetActive(false);
            Time.timeScale = 1;
            
        }

    }
}
