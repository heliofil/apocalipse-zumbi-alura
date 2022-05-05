using UnityEngine;

public class BulletDomain {

    private int speed;
    private int[] hits;
    private int hitId;
    private Color color;

    public BulletDomain(int speed,int[] hits,Color color) {
        this.speed = speed;
        this.hits = hits;
        this.hitId = 0;
        this.color = color;
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

    public int[] GetHits() {
        return hits;
    }

    public Color GetColor() {
        return color;
    }

}