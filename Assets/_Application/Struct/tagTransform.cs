﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-----------------------------------------------------------------------------------------------------------------------------------
// 트랜스폼 정보를 처리하기 위한 구조체
//-----------------------------------------------------------------------------------------------------------------------------------
public class tagTransform
{
	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	public Vector3		position		= new Vector3();
	public Quaternion	rotation		= new Quaternion();
	public Vector3		scale			= new Vector3();

	//-------------------------------------------------------------------------------------------------------------------------------
	// 트랜스폼 정보를 설정하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void Set( Transform transform )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (transform)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(this.position)		= (transform.localPosition);
		(this.rotation)		= (transform.localRotation);
		(this.scale)		= (transform.localScale);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 트랜스폼 정보를 설정하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void Get( Transform transform )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (transform)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(transform.localPosition)	= (this.position);
		(transform.localRotation)	= (this.rotation);
		(transform.localScale)		= (this.scale);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 트랜스폼을 비교하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool Equals( Transform transform )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (transform)==(null) ) return false;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (this.position)!=(transform.localPosition) )
		{
			return false;
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (this.rotation)!=(transform.localRotation) )
		{
			return false;
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (this.scale)!=(transform.localScale) )
		{
			return false;
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return true;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
}

//-----------------------------------------------------------------------------------------------------------------------------------
// -
//-----------------------------------------------------------------------------------------------------------------------------------