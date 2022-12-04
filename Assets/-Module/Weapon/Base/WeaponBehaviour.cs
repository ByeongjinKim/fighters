//���� ������ ó���ϱ� ���� Ŭ����
public class WeaponBehaviour : TransformBehaviour
{
	private objWeaponHandle m_handle = null;

	protected override void Awake()
	{
		base.Awake();
		m_handle = GetComponentInChildren(typeof(objWeaponHandle)) as objWeaponHandle;
	}

	//�ڵ� ��ü�� ��� ���� �Լ�
	public objWeaponHandle Handle()
	{
		return m_handle;
	}
}