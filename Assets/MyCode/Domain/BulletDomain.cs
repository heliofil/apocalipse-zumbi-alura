using System;

public class BulletDomain {

    private int speed;
    private int[] hits;
    private int hitId;

    public BulletDomain(int speed,int[] hits) {
        this.speed = speed;
        this.hits = hits;
        this.hitId = 0;
    
    }

    public int GetSpeed() {
       return speed;
    }

    public int GetNextHit() {
        int hit = 0;
        if(hitId < hits.Length) {
            hit = hits[hitId];
            hitId++;
        }
        return hit;
    }

    internal object GetHits() {
        throw new NotImplementedException();
    }
}