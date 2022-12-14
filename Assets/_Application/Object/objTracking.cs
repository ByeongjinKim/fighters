using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-----------------------------------------------------------------------------------------------------------------------------------
// -
//-----------------------------------------------------------------------------------------------------------------------------------
public class objTracking : MonoBehaviour
{
	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	[System.Serializable]
	public class tagData
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		public Transform	transform		= (null);
		public GameObject	gameObject		= (null);
		public Transform	target			= (null);
		public objMove		move			= (null);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		public bool			LookAt			= (false);
		public Vector3		vAdded			= new Vector3();

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}
	public tagData	data	= new tagData();

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	void Awake()
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		(data.transform)	= (transform);
		(data.gameObject)	= (gameObject);
		(data.move)			= (GetComponent(typeof(objMove)) as objMove);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		Enable( false );

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	void Update()
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( Target()!=(null) && (Transform().position)!=(Target().position)+(data.vAdded) )
		{
			UpdateCommit();
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 타깃을 설정하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void ON( Transform target )
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
//		if( (target)==(null) ) return;		//(NULL)값을 허용함

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		(data.target)	= (target);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( Target()!=(null) )
		{
			//-----------------------------------------------------------------------------------------------------------------------
		    // -
	        //-----------------------------------------------------------------------------------------------------------------------
			UpdateCommit();

			//-----------------------------------------------------------------------------------------------------------------------
		    // -
	        //-----------------------------------------------------------------------------------------------------------------------
			Enable( true );

			//-----------------------------------------------------------------------------------------------------------------------
		    // -
	        //-----------------------------------------------------------------------------------------------------------------------
		}
		else
		{
			Enable( false );
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 활성화를 설정하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	void Enable( bool value )
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( (enabled)!=(value) )
		{
			(enabled)	= (value);
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	void UpdateCommit()
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( Move()!=(null) )
		{
			Move().ON( (Target().position) + (data.vAdded) );
		}
		else
		{
			(Transform().position)	= (Target().position) + (data.vAdded);
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (data.LookAt) && (Transform().position)!=(Target().position) )
		{
			Transform().LookAt( (Target().position), (Transform().up) );
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 트랜스폼 객체를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public Transform Transform()
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return (data.transform);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 게임 오브젝트를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public GameObject _GameObject()
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return (data.gameObject);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 타깃 객체를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public Transform Target()
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return (data.target);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 이동 객체를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public objMove Move()
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return (data.move);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 활성화되어 있는지 확인하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool IsActive()
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return (isActiveAndEnabled);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
}

//-----------------------------------------------------------------------------------------------------------------------------------
// -
//-----------------------------------------------------------------------------------------------------------------------------------