using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invulnerable : MonoBehaviour
{
    private bool _invulnerable = false;

    public bool InvulnerableState()
    {
        return _invulnerable;
    }

    public void InvulnerableOn()
    {
        _invulnerable =  true;
    }

    public void InvulnerableOff()
    {
        _invulnerable = false;
    }
}
