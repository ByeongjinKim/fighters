﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-----------------------------------------------------------------------------------------------------------------------------------
// -
//-----------------------------------------------------------------------------------------------------------------------------------
public class objAngle : MonoBehaviour
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
		public Transform		transform		= (null);
		public objLerp			lerp			= (null);
		public objMove			move			= (null);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		public Quaternion		qAngle			= new Quaternion();
		public Vector3			vAngle			= new Vector3();
		public Quaternion		qStart			= new Quaternion();
		public float			Divide			= (10);
		public float			Lerp			= (0);
		public bool				SyncLerp		= (false);
		public bool				Destroy			= (false);

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
		(data.lerp)			= (GetComponent(typeof(objLerp)) as objLerp);
		(data.move)			= (GetComponent(typeof(objMove)) as objMove);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		(enabled)	= (false);

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
		if( Lerp()!=(null) && Lerp().IsAction() )
		{
			(data.Lerp)		= Lerp().Value();
		}
		else
		if( (data.SyncLerp) && Move()!=(null) && Move().IsAction() )
		{
			(data.Lerp)		= Move().GetLerpValue();
		}
		else
		if( !float.IsNaN(data.Lerp) )
		{
			(data.Lerp)		+= (1/data.Divide) * Func.DeltaTime();
		}
		else
		{
			(enabled)		= (false);
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( (data.qStart)!=(data.qAngle) && !float.IsNaN(data.Lerp) )
		{
			(Transform().localRotation)		= Quaternion.Lerp( (data.qStart), (data.qAngle), (data.Lerp) );
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( (data.Lerp)>=(1) )
		{
			(enabled)	= (false);
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 이동을 설정하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void ON( Vector3 vAngle, bool SyncLerp=(true) )
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( (Transform().localRotation)==Quaternion.Euler(vAngle) ) return;

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		(data.qAngle)		= Quaternion.Euler(vAngle);
		(data.vAngle)		= (vAngle);
		(data.qStart)		= (Transform().localRotation);
		(data.Lerp)			= (0);
		(data.SyncLerp)		= (SyncLerp);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		(enabled)		= (true);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 비활성화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void OFF()
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		(data.SyncLerp)		= (false);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		(enabled)	= (false);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( data.Destroy )
		{
			Component.Destroy( this );
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
	// 활성화되어 있는지 확인하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool IsAction()
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
	// LERP 객체를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public objLerp Lerp()
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return (data.lerp);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 트랜스폼 객체를 얻기 위한 함수
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
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
}

//-----------------------------------------------------------------------------------------------------------------------------------
// -
//-----------------------------------------------------------------------------------------------------------------------------------