using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] private FixedJoystick _fixedJoystickRotate;
    [SerializeField] Transform spawnPosition;
    [SerializeField] private float timer = 0;
    [SerializeField] private Collider2D ignoreColider;
    [SerializeField] MainColorManager _mainColorManager;
    [SerializeField] List<Color> _colorList = new List<Color>();
    [SerializeField] Color _currentColor;
    [SerializeField] private EnemyManager _enemyManager;
    private bool _isAttacking;
    [SerializeField] private float _attackTime;

    private void Awake()
    {
        _mainColorManager = FindObjectOfType<MainColorManager>();
        _colorList = _mainColorManager.AllColorsMain();
    }

    private void Update()
    {
        TargetAim();
    }


    public void SetColor(int index)
    {
        _currentColor = _colorList[index]; 
    }

    public void TargetAim()
    {
        timer += Time.deltaTime;


        if (_enemyManager.ReturnClosetSlimePosition() != null)
        {
            float angle = Vector2.SignedAngle(_enemyManager.ReturnClosetSlimePosition().position - spawnPosition.position, Vector2.right);
            Debug.Log(angle);
            spawnPosition.eulerAngles = new Vector3(0f, 0f, -angle);

            if (Input.GetKey(KeyCode.Space))
            {
                _isAttacking = true;
                Attack();
            }
            else
            {
                _isAttacking = false;
            }
        }
    }

    public void Attack()
    {
        if (timer > _attackTime)
        {
            timer = 0;
            GameObject newBulletPrefab = Instantiate(bulletPrefab, spawnPosition.position, spawnPosition.rotation);
            newBulletPrefab.GetComponent<SpriteRenderer>().color = new Color(_currentColor.r, _currentColor.g, _currentColor.b);
            Physics2D.IgnoreCollision(newBulletPrefab.GetComponent<Collider2D>(), ignoreColider);
        }
    }


    

    public bool IsAttacking()
    {
        return _isAttacking;
    }
}
