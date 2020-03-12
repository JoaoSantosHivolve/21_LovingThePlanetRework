using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RotateLeaf : MonoBehaviour
{
    public float smooth = 1f;
    private Quaternion targetRotation;
    public float angle = 20;

    void Start()
    {
        targetRotation = transform.rotation;

    }
    void Update()
    {
        angle = Random.Range(-50.0f, 50.0f);
        if (Input.GetKeyDown(KeyCode.Space))
        {

        targetRotation *= Quaternion.AngleAxis(angle, Vector3.forward);

        }
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);

        //transform.Rotate(Vector3.forward * Time.deltaTime * 100);
    }

}


