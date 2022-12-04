using System.Collections.Generic;
using UnityEngine;

//-----------------------------------------------------------------------------------------------------------------------------------
// Home 인터페이스를 처리하기 위한 클래스
//-----------------------------------------------------------------------------------------------------------------------------------
public class CViewDashboardBusiness : ViewPanel
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
		public List<uiBusiness>		Businesses		= new List<uiBusiness>();

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		public objControl			build			= (null);
		public objControl			foundation		= (null);

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
//			ForeBack();
//			Indigator( app.Language.Get(TEXT.기업_정보를_불러오는_중입니다) );

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			app.Canvas.FullscreenScrollViewInit( ScrollView()._RectTransform(), (0), (true), (0), (true) );

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			Reload();

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( app.ViewWorldMap.IsActive() )
		{
			app.ViewWorldMap.Inactive();
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return base.ON();
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 인터페이스가 전면에 출력되었을 때 반응하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override void ONFORE()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		app.ViewBottom.Fore();
		app.ViewTop.Fore();

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
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
	void Register( tagBusiness business )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (business)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		uiBusiness icon = Find(business);
		if( (icon)!=(null) )
		{
			return;
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		GameObject		sample_gameobject	= (Resources.Load((PATH.UI)+"/DashboardBusinessListItem") as GameObject);
		RectTransform	sample_transform	= (sample_gameobject.transform as RectTransform);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(icon)	= (Func.Create( ScrollView().Content(), (sample_gameobject) ).GetComponent(typeof(uiBusiness)) as uiBusiness);
		if( (icon)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
//		(icon.Transform().sizeDelta)	= new Vector2( tagSystem.GetScreenWidth()/(3), tagSystem.GetScreenWidth()/(3) );
		(icon.Transform().localScale)	= new Vector3( Func.Divide( tagSystem.GetScreenWidth()/(3), (sample_transform.sizeDelta.x) ), Func.Divide( tagSystem.GetScreenWidth()/(3), (sample_transform.sizeDelta.y) ), (icon.Transform().localScale.z) );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		icon.Set( business );
		icon.Company().Set(business.Company());
		icon.Graph().Set( (IDENTITY.BUSINESS), (business.id), (GRAPH.순이익) );
		icon.Graph().Initialize( business.GraphValues );

		//---------------------------------------------------------------------------------------------------------------------------
		// 상품
		//---------------------------------------------------------------------------------------------------------------------------
		if( Apps.Is(business.product) && icon.Product()!=(null) && business.Type()!=(UPDATE_TYPE.Market) )
		{
			Func.Active(icon.Product()._GameObject());
			icon.Product().Set(business.product);
			icon.Product().SetID( business.product_id );
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		GetList().Add( icon );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (data.foundation)!=(null) )
		{
			Func.Destroy(data.foundation);
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 리스트를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public List<uiBusiness> GetList()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.Businesses);

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
		if( (data.foundation)!=(null) && app.Company.Is(app.Player.Company()) )
		{
			Func.Destroy(data.foundation);
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (GetList().Count)<=(0) && !app.Company.Is(app.Player.Company()) )
		{
			if( (data.foundation)==(null) )
			{
				CreateFoundation();
			}
		}
		else
		if( (data.build)==(null) )
		{
			CreateBuild();
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (data.build)!=(null) )
		{
			data.build._RectTransform().SetAsLastSibling();
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		ScrollView().Init();

		/*
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
		(nPattern)	= (1) - (nPattern);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		foreach( objControl icon in GetList() )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			if( (i+nPattern)%(2)==(0) )
			{
				(icon.Image().color)	= Func.Color( (32), (46), (69) );
			}
			else
			{
				(icon.Image().color)	= Func.Color( (24), (34), (52) );
			}

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			(i)	++;
		}
		*/

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 사업체 정보를 불러오기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void Reload()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( app.Identity.IsCompany() )
		{
			foreach( tagBusiness business in app.Business.GetList() )
			{
				if( app.Company.IsRight(business.Company()) )
				{
					Register(business);
				}
			}
		}
		else
		{
			foreach( tagBusiness business in app.Business.GetList() )
			{
				if( app.Business.IsRight(business) )
				{
					Register(business);
				}
			}
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		Refresh();

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 사업체 정보를 등록하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	uiBusiness Find( tagBusiness business )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (business)==(null) ) return (null);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		foreach( uiBusiness icon in GetList() )
		{
			if( icon.Get()==(business) )
			{
				return (icon);
			}
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (null);
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 사업체 정보를 초기화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void Release( tagBusiness business, bool allowRefresh=(true) )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (business)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		foreach( uiBusiness icon in GetList() )
		{
			if( icon.Get()==(business) )
			{
				Release( icon );
				break;
			}
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 사업체 정보를 초기화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void Release( uiBusiness icon, bool allowRefresh=(true) )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (icon)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		Func.Destroy( icon );
		GetList().Remove( icon );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( allowRefresh )
		{
			Refresh();
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 사업체 정보를 등록하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	void CreateBuild()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (data.build)!=(null) )
		{
			return;
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		GameObject		sample_gameobject	= (Resources.Load((PATH.UI)+"/DashboardBuildListItem") as GameObject);
		RectTransform	sample_transform	= (sample_gameobject.transform as RectTransform);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(data.build)	= (Func.Create( ScrollView().Content(), (sample_gameobject) ).GetComponent(typeof(objControl)) as objControl);
		if( (data.build)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
//		(transform.sizeDelta)	= new Vector2( tagSystem.GetScreenWidth()/(3), tagSystem.GetScreenWidth()/(3) );
		(data.build.Transform().localScale)	= new Vector3( Func.Divide( tagSystem.GetScreenWidth()/(3), (sample_transform.sizeDelta.x) ), Func.Divide( tagSystem.GetScreenWidth()/(3), (sample_transform.sizeDelta.y) ), (transform.localScale.z) );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	void CreateFoundation()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (data.foundation)!=(null) )
		{
			return;
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		GameObject		sample_gameobject	= (Resources.Load((PATH.UI)+"/DashboardFoundationListItem") as GameObject);
		RectTransform	sample_transform	= (sample_gameobject.transform as RectTransform);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(data.foundation)	= (Func.Create( ScrollView().Content(), (sample_gameobject) ).GetComponent(typeof(objControl)) as objControl);
		if( (data.foundation)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(data.foundation._RectTransform().sizeDelta)	= new Vector2( tagSystem.GetScreenWidth(), (data.foundation._RectTransform().sizeDelta.y) );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 사업체 정보를 초기화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void Clear()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		while( (GetList().Count)>(0) )
		{
			Release( (GetList()[0]), (false) );
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 인터페이스를 비활성화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override bool Active()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		CApp.This.ViewTop.data.business.Toggle().Active();
		CApp.This.ViewTop.data.world.Toggle().Inactive();

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return base.Active();
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 취소 입력에 반응하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override bool ONCANCEL( CANCEL Cancel )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return false;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
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
		foreach( uiBusiness icon in GetList() )
		{
			if( (control)==icon.Company().Control() && (Action)==(CONTROL_ACTION.SELECT) )
			{
				app.ViewCompany.ON( icon.Company().Get() );
				return true;
			}
			else
			if( (control)==icon.City().Control() && (Action)==(CONTROL_ACTION.SELECT) )
			{
				app.ViewCity.ON( icon.City().Get() );
				return true;
			}
			else
			if( (control)==icon.City().Nation().Control() && (Action)==(CONTROL_ACTION.SELECT) )
			{
				app.ViewNation.ON( icon.City().Nation().Get() as tagNationStatic );
				return true;
			}
			else
			if( (control)==icon.Product().Control() && (Action)==(CONTROL_ACTION.SELECT) )
			{
				app.ViewProduct.ON( icon.Product().Get(), icon.Product().ID() );
				return true;
			}
			else
			if( (control)==icon.Graph().Control() && (Action)==(CONTROL_ACTION.SELECT) )
			{
				app.ViewBusiness.ON( icon.Get() );
				return true;
			}
			else
			if( (control)==icon.Control() && (Action)==(CONTROL_ACTION.SELECT) )
			{
				app.ViewBusiness.ON( icon.Get() );
				return true;
			}
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// 건설 (BUILD)
		//---------------------------------------------------------------------------------------------------------------------------
		if( (control)==(data.build) && (Action)==(CONTROL_ACTION.SELECT) )
		{
			app.Business.funcBuild();
			return true;
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// 창업 (FOUNDATION)
		//---------------------------------------------------------------------------------------------------------------------------
		if( (control)==(data.foundation) && (Action)==(CONTROL_ACTION.SELECT) )
		{
			app.Confirm.ON( app.Language.Get(TEXT.아직_기업이_없습니다_지금_창업하시겠습니까), (CONFIRM.YESNO), (app.Company.funcFoundation) );
			return true;
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
		base.Loader( Resources.Load("ApplicationLoader/View/ViewDashboardBusiness"), (play.uiCanvas) );

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