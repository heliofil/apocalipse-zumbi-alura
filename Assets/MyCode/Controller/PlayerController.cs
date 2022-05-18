using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    private Vector3 direction;
    
    private PlayerDomain player;
    public LayerMask BaseFloor;
    public AudioClip TakeHitAudio;
    private BasicAnimator basicAnimator;

    private static PlayerController playerInstance;
    public static PlayerController PlayerInstance {
        get {

            if(!playerInstance) {
                playerInstance = GameObject.FindWithTag(Utils.PLAYER_TAG).GetComponent < PlayerController > ();
            }
            
            return playerInstance;

        }
     }

    private void Start() {
        basicAnimator = GetComponent<BasicAnimator> ();
    }


    public void TakeHit(int hit) {

        AudioSourceController.AudioSourceInstance.PlayOneShot(TakeHitAudio);

        if(player.ReduceLife(hit)) {
            UIController.UIInstance.GameOver();
        };
        UIController.UIInstance.SetLifeBar(player.Life);

    }

    public void HasGun() {
        basicAnimator.OnMove();
        player.EnableSlow();
    }

    public void NoGun() {
        player.DisableSlow();
    }

    // Start is called before the first frame update
    void Awake()
    {
        
        player = new PlayerDomain(GetComponent<Rigidbody>());
        UIController.UIInstance.SetMaxLifeBar(player.Life);
        UIController.UIInstance.SetLifeBar(player.Life);
        
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

        player.Rotation(BaseFloor);


    }

}
