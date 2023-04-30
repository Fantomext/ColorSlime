using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] private float _speed = 5f; 
    private Collider2D _slimeColider;
    private SpriteRenderer spriteSlime;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] MainColorManager mainColor;
    [SerializeField] List<Color> mainColors = new List<Color>();
    [SerializeField] List<Color> mixColors = new List<Color>();
    [SerializeField] Animator _animator;
    [SerializeField] int randomColor;
    [SerializeField] Score score;
    [SerializeField] Collider2D wall;
    [SerializeField] private Transform _player;
    [SerializeField] private bool _facingRight;

    private void Start()
    {
        _slimeColider = GetComponentInChildren<Collider2D>();
        score = FindObjectOfType<Score>();
        _player = FindObjectOfType<Player>().transform;
        mainColor = FindAnyObjectByType<MainColorManager>();
        mainColors = mainColor.AllColorsMain();
        mixColors = mainColor.AllColorsMix();
        randomColor = Random.Range(0, 4);
        GetComponentInChildren<SpriteRenderer>().color = new Color(mainColors[randomColor].r, mainColors[randomColor].g, mainColors[randomColor].b);
        spriteSlime = GetComponentInChildren<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        wall = GameObject.Find("FencyTail").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(_slimeColider, wall);
        
    }

    private void FixedUpdate()
    {
        Vector2 toPlayer = _player.position - transform.position;
     
        _rigidbody2D.velocity = new Vector2(toPlayer.x, toPlayer.y).normalized * _speed;

        if (toPlayer.x < 0 && _facingRight == false)
        {
            FlipRotate();
        }
        if (toPlayer.x > 0 && _facingRight == true)
        {
            FlipRotate();
        }

        DieCheck();

    }

    public void DieCheck()
    {
        Color currentColor = GetComponentInChildren<SpriteRenderer>().color;
        if (new Color(currentColor.r, currentColor.g, currentColor.b) == new Color(mainColor.MainColor().r, mainColor.MainColor().g, mainColor.MainColor().b))
        {
            score.AddScore(50);
            score.UpdateScore();
            _animator.SetTrigger("isDead");
            Destroy(gameObject, 0.6f);
        }
    }

    public void SetSpeed(int speed)
    {
        _speed = speed;
    }

    public void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        _facingRight = !_facingRight;
    }

    private void FlipRotate()
    {
        Vector3 currentRotate = gameObject.transform.localEulerAngles;
        currentRotate.y += 180;
        gameObject.transform.localEulerAngles = currentRotate;

        _facingRight = !_facingRight;
    }
}
