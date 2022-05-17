using UnityEngine;
   
public class BasicAnimation : MonoBehaviour {

    private Animator animator;

    private const string ON_RUN = "OnRun";
    private const string ON_TAKE_HIT = "OnTakeHit";
    private const string ON_MOVE = "OnMove";
    private const string ON_ATTACK = "OnAttack";

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    public void OnRun(bool action) {
        animator.SetBool(Utils.ON_RUN,action);
    }
    public void OnTakeHit(bool action) {
        animator.SetBool(Utils.ON_TAKE_HIT,action);
    }
    public void OnMove(bool action) {
        animator.SetBool(Utils.ON_MOVE,action);
    }
    public void OnAttack(bool action) {
        animator.SetBool(Utils.ON_ATTACK,action);
    }

}