using System;

//���ø����̼� ������ ó���ϱ� ���� Ŭ����
public class ApplicationBehaviourBase : CApp
{
	[NonSerialized] public CAssetLoader AssetLoader = null;

	[NonSerialized] public CEffectStatic EffectStatic = null;
	[NonSerialized] public CModel Model = null;
	[NonSerialized] public CMotion Motion = null;

	protected override void Awake()
	{
		base.Awake();

		AssetLoader = GetComponentInChildren(typeof(CAssetLoader)) as CAssetLoader;

		EffectStatic = GetComponentInChildren(typeof(CEffectStatic)) as CEffectStatic;
		Model = GetComponentInChildren(typeof(CModel)) as CModel;
		Motion = GetComponentInChildren(typeof(CMotion)) as CMotion;
	}
}