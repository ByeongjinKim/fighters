using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//-----------------------------------------------------------------------------------------------------------------------------------
// 국가 정보를 처리하기 위한 클래스
//-----------------------------------------------------------------------------------------------------------------------------------
public class CViewNation : ViewPanel
{
	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	public const float		CityIconWidth		= (280);

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	[System.Serializable]
	public class tagData : _tagData
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		public tagNationStatic		nationstatic	= (null);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		public uiIcon				nation			= (null);
		public RectTransform		주요_도시			= (null);
		public Text					통화				= (null);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		public List<uiCity>			Cities			= new List<uiCity>();

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	};
	public tagData		data		= new tagData();

	//-------------------------------------------------------------------------------------------------------------------------------
	// 인터페이스를 활성화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool ON( tagNationStatic nationstatic )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( !Apps.Is(nationstatic) ) return false;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		bool isChange = Get()!=(nationstatic) || !Is(true);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(data.nationstatic)	= (nationstatic);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( base.ON(data) )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
//			ForeBack();

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
//			app.Canvas.FullscreenScrollViewInit( ScrollView()._RectTransform() );

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			LoadCities();

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( isChange )
		{
			Fullscreen( new historyNation(nationstatic) );
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		Nation().Set(Get());
//		(Nation().Image().uvRect)	= new Rect( (1-0.5f)/(2), (1-0.5f)/(2), (0.5f), (0.5f) );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
//		(data.통화.text)	= app.Language.Get(nationstatic.Currency().Name())+" (환율: "+app.Cash.ExchangeToString( (nationstatic.Currency().value), (play.dallor) )+")";

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return base.ON();
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 네비게이션을 처리하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override void ONNAVIGATION()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		app.ViewNavigation.ON( (this), app.Language.Get(Get().Name()) );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
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
			(data.nation)	= (null);

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			Cities().Clear();

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
	// 주요 도시를 불러오기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	void LoadCities()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		int					Count	= tagSystem.GetScreenWidth() / (280);
		List<tagCityStatic>	Cities	= new List<tagCityStatic>();

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		foreach( tagCityStatic citystatic in app.CityStatic.GetList() )
		{
			if( citystatic.Nation()==Get() )
			{
				Cities.Add(citystatic);
			}
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// 정렬 : 인구순
		//---------------------------------------------------------------------------------------------------------------------------
		SortCities( Cities );

		//---------------------------------------------------------------------------------------------------------------------------
		// 초과된 도시를 삭제함
		//---------------------------------------------------------------------------------------------------------------------------
		while( (Cities.Count)>(Count) )
		{
			Cities.RemoveAt(Cities.Count-1);
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// 커버 텍스쳐를 불러옴
		//---------------------------------------------------------------------------------------------------------------------------
		foreach( tagCityStatic citystatic in Cities )
		{
			app.CityStatic.CorverTextureDownload(citystatic);
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// 함수를 예약함
		//---------------------------------------------------------------------------------------------------------------------------
		app.Download.SetCallback( (funcCitiesInitialize), (Cities) );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 주요 도시를 불러오기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	void SortCities( List<tagCityStatic> Cities )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (Cities)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		tagCityStatic	temp	= (null);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		for( int i=0; i<(Cities.Count-1); i++ )
		{
			for( int j=(i+1); j<(Cities.Count); j++ )
			{
				if( (Cities[i].population)<(Cities[j].population) )
				{
					(temp)		= (Cities[i]);
					(Cities[i])	= (Cities[j]);
					(Cities[j]) = (temp);
				}
			}
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 주요 도시를 불러오기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	void funcCitiesInitialize( object wParam=(null), object lParam=(null) )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (wParam)==(null) || wParam.GetType()!=typeof(List<tagCityStatic>) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		List<tagCityStatic>	Cities	= (wParam as List<tagCityStatic>);

		//---------------------------------------------------------------------------------------------------------------------------
		// 커버 텍스쳐를 불러옴
		//---------------------------------------------------------------------------------------------------------------------------
		foreach( tagCityStatic citystatic in Cities )
		{
			Register( (citystatic), (Cities.Count) );
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(data.주요_도시.localPosition)	= new Vector3( -(CityIconWidth)*(Cities.Count-1)/(2)-(CityIconWidth/2)+(20), (data.주요_도시.localPosition.y), (data.주요_도시.localPosition.z) );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 주요 도시를 불러오기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	void Register( tagCityStatic citystatic, int nEnd )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (citystatic)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		uiCity icon = (Func.Create( _Transform(), (Resources.Load(PATH.UI_CITY_ICON) as GameObject) ).GetComponent(typeof(uiCity)) as uiCity);
		if( (icon)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(icon.Transform().localPosition)	= new Vector3( (CityIconWidth)*(Cities().Count)-(CityIconWidth)*(nEnd-1)/(2), (-440), (0) );
		(icon.Transform().localEulerAngles)	= new Vector3();
		(icon.Transform().localScale)		= new Vector3( (1), (1), (1) );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		icon.Set( citystatic );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		Cities().Add( icon );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 도시 리스트를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public List<uiCity> Cities()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.Cities);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 도시 정보를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public tagNationStatic Get()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.nationstatic);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 국가 객체를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public uiIcon Nation()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.nation);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 인터페이스를 활성화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override void OnHistory( tagHistory _history )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (_history)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		historyNation history = (_history as historyNation);
		if( (history)!=(null) )
		{
			ON( history.nation );
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
		foreach( uiCity city in Cities() )
		{
			if( (control)==city.Control() && (Action)==(CONTROL_ACTION.SELECT) )
			{
				app.ViewCity.ON( city.Get() );
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
		(data.nation)	= (null);
		(data.주요_도시)	= (null);
		(data.통화)		= (null);

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
		base.Loader( Resources.Load("ApplicationLoader/View/ViewNation"), (play.uiCanvas) );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(data.nation)	= (Func.Get( _Transform(), "Left-Top/Nation" ).GetComponent(typeof(uiIcon)) as uiIcon);
		(data.주요_도시)	= (Func.Get( _Transform(), "주요 도시" ) as RectTransform);
		(data.통화)		= (Func.Get( _Transform(), "Left-Top/통화/Value" ).GetComponent(typeof(Text)) as Text);

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