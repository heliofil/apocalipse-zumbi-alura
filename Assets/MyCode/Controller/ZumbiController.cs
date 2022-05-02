using UnityEngine;

public class ZumbiController : MonoBehaviour{
   
    private GameObject Player;

    private ZumbiDomain _zumbiDomain;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private PlayerController _playerController;


    private BulletDomain _bulletDomain;

    public void DefineZumbiById(int id) {
        _zumbiDomain = Utils.CreateZumbi(id);
    }

    public void SetBullet(BulletDomain bulletDomain) {
        _bulletDomain = bulletDomain;
    }


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag(Utils.PLAYER_TAG);
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _playerController = Player.GetComponent<PlayerController>();
        transform.GetChild(_zumbiDomain.GetTypeBody()).gameObject.SetActive(true);

    }

    void FixedUpdate() {
        
        if(TakeHit()) {
            _animator.SetBool(Utils.ON_TAKE_HIT,true);
            return;
        }
        _animator.SetBool(Utils.ON_TAKE_HIT,false);
        _rigidbody.MoveRotation(Quaternion.LookRotation(Offset()));

        if(Distance() < Utils.IMPACT_DISTANCE) {
            _animator.SetBool(Utils.ON_ATTACK,true);
            return;
        }
        _animator.SetBool(Utils.ON_ATTACK,false);
        _rigidbody.MovePosition(Moviment());
        
        

    }

    Vector3 Moviment() {
        return _rigidbody.position + Offset(); 
    }

    Vector3 Offset() {
        return (Player.transform.position - transform.position).normalized * _zumbiDomain.GetSpeed() * Time.deltaTime ;
    }

    float Distance() {
        return Vector3.Distance(transform.position, Player.transform.position);  
    }

    void Attack() {
      
        _playerController.TakeHit(_zumbiDomain.GetStrength());
    }

    bool TakeHit() {
        if(_bulletDomain == null) {
            return false;
        }
        int hit = _bulletDomain.GetNextHit();
        if(hit == 0) {
            return false ;
        }
        if(_zumbiDomain.ReduceLife(hit)) {
            Destroy(gameObject);
        }
        return true;
         
    }

}
