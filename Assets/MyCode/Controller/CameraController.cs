using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Vector3 offSet;

    // Start is called before the first frame update
    void Start()
    {
        offSet = transform.position - PlayerController.PlayerInstance.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Move();
    }

    private Vector3 Move() {
        return new Vector3(
            DelayPosition(PlayerController.PlayerInstance.transform.position.x),
            DelayPosition(PlayerController.PlayerInstance.transform.position.y),
            DelayPosition(PlayerController.PlayerInstance.transform.position.z)
            ) + offSet;
    }

    private float DelayPosition(float position) {
        return position - (position - (position / Utils.CAMERA_DELAY));
    }

}
