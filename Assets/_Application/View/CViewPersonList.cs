using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

//-----------------------------------------------------------------------------------------------------------------------------------
// 인물 리스트를 처리하기 위한 클래스
//-----------------------------------------------------------------------------------------------------------------------------------
public class CViewPersonList : ViewPanel
{
	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	[System.Serializable]
	public class tagData : _tagData
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		public List<uiPerson>		Persons		= new List<uiPerson>();

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	};
	public tagData		data		= new tagData();

	//-------------------------------------------------------------------------------------------------------------------------------
	// 인터페이스를 활성화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override bool ON()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( base.ON(data) )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			ForeBack();
			Indigator( app.Language.Get(TEXT.경영인_정보를_불러오는_중입니다) );

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			ManagementHash.LoadPersonList();

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
		}
		else
		{
			ForeBack();
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return base.ON();
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 인터페이스를 비활성화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override bool OFF()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( Is(true) )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			GetList().Clear();

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			return base.OFF();
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 사업체 정보를 등록하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void Register( tagPerson person )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (person)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		uiPerson icon = (Func.Create( ScrollView().Content(), (Resources.Load(PATH.UI_PERSON_LIST_ITEM) as GameObject) ).GetComponent(typeof(uiPerson)) as uiPerson);
		if( (icon)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		icon.Set( person );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		Func.TextWidthPerfect(icon.Name());

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		GetList().Add( icon );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 리스트를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public List<uiPerson> GetList()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.Persons);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 리스트를 새로고침 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void Refresh()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		ScrollView().Init();

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		int	i = (0);
		int nPattern = (0);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (ScrollView().Content().sizeDelta.y)<ScrollView().Height() )
		{
			(nPattern)	= (GetList().Count)%(2);
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		foreach( uiPerson icon in GetList() )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			if( (i+nPattern)%(2)==(0) )
			{
				(icon.Back().color)	= Func.Color( (32), (46), (69) );
			}
			else
			{
				(icon.Back().color)	= Func.Color( (24), (34), (52) );
			}

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			(i)	++;
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 사업체 정보를 업데이트하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void update( tagCompany company )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (company)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		foreach( uiPerson person in GetList() )
		{
			if( person.Get().Company()==(company) )
			{
				//-------------------------------------------------------------------------------------------------------------------
				// -
				//-------------------------------------------------------------------------------------------------------------------
				if( person.Company()!=(null) )
				{
					person.Company().Set( company );
				}

				//-------------------------------------------------------------------------------------------------------------------
				// -
				//-------------------------------------------------------------------------------------------------------------------
				break;
			}
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 취소 입력에 반응하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override bool ONCANCEL( CANCEL Cancel )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( Is() )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			GetList().Clear();

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			return base.ONCANCEL( Cancel );
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 인터페이스를 활성화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override bool ONCONTROL( objControl control, CONTROL_ACTION Action, tagFocus focus )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (control)==(null) ) return false;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		foreach( uiPerson icon in GetList() )
		{
			if( (control)==icon.Control() && (Action)==(CONTROL_ACTION.SELECT) )
			{
				app.ViewPerson.ON( icon.Get() );
				return true;
			}
			else
			if( icon.Company()!=(null) && (control)==icon.Company().Control() && (Action)==(CONTROL_ACTION.SELECT) )
			{
				app.ViewCompany.ON( icon.Company().Get() as tagCompany );
				return true;
			}
			else
			if( icon.Nation()!=(null) && (control)==icon.Nation().Control() && (Action)==(CONTROL_ACTION.SELECT) )
			{
				app.ViewNation.ON( icon.Nation().Get() as tagNationStatic );
				return true;
			}
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 메모리를 초기화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override void Unloader()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 인터페이스를 불러오기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override void Loader()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		base.Loader( Resources.Load("ApplicationLoader/View/ViewGenericList"), (play.uiCanvas) );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		Text subject = (Func.Get( _Transform(), "Subject" ).GetComponentInChildren(typeof(Text)) as Text);
		if( (subject)!=(null) )
		{
			(subject.text)	= app.Language.Get(TEXT.경영인);
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