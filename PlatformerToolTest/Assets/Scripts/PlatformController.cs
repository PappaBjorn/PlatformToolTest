using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

[RequireComponent(typeof(NavMeshAgent))]

public class AIController : MonoBehaviour
{
    //[MinMax(5f, 15f)]
    public Vector2 value;

    public WayPointSystem _waypoints;
    public float nextPointDistance = 0.5f;

    private NavMeshAgent _agent;
    private int _currentWaypointIndex = 0;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        Assert.IsNotNull(_agent, "Failed to locate <b>NavMeshAgebnt</b> component");
    }

    private void Start()
    {
        Assert.IsNotNull(_waypoints, "Waypoints system is null.");
        _agent.SetDestination(_waypoints.points[_currentWaypointIndex]);
    }

    private void Update()
    {
        if (!_agent.pathPending && _agent.remainingDistance <= nextPointDistance)
            GoToNextWaypoint();
    }

    public void GoToNextWaypoint()
    {
        _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.points.Length;
        _agent.SetDestination(_waypoints.points[_currentWaypointIndex]);
    }
}
