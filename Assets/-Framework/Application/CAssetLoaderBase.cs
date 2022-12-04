using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class CAssetLoaderBase : FrameworkBehaviour
{
	public virtual void ON( Transform transform, GameObject gameObject )
	{
		if( transform==null ) return;
//		if( gameObject==null ) return;	//(NULL)값을 허용함

		if( gameObject==null )
		{
			gameObject = transform.gameObject;
		}

		Component[] comArray = null;

		/*
		MaterialPlatform mtrlPlatform = null;
		comArray = transform.GetComponentsInChildren(typeof(Renderer));
		foreach( Renderer renderer in comArray )
		{
			mtrlPlatform = renderer.GetComponent(typeof(MaterialPlatform)) as MaterialPlatform;
			if( mtrlPlatform!=null && Application.isMobilePlatform && !Application.isEditor && mtrlPlatform.Mobile.Count>(0) )
			{
				MaterialChange( (renderer), (mtrlPlatform.Mobile) );
			}
			else
			{
				Func.MaterialSetup( renderer );
			}

			Component.Destroy( mtrlPlatform );
		}
		*/

		comArray = transform.GetComponentsInChildren(typeof(AssetComponent));
		foreach( AssetComponent asset in comArray )
		{
			AssetComponent( asset, transform );
			Component.Destroy( asset );
		}

		/*
		comArray = transform.GetComponentsInChildren(typeof(Light));
		foreach( Light light in comArray )
		{
			if( light.type!=LightType.Directional && Application.isMobilePlatform && !Application.isEditor )
			{
				Component.Destroy( light );
			}
		}
		*/
	}

	public void AssetComponent( AssetComponent asset, Transform root )
	{
		if( asset==null ) return;
		if( root==null ) return;

		Transform	transform	= asset.transform;
		GameObject	gameObject	= asset.gameObject;

		if( asset.xml==null )
		{
			if( !AssetComponent( asset, null, (XmlNode)null, transform, gameObject ) )
			{
#if UNITY_EDITOR
				Debug.Log( "정의되지 않은 Asset Component : "+asset.value, transform );
#endif
			}
		}
		else
		if( !AssetComponent( asset, asset.xml.name, null, transform, gameObject ) )
		{
			XmlDocument xmlDoc = CXml.Load(asset.xml);
			if( xmlDoc==null ) return;

			XmlNodeList nodeList = xmlDoc.ChildNodes;
			XmlNode pNode = null;
			for( int i=0; i<nodeList.Count; i++ )
			{
				pNode = nodeList.Item(i);
				if( !AssetComponent( asset, pNode.Name, pNode, transform, gameObject ) )
				{
#if UNITY_EDITOR
					if( pNode!=null && pNode.Name!="xml" )
					{
						Debug.Log( "정의되지 않은 Asset Component : "+pNode.Name, transform );
					}
#endif
				}
			}
		}
	}

	protected virtual bool AssetComponent( AssetComponent asset, string name, XmlNode pNode, Transform transform, GameObject gameObject )
	{
		if( asset==null ) return false;
		if( !Library.Is(name) ) return false;
//		if( pNode==null ) return false;			//(NULL)값을 허용함
		if( transform==null ) return false;
		if( gameObject==null ) return false;

		if( IsAssetComponent( asset, name, pNode, "RenderQueue" ) )
		{
			if( Library.IsNumber(asset.value) )
			{
				Renderer renderer = gameObject.GetComponent(typeof(Renderer)) as Renderer;
				if( renderer!=null )
				{
					foreach( Material mtrl in renderer.materials )
					{
						mtrl.renderQueue = int.Parse(asset.value);
					}
				}
			}

			return true;
		}
		else
		if( IsAssetComponent( asset, name, pNode, "Destroy" ) )
		{
			objDestroy destroy = gameObject.AddComponent(typeof(objDestroy)) as objDestroy;
			if( destroy!=null )
			{
				if( Library.IsSingle(asset.value) )
				{
					destroy.time = float.Parse(asset.value);

					if( destroy.time<=0f )
					{
						GameObject.Destroy( gameObject );
					}
				}
			}

			return true;
		}

		return false;
	}

	protected bool IsAssetComponent( AssetComponent asset, string name, XmlNode pNode, string id )
	{
		if( asset==null ) return false;
		if( !Library.Is(name) ) return false;
//		if( pNode==null ) return false;		//(NULL)값을 허용함
		if( !Library.Is(id) ) return false;

		if( ( name==id ) || ( pNode!=null && pNode.Name==id ) || ( pNode==null && asset.value==id ) )
		{
			return true;
		}

		return false;
	}

    //매트리얼을 교체하기 위한 함수
	void MaterialChange( Renderer renderer, List<Material> Materials )
	{
		if( renderer==null ) return;
		if( Materials==null ) return;

		int End = renderer.materials.Length;
		for( int i=0; i<End; i++ )
		{
			if( i<Materials.Count )
			{
				renderer.materials[i].CopyPropertiesFromMaterial(Materials[i]);

				if( Materials[i].shader!=null && Library.Is(Materials[i].shader.name) )
				{
					renderer.materials[i].shader = Shader.Find(Materials[i].shader.name);
				}
			}
			else
			{
				renderer.materials[i].shader = Shader.Find(renderer.materials[i].shader.name);
			}
		}
	}
}
