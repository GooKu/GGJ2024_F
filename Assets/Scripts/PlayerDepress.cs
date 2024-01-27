using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDepress : MonoBehaviour
{
    public int depress = 0;
    public int maxDepress = 100;
    public float hurtCdTime;
    public int blinksCount;
    public float durationTime;
    private Renderer myRenderer;
    private PolygonCollider2D playerHurtCollider;

    public static PlayerDepress instance; 
    
    void Awake()
    {
        instance = this;
        playerHurtCollider = GetComponent<PolygonCollider2D>();
        myRenderer = GetComponent<Renderer>();
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
        // BlinkPlayerSprite();
    }

    void EnableHurtCollider()
    {
        playerHurtCollider.enabled = true;
    }

    void BlinkPlayerSprite(int numBlinks, float seconds)
    {
        StartCoroutine(BlinkPlayer(numBlinks, seconds));
    }
    IEnumerator BlinkPlayer(int numBLinks, float seconds)
    {
        for(int i =0; i < numBLinks * 2; i++)
        {
            myRenderer.enabled = !myRenderer.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRenderer.enabled = true;
    }

    void Update()
    {

    }
}
