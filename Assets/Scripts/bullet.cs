using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    MainColorManager _mainColor;
    Color bulletColor;
    [SerializeField] List<Color> _mainColors = new List<Color>();
    [SerializeField] List<Color> _mixColors = new List<Color>();
    [SerializeField] AudioSource _soundHit;
 
    [SerializeField] private float _bulletPower = 10f;


    void Start()
    {
        _soundHit = GameObject.Find("colorHit").GetComponent<AudioSource>();
        _mainColor = FindObjectOfType<MainColorManager>();
        bulletColor = gameObject.GetComponent<SpriteRenderer>().color;
        _mainColors = _mainColor.AllColorsMain();
        _mixColors = _mainColor.AllColorsMix();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(transform.right * Random.Range(250, 500));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody)
        {
            if (collision.attachedRigidbody.TryGetComponent<Slime>(out var slime))
            {
                _soundHit.Play();
                Color colorSlime = slime.GetComponentInChildren<SpriteRenderer>().color;

                //slime.GetComponentInChildren<SpriteRenderer>().color = bulletColor;
                slime.GetComponent<Rigidbody2D>().AddForce(transform.right * _bulletPower);
                if (slime.GetComponentInChildren<SpriteRenderer>())
                {
                    Color slimeSprite = slime.GetComponentInChildren<SpriteRenderer>().color;
                    //Debug.Log(new Color(slimeSprite.r, slimeSprite.g, slimeSprite.b) == new Color(mainColors[0].r, mainColors[0].g, mainColors[0].b));
                    Color currentColor = CoombinateColor(slimeSprite);
                    slime.GetComponentInChildren<SpriteRenderer>().color = new Color(currentColor.r, currentColor.g, currentColor.b);
                    
                }
            }
        }
        
        Destroy(gameObject);
    }

    public Color CoombinateColor(Color slimeColor)
    {
        Debug.Log("start");
        Color currentColor = _mainColor.MainColor();

        Color slimeColorNormal = new Color(slimeColor.r, slimeColor.g, slimeColor.b);
        Color yellowMain = new Color(_mainColors[0].r, _mainColors[0].g, _mainColors[0].b);
        Color blueMain = new Color(_mainColors[1].r, _mainColors[1].g, _mainColors[1].b);
        Color redMain = new Color(_mainColors[2].r, _mainColors[2].g, _mainColors[2].b);
        Color bleach = new Color(_mainColors[3].r, _mainColors[3].g, _mainColors[3].b);
        Color bulletColorNormal = new Color(bulletColor.r, bulletColor.g, bulletColor.b);

        if (bulletColorNormal == bleach)
        {
            return bleach;
        }

        if (slimeColorNormal == bleach)
        {
            return bulletColorNormal;
        }

        if (slimeColorNormal == yellowMain) // yellow color
        {
            Debug.Log("1st");
            if (bulletColorNormal == blueMain) //blue + yellow
            {
                Debug.Log("green");
                return _mixColors[1]; // green
            }
            if (bulletColorNormal == redMain) // red + yellow
            {
                Debug.Log("oranje");
                return _mixColors[0];
            }
        }
        if (slimeColorNormal == blueMain)
        {
            if (bulletColorNormal == yellowMain) //blue + yellow
            {
                Debug.Log("green");
                return _mixColors[1]; // green
            }
            if (bulletColorNormal == redMain) // red + yellow
            {
                Debug.Log("purple");
                return _mixColors[2];
            }
        }
        if (slimeColorNormal == redMain)
        {
            if (bulletColorNormal == yellowMain) //blue + yellow
            {
                Debug.Log("green");
                return _mixColors[0]; // green
            }
            if (bulletColorNormal == blueMain) // red + yellow
            {
                Debug.Log("purple");
                return _mixColors[2];
            }
        }


        return slimeColor;
        
    }
    
}


   
