using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowingDown : MonoBehaviour
{
    [HideInInspector] public EnemyDungBeetle _enemyDungBeetle;
    private bool _Plant = true;
    [SerializeField] private GameObject _PlantLadder;
    private Animator _anim;
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (_enemyDungBeetle != null)
        {
            if (_enemyDungBeetle._PlantGrowing && _Plant)
            {


                StartCoroutine(AnimGrowing());
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
    IEnumerator AnimGrowing()
    {
        _anim.SetBool("Growing", true);
        yield return new WaitForSeconds(0.8f);
        _PlantLadder.SetActive(true);
    }
}
