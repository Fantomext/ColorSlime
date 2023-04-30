using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlime : MonoBehaviour
{
    [SerializeField]GameObject _slimePrefab;
    private float timer = 0;
    [SerializeField] private float timerToSpawn = 4f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timerToSpawn)
        {
            timer = 0;
            Instantiate(_slimePrefab, transform.position, Quaternion.identity);
        }
    }
}
