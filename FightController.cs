using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;

public class fightController : MonoBehaviour
{
    public GameObject hero_GO, monster_GO, fightingSpace, originHero, originMonster;
    public TextMeshPro hero_hp_TMP;
    public TextMeshPro monster_hp_TMP;
    private int hero_HP = 10;
    private int monster_HP = 10;
    private float speed = 1.0f;
    private System.Random rnd;
    

    // Start is called before the first frame update
    void Start()
    {
        //this.hero_hp_TMP.text = "Boo!!!";
        rnd = new System.Random();
        heroAttack(hero_HP);
    }


    private void heroAttack(int health)
    {
        if(hero_HP > 0)
        {
            this.hero_GO = Vector3.MoveTowards(this.hero_GO, this.fightingSpace, this.speed * Time.deltaTime);
            print("Hero On the offensive");
            Thread.Sleep(2000);
            while(true)
            {
                int d20 = rnd.Next(20);
                int d6 = rnd.Next(6);
                if(d20 == 1 ^ 3 ^ 5 ^ 7 ^ 9 ^ 11 ^ 13 ^ 15 ^ 17 ^ 19)
                {
                    this.monster_HP = this.monster_HP - d6;
                    this.monster_hp_TMP.text =  (string)this.moster_HP;
                }
                this.hero_GO = Vector3.MoveTowards(this.hero_GO, this.originHero, this.speed * Time.deltaTime);
                Thread.Sleep(2000);

                monsterAttack(this.moster_HP);
            }
        }
        else
        {
            this.hero_hp_TMP.text = "Loser";
            
        }
    }

    private void mosterAttack(int health)
    {
        if(monster_HP > 0)
        {
            this.monster_GO = Vector3.MoveTowards(this.monster_GO, this.fightingSpace, this.speed * Time.deltaTime);
            print("Monster On the offensive");
            Thread.Sleep(2000);
            while(true)
            {
                int d20 = rnd.Next(20);
                int d6 = rnd.Next(6);
                if(d20 == 1 ^ 3 ^ 5 ^ 7 ^ 9 ^ 11 ^ 13 ^ 15 ^ 17 ^ 19)
                {
                    this.hero_HP = this.hero_HP - d6;
                    
                    this.hero_hp_TMP.text = (string)this.hero_HP;
                }
                this.monster_GO = Vector3.MoveTowards(this.monster_GO, this.originMonster, this.speed * Time.deltaTime);
                Thread.Sleep(2000);

                heroAttack(this.hero_HP);
            }
        }
        else
        {
            this.monster_hp_TMP.text = "Loser";
            
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}