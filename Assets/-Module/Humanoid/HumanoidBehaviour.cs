public class HumanoidBehaviour : TransformBehaviour
{
	private objHandRight m_handRight = null;

	protected override void Awake()
	{
		base.Awake();
		m_handRight = GetComponentInChildren(typeof(objHandRight)) as objHandRight;
	}

	//오른손 객체를 얻기 위한 함수
	public objHandRight HandRight()
	{
		return m_handRight;
	}
}