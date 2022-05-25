using UnityEngine;

public class BulletDomain: BasicDomain {
    private const string BULLET_NAME = "Bullet";
    private static readonly int[] SPEED_BULLET_DEFINITION = new int[Utils.GUNPACK_SIZE]{40,30,50,30 };
    private static readonly int[][] HITS_BULLET_DEFINITION = new int[Utils.GUNPACK_SIZE][] {
         new int[]{4,0,0,0},
         new int[]{ 3,2,1,0 },
         new int[]{ 10,0,0,0 },
         new int[]{ 3,2,4,1 }
    };


    private int hitId;

    public int[] Hits;
    public Color Color { get;}


    public BulletDomain(Rigidbody rigidbody,int id): this(rigidbody,id,BULLET_NAME,SPEED_BULLET_DEFINITION[id],HITS_BULLET_DEFINITION[id]) {

    }


    public BulletDomain(Rigidbody rigidbody,int id,string name,int speed,int[] hits): base(rigidbody,id,name,Utils.BULLET_TIME_INIT,speed) {
        this.Hits = hits;
        this.hitId = 0;
        this.Color = Utils.COLOR_DEFINITION[id];
    }

    public int GetNextHit() {
        int hit = 0;
        if(hitId < Hits.Length) {
            hit = Hits[hitId];
            hitId++;
        }
       
        return hit;
    }



}