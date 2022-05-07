public class ZumbiDomain : BasicDomain {

    private static readonly int[,] ZUMBI_DEFINITION = new int[Utils.ZUMBI_DEFINITION_SIZE,4] {
        { 1,19,3,1 },
         { 3,39,2,1 } ,
         { 4,16,3 ,1 },
        { 5,29,3,2 },
        { 9,44,1,5 },
        { 10,25,3,2 },
        { 2,16,2,1 },
        { 14,19,3,3 },
        { 17,12,2,1 },
        { 18,19,1,2 },
        { 9,15,1,1 },
        { 23,15,3,1 },
        { 27,12,1,2 }
    };

    public int Strength {
        get; 
    }

    public ZumbiDomain(int id) : this(ZUMBI_DEFINITION[id,2],ZUMBI_DEFINITION[id,0],ZUMBI_DEFINITION[id,1],ZUMBI_DEFINITION[id,3]) {

    }

    public ZumbiDomain(int speed,int id,int life, int strength): base(speed,id,life) {
        
        this.Strength = strength;
        
    }
    
}