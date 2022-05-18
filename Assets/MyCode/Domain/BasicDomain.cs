using UnityEngine;

public class BasicDomain {

    public int InitialLife {
        get; private set;
    }

    public int Life {
        get; private set;
    }

    public int Speed {
        get; private set;
    }

    public int Id {
        get; private set;
    }

    public Rigidbody Rigidbody {
        get; private set;
    }

    public bool Walk {
        get; private set;
    }


    public BasicDomain(Rigidbody rigidbody, int speed,int id,int life) {
        Speed = speed;
        Id = id;
        Life = life;
        InitialLife = life;

        Rigidbody = rigidbody;
        Walk = false;
    }
    public void EnableSlow() {
        Walk = true;
    }
    public void DisableSlow() {
        Walk = false;
    }

    public bool ReduceLife(int reduce) {
        Life -= reduce;
        if(Life < 1) {
            return true;
        }
        return false;
    }

    public void Move(Vector3 direction) {
            int speed = Speed;
            if(Walk) {
                speed = Speed - (Speed / 3);
            }

        Rigidbody.MovePosition(
            Rigidbody.position + (speed * Time.deltaTime * direction)
            );
    }

    public void Rotation(Vector3 direction) {
        Rigidbody.MoveRotation(
            Quaternion.LookRotation(
                direction
                )
            );
    }





}