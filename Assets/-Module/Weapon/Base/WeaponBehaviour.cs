//무기 정보를 처리하기 위한 클래스
public class WeaponBehaviour : TransformBehaviour
{
	private objWeaponHandle m_handle = null;

	protected override void Awake()
	{
		base.Awake();
		m_handle = GetComponentInChildren(typeof(objWeaponHandle)) as objWeaponHandle;
	}

	//핸들 객체를 얻기 위한 함수
	public objWeaponHandle Handle()
	{
		return m_handle;
	}
}