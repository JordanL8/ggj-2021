using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloofMovement : MonoBehaviour
{
    public Transform target;

    public float m_stoppingDistance;

    public float m_rotationSpeed;
    public float m_maxSpeed;
    public float m_acceleration;


    private Animator m_animator;
    private Rigidbody m_rigidbody;

    private float m_currentSpeed;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody>();

        m_currentSpeed = 0.0f;
    }


    private void Update()
    {
        if (target != null)
        {
            Vector3 meToTarget = target.position - transform.position;
            Vector3 dir = meToTarget.normalized;
            dir.y = 0;
            Quaternion rot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, m_rotationSpeed * Time.deltaTime);

            m_animator.SetFloat("speed", 1.0f);

            float modifier = meToTarget.magnitude > m_stoppingDistance ? 1.0f : -1.0f;
            m_currentSpeed += m_acceleration * modifier * Time.deltaTime;

            m_currentSpeed = Mathf.Clamp(m_currentSpeed, 0, m_maxSpeed);


            m_rigidbody.velocity = dir * m_currentSpeed;
        }
    }


    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
