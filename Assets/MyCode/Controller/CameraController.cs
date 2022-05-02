using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;

    private float _delay = Utils.CAMERA_DELAY;
    private Vector3 _offSet;

    // Start is called before the first frame update
    void Start()
    {
        _offSet = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Move();
    }

    private Vector3 Move() {
        return new Vector3(
            DelayPosition(Player.transform.position.x),
            DelayPosition(Player.transform.position.y),
            DelayPosition(Player.transform.position.z)
            ) + _offSet;
    }

    private float DelayPosition(float position) {
        return position - (position - (position / _delay));
    }

}
