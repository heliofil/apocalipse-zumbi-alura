using UnityEngine;

public class BasicDomain {

    public int InitialLife {
        get; private set;
    }

    public int Life {
        get; private set;
    }

    public string Name {
        get; private set;
    }

    public int Id {
        get; private set;
    }


    public BasicDomain(int id,string name, int life) {
        Id = id;
        Life = life;
        InitialLife = life;
        Name = name;
    }


    public void RestoreLife() {

        int RestoreLife = InitialLife - Life;
        if(RestoreLife < 1) {
            return;
        }

        Life += RestoreLife / 2;

    }
    public bool ReduceLife(int reduce) {
        Life -= reduce;
        
        if(Life < 1) {
            return true;
        }
        return false;
    }

}