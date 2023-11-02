using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlime : MonoBehaviour
{
    [SerializeField]GameObject _slimePrefab;
    private float timer = 0;
    [SerializeField] private float timerToSpawn = 4f;
    [SerializeField] private EnemyManager _enemyManager;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timerToSpawn)
        {
            timer = 0;
            GameObject slime = Instantiate(_slimePrefab, transform.position, Quaternion.identity);
            _enemyManager.AddSlime(slime);
        }
    }
}
