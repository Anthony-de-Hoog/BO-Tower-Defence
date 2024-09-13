using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    [SerializeField] private GameObject[] tower;
    public bool MouseHasTower = false;

    public void Tower(int towerNumber)
    {
        if (!MouseHasTower)
        {
            //MouseHasTower = true;
            Instantiate(tower[towerNumber]);
        }
    }
}
