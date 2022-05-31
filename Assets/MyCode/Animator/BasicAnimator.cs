using UnityEngine;
   
public class BasicAnimator : MonoBehaviour {

    private Animator animator;

    private const string ON_TAKE_HIT = "OnTakeHit";
    private const string ON_MOVE = "OnMove";
    private const string ON_ATTACK = "OnAttack";
    private const string ON_DIE = "OnDie";

    private const int ON_MOVE_IDLE = 0;
    private const int ON_MOVE_WALK = 1;
    private const int ON_MOVE_RUN = 2;
    private void Awake() {
        animator = GetComponent<Animator>();
    }
   
    public void OnTakeHit(bool action) {
        animator.SetBool(ON_TAKE_HIT,action);
    }
   
    public void OnAttack(bool action) {
        animator.SetBool(ON_ATTACK,action);
    }

    public void OnIdle() {
        animator.SetInteger(ON_MOVE,ON_MOVE_IDLE);
    }
    public void OnMove() {
        animator.SetInteger(ON_MOVE,ON_MOVE_WALK);
    }
    public void OnRun() {
        animator.SetInteger(ON_MOVE,ON_MOVE_RUN);
    }

    public void OnDie() {
        animator.SetTrigger(ON_DIE);
    }

}