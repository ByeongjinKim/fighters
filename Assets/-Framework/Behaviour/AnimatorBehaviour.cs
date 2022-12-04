using UnityEngine;

public class AnimatorBehaviour : MonoBehaviour
{
	private Animator m_animator = null;

	void Awake()
	{
		m_animator = GetComponentInChildren(typeof(Animator)) as Animator;
	}

	//애니메이터를 설정하기 위한 함수
	public void Set( RuntimeAnimatorController animatorcontroller )
	{
//		if( animatorcontroller==null ) return;	//(NULL)값을 허용함
	
		Animator().runtimeAnimatorController = animatorcontroller;
	}

	//애니메이터 객체를 얻기 위한 함수
	Animator Animator()
	{
		return m_animator;
	}
}