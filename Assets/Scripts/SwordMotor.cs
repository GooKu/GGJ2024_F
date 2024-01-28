using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMotor : MonoBehaviour
{
    public float speed = 10f;
    public Transform ground;
    private Vector3 groundPos;
    private float distance, maxDistance = 100f;
    private float direc;

    private void Start()
    {
        groundPos = ground.transform.position;
    }

    void Update()
    {
        if (gameObject.CompareTag("Fall_Sword"))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            VerticalDistance();
        }

        else
        {
            if (gameObject.CompareTag("Right_Sword"))
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }

            else if (gameObject.CompareTag("Left_Sword"))
            {
                transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            HorizontalDistance();
        }
        
    }

    public void HorizontalDistance()
    {
        distance = Mathf.Abs(groundPos.x - transform.position.x);

        if( distance >= maxDistance)
        {
            Debug.Log("Destroy tag = " + gameObject.tag + distance);
            Destroy(gameObject);
        }
    }

    public void VerticalDistance()
    {
        direc = transform.position.y - ground.position.y;

        if( direc <= -20f)
        {
            Debug.Log("Destroy tag = " + gameObject.tag + direc);
            Destroy(gameObject);
        }
    }
}
