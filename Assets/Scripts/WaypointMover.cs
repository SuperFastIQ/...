using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] private GameObject[] _waypoints;
    private int _currentWaypointIndex = 0;

    [SerializeField] private float _speed = 2f;

    private void Update()
    {
        if(Vector2.Distance(_waypoints[_currentWaypointIndex].transform.position, transform.position) < 0.1f)
        {
            _currentWaypointIndex++;
            if (_currentWaypointIndex >= _waypoints.Length)
            {
                _currentWaypointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentWaypointIndex].transform.position, Time.deltaTime * _speed);
    }
}
