using UnityEngine;

public class CCharacter : FrameworkBehaviour
{
	//캐릭터를 생성하기 위한 함수
	public void Create( tagModel model )
	{
		if( model==null ) return;
		model.Download(funcCreate);
	}

	//캐릭터를 생성하기 위한 함수
	void funcCreate( object wParam=null, object lParam=null )
	{
		if( lParam==null || lParam.GetType()!=typeof(tagModel) ) return;

		tagModel model = lParam as tagModel;
		if( model!=null && model.AssetBundle().IsLoad() )
		{
			Transform transform = Library.Create( model.GetMainAsset() );
			GameObject gameObject = transform.gameObject;

			transform.localEulerAngles = new Vector3( 0f, 90f, 0f );

			AssetLoader.ON( transform, gameObject );

			CharacterBehaviour characterbehaviour = gameObject.AddComponent(typeof(CharacterBehaviour)) as CharacterBehaviour;
			if( characterbehaviour!=null )
			{
				tagMotion motion = app.Motion.Find(ANIMATION.라이플);
				if( motion!=null )
				{
					motion.Download(characterbehaviour.funcAnimation);
				}
			}
		}
	}
}