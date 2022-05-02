public class ZumbiDomain {
   
    private int typeBody;
    private int life;
    private int speed;
    private int strength;
    private bool dead;


    public ZumbiDomain(int typeBody, int life, int speed,int strength) {
        this.typeBody = typeBody;
        this.life = life;
        this.speed = speed;
        this.strength = strength;
        dead = false;
    }

    public int GetTypeBody() {
        return typeBody;
    }

    public int GetLife() {
        return life;
    }

    public int GetSpeed() {
        return speed;
    }

    public int GetStrength() {
        return strength;
    }

    public bool ReduceLife(int reduce) {
        life -= reduce;
        if(life < 1) {
            dead = true;
        }
        return dead;
    }

    


}