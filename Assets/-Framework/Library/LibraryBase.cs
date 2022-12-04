using System.Text.RegularExpressions;
using System.IO;
using UnityEngine;

public class LibraryBase
{
	//문자열을 확인하기 위한 함수
    public static bool Is( string value )
    {
		if( value==null ) return false;

		if( string.IsNullOrEmpty(value) )
		{
			return false;
		}

		return true;
    }

	//객체를 생성하기 위한 함수
	public static Transform Create( Transform parent, GameObject sample )
	{
//		if( parent==null ) return null;		//(NULL)값을 허용함
		if( sample==null ) return null;

		GameObject gameObject = null;
		if( parent!=null )
		{
			gameObject = GameObject.Instantiate( sample, parent );
		}
		else
		{
			gameObject = GameObject.Instantiate( sample );
		}

		return gameObject.transform;
	}

	//객체를 생성하기 위한 함수
	public static Transform Create( GameObject sample )
	{
		if( sample==null ) return null;
		return Create( null, sample );
	}

	//파일을 확인하기 위한 함수
	public static bool IsFile( string filepath )
	{
		if( !Is(filepath) ) return false;

		if( File.Exists(filepath) ) 
		{
			return true;
		}

		return false;
	}

	//파일의 확장자를 얻기 위한 함수
	public static string Ext( string filepath )
	{
		if( !Is(filepath) ) return null;

		string[] urlarray	= filepath.Split('?');
		string[] strarray	= urlarray[0].Split('.');
		if( strarray.Length<1 ) return null;

		return strarray[strarray.Length-1].ToLower();
	}

	//파일 이름을 얻기 위한 함수
	public static string GetFileName( string filepath )
	{
		if( !Is(filepath) ) return null;

		string filenameext = GetFileNameExt(filepath);

		string[] strarray = filenameext.Split('.');
		if( strarray.Length<1 ) return null;

		return filenameext.Substring( 0, filenameext.Length-Ext(filenameext).Length+1 );
	}

	//파일 이름을 얻기 위한 함수
	public static string GetFileNameExt( string filepath )
	{
		if( !Is(filepath) ) return null;

		string[] strarray = filepath.Replace( "\\", "/" ).Split('/');
		if( strarray.Length<1 ) return null;

		return strarray[strarray.Length-1];
	}

	//파일 이름을 얻기 위한 함수
	public static string GetPath( string filepath )
	{
		if( !Is(filepath) ) return null;
		return filepath.Substring( 0, filepath.Length-GetFileNameExt(filepath).Length );
	}

	//숫자인지 확인하기 위한 함수
	public static bool IsNumber( string value )
	{
		if( !Is(value) ) return false;

		int numChk = 0;
		if( int.TryParse( value, out numChk ) )
		{
			return true;
		}

		return false;
	}

	//실수인지 확인하기 위한 함수 
	public static bool IsSingle( string value )
	{
		if( !Is(value) ) return false;

		if( IsNumber(value) )
		{
			return true;
		}

		Regex regex = new Regex(@"[^0-9\.\-]");

		if( regex.IsMatch(value) )
		{
			//숫자, 음수, 콤마 외에 다른 문자가 포함되었을 경우, FALSE
			return false;
		}

		if (value.Split('.').Length > 2)
		{
			//실수 콤마가 여러개 사용되었을 경우, FALSE
			return false;
		}

		if( value.IndexOf('-')>0 )
		{
			//음수 표기가 맨 앞에 있지 않으면, FALSE
			return false;
		}

		return true;
	}
	//나누셈을 처리하기 위한 함수
    public static float Divide( int value1, int value2 )
    {
		if( value2!=0 )
        {
            return value1 / (float)value2;
        }

        return 0;
    }

	//나누셈을 처리하기 위한 함수
    public static Vector3 Divide( Vector3 vector, int value )
    {
		vector.x = Divide( vector.x, value );
		vector.y = Divide( vector.y, value );
		vector.z = Divide( vector.z, value );

        return vector;
    }

	//나누셈을 처리하기 위한 함수
    public static float Divide( float value1, float value2 )
    {
        if( value2!=0 )
        {
            return value1 / value2;
        }

        return 0;
    }
}