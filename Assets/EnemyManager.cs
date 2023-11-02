using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _slimes = new List<GameObject>();
    [SerializeField] private GameObject _currentSlime;
    [SerializeField] private Player _player;

    private void Update()
    {
        ClosetSlime();
    }

    public void AddSlime(GameObject slime)
    {
        _slimes.Add(slime);
    }
    public Transform ReturnClosetSlimePosition()
    {
        if (_currentSlime != null)
        {
            return _currentSlime.transform;
        }
        else
        {
            return null;
        }
    }

    public void ClosetSlime()
    {
        if (_slimes.Count > 0)
        {
            if (_currentSlime == null && _slimes != null)
            {
                _currentSlime = _slimes[0];
            }
            else
            {
                float minDistance = float.MaxValue;
                for (int i = 0; i < _slimes.Count; i++)
                {
                    float distance = Vector2.Distance(_player.transform.position, _slimes[i].transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        _currentSlime = _slimes[i];
                    }
                }
            }
        }
        
    }
}
