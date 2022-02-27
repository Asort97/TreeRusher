using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private GameObject _particles;
    public void OnTakeWood()
    {
        Instantiate(_particles, new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z), Quaternion.identity);
    }
}
