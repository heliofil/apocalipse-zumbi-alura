using UnityEngine;

public class CameraController : MonoBehaviour
{

    private PlayerController playerInstance;

    private void Start() {
        playerInstance = PlayerController.PlayerInstance;

    }


    // Update is called once per frame


    void Update() {
        transform.position = Move();
    }

    private Vector3 Move() {

       
        

        return new Vector3(
            DelayPosition(playerInstance.transform.position.x),
            DelayPosition(playerInstance.transform.position.y),
            DelayPosition(playerInstance.transform.position.z)
            ) + Utils.CAMERA_DELAY_POSITION;
    }

    private float DelayPosition(float position) {
       
        return position - (position - (position / Utils.CAMERA_DELAY));
    }

}
