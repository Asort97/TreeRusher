using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _timerText;
    [SerializeField] private GameObject _endGamePan;
    [SerializeField] private GameObject _yandexSDK;

    [SerializeField] private GameObject _treePrefab;
    private float _timer = 120f;

    [SerializeField] private GameObject _soundOn;
    [SerializeField] private GameObject _soundOff;

    // Start is called before the first frame update
    private void Start()
    {
        Application.ExternalCall("ShowAd");
    }

    private void Update() {
        
        
        if(_timer <= 0f)
        {
            _endGamePan.SetActive(true);
        }
        else
        {
            _timerText.text = "s "  + (int)_timer;
            _timer -= Time.deltaTime;
        }
    }

    public void OnRestart()
    {
        SceneManager.LoadScene(0);
    }

    public void SpawnTree()
    {
        Vector3 _pos = new Vector3(Random.Range(-39f, 37f), 0.2341865f, Random.Range(36f, -40f));
        Instantiate(_treePrefab, _pos, Quaternion.identity);
    }

    public void SoundOn()
    {
        _soundOn.SetActive(!_soundOn.activeSelf);
        _soundOff.SetActive(!_soundOff.activeSelf);
    }

}
