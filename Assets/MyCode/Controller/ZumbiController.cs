using UnityEngine;

public class ZumbiController : MonoBehaviour, ILivingController {
   
    

    private ZumbiDomain zumbi;
    public AudioClip AttackAudio;
    private BulletDomain bullet;
    private BasicAnimator basicAnimator;
    private Vector3 offsetInstance;
    

    private void Start() {
        basicAnimator = GetComponent<BasicAnimator>();
        offsetInstance = Vector3.zero;
    }

    public static void CreateInstance(int id,Vector3 position,Quaternion rotation) {
        Instantiate(Resources.Load<GameObject>(Utils.ZUMBI_PATH),position,rotation)
           .GetComponent<ZumbiController>()
           .DefineZumbiById(id);
    }


    public void SetBullet(BulletDomain bulletDomain) {
        bullet = bulletDomain;
    }

    public void DefineZumbiById(int id) {
        zumbi = new ZumbiDomain(GetComponent<Rigidbody>(),id);
        transform.GetChild(zumbi.Id).gameObject.SetActive(true);
    }

    void FixedUpdate() {
        
        if(WhileTakeHit()) {
            return;
        }
        basicAnimator.OnTakeHit(false); 
        basicAnimator.OnAttack(false);

        if(IsIdleDistance()) {
            return;
        }

        if(IsMoveDistance()) {
            zumbi.Move(OffsetRandom());
            zumbi.Rotation(OffsetRandom());
            return;
        }

        if(IsSeekDistance()) {
            IsAttackDistance();
            zumbi.Move(OffsetPlayer());
            zumbi.Rotation(OffsetPlayer());
            return; 
        }
        
        

    }

    Vector3 OffsetRandom() {
        Debug.Log(Vector3.Distance(transform.position,offsetInstance));
        if((offsetInstance == Vector3.zero)||(Vector3.Distance(transform.position,offsetInstance) < Utils.IMPACT_DISTANCE)) {
            Vector3 position = Utils.GetRandomPosition() + transform.position;
            position.y = transform.position.y;
            offsetInstance = (position - transform.position).normalized;
            Debug.Log("gerou aleatorio");
        }

        return offsetInstance;
        
    }

    Vector3 OffsetPlayer() {
        return (PlayerController.PlayerInstance.gameObject.transform.position - transform.position).normalized;
    }

    float DistancePlayer() {
        return Vector3.Distance(transform.position, PlayerController.PlayerInstance.gameObject.transform.position);  
    }

    bool IsIdleDistance() {
        if(DistancePlayer() > Utils.IDLE_DISTANCE) {
            basicAnimator.OnIdle();
            return true;
        }
        return false;
    }

    bool IsMoveDistance() {
        if(DistancePlayer() > Utils.MOVE_DISTANCE) {
            basicAnimator.OnMove();
            zumbi.EnableSlow();
            return true;
        }
        return false;
    }

    bool IsSeekDistance() {
        if(DistancePlayer() < Utils.SEEK_DISTANCE) {
            zumbi.DisableSlow();
            basicAnimator.OnMove();
            return true;
        }
        return false;
    }

    bool IsAttackDistance() {
        if(DistancePlayer() < Utils.IMPACT_DISTANCE) {
            basicAnimator.OnAttack(true);
            return true;
        }
        return false;
    }

    void Attack() {

        PlayerController.PlayerInstance.TakeHit(zumbi.Strength);
    }

    private bool WhileTakeHit() {
        if(bullet == null) {
            return false;
        }
        int hit = bullet.GetNextHit();
        if(hit == 0) {
            return false ;
        }
        TakeHit(hit);
        return true;
         
    }

    public void TakeHit(int hit) {
        if(zumbi.ReduceLife(hit)) {
            ToDie();
        }
        basicAnimator.OnTakeHit(true);
    }


    public void ToDie() {
        AudioSourceController.AudioSourceInstance.PlayOneShot(AttackAudio);
        Destroy(gameObject);
    }

}
