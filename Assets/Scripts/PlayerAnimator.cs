using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string isWalking = "isWalking";
    private const string isAttacking = "isAttacking";
    private const string isDamaging = "isDamaging";
    private const string isDie = "isDie";

    [SerializeField] Invulnerable _invulnerable; 
    [SerializeField] private Animator _animator;
    [SerializeField] private Player _player;
    [SerializeField] private SpawnBullet _spawnBullet;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponentInParent<Player>();
        _invulnerable = GetComponent<Invulnerable>();
    }

    private void Update()
    {
        _animator.SetBool(isWalking, _player.IsWalking());
        _animator.SetBool(isAttacking, _spawnBullet.IsAttacking());

    }

    public void Die()
    {
        _animator.SetTrigger(isDie);
    }

    public void TakeDamageTrigger()
    {
        _animator.SetTrigger(isDamaging);
    }


}
