using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cCaster : MonoBehaviour { 

    #region public 변수

    public GameObject m_objRushCollider;
    public Canvas m_canvasSkillTree;
	public Animator m_animatorAnim;

    #endregion


    #region private 변수

    private GameObject m_objHit;                                 

    #endregion

    // Use this for initialization
    void Start ()
    {
		InitSkillSlot();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.K))
		{
			m_canvasSkillTree.gameObject.SetActive(!m_canvasSkillTree.gameObject.activeInHierarchy);
		}
		CastSkill();
	}

	private void LateUpdate()
	{
		
	}

    #region 스킬 발동 조건 구현

	/// <summary>
	/// 근거리 스킬 슬롯을 장착한다.
	/// </summary>
	public void InitSkillSlot()
	{
		int nComboStep = cCharacterInformation.Instance.m_nMeleeSkillComboStep;
		cCharacterInformation.Instance.m_dicCurrentSkillSlot = cCharacterInformation.Instance.m_listDicMeleeSkillSlot[nComboStep];
		cCharacterInformation.Instance.m_nCurrentSkillSlotIndex = 1;
	}


    /// <summary>
    /// [사용안함] 1, 2, 3의 숫자키를 이용하여 근거리/원거리/보조 스킬 슬롯을 교체한다.
    /// </summary>
    public void SwitchSkillSlot()
	{
		int nComboStep = -1;
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			nComboStep = cCharacterInformation.Instance.m_nMeleeSkillComboStep;
            cCharacterInformation.Instance.m_dicCurrentSkillSlot = cCharacterInformation.Instance.m_listDicMeleeSkillSlot[nComboStep];
			cCharacterInformation.Instance.m_nCurrentSkillSlotIndex = 1;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			nComboStep = cCharacterInformation.Instance.m_nRangeSkillComboStep;
            cCharacterInformation.Instance.m_dicCurrentSkillSlot = cCharacterInformation.Instance.m_listDicRangeSkillSlot[nComboStep];
			cCharacterInformation.Instance.m_nCurrentSkillSlotIndex = 2;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			nComboStep = cCharacterInformation.Instance.m_nOtherSkillComboStep;
            cCharacterInformation.Instance.m_dicCurrentSkillSlot = cCharacterInformation.Instance.m_listDicOtherSkillSlot[nComboStep];
			cCharacterInformation.Instance.m_nCurrentSkillSlotIndex = 3;
		}
	}

	/// <summary>
	/// 좌클릭 시 공격, 우클릭 시 선택된 스킬을 시전시킨다.
	/// </summary>
	public void CastSkill()
	{
        // 알고리즘 수정 필요
	}


	/// <summary>
	/// 스킬별 애니메이션을 시작시킨다.
	/// </summary>
	private void StartAnimation()
	{
		// 애니메이션 어디서 해야할지 잘 모름...
	}

	#endregion

}
