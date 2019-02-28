﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardGivenTarget : MonoBehaviour
{
    public Transform m_missileDirection;
    public Transform m_target;
    public float m_speed=10;
    public float m_angleDegreeLerp = 30f;
    
    void Update()
    {
        if (!m_target)
            return;
        if (transform.parent)
            transform.parent = null;

        Vector3 localDirectionOfTarget = m_missileDirection.InverseTransformPoint(m_target.position);
        Quaternion toRotate = Quaternion.FromToRotation(Vector3.forward, localDirectionOfTarget);
        m_missileDirection.rotation =
            Quaternion.RotateTowards(Quaternion.identity, toRotate, m_angleDegreeLerp*Time.deltaTime)
            * m_missileDirection.rotation;
        transform.Translate(Vector3.forward * m_speed*Time.deltaTime, Space.Self);
    }
}
