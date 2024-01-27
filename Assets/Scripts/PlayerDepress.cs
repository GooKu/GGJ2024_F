using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDepress : MonoBehaviour
{
    public event Action<int> DamageEvent;
    public event Action DeadEvent;

    [SerializeField] private SpriteRenderer injuriedRender;

    public int depress = 0;
    public int maxDepress = 100;
    public float hurtCdTime;
    public int blinksCount;
    public float blinkDurationTime;
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
        depress = GameManger.Instance.GetDepress();
        injuriedCheck();
    }

    public void PlayerGetDamage(int damage)
    {
        playerHurtCollider.enabled = false;
        depress += damage;
        if(depress > 100)
        {
            depress = 100;
        }
        DamageEvent?.Invoke(depress);
        injuriedCheck();

        if (depress == 100)
        {
            Dead();
            return;
        }
        Invoke("EnableHurtCollider", hurtCdTime);
        BlinkPlayerSprite(blinksCount, blinkDurationTime);
    }

    private void injuriedCheck()
    {
        injuriedRender.enabled = depress != 0;
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

    public void Dead()
    {
        DeadEvent?.Invoke();
    }
}
