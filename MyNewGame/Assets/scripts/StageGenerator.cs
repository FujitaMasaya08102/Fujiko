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
    private List<GameObject> stagePrefabList;//�X�e�[�W�̃v���n�u

    [SerializeField]
    private int FirstStageIndex;//�X�^�[�g���ɂǂ̃C���f�b�N�X����X�e�[�W�𐶐�����̂�

    [SerializeField]
    private int aheadStage; //���O�ɐ������Ă����X�e�[�W

    private List<GameObject> StageList = new List<GameObject>();//���������X�e�[�W�̃��X�g

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

        for (int i = StageIndex + 1; i <= maps; i++)//�w�肵���X�e�[�W�܂ō쐬����
        {

            GameObject stage = MakeStage(i);
            StageList.Add(stage);

        }

        while (StageList.Count > aheadStage + 1)//�Â��X�e�[�W���폜����
        {

            DestroyStage();

        }

        StageIndex = maps;
    }

    GameObject MakeStage(int index)//�X�e�[�W�𐶐�����
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