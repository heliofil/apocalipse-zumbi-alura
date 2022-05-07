public class BasicDomain {

    
    public int Life {
        get; private set;
    }

    public int Speed {
        get; private set;
    }

    public int Id {
        get; private set;
    }

    public bool Dead { get; private set;
    }

    public BasicDomain():this(10,1,10) {
    
    }

    public BasicDomain(int speed,int id,int life) {
        Speed = speed;
        Id = id;
        Life = life;
        Dead = false;
    }

    public int Slow() {
        return Speed - (Speed/3);
    }

    public bool ReduceLife(int reduce) {
        Life -= reduce;
        if(Life < 1) {
            Dead = true;
        }
        return Dead;
    }

}