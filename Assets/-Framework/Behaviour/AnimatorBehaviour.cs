using UnityEngine;

public class AnimatorBehaviour : MonoBehaviour
{
	private Animator m_animator = null;

	void Awake()
	{
		m_animator = GetComponentInChildren(typeof(Animator)) as Animator;
	}

	//�ִϸ����͸� �����ϱ� ���� �Լ�
	public void Set( RuntimeAnimatorController animatorcontroller )
	{
//		if( animatorcontroller==null ) return;	//(NULL)���� �����
	
		Animator().runtimeAnimatorController = animatorcontroller;
	}

	//�ִϸ����� ��ü�� ��� ���� �Լ�
	Animator Animator()
	{
		return m_animator;
	}
}