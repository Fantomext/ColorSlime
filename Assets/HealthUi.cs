using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUi : MonoBehaviour
{
    [SerializeField] GameObject healthIcon;
    List<GameObject> iconList = new List<GameObject>();

    public void Setup(int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject iconPrefab = Instantiate(healthIcon, transform);
            iconList.Add(iconPrefab);
        }
        
    }

    public void DisplayHealth(int health)
    {
        for (int i = 0; i < iconList.Count; i++)
        {
            if (i < health)
            {
                iconList[i].SetActive(true);
            }
            else
            {
                iconList[i].SetActive(false);
            }
        }
    }
}
