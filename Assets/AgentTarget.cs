using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.AI;

public class AgentTarget : MonoBehaviour
{
    public NavMeshAgent nma;

    public GameObject target;

    public Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = target.transform.position;
        nma.SetDestination(targetPosition);
    }

    // check distane between you and player., every x seconds attack player.
}
