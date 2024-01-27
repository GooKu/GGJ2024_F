using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDepress : MonoBehaviour
{
    public int depress = 0;
    public int maxDepress = 100;
    public float hurtCdTime;
    private PolygonCollider2D playerHurtCollider;

    public static PlayerDepress instance; 
    
    void Awake()
    {
        instance = this;
        playerHurtCollider = GetComponent<PolygonCollider2D>();
    }
    void Start()
    {
        PlayerData.currentDepress = depress;
    }

    public void PlayerGetDamage(int damage)
    {
        playerHurtCollider.enabled = false;
        depress += damage;
        if(depress > 100)
        {
            depress = 100;
        }
        PlayerData.currentDepress = depress;
        Invoke("EnableHurtCollider", hurtCdTime);
    }

    void EnableHurtCollider()
    {
        playerHurtCollider.enabled = true;
    }

    void Update()
    {

    }
}
