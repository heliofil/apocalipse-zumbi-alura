using UnityEngine;

public class ZumbiDomain : BasicDomain {

    private static readonly int[,] ZUMBI_DEFINITION = new int[Utils.ZUMBI_DEFINITION_SIZE,4] {
        { 1,24,3,1 },
        { 2,16,2,1 },
        { 3,39,2,1 } ,
        { 4,26,3 ,2 },
        { 5,39,3,2 },
        { 9,44,1,5 },
        { 10,25,3,2 },
        { 14,19,3,3 },
        { 16,15,1,1 },
        { 17,12,2,1 },
        { 18,19,1,2 },
        { 23,15,3,1 },
        { 27,12,1,2 }
    };

    private static readonly string[] ZUMBI_DEFINITION_NAME = new string[Utils.ZUMBI_DEFINITION_SIZE] {
        "Mille",
        "Zac",
        "Alf",
        "Scott",
        "Lexi",
        "Steve",
        "Danny",
        "Mario",
        "Lewis",
        "Jack",
        "Adam",
        "Zhou",
        "Rhoades"
    };

    public int Strength {
        get; 
    }

    public ZumbiDomain(Rigidbody rigidbody,int id) : this(rigidbody,ZUMBI_DEFINITION[id,0],ZUMBI_DEFINITION_NAME[id],ZUMBI_DEFINITION[id,1],ZUMBI_DEFINITION[id,2],ZUMBI_DEFINITION[id,3]) {

    }

    public ZumbiDomain(Rigidbody rigidbody,int id,string name,int life, int speed, int strength): base(rigidbody,id,name,life,speed) {
        
        this.Strength = strength;
        
    }

    public static int GetIdByOrder(int order) {
        return ZUMBI_DEFINITION[order,0];
    }
    
}