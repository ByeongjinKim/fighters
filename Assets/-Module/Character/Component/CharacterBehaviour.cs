using UnityEngine;

public class CharacterBehaviour : HumanoidBehaviour
{
	private AnimatorBehaviour m_animator = null;
	private GunBehaviour m_rifle = null;

	protected override void Awake()
	{
		base.Awake();
		m_animator = GetComponentInChildren(typeof(AnimatorBehaviour)) as AnimatorBehaviour;
		if( m_animator==null )
		{
			Animator animator = GetComponentInChildren(typeof(Animator)) as Animator;
			if( animator!=null )
			{
				m_animator = _GameObject().AddComponent(typeof(AnimatorBehaviour)) as AnimatorBehaviour;
			}
		}
	}

	void Start()
	{
		tagWeaponStatic weapon = ApplicationBehaviour.This.Weapon.Find(WEAPON.������);
		if( weapon!=null )
		{
			weapon.Download( funcWeapon );
		}
	}

	void Update()
	{
		if( Rifle()!=null )
		{
			Rifle().Fire();
		}
	}

	//�ִϸ��̼��� ����ϱ� ���� �Լ�
	public void funcAnimation( object wParam=null, object lParam=null )
	{
		if( lParam==null || lParam.GetType()!=typeof(tagMotion) ) return;

		tagMotion motion = lParam as tagMotion;
		if( motion!=null && motion.AssetBundle().IsLoad() )
		{
			Object[] objArray = motion.AssetBundle().bundle.LoadAllAssets(typeof(RuntimeAnimatorController));
			foreach( RuntimeAnimatorController animatorcontroller in objArray )
			{
				Animator().Set( animatorcontroller );
				break;
			}			
		}
	}

	//���⸦ ó���ϱ� ���� �Լ�
	void funcWeapon( object wParam=null, object lParam=null )
	{
		if( lParam==null || lParam.GetType()!=typeof(tagWeaponStatic) ) return;

		tagWeaponStatic weapon = lParam as tagWeaponStatic;
		if( weapon!=null && weapon.AssetBundle().IsLoad() )
		{
			Transform transform = Library.Create( HandRight().Transform(), weapon.GetMainAsset() );
			if( transform!=null )
			{
				GameObject gameObject = transform.gameObject;
				AssetLoader.ON( transform, gameObject );
				
				m_rifle = gameObject.GetComponent(typeof(WeaponBehaviour)) as GunBehaviour;
				if( m_rifle==null )
				{
					m_rifle = gameObject.AddComponent(typeof(WeaponBehaviour)) as GunBehaviour;
				}

				if( m_rifle!=null && m_rifle.Handle()!=null )
				{
					transform.localPosition = m_rifle.Transform().position-HandRight().Transform().position;
				}
			}
		}
	}

	//�ִϸ����� ��ü�� ��� ���� �Լ�
	AnimatorBehaviour Animator()
	{
		return m_animator;
	}

	//���� ��ü�� ��� ���� �Լ�
	GunBehaviour Rifle()
	{
		return m_rifle;
	}
}