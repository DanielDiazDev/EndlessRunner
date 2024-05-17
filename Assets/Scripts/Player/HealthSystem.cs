using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamageable
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth;
    private DeathHandler _deathHandler;
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
        _deathHandler = GetComponent<DeathHandler>();
    }
    public void Damage(int damage)
    {
        _currentHealth -= damage;
        if( _currentHealth <= 0)
        {
            _deathHandler.HandleDeath();
        }
    }
}
