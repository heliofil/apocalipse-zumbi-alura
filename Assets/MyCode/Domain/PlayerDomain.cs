public class PlayerDomain {

    private int speed;
    private int life;

    public PlayerDomain(int speed,int life) {
        this.speed = speed;
        this.life = life;

    }

    public int GetSpeed() {
        return speed;
    }

    public int GetLife() {
        return life;
    }

       public bool ReduceLife(int reduce) {
        life -= reduce;
        if(life < 1) {
            return true;
        }
        return false;
    }

}