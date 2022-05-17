using UnityEngine;

public class BulletDomain: BasicDomain {

    private static readonly int[] SPEED_BULLET_DEFINITION = new int[Utils.GUNPACK_SIZE]{30,20,30,50 };
    private static readonly int[][] HITS_BULLET_DEFINITION = new int[Utils.GUNPACK_SIZE][] {
         new int[]{1,1,1,1},
         new int[]{ 4,2,2,1 },
         new int[]{ 4,4,4,4 },
         new int[]{ 3,2,3,3 }
    };


    private int hitId;

    public int[] Hits;
    public Color Color { get;}


    public BulletDomain(Rigidbody rigidbody,int id): this(rigidbody,SPEED_BULLET_DEFINITION[id],id,HITS_BULLET_DEFINITION[id]) {

    }


    public BulletDomain(Rigidbody rigidbody,int speed,int id,int[] hits): base(rigidbody ,speed,id,Utils.BULLET_TIME_INIT) {
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