using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 2f;

    private void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * _rotationSpeed * 360);
    }
}
