using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    Transform platform;

    [SerializeField]
    Transform startTransform;

    [SerializeField]
    Transform endTransform;

    [SerializeField]
    float platformSpeed;

    [SerializeField]
    Mesh mesh;

    Vector3 direction;
    Transform destination;

    //public WayPointSystem _waypoints;
    //public float nextPointDistance = 0.5f;

    //private int _currentWaypointIndex = 0;

    //private void Awake()
    //{
        //Assert.IsNotNull(_waypoints, "Waypoints system is null.");
    //}

    private void Start()
    {
        SetDestination(startTransform);
        //platform.SetDestination(_waypoints.points[_currentWaypointIndex]);
    }

    private void FixedUpdate()
    {
        platform.GetComponent<Rigidbody>().MovePosition(platform.position + direction * platformSpeed * Time.fixedDeltaTime);

        if (Vector3.Distance(platform.position, destination.position) < platformSpeed * Time.fixedDeltaTime)
            SetDestination(destination == startTransform ? endTransform : startTransform);
    }

    private void OnDrawGizmos()
    {
//         Gizmos.color = Color.green;
//         Gizmos.DrawWireCube(startTransform.position, platform.localScale);
// 
//         Gizmos.color = Color.red;
//         Gizmos.DrawWireCube(endTransform.position, platform.localScale);

        Gizmos.color = Color.green;
        Gizmos.DrawWireMesh(mesh, startTransform.position, startTransform.rotation, Vector3.one);

        Gizmos.color = Color.red;
        Gizmos.DrawWireMesh(mesh, endTransform.position, endTransform.rotation, Vector3.one);
    }

    void SetDestination(Transform dest)
    {
        destination = dest;
        direction = (destination.position - platform.position).normalized;

    }
}
