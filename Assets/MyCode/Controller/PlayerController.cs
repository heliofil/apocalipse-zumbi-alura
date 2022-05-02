using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Vector3 _direction;
    private Animator _animator;
    private Rigidbody _rigidbody;
    private PlayerDomain _playerDomain;

    public LayerMask BaseFloor;
    public GameObject GameOverText;


    public void TakeHit(int hit) {
     
        if(_playerDomain.ReduceLife(hit)) {
            GameOver();
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _playerDomain = Utils.CreatePlayer();

    }

    // Update is called once per frame
    void Update()
    {
        if((_playerDomain.IsDead()) && (Input.GetButtonDown(Utils.BUTTON_FIRE))) {
            Restart();
        }

        _animator.SetBool(Utils.ON_MOVE, false);
        _direction.Set(Input.GetAxis(Utils.HORIZONTAL), 0,Input.GetAxis(Utils.VERTICAL));

        if(_direction != Vector3.zero)
        {
            _animator.SetBool(Utils.ON_MOVE, true);
            
        }
    }

    void FixedUpdate() {

        if(_direction != Vector3.zero) {
            _rigidbody.MovePosition(Move(_direction));
            _rigidbody.MoveRotation(Quaternion.LookRotation(_direction));
        }


        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(raio,out hit,100,BaseFloor)) {
            Vector3 aim = hit.point - transform.position;
            aim.y = 0;
            _rigidbody.MoveRotation(Quaternion.LookRotation(aim));
        }
      
    }

    Vector3 Move(Vector3 direction) {
        return _rigidbody.position + (direction * _playerDomain.GetSpeed() * Time.deltaTime);
    }

    void GameOver() {
        GameOverText.SetActive(true);
        Time.timeScale = 0;
    }

    void Restart() {
        _playerDomain = null;
        SceneManager.LoadScene("parking");
        Time.timeScale = 1;
    }





}
