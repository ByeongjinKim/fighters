using UnityEngine;

//총기 정보를 처리하기 위한 클래스
public class GunBehaviour : WeaponBehaviour
{
	private objWeaponMuzzle m_muzzle = null;
	public float fire_time = 0f;

	protected override void Awake()
	{
		base.Awake();
	}

	void Start()
	{
		m_muzzle = GetComponentInChildren(typeof(objWeaponMuzzle)) as objWeaponMuzzle;

		if( Muzzle()!=null )
		{
			tagEffectStatic effefctstatic = ApplicationBehaviour.This.EffectStatic.Find("dd29b300657a2462bge5");
			if( effefctstatic!=null )
			{
				effefctstatic.Download(funcEffect);
			}
		}
	}

	//총구 객체를 얻기 위한 함수
	public objWeaponMuzzle Muzzle()
	{
		return m_muzzle;
	}

	//이펙트를 생성하기 위한 함수
	void funcEffect( object wParam=null, object lParam=null )
	{
		if( lParam==null || lParam.GetType()!=typeof(tagEffectStatic) ) return;

		tagEffectStatic effectstatic = lParam as tagEffectStatic;
		if( effectstatic!=null )
		{
			Transform transform = Library.Create( Muzzle().Transform(), effectstatic.GetMainAsset() );
			if( transform!=null )
			{
				Component[] comArray = transform.GetComponentsInChildren(typeof(ParticleSystem));
				foreach( ParticleSystem particle in comArray )
				{
					Muzzle().Register(particle);
				}
			}
		}
	}

	//발포를 처리하기 위한 함수
	public void Fire()
	{
		if( Muzzle()!=null && Time.time-fire_time>=0.1f )
		{
			Muzzle().Fire();
			fire_time = Time.time;
		}
	}
}