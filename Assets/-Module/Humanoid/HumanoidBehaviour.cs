public class HumanoidBehaviour : TransformBehaviour
{
	private objHandRight m_handRight = null;

	protected override void Awake()
	{
		base.Awake();
		m_handRight = GetComponentInChildren(typeof(objHandRight)) as objHandRight;
	}

	//������ ��ü�� ��� ���� �Լ�
	public objHandRight HandRight()
	{
		return m_handRight;
	}
}