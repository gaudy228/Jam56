using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlantGrowing : MonoBehaviour
{
    [HideInInspector] public EnemyDungBeetle _enemyDungBeetle;
    private bool _Plant = true;
    [SerializeField] private GameObject _PlantLadder;
    private void Update()
    {
        if(_enemyDungBeetle != null)
        {
            if (_enemyDungBeetle._PlantGrowing && _Plant)
            {

                
                _PlantLadder.SetActive(true);
                _Plant = false;
            }

        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CountPoop"))
        {
            
            _enemyDungBeetle = collision.gameObject.transform.parent.GetComponent<EnemyDungBeetle>();
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CountPoop"))
        {
            _enemyDungBeetle = null;
            
        }
    }
}
