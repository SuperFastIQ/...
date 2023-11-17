using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;

    private void Update()
    {
        transform.position = new Vector3(_followTarget.position.x, _followTarget.position.y, transform.position.z);
    }
}
