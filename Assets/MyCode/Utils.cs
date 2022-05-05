using UnityEngine;
public static class Utils {
    public const string GUNPACK_TAG = "GunPack";
    public const int GUNPACK_SIZE = 4;
    public const int ZUMBI_DEFINITION_SIZE = 13;
    public const float IMPACT_DISTANCE = 2.2f;
    public const int BULLET_TIME_INIT = 150;
    public const string BUTTON_FIRE = "Fire1";
    public const int ZUMBI_MAX = 55;
    public const string SCENE_PARKING = "Parking";


    public const int TIME_TO_NEW_INIT = 850;

    public const string IS_GUN = "IsGun";
    public const string ON_TAKE_HIT = "OnTakeHit";
    public const string ON_MOVE = "OnMove";
    public const string ON_ATTACK = "OnAttack";
    public const string PLAYER_TAG = "Player";
    public const string ZUMBI_TAG = "Zumbi";
    public const float CAMERA_DELAY = 1.3f;
    public const string VERTICAL = "Vertical";
    public const string HORIZONTAL = "Horizontal";

    public static PlayerDomain CreatePlayer() {
        return new PlayerDomain(10,10);
    }

    private static readonly ZumbiDomain[] ZUMBI_DEFINITION = new ZumbiDomain[ZUMBI_DEFINITION_SIZE] {
        new ZumbiDomain(1,19,3,1),
        new ZumbiDomain( 3,39,2,1 ),
        new ZumbiDomain( 4,16,3 ,1),
        new ZumbiDomain(5,29,3,2),
        new ZumbiDomain(9,44,1,5),
        new ZumbiDomain(10,25,3,2),
        new ZumbiDomain(12,16,2,1),
        new ZumbiDomain(14,19,3,3),
        new ZumbiDomain(17,12,2,1),
        new ZumbiDomain(18,19,1,2),
        new ZumbiDomain(19,15,1,1),
        new ZumbiDomain(23,15,3,1),
        new ZumbiDomain(27,12,1,2)
    };

    public static ZumbiDomain CreateZumbi(int rad) {
        return new ZumbiDomain(
            ZUMBI_DEFINITION[rad].GetTypeBody(),
            ZUMBI_DEFINITION[rad].GetLife(),
            ZUMBI_DEFINITION[rad].GetSpeed(),
            ZUMBI_DEFINITION[rad].GetStrength()
            );
    }

    public static readonly Color[] COLOR_DEFINITION = new Color[GUNPACK_SIZE] {
        new Color(0.2f,0.2f,0.8f),
        new Color(0.8f,0.2f,0.2f),
        new Color(0.8f,0.4f,0.2f),
        new Color(0.2f,0.8f,0.2f)
    };

    private static readonly BulletDomain[] BULLET_DEFINITION = new BulletDomain[GUNPACK_SIZE] {
        new BulletDomain(25,new int[]{1,1,1,1},COLOR_DEFINITION[0]),
        new BulletDomain(25,new int[]{4,2,2,1},COLOR_DEFINITION[1]),
        new BulletDomain(25,new int[]{4,4,4,4},COLOR_DEFINITION[2]),
        new BulletDomain(25,new int[]{3,2,3,3},COLOR_DEFINITION[3])
    };

    public static BulletDomain CreateBullet(int rad) {
        return new BulletDomain(
            BULLET_DEFINITION[rad].GetSpeed(),
            BULLET_DEFINITION[rad].GetHits(),
            BULLET_DEFINITION[rad].GetColor()
       );
    }


    public static int GetTimeToNew(int rad) {
        return (5 * (rad +1)) * 10;
    }

}