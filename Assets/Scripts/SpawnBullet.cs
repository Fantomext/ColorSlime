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
    private bool _isAttacking;

    private void Awake()
    {
        _mainColorManager = FindObjectOfType<MainColorManager>();
        _colorList = _mainColorManager.AllColorsMain();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (_fixedJoystickRotate.Horizontal != 0 || _fixedJoystickRotate.Vertical != 0)
        {
            _isAttacking = true;
            if (timer > 0.25)
            {
                timer = 0;
                GameObject newBulletPrefab = Instantiate(bulletPrefab, spawnPosition.position, spawnPosition.rotation);
                newBulletPrefab.GetComponent<SpriteRenderer>().color = new Color(_currentColor.r, _currentColor.g, _currentColor.b);
                Physics2D.IgnoreCollision(newBulletPrefab.GetComponent<Collider2D>(), ignoreColider);
            }
        }
        else
        {
            _isAttacking = false;
        }
    }

    public void SetColor(int index)
    {
        _currentColor = _colorList[index]; 
    }

    

    public bool IsAttacking()
    {
        return _isAttacking;
    }
}
