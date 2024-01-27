using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMotor : MonoBehaviour
{
    public float speed = 10f;
    void Update()
    {
        if (gameObject.CompareTag("Right_Sword"))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        else if (gameObject.CompareTag("Left_Sword"))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

    }
}
