using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status
{

    //　この3つの値がVo,Ba,Viの変わりみたいにする
    //　この値で合戦時にバフを与える
    public int goodFriends = 0;
    //　実質的な攻撃力
    public int playSkill = 0;
    //　この値で合戦時にバフを与える
    public int fun = 0;

    // ステータスの初期値
    private readonly int BASE = 120;

    //ステータスの最大値
    public readonly int BASE_MAX = 2800;

    //　この値の上昇割合 100で100％上昇
    public int goodFriendsRate = 0;
    //　この値の上昇割合 100で100％上昇
    public int playSkillRate = 0;
    //　この値の上昇割合 100で100％上昇
    public int funRate = 0;

    //  100で100％上昇
    private readonly int BASE_RATE = 20;

    // 通貨単位は1000
    public int fuju = 0;
    // 基礎的なHPの最大値
    private readonly int BASE_MAX_HP = 26;
    // HP 体力
    public int HP = 0;
    // HP 最大体力
    public int MAX_HP = 0;
    // 余裕
    public int LEEWAY_HP = 0;

    public Status()
    {
        // 値の初期値を設定
        goodFriends = playSkill = fun = BASE;

        // 上昇量の初期値を設定
        goodFriendsRate = playSkillRate =
        funRate = BASE_RATE;

        // HPの初期値を設定
        HP= MAX_HP= BASE_MAX_HP;
    }

    public Status Cope() { return (Status)this.MemberwiseClone(); }

}
