using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public Transform _player;
    [SerializeField] private PlayerController _playerController;

    private void LateUpdate ()
    {
        transform.LookAt (_player.transform.position);
    }

    private void Update() {
        if(_playerController.isZoom)
        {
            float _fov = GetComponent<Camera>().fieldOfView;

            if(_fov > 45f)
            {
                GetComponent<Camera>().fieldOfView -= Time.deltaTime * 15f;
            }
             
        }
        else
        {
            float _fov = GetComponent<Camera>().fieldOfView;

            if(_fov < 60f)
            {
                GetComponent<Camera>().fieldOfView += Time.deltaTime * 10f;
            }
             
        }
    }
}
