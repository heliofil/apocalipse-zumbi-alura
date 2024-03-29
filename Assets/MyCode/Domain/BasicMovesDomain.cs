﻿using UnityEngine;

public class BasicMovesDomain: BasicDomain {

  
    public int Speed {
        get; private set;
    }

    public Rigidbody Rigidbody {
        get; private set;
    }

    public bool Walk {
        get; private set;
    }

    public BasicMovesDomain(Rigidbody rigidbody,int id,string name, int life,int speed): base(id,name,life) {
        Speed = speed;
      
        Rigidbody = rigidbody;
        Walk = false;
    }

    public void EnableSlow() {
        Walk = true;
    }
    public void DisableSlow() {
        Walk = false;
    }

    public int TryWalkOrRun() {
        int speed = Speed;
        if(Walk) {
           speed -= (speed / 3);
        }
        return speed;
    }

    public virtual void Move(Vector3 direction) {
        
        Rigidbody.MovePosition(
            Rigidbody.position + (TryWalkOrRun() * Time.deltaTime * direction)
            );
    }

    public virtual void Rotation(Vector3 direction) {
        Rigidbody.MoveRotation(
            Quaternion.LookRotation(
                direction
                )
            );
    }

    public virtual void DropOut() {
        Rigidbody.constraints = RigidbodyConstraints.None;
        Rigidbody.velocity = Vector3.zero;
    }





}