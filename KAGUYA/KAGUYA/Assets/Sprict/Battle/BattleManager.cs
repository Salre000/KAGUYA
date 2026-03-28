using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    private readonly int CARD_COST_RATE = 1;
    private readonly int CARD_NAME_RATE = 2;
    private readonly int CARD_ATTACK_RATE = 3;
    private readonly int CARD_EXTRA_RATE = 4;
    private readonly int CARD_ATTACK_ENHANCED_RATE = 5;
    private readonly int CARD_EXTRA_ENHANCED_RATE = 6;
    private readonly int CARD_LEVEL_BASE = 1;



    List<BattleCard> battleCards = new List<BattleCard>();
    List<int> handCards = new List<int>();

    List<List<string>> battleCardTextData = new List<List<string>>();

    int irohaPower = 0;
    int YCPower = 0;
    int kaguyaPower = 0;

    private System.Action<int,int> SetBattlePower = null;

    private int turn = 0;
    private int kassenMaxTurn = 12;

    private int turnInAction = 1;

    private readonly int BASE_TURN_IN_ACTION = 1;


    [SerializeField] SpriteScriptableObject battleImages;
    public void Awake()
    {
        instance = this;

        handCards = new List<int> { 0, 1, 2 };
    }

    public void Start()
    {

        battleCardTextData = TextLoad.Load("BattleCard");

        for(int i = 1; i < 11; i++) 
        {
            SetBattleCard(i);
        }

    }

    public void Update()
    {
        Debug.Log("TEST:IROHA:" + irohaPower);
        Debug.Log("TEST:YC:" + YCPower);
        Debug.Log("TEST:KAGUYA:" + kaguyaPower);

        if (Input.GetKeyDown(KeyCode.E))
        {

            for (int i = 0; i < battleCards.Count; i++)
            {
                for (int j = 0; j < battleCards[i].extra.Count; j++)
                {
                    battleCards[i].extra[j]();
                }



            }

        }
    }
    public int GetTurn() { return turn; }
    public int GetRemainingTurn() { return kassenMaxTurn-turn; }
    public void NestTurn() 
    {
        turnInAction--;

        if (turnInAction > 0) return;

        turnInAction = BASE_TURN_IN_ACTION;

        turn++;

        if (turn < kassenMaxTurn) return;

        SceneManager.instance.SceneEnd();


    }
    public Sprite GetCardImage(int ID)
    {
        return battleImages.sprites[ID];

    }

    public int GetHandIndex(int ID)
    {
        return handCards[ID];

    }

    public BattleCard GetCard(int ID)
    {
        return battleCards[ID];

    }

    public void SetSetBattlePower(System.Action<int, int> action) 
    {
        SetBattlePower=action;
    }

    public void BattleStart() 
    {
        turn = 0;
    }

    public void Attack(int value) 
    {

        SetBattlePower(value, 0);


        Debug.Log("攻撃力"+value);
    }

    public void LeewayUp(int value) 
    {
        // まだ中身がない

        Status status=　StatusManager.instance.GetStatus();

        status.LEEWAY_HP += value;

        StatusManager.instance.SetStatus(status);

        Debug.Log("攻撃力"+value);
    }

    public void SetCardAction(int index,System.Action Reroll) 
    {

        index = handCards[index];

        // Hpの消費が可能かどうかを判断
        if (battleCards[index].cost > StatusManager.instance.GetStatus().HP+ StatusManager.instance.GetStatus().LEEWAY_HP) return;



        StatusManager.instance.StatusInterference(status =>
        {

            Cost (battleCards[index].cost);

            StatusManager.instance.SetStatus(status);

        });


        Attack(battleCards[index].attack);


        battleCards[index].cardStatus = cardStatus.trash;

        for (int i=0;i< battleCards[index].extra.Count; i++)  
        {
            battleCards[index].extra[i]();
        }

        BattleManager.instance.NestTurn();

        Reroll();

    }
    public void SetHand(int count=1) 
    {
        List<int> indexs=new List<int>();

        if (battleCards.GetCount(status => { return status.cardStatus == cardStatus.deck; }) < count)
            battleCards.GetAction(status => 
            {
                if(status.cardStatus== cardStatus.trash)
                    status.cardStatus= cardStatus.deck;
                return status;
            });



        for (int i = 0; i < battleCards.Count; i++) 
        {
            if (battleCards[i].cardStatus != cardStatus.deck) continue;
            indexs.Add(i);
        }

        for(int i = 0; i < count; i++) 
        {
            int random= UnityEngine.Random.Range(0, indexs.Count);



            handCards.Add(indexs[random]);

            battleCards[handCards[handCards.Count - 1]].cardStatus = cardStatus.hand;

            indexs.RemoveAt(random);
        }

    }

    public void ResetHand() 
    {
        handCards.Clear();
    }
    public void HandTrash() 
    {

        battleCards.GetAction(card =>
        {
            if (card.cardStatus == cardStatus.hand)
                card.cardStatus = cardStatus.trash;
            return card;
        });


    }

    public void Heel(int value) 
    {
        Status status = StatusManager.instance.GetStatus();

        status.HP += value;
        
        if(status.HP>status.MAX_HP) status.HP=status.MAX_HP;

        StatusManager.instance.SetStatus(status);



    }

    /// <summary>
    /// IDを基にBattleCardの一部を埋める
    /// </summary>
    /// <param name="ID"></param>
    private void SetBattleCard(int ID)
    {
        BattleCard battleCard = new BattleCard();
        battleCard.id = ID;
        battleCard.cost = int.Parse(battleCardTextData[ID][CARD_COST_RATE]);
        battleCard.name = battleCardTextData[ID][CARD_NAME_RATE];
        battleCard.attack = int.Parse(battleCardTextData[ID][CARD_ATTACK_RATE]);
        battleCard.level = 10;//CARD_LEVEL_BASE;

        battleCards.Add(battleCard);

        //テスト
        BattleSetBattleCard(battleCards.Count - 1);
    }
    /// <summary>
    /// バトルに使用できるようにBattleCardに更新を与える
    /// </summary>
    private void BattleSetBattleCard(int index)
    {
        battleCards[index].attack = int.Parse(battleCardTextData[battleCards[index].id][CARD_ATTACK_RATE]);
        battleCards[index].attack += int.Parse(battleCardTextData[battleCards[index].id][CARD_ATTACK_ENHANCED_RATE]);


        SetExtra(index, battleCardTextData[battleCards[index].id][CARD_EXTRA_RATE]);
        SetExtra(index, battleCardTextData[battleCards[index].id][CARD_EXTRA_ENHANCED_RATE]);
    }

    private void Cost(int cost) 
    {
        Status status = StatusManager.instance.GetStatus();

        if (status.LEEWAY_HP < 0) 
        { 
            status.HP -= cost;
        }
        else 
        {
            if(cost> status.LEEWAY_HP) 
            {
                status.HP -= cost- status.LEEWAY_HP;
                status.LEEWAY_HP = 0;

            }
            else 
            {
                status.LEEWAY_HP-= cost;
            }



        }

            StatusManager.instance.SetStatus(status);

    }



    private void SetExtra(int index, string extraText)
    {
        for (int i = 0; i < extraText.Length; i++)
        {
            // ＝の時にリセット
            if (extraText[i] == '=') { battleCards[index].extra.Clear(); continue; }

            //　コマンドの文字が来ないとコンテニュー
            if (!CheckExtraTextCommand(extraText[i])) continue;

            int power = GetExtraValue(i, index, extraText); ;

            switch (extraText[i])
            {

                case 'I':

                    battleCards[index].extra.Add(() =>
                    {
                        AddIroha(power);
                    });

                    break;
                case 'Y':

                    battleCards[index].extra.Add(() =>
                    {
                        AddYC(power);
                    });

                    break;
                case 'K':

                    battleCards[index].extra.Add(() =>
                    {
                        AddKaguya(power);
                    });

                    break;
                case 'C':

                    battleCards[index].extra.Add(() =>
                    {
                        Attack(power);
                        Debug.Log("攻撃力" + power + "の攻撃");
                    });

                    break;

                case 'R':

                    System.Action action = battleCards[index].extra[battleCards[index].extra.Count-1];

                    for (int j = 0; j < power; j++)
                    {
                        battleCards[index].extra.Add(() => { action();});
                    }

                    break;
                case 'L':


                    battleCards[index].extra.Add(() =>
                    {
                        LeewayUp(power);
                    });

                    break;

            }

        }



    }




    /// <summary>
    /// コマンドの文字かどうかを判断する
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    private bool CheckExtraTextCommand(char c)
    {
        if (c == 'I') return true;
        if (c == 'Y') return true;
        if (c == 'K') return true;
        if (c == 'C') return true;
        if (c == 'N') return true;
        if (c == 'R') return true;
        if (c == 'L') return true;

        return false;
    }

    /// <summary>
    /// 数字に変換できるコマンドかどうかを判断する
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    private bool CheckExtraNumberTextCommand(char c)
    {
        if (c == 'N') return true;

        return false;
    }

    private int GetExtraValue(int i, int index, string extraText)
    {

        int power = -1;

        //　一文字進める
        i += 1;

        List<int> StackList = new List<int>();

        string c = string.Empty;
        // 数字のみ
        for (int j = i; j < extraText.Length; j++)
        {

            //　ゴリ押し
            c += extraText[j];

            int powerDummy = 0;


            if (!int.TryParse(c, out powerDummy))
            {
                break;
            }

            power = powerDummy;
        }

        //文字あり
        if (power == -1)
        {
            for (int j = i; j < extraText.Length; j++)
            {
                if (!CheckExtraNumberTextCommand(extraText[j])) continue;

                switch (extraText[j])
                {
                    case 'N':

                        power = battleCards[index].level;

                        break;


                }

                if (extraText.Length < j + 1 && CheckExtraNumberTextCommand(extraText[j + 1])) continue;
                int powerDummy = 0;
                j++;
                c = string.Empty;
                // 数字のみ
                for (int p = j; p < extraText.Length; p++)
                {

                    //　ゴリ押し
                    c += extraText[p];

                    int powerDummyDummy = 0;

                    if (!int.TryParse(c, out powerDummyDummy))
                    {
                        break;
                    }
                    powerDummy = powerDummyDummy;
                }

                power += powerDummy;


            }
        }

        return power;

    }


    /// <summary>
    ///  いろはの努力の値を加算する関数
    /// </summary>
    /// <param name="add"></param>
    private void AddIroha(int add)
    {
        irohaPower += add;

    }

    /// <summary>
    ///  ヤチヨの思いの値を加算する関数
    /// </summary>
    /// <param name="add"></param>
    private void AddYC(int add)
    {
        YCPower += add;

    }

    /// <summary>
    ///  かぐやの情熱の値を加算する関数
    /// </summary>
    /// <param name="add"></param>
    private void AddKaguya(int add)
    {
        kaguyaPower += add;

    }





    public enum cardStatus 
    {
        deck,
        hand,
        trash,
        exclusion,


    }

    public class BattleCard
    {
        public int id = 0;
        public int cost = 0;
        public int attack = 0;
        public int level = 0;
        public string name = string.Empty;
        public List<System.Action> extra = new List<System.Action>();
        public cardStatus cardStatus = cardStatus.deck;

    }



}
