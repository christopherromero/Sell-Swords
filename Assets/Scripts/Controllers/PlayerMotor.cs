using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    Transform target;       // Target to follow
    NavMeshAgent agent;     // Reference to our agent

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Allows player to follow object position in game  
        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    // Update is called once per frame
    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    // Allows player to follow interactable object
    public void FollowTarget(Interactable newTarget)
    {
        // Sets distance away player will be before reaching target
        agent.stoppingDistance = newTarget.radius * .8f;
        // Handles rotation of object when following target
        agent.updateRotation = false;

        target = newTarget.interactionTransform;
    }

    // Allows player to unfollow unfocused targets
    public void StopFollowingTarget()
    {   // Resets distance away player can be from target when focusing
        agent.stoppingDistance = 0f;
        // Resets rotation of following target
        agent.updateRotation = true;
        // Unsets focused target
        target = null;
    }

    public void FaceTarget()
    {
        // Calculates difference in target-current postion
        Vector3 direction = (target.position - transform.position).normalized;

        // Calculates how much player will rotate while avoid rotation on y-axis
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));

        // Performs rotation
        transform.rotation =
             Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); // Slerp allows to interplate between two points

    }
}
