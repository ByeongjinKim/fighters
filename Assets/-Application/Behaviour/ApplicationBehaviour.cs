using System;

//���ø����̼� ������ ó���ϱ� ���� Ŭ����
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