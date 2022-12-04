using System;

//어플리케이션 정보를 처리하기 위한 클래스
public class ApplicationBehaviour : ApplicationBehaviourBase
{
	[NonSerialized] public CCharacter Character = null;
	[NonSerialized] public CWeaponStatic Weapon = null;

	protected override void Awake()
	{
		base.Awake();
		Character = GetComponentInChildren(typeof(CCharacter)) as CCharacter;
		Weapon = GetComponentInChildren(typeof(CWeaponStatic)) as CWeaponStatic;
	}
}