using System;

//어플리케이션 정보를 처리하기 위한 클래스
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