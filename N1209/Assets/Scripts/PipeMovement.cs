using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField]private float PipeSpeed = 3;
    private float DeadZone = -24f;
    private void Update()
    {
        transform.position = transform.position + (Vector3.left * PipeSpeed) * Time.deltaTime;
        if(transform.position.x < DeadZone)
        {
            Destroy(gameObject);
        }
    }
}
