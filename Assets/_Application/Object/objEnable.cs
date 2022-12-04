﻿using UnityEngine;
using System.Collections;

//-----------------------------------------------------------------------------------------------------------------------------------
// 오브젝트의 활성화를 설정하기 위한 클래스
//-----------------------------------------------------------------------------------------------------------------------------------
public class objEnable : MonoBehaviour
{
	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	public ENABLE_N		OnStart		= (ENABLE_N.NOTHING);
	public bool			Enabled		= (false);

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	void Awake()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (this.OnStart)==(ENABLE_N.AWAKE) || (this.OnStart)==(ENABLE_N.NOTHING) )
		{
			(this.OnStart)	= (ENABLE_N.END);
			gameObject.SetActive( this.Enabled );
			Component.Destroy( this );
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	void Start()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (this.OnStart)==(ENABLE_N.START) )
		{
			(this.OnStart)	= (ENABLE_N.END);
			gameObject.SetActive( this.Enabled );
			Component.Destroy( this );
		}

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