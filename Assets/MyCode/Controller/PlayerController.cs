using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _direction;
    private Animator _animator;
    private Rigidbody _rigidbody;
    private PlayerDomain _playerDomain;
    private UIController _uiController;
    public LayerMask BaseFloor;
    public GameObject Canvas;


    public void TakeHit(int hit) {

        if(_playerDomain.ReduceLife(hit)) {
            _uiController.GameOver();
        };
        _uiController.SetLifeBar(_playerDomain.GetLife());

    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _uiController = Canvas.GetComponent<UIController>();
        _playerDomain = Utils.CreatePlayer();
        _uiController.MaxLife(_playerDomain.GetLife());
    }

    // Update is called once per frame
    void Update()
    {
        

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




}
