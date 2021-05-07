using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField] private float RotationSpeed;
    
    void Update()
    {
        RotateRing();
    }

    private void RotateRing()
    {
        transform.Rotate(Vector3.right * RotationSpeed * Time.deltaTime);
    }

}
