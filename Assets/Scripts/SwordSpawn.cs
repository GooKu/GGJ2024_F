using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSpawn : MonoBehaviour
{
    public GameObject swordPrefab;

    public int intervalStart = 0;
    public int intervalEnd = 100;
    private int genNum = 7;

    private void Update()
    {
        SowrdsSpawn();
    }

    public void SowrdsSpawn()
    {
        int num = Random.Range(intervalStart, intervalEnd);

        if( num == genNum)
        {
            GameObject swords = Instantiate(swordPrefab, transform.position, transform.rotation);
            //swordPrefab.transform.parent = null;
        }
    }
}

