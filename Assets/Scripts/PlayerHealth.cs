using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private int _health = 5;
    [SerializeField] private int _maxHealth = 6;
    [SerializeField] private bool _invulnerable = false;

    [SerializeField] HealthUi _healthUi;
    [SerializeField] Invulnerable _invulnerableState;
    [SerializeField] private UnityEvent _takeDamageEvent;
    [SerializeField] private UnityEvent _dieEvent;
    [SerializeField] private UnityEvent _healEvent;
    void Start()
    {
        _health = _maxHealth;
        _healthUi.Setup(_maxHealth);
        _healthUi.DisplayHealth(_health);
    }

    // Update is called once per frame
    
    public void TakeDamage(int damage)
    {
        if (_invulnerableState.InvulnerableState() == false)
        {
            _health -= damage;
            if (_health <= 0)
            {
                _dieEvent.Invoke();
                Invoke(nameof(RestartLvl),2f);
                
            }
            _healthUi.DisplayHealth(_health);
            _takeDamageEvent.Invoke();

        }
    }   

    
  public void RestartLvl()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Heal(int heal)
    {
        _health += heal;
        if (_health >= _maxHealth)
        {
            _health = _maxHealth;
        }
        _healthUi.DisplayHealth(_health);
        _healEvent.Invoke();
    }


}
