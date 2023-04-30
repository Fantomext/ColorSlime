using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MainColorManager : MonoBehaviour
{
    [SerializeField] List<Color> _colorListMain = new List<Color>();
    [SerializeField] List<Color> _colorListMixing = new List<Color>();
    [SerializeField] Tilemap _tilemapGround;
    [SerializeField] SpriteRenderer _roofCastle;
    [SerializeField] private float timer = 0f;
    

    [SerializeField] Color _mainColorLocation;

    private void Start()
    {
        _mainColorLocation = _colorListMain[1] + _colorListMain[2];
        
    }

    private void Update()
    {
        ChangeLocationColor();
        timer += Time.deltaTime;
        if (timer > 15f)
        {
            timer = 0f;
            ChangeMainColor();
        }
    }

    public void ChangeLocationColor()
    {
        _tilemapGround.color = Color.Lerp(new Color(_tilemapGround.color.r, _tilemapGround.color.g, _tilemapGround.color.b), new Color(_mainColorLocation.r, _mainColorLocation.g, _mainColorLocation.b), Time.deltaTime * 5f);
        _roofCastle.color = Color.Lerp(new Color(_roofCastle.color.r, _roofCastle.color.g, _roofCastle.color.b), new Color(_mainColorLocation.r, _mainColorLocation.g, _mainColorLocation.b), Time.deltaTime * 5f);
    }

    public List<Color> AllColorsMix()
    {
        return _colorListMixing;
    }

    public List<Color> AllColorsMain()
    {
        return _colorListMain;
    }

    public Color MainColor()
    {
        return _mainColorLocation;
    }

    public void ChangeMainColor()
    {
        _mainColorLocation = _colorListMixing[Random.Range(0, _colorListMixing.Count)];
    }


}
