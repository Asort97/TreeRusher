using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{

    public bool isZoom;
    private float _startInterval;
    private TreeObject _closedTree;
    [SerializeField] private float _interval;
    [SerializeField] private Animator _anim;
    [SerializeField] private Text _currentWoods;
    private int _takedWoods;
    private void Update()
    {
        if(_closedTree != null)
        {
            float _dist = Vector3.Distance(_closedTree.transform.position, transform.position);
            if(_dist < 10f)
            {
                if(_startInterval <= 0f)
                {
                    _anim.SetTrigger("isAttack");
                    _startInterval = _interval;
                }
                else
                {
                    _startInterval -= Time.deltaTime;
                }
            }
        }
    }


    public void HitCurrentTree()
    {
        if(_closedTree != null)
        {
            _closedTree.TakeDamage(1);
        }
    }



    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Wood"))
        {
            other.gameObject.GetComponent<Wood>().OnTakeWood();
            _takedWoods++;
            _currentWoods.text = _takedWoods.ToString();
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Tree"))
        {
            isZoom = true;
            _closedTree = other.GetComponent<TreeObject>();
            _closedTree.BigArea();
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Tree"))
        {
            isZoom = false;
            _closedTree.SmallArea();
        }
    }

}
