using UnityEngine;
public static class Utils {
    public const string GUNPACK_TAG = "GunPack";
    public const int GUNPACK_SIZE = 4;
    public const int ZUMBI_DEFINITION_SIZE = 13;
    public const float IMPACT_DISTANCE = 2.2f;
    public const int BULLET_TIME_INIT = 150;
    public const string BUTTON_FIRE = "Fire1";
    public const int ZUMBI_MAX = 55;


    public const int TIME_TO_NEW_INIT = 850;

    public const string ON_TAKE_HIT = "OnTakeHit";
    public const string ON_MOVE = "OnMove";
    public const string ON_ATTACK = "OnAttack";
    public const string PLAYER_TAG = "Player";
    public const string ZUMBI_TAG = "Zumbi";
    public const float CAMERA_DELAY = 1.3f;
    public const string VERTICAL = "Vertical";
    public const string HORIZONTAL = "Horizontal";

    public static PlayerDomain CreatePlayer() {
        return new PlayerDomain(10,5);
    }

    private static readonly int[,] ZUMBI_DEFINITION = new int[ZUMBI_DEFINITION_SIZE,4] {
        { 1,19,5,1 },
        { 3,39,3,1 } ,
        { 4,16,4 ,1 },
        { 5,29,5,2 },
        { 9,44,3,1 },
        { 10,25,4,2 },
        { 12,16,4,1 },
        { 14,19,5,1 },
        { 17,12,4,1 },
        { 18,19,5,1 },
        { 19,15,3,1 },
        { 23,15,3,1 },
        { 27,12,4,2 }
    };

    public static ZumbiDomain CreateZumbi(int rad) {
        return new ZumbiDomain(
            ZUMBI_DEFINITION[rad,0],
            ZUMBI_DEFINITION[rad,1],
            ZUMBI_DEFINITION[rad,2],
            ZUMBI_DEFINITION[rad,3]
            );
    }

    private static readonly int[,] BULLET_DEFINITION = new int[GUNPACK_SIZE,5] {
        {25,3,3,3,3},
        {20,1,2,3,2},
        {25,6,5,5,2},
        {20,3,3,3,2}
    };

    public static BulletDomain CreateBullet(int rad) {
        return new BulletDomain(
            BULLET_DEFINITION[rad,0],
            new int[4] {
                BULLET_DEFINITION[rad,1],
                BULLET_DEFINITION[rad,2],
                BULLET_DEFINITION[rad,3],
                BULLET_DEFINITION[rad,4]
            }
       );
    }


    public static int GetTimeToNew(int rad) {
        return (5 * (rad +1)) * 10;
    }

}