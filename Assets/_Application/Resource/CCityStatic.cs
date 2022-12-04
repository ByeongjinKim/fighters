using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

//-----------------------------------------------------------------------------------------------------------------------------------
// 도시 정보를 처리하기 위한 클래스
//-----------------------------------------------------------------------------------------------------------------------------------
public class CCityStatic : AppsItemListener
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
		public List<tagCityStatic>	Citys	= new List<tagCityStatic>();

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
    };
    public tagData		data		= new tagData();

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	protected virtual void Awake()
	{
	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		Initialize( (data), "City", UPDATE_CLASS.City.ToString(), (null) );

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
	}

	/*
	//-------------------------------------------------------------------------------------------------------------------------------
    // 도시 정보를 설정하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override void Initialize()
	{
	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		foreach( tagCityStatic citystatic in GetList() )
		{
			if( (citystatic.nation)!=(null) && citystatic.nation.GetType()==typeof(string) )
			{
				(citystatic.nation)	= app.NationStatic.Find(citystatic.nation as string);
			}
		}

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
	}
	*/

	//-------------------------------------------------------------------------------------------------------------------------------
    // 객체를 생성하기 위한 함수 
	//-------------------------------------------------------------------------------------------------------------------------------
    protected override tagAppsItem New()
    {
        //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
        return new tagCityStatic();

        //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
    }

	//-------------------------------------------------------------------------------------------------------------------------------
	// 객체를 삭제하기 위한 함수 
	//-------------------------------------------------------------------------------------------------------------------------------
	protected override void OnDelete( tagAppsItem appsItem )
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( (appsItem)==(null) ) return;

        //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		GetList().Remove( appsItem as tagCityStatic );

        //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
    }

	//-------------------------------------------------------------------------------------------------------------------------------
	// 리스트를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public List<tagCityStatic> GetList()
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return (data.Citys);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
	}

    //-------------------------------------------------------------------------------------------------------------------------------
	// 객체 정보를 검색하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
    public tagCityStatic Find( string id )
    {
        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
        if( (id)==(null) ) return (null);

        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
        foreach( tagCityStatic city in GetList() )
        {
            //-----------------------------------------------------------------------------------------------------------------------
	        // -
	        //-----------------------------------------------------------------------------------------------------------------------
            if( (city.id)==(id) )
            {
				return (city);
            }

            //-----------------------------------------------------------------------------------------------------------------------
	        // -
	        //-----------------------------------------------------------------------------------------------------------------------
        }

        //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return (null);
    }

	//-------------------------------------------------------------------------------------------------------------------------------
	// 로컬에 저장된 정보를 불러오기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override void OnLoadCache( tagAppsItem appsItem, AppsParameter col=(null) )
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( (appsItem)==(null) ) return;
//		if( (col)==(null) ) return;	//(NULL)값을 허용함

        //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		tagCityStatic	citystatic	= (appsItem as tagCityStatic);
		if( (citystatic)==(null) ) return;

        //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( (col)!=(null) )
		{
			(citystatic.nation)		= col.Get("nation");
			(citystatic.openmarket)	= col.GetBoolean("openmarket");
			(citystatic.extent)		= col.GetInt("extent");
			(citystatic.population)	= col.GetInt("population");
			(citystatic.gdp)		= col.GetInt("gdp");
			(citystatic.inflation)	= col.GetInt("inflation");
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( !GetList().Contains(citystatic) )
		{
			GetList().Add(citystatic);
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// XML 파일을 저장하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override void OnXmlSave( XmlTextWriter xmlWriter, tagAppsItem appsItem )
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( (xmlWriter)==(null) ) return;
		if( (appsItem)==(null) ) return;

        //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		tagCityStatic	citystatic	= (appsItem as tagCityStatic);
		if( (citystatic)==(null) ) return;

        //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		CXml.WriteNodeValue( (xmlWriter), "nation", citystatic.GetNationId() );
		CXml.WriteNodeValue( (xmlWriter), "openmarket", (citystatic.openmarket) );
		CXml.WriteNodeValue( (xmlWriter), "extent", (citystatic.extent) );
		CXml.WriteNodeValue( (xmlWriter), "population", (citystatic.population) );
		CXml.WriteNodeValue( (xmlWriter), "gdp", (citystatic.gdp) );
		CXml.WriteNodeValue( (xmlWriter), "inflation", (citystatic.inflation) );

        //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// XML 파일을 불러오기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override void OnXmlLoad( XmlNode pNode, tagAppsItem appsItem )
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( (pNode)==(null) ) return;
		if( (appsItem)==(null) ) return;

        //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		tagCityStatic	citystatic	= (appsItem as tagCityStatic);
		if( (citystatic)==(null) ) return;

        //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		(citystatic.nation)		= CXml.GetChildValue( (pNode), "nation" );
		(citystatic.openmarket)	= CXml.GetChildBoolean( (pNode), "openmarket" );
		(citystatic.extent)		= CXml.GetChildInt( (pNode), "extent" );
		(citystatic.population)	= CXml.GetChildInt( (pNode), "population" );
		(citystatic.gdp)		= CXml.GetChildInt( (pNode), "gdp" );
		(citystatic.inflation)	= CXml.GetChildInt( (pNode), "inflation" );

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