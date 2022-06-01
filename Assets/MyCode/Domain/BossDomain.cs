using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossDomain : ZumbiDomain
{

    public NavMeshAgent Agent {
        get; private set;
    }

    public BossDomain(Rigidbody rigidbody,NavMeshAgent agent) : base(rigidbody,0,"BOSS",800,8,7) {
        Agent = agent;
        Agent.speed = Speed;
        Agent.stoppingDistance = Utils.IMPACT_DISTANCE;
        EnableSlow();
    }

    public override void Rotation(Vector3 direction) {
        direction -= Rigidbody.transform.position;
        direction = direction.normalized;
        Rigidbody.MoveRotation(
            Quaternion.LookRotation(
                direction
                )
            );
    }

    public override void Move(Vector3 position) {
        Agent.speed = TryWalkOrRun();
        Agent.SetDestination(position);
    }

    public override void RestoreLife() {
        base.RestoreLife();
        base.RestoreLife();
    }

    public bool IsPlayerNear() {
        if(Agent.hasPath) {
            if(Agent.remainingDistance <= Agent.stoppingDistance) {
                return true;
            }
        }
        return false;

    }

}
