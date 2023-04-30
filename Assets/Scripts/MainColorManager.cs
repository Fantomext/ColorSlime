using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainColorManager : MonoBehaviour
{
    [SerializeField] List<Color> _colorListMain = new List<Color>();
    [SerializeField] List<Color> _colorListMixing = new List<Color>();

    [SerializeField] Color _mainColorLocation;

    private void Start()
    {
        _mainColorLocation = _colorListMain[1] + _colorListMain[2];
        
    }


    public List<Color> ListAllColorsMain()
    {
        return _colorListMain;
    }



    public Color MainColor()
    {
        return _mainColorLocation;
    }

    public void ChangeMainColor()
    {
        _mainColorLocation = _colorListMain[Random.Range(0, _colorListMain.Count+1)];
    }


}
