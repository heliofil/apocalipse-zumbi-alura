using UnityEngine;

public class PlayerDomain:BasicMovesDomain {
    
    private const string PLAYER_NAME = "Bob";

    public PlayerDomain(Rigidbody rigidbody) : base(rigidbody,1,PLAYER_NAME,10,10) {

    }

    public void Rotation(LayerMask baseFloor) {
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(raio,out RaycastHit hit,100,baseFloor)) {
            Vector3 aim = hit.point - Rigidbody.position;
            aim.y = 0;
            Rigidbody.MoveRotation(
                Quaternion.LookRotation(
                    aim
                )
            );
        }
    }

}