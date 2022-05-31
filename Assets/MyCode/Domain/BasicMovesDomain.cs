using UnityEngine;

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