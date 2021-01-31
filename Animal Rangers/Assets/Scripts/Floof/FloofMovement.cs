using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloofMovement : MonoBehaviour
{

    public Transform target;

    public float m_speed;
    public float m_rotationSpeed;

    private Rigidbody m_rigidbody;

    private Animator m_animator;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (target != null)
        {
            Vector3 distance = target.position - transform.position;
            Vector3 dir = distance.normalized;
            dir.y = 0;
            Quaternion rot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, m_rotationSpeed * Time.deltaTime);

            m_animator.SetFloat("speed", 0.5f);

            if (distance.magnitude > 3)
            {
                m_rigidbody.position += dir * m_speed * Time.deltaTime;
            }
        }
    }


    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
