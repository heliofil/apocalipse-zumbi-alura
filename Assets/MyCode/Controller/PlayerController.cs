using UnityEngine;

public class PlayerController : MonoBehaviour, ILivingController {

    public AudioClip TakeHitAudio;

    private Vector3 direction;
    
    private PlayerDomain player;
    private LayerMask baseFloor;
    private BasicAnimator basicAnimator;
    private UIController uiInstance;
    
    private static PlayerController playerInstance;
    public static PlayerController PlayerInstance {
        get {

            if(!playerInstance) {
                playerInstance = GameObject.FindWithTag(Utils.PLAYER_TAG).GetComponent<PlayerController>();
            }
            
            return playerInstance;

        }
     }

    public bool IsPlayerNear(Vector3 position,float reference) {
        if(DistancePlayer(position) < reference) {
            return true;
        }
        return false;
    
    }

    public float DistancePlayer(Vector3 position) {
        return Vector3.Distance(position,transform.position);
    }

   
    public void TakeHit(int hit) {

        AudioSourceController.AudioSourceInstance.PlayOneShot(TakeHitAudio);
        if(player.ReduceLife(hit)) {
          ToDie();
        };
        uiInstance.SetLifeBar(player.Life);

    }

    public void ToDie() {
        uiInstance.GameOver();
    }

    public void HasGun() {
        basicAnimator.OnMove();
        player.EnableSlow();
    }

    public void NoGun() {
        player.DisableSlow();
    }

    public void Restore() {
        player.RestoreLife();
        uiInstance.SetLifeBar(player.Life);
    }

    public void LightOn() {
        transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
    }


    void Start() {
        player = new PlayerDomain(GetComponent<Rigidbody>());
        uiInstance = UIController.UIInstance;
        uiInstance.SetMaxLifeBar(player.Life);
        uiInstance.SetLifeBar(player.Life);
        baseFloor = LayerMask.GetMask(Utils.BASE_FLOOR_TAG);
        basicAnimator = GetComponent<BasicAnimator>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        direction.Set(Input.GetAxis(Utils.HORIZONTAL), 0,Input.GetAxis(Utils.VERTICAL));

        if(player.Walk) { 
            return; 
         }

        if((direction == Vector3.zero)) {
            basicAnimator.OnIdle();
            return;

        }
        basicAnimator.OnRun();


    }


    void FixedUpdate() {

        if(direction != Vector3.zero) {
            player.Move(direction);
            player.Rotation(direction);
        }

        player.Rotation(baseFloor);

    }



}
