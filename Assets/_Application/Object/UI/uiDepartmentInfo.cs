using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//-----------------------------------------------------------------------------------------------------------------------------------
// 부서 정보를 처리하기 위한 클래스
//-----------------------------------------------------------------------------------------------------------------------------------
public class uiDepartmentInfo : MonoBehaviour
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
		public Text		employee			= (null);	//직원
		public Text		employee_level		= (null);	//직원 레벨
		public Text		facilities			= (null);	//시설 레벨
		public Text		size				= (null);	//규모
		public Text		rate_operation		= (null);	//가동율

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	};
	public tagData		data		= (null);

	//-------------------------------------------------------------------------------------------------------------------------------
	// 부서 정보를 설정하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void Set( AppsParameter col )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (col)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(data.employee.text)		= col.GetInt("employee").ToString();
		(data.employee_level.text)	= col.GetInt("employee_level").ToString();
		(data.facilities.text)		= col.GetInt("facilities").ToString();
		(data.size.text)			= col.GetInt("size").ToString();
		(data.rate_operation.text)	= ((int)(col.GetFloat("rate_operation")*(100)))+"%";

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