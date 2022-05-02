public class PlayerDomain {

    private int speed;
    private int life;
    private bool dead;


    public PlayerDomain(int speed,int life) {
        this.speed = speed;
        this.life = life;
        this.dead = false;
    }

    public int GetSpeed() {
        return speed;
    }

    public bool IsDead() {
        return dead;
    }

    public bool ReduceLife(int reduce) {
        life -= reduce;
        if(life < 1) {
            dead = true;
        }
        return dead;
    }

}