using System.Collections;
using UnityEngine;

public class ZumbiController : MonoBehaviour, ILivingController {
   
    

    private ZumbiDomain zumbi;
    public AudioClip AttackAudio;
    private BulletDomain bullet;
    private BasicAnimator basicAnimator;
    private Vector3 offsetInstance;
    private UIController uiInstance;
    private PlayerController playerInstance;


    void Start() {
        basicAnimator = GetComponent<BasicAnimator>();
        offsetInstance = Utils.GetRandomByPosition(transform.position,Utils.SEEK_DISTANCE);
        uiInstance = UIController.UIInstance;
        playerInstance = PlayerController.PlayerInstance;
    }

    public static void CreateInstance(int id,Vector3 position,Quaternion rotation) {
        Instantiate(Resources.Load<GameObject>(Utils.ZUMBI_PATH),
            Utils.GetRandomByPosition(position,Utils.IMPACT_DISTANCE)
            ,rotation)
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

    void Update() {
        
        if(bullet != null) {
            StartCoroutine(GetNextHit(bullet));
            bullet = null;
            return;
        }


        basicAnimator.OnTakeHit(false); 

        if(playerInstance.IsPlayerNear(transform.position,Utils.IMPACT_DISTANCE)) {
            zumbi.Rotation(OffsetPlayer());
            basicAnimator.OnAttack(true);
            return;
        }
        
        basicAnimator.OnAttack(false);
        
        if(playerInstance.IsPlayerNear(transform.position,Utils.SEEK_DISTANCE)) {
            zumbi.DisableSlow();
            basicAnimator.OnMove();
            zumbi.Move(OffsetPlayer());
            zumbi.Rotation(OffsetPlayer());
            return ;
        }
        
        if(playerInstance.IsPlayerNear(transform.position,Utils.MOVE_DISTANCE)) {
            basicAnimator.OnMove();
            zumbi.EnableSlow();
            zumbi.Move(OffsetRandom());
            zumbi.Rotation(OffsetRandom());
            return ;
        }

        basicAnimator.OnIdle();


    }

    Vector3 OffsetRandom() {
        if(Vector3.Distance(transform.position,offsetInstance) < Utils.IMPACT_DISTANCE) {
            offsetInstance = Utils.GetRandomByPosition(transform.position,Utils.SEEK_DISTANCE);
        }

        return (offsetInstance - transform.position).normalized;
        
    }

    Vector3 OffsetPlayer() {
        return (playerInstance.gameObject.transform.position - transform.position).normalized;
    }

    void Attack() {
        playerInstance.TakeHit(zumbi.Strength);
    }

    IEnumerator GetNextHit(BulletDomain bullet) {
        int hit = bullet.GetNextHit();
        while(hit != 0) {
            TakeHit(hit);
            uiInstance.SetZumbiBar(zumbi.Life);
            hit = bullet.GetNextHit();
            yield return new WaitForSeconds(1f);
        }
        uiInstance.HideZumbi();
    }

    


    public void TakeHit(int hit) {
        uiInstance.InitHitZumbi(zumbi);
       
        if(zumbi.ReduceLife(hit)) {
            ToDie();
        }
        basicAnimator.OnTakeHit(true);
    }


    public void ToDie() {
        AudioSourceController.AudioSourceInstance.PlayOneShot(AttackAudio);
        GivePickUps();
        uiInstance.SetScore(zumbi.Points);
        uiInstance.HideZumbi();
        Destroy(gameObject);
    }

    public void Restore() {
        zumbi.RestoreLife();
    }

    private void GivePickUps() {

        float verify = Random.value;

        for(int i=0;i <Utils.PICKUPS_SHOWOFF.Length;i++) {   
            if(verify <= Utils.PICKUPS_SHOWOFF[i]) {
                PickUpController.CreateInstance(i,transform.position,transform.rotation);
                break;
            }
            
        }

    }

}
