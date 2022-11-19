using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{

    private int StageSize = 20;
    private int StageIndex;

    [SerializeField]
    private Transform Target;//Unitychan

    [SerializeField]
    private List<GameObject> stagePrefabList;//ステージのプレハブ

    [SerializeField]
    private int FirstStageIndex;//スタート時にどのインデックスからステージを生成するのか

    [SerializeField]
    private int aheadStage; //事前に生成しておくステージ

    private List<GameObject> StageList = new List<GameObject>();//生成したステージのリスト

    // Start is called before the first frame update
    void Start()
    {

        StageIndex = FirstStageIndex - 1;
        StageManager(aheadStage);

    }

    // Update is called once per frame
    void Update()
    {

        int targetPosIndex = (int)(Target.position.z / StageSize);

        if (targetPosIndex + aheadStage > StageIndex)
        {

            StageManager(targetPosIndex + aheadStage);

        }

    }
    void StageManager(int maps)
    {

        if (maps <= StageIndex)
        {

            return;

        }

        for (int i = StageIndex + 1; i <= maps; i++)//指定したステージまで作成する
        {

            GameObject stage = MakeStage(i);
            StageList.Add(stage);

        }

        while (StageList.Count > aheadStage + 1)//古いステージを削除する
        {

            DestroyStage();

        }

        StageIndex = maps;
    }

    GameObject MakeStage(int index)//ステージを生成する
    {

        int nextStage = Random.Range(0, stagePrefabList.Count);

        GameObject stageObject = (GameObject)Instantiate(stagePrefabList[nextStage], new Vector3(0, 0, index * StageSize), Quaternion.identity);

        return stageObject;

    }

    void DestroyStage()
    {

        GameObject oldStage = StageList[0];
        StageList.RemoveAt(0);
        Destroy(oldStage);

    }

}