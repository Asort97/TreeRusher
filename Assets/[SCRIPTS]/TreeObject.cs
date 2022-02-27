using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TreeObject : MonoBehaviour
{
    [SerializeField] private GameObject _hitParticles;
    [SerializeField] private GameObject _hitParticlesLeaf;
    [SerializeField] private GameObject _woodPrefab;
    [SerializeField] private GameObject _zoneAttack;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _spawnPointLeaf;
    [SerializeField] private Animator _anim;

    [SerializeField] private float _forceWoods;



    private bool isDead;
    private int _hp = 6;


    public void TakeDamage(int _damage)
    {
        _hp -= _damage;
        _anim.SetTrigger("isHit");
        SpawnWoods();
        if(_hp == 0)
        {
            FallTree();
            isDead = true;
            Camera.main.GetComponent<GameManager>().SpawnTree();
            _zoneAttack.SetActive(false);
            Destroy(gameObject,3f);
        }
    }

    private void SpawnWoods()
    {
        Instantiate(_hitParticles, _spawnPoint.position, Quaternion.identity);
        Instantiate(_hitParticlesLeaf, _spawnPointLeaf.position, Quaternion.identity);
        GameObject _wood = Instantiate(_woodPrefab, _spawnPoint.position, Quaternion.identity);

        Vector3 _randDir = new Vector3(Random.Range(-1, 2), 0, Random.Range(-1, 2)); 
        _wood.GetComponent<Rigidbody>().AddForce(_randDir * _forceWoods, ForceMode.Impulse);
    }

    private void FallTree()
    {
        int i = Random.Range(0, 2);
        if(i == 0)
        {
            Vector3 _newRot = new Vector3(-75f, Random.Range(-30f, 30f), 0f);
            transform.DORotate(_newRot, 2f, RotateMode.Fast); 
        }

        if(i == 1)
        {
            Vector3 _newRot = new Vector3(75f, Random.Range(-30f, 30f), 0f);
            transform.DORotate(_newRot, 2f, RotateMode.Fast); 
        }
        
    }

    public void SmallArea()
    {
        if(!isDead)
        {
            _zoneAttack.transform.DOScale(new Vector3(0.01f, 0.01f, 0.01f), 1f);
        }
    }

    public void BigArea()
    {
        if(!isDead)
        {
            _zoneAttack.transform.DOScale(new Vector3(0.45f, 0.45f, 0.45f), 1f);
        }
    }

}
