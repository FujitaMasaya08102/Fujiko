using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private readonly int EnemySize = 20;
    private int EnemyIndex;

    [SerializeField]
    private GameObject StagePrefab;

    [SerializeField]
    private Transform Target;//Unitychan

    [SerializeField]
    private List<GameObject> EnemyPrefabList;//敵のプレハブ

    [SerializeField]
    private int FirstEnemyIndex;//スタート時にどのインデックスから敵を生成するのか

    [SerializeField]
    private int aheadEnemy; //事前に生成しておく敵

    private List<GameObject> EnemyList = new List<GameObject>();//生成した敵のリスト

    // Start is called before the first frame update
    void Start()
    {

        EnemyIndex = FirstEnemyIndex - 1;
        StageManager(aheadEnemy);

    }

    // Update is called once per frame
    void Update()
    {


        int targetPosIndex = (int)(Target.position.z / EnemySize);

        if (targetPosIndex + aheadEnemy > EnemyIndex)
        {

            StageManager(targetPosIndex + aheadEnemy);

        }

    }
    void StageManager(int maps)
    {

        if (maps <= EnemyIndex)
        {

            return;

        }

        for (int i = EnemyIndex + 1; i <= maps; i++)//指定したステージまで作成する
        {

            GameObject Enemy = MakeStage(i);
            EnemyList.Add(Enemy);

        }

        while (EnemyList.Count > aheadEnemy + 1)//古いステージを削除する
        {

            DestroyStage();

        }

        EnemyIndex = maps;
    }

    GameObject MakeStage(int index)//ステージを生成する
    {

        int nextStage = Random.Range(0, EnemyList.Count);

        GameObject stageObject = (GameObject)Instantiate(EnemyList[nextStage], new Vector3(0, 0, index * EnemySize), Quaternion.identity);

        return stageObject;

    }

    void DestroyStage()
    {

        GameObject oldStage = EnemyList[0];
        EnemyList.RemoveAt(0);
        Destroy(oldStage);

    }

}