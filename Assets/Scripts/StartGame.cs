using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject buttonPlay;
    [SerializeField] GameObject Poster;
    [SerializeField] AudioSource _sound;
    private float _timer = 0;
    private bool _soundBool = true;

    private void Start()
    {
        _soundBool = true;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 3)
        {
            if (_soundBool)
            {
                _sound.Play();
                _soundBool = false;
            }
            buttonPlay.SetActive(true);
            Poster.SetActive(false);
        }
    }
}
