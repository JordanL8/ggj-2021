using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class FloofMovement : MonoBehaviour
{
    
    public UnityEngine.AI.NavMeshAgent agent { get; private set; }

    public Transform target;

    public float m_rotationSpeed;


    private void Start()
    {
        agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();

        agent.updateRotation = false;
        agent.updatePosition = true;
    }


    private void Update()
    {
        if (target != null)
        {
            Vector3 dir = target.position - transform.position;
            dir.y = 0;
            Quaternion rot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, m_rotationSpeed * Time.deltaTime);

            agent.SetDestination(target.position);
        }
    }


    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
