using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerDepress : MonoBehaviour
{
    public event Action<int> DamageEvent;
    public event Action DeadEvent;

    [SerializeField] private SpriteRenderer injuriedRender;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] damageClips;

    public int depress = 0;
    public int maxDepress = 100;
    public float hurtCdTime;
    public int blinksCount;
    public float blinkDurationTime;
    private Renderer myRenderer;
    private PolygonCollider2D playerHurtCollider;

    public static PlayerDepress instance;
    public static bool failEndActivated = false;

    private readonly float soundPlaySpacing = 3;
    private bool soundCoolDown;
    private int soundIndex = 0;

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
        if(soundCoolDown)
        {
            audioSource.PlayOneShot(damageClips[soundIndex]);
            soundIndex  = soundIndex + 1;
            if(soundIndex >= damageClips.Length)
            {
                soundIndex = 0;
            }
            StartCoroutine(coolDownSoundPlay());
        }
        playerHurtCollider.enabled = false;
        depress += damage;
        if(depress >= maxDepress)
        {
            depress = maxDepress;
            failEndActivated = true;
        }

        DamageEvent?.Invoke(depress);

        injuriedCheck();

        if (depress == maxDepress)
        {
            Dead();
            return;
        }
        Invoke("EnableHurtCollider", hurtCdTime);
        BlinkPlayerSprite(blinksCount, blinkDurationTime);
    }

    private IEnumerator coolDownSoundPlay()
    {
        soundCoolDown = true;
        yield return new WaitForSeconds(soundPlaySpacing);
        soundCoolDown = false;
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
