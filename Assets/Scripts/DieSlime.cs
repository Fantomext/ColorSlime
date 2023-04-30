using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSlime : MonoBehaviour
{

    public void Die()
    {
        Destroy(transform.parent.gameObject);
    }
}
