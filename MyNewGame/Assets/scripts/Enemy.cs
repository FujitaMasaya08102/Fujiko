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
    private List<GameObject> EnemyPrefabList;//�G�̃v���n�u

    [SerializeField]
    private int FirstEnemyIndex;//�X�^�[�g���ɂǂ̃C���f�b�N�X����G�𐶐�����̂�

    [SerializeField]
    private int aheadEnemy; //���O�ɐ������Ă����G

    private List<GameObject> EnemyList = new List<GameObject>();//���������G�̃��X�g

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

        for (int i = EnemyIndex + 1; i <= maps; i++)//�w�肵���X�e�[�W�܂ō쐬����
        {

            GameObject Enemy = MakeStage(i);
            EnemyList.Add(Enemy);

        }

        while (EnemyList.Count > aheadEnemy + 1)//�Â��X�e�[�W���폜����
        {

            DestroyStage();

        }

        EnemyIndex = maps;
    }

    GameObject MakeStage(int index)//�X�e�[�W�𐶐�����
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