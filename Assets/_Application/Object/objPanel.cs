﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//-----------------------------------------------------------------------------------------------------------------------------------
// 패널 정보를 처리하기 위한 클래스
//-----------------------------------------------------------------------------------------------------------------------------------
public class objPanel : MonoBehaviour
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
		public Transform			transform			= (null);
		public RectTransform		rectTransform		= (null);
		public GameObject			gameObject			= (null);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		public ViewPanel			reciveComponent		= (null);
		public List<objControl>		Controls			= new List<objControl>();
		public objControl			Close				= (null);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		public objForeBack			foreback			= (null);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		public bool					allowSound			= (true);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}
	public tagData		data		= new tagData();

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	protected CApp		app			= (null);
	protected CPlay		play		= (null);

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	void Awake()
	{
        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		(this.app)		= (CApp.This);
		(this.play)		= (CPlay.This);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		(data.transform)		= (transform);
		(data.rectTransform)	= (GetComponent(typeof(RectTransform)) as RectTransform);
		(data.gameObject)		= (gameObject);
		(data.foreback)			= (GetComponent(typeof(objForeBack)) as objForeBack);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( _RectTransform()!=(null) )
		{
			(_RectTransform().anchoredPosition)		= new Vector2();
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 인터페이스를 활성화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool ON()
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
//		Func.SetAsLastSibling( Transform() );
		/*
		Vector3		position	= (Transform().position);
		Transform	parent		= (Transform().parent);
		Transform().SetParent( null );
		Transform().SetParent( parent );
		(Transform().position)	= (position);
		*/

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		app.Panel.Fore( this );

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( !(_GameObject().activeSelf) )
		{
			_GameObject().SetActive( true );
			return true;
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 인터페이스를 비활성화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void OFF()
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		_GameObject().SetActive( false );

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
	// 트랜스폼 객체를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public RectTransform _RectTransform()
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return (data.rectTransform);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 활성화 되어 있는지 확인하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool Is()
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return (_GameObject().activeInHierarchy);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}

    //-------------------------------------------------------------------------------------------------------------------------------
	// 패널 컴포넌트를 설정하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void Set( ViewPanel panel )
	{
        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		(data.reciveComponent)	= (panel);

        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 컴포넌트를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public ViewPanel ReciveComponent()
	{
        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return (data.reciveComponent);

        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 컴포넌트를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void Register( objControl control )
	{
        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( (control)==(null) ) return;

        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( !data.Controls.Contains(control) )
		{
			data.Controls.Add( control );
		}

        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	void OnDestroy()
	{
        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( (app)!=(null) && app.Panel.Is(this) )
		{
			app.Panel.Release( this );
		}

        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	public objForeBack ForeBack()
	{
        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return (data.foreback);

        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool IsForeBack()
	{
        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( ForeBack()!=(null) && ForeBack().IsActive() )
		{
			return true;
		}

        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// Depth를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public float Depth()
	{
        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( ReciveComponent()!=(null) )
		{
			return ReciveComponent().Depth();
		}

        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return (0f);
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 닫기 버튼 객체를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public objControl Close()
	{
        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return (data.Close);

        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 가로 너비를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public float Width()
	{
        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return (_RectTransform().sizeDelta.x) * (Transform().localScale.x);

        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 세로 높이를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public float Height()
	{
        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return (_RectTransform().sizeDelta.y) * (Transform().localScale.y);

        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 사운드가 허용되어 있는지 확인하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool IsAllowSound()
	{
        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return (data.allowSound);

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