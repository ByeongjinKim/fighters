﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//-----------------------------------------------------------------------------------------------------------------------------------
// 점멸을 처리하기 위한 함수
//-----------------------------------------------------------------------------------------------------------------------------------
public class comUIGlow : MonoBehaviour
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
		public Image	image		= (null);

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		public float	Seed		= (0);
		public float	Speed		= (1);
		public float	Power		= (0.25f);

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
    };
    public tagData	data	= new tagData();

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
    void Awake()
    {
	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		(data.image)	= (GetComponent(typeof(Image)) as Image);

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		(data.Seed)		= Random.Range( (0f), (100f) );

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
		(Image().color)		= new Color( (Image().color.r), (Image().color.g), (Image().color.b), Mathf.Cos(Time.time*data.Speed+data.Seed)*(data.Power)+(1-data.Power) );

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
    }

	//-------------------------------------------------------------------------------------------------------------------------------
	// 이미지 객체를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public Image Image()
	{
	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return (data.image);

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