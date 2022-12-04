using System.Text.RegularExpressions;
using System.IO;
using UnityEngine;

public class LibraryBase
{
	//���ڿ��� Ȯ���ϱ� ���� �Լ�
    public static bool Is( string value )
    {
		if( value==null ) return false;

		if( string.IsNullOrEmpty(value) )
		{
			return false;
		}

		return true;
    }

	//��ü�� �����ϱ� ���� �Լ�
	public static Transform Create( Transform parent, GameObject sample )
	{
//		if( parent==null ) return null;		//(NULL)���� �����
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

	//��ü�� �����ϱ� ���� �Լ�
	public static Transform Create( GameObject sample )
	{
		if( sample==null ) return null;
		return Create( null, sample );
	}

	//������ Ȯ���ϱ� ���� �Լ�
	public static bool IsFile( string filepath )
	{
		if( !Is(filepath) ) return false;

		if( File.Exists(filepath) ) 
		{
			return true;
		}

		return false;
	}

	//������ Ȯ���ڸ� ��� ���� �Լ�
	public static string Ext( string filepath )
	{
		if( !Is(filepath) ) return null;

		string[] urlarray	= filepath.Split('?');
		string[] strarray	= urlarray[0].Split('.');
		if( strarray.Length<1 ) return null;

		return strarray[strarray.Length-1].ToLower();
	}

	//���� �̸��� ��� ���� �Լ�
	public static string GetFileName( string filepath )
	{
		if( !Is(filepath) ) return null;

		string filenameext = GetFileNameExt(filepath);

		string[] strarray = filenameext.Split('.');
		if( strarray.Length<1 ) return null;

		return filenameext.Substring( 0, filenameext.Length-Ext(filenameext).Length+1 );
	}

	//���� �̸��� ��� ���� �Լ�
	public static string GetFileNameExt( string filepath )
	{
		if( !Is(filepath) ) return null;

		string[] strarray = filepath.Replace( "\\", "/" ).Split('/');
		if( strarray.Length<1 ) return null;

		return strarray[strarray.Length-1];
	}

	//���� �̸��� ��� ���� �Լ�
	public static string GetPath( string filepath )
	{
		if( !Is(filepath) ) return null;
		return filepath.Substring( 0, filepath.Length-GetFileNameExt(filepath).Length );
	}

	//�������� Ȯ���ϱ� ���� �Լ�
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

	//�Ǽ����� Ȯ���ϱ� ���� �Լ� 
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
			//����, ����, �޸� �ܿ� �ٸ� ���ڰ� ���ԵǾ��� ���, FALSE
			return false;
		}

		if (value.Split('.').Length > 2)
		{
			//�Ǽ� �޸��� ������ ���Ǿ��� ���, FALSE
			return false;
		}

		if( value.IndexOf('-')>0 )
		{
			//���� ǥ�Ⱑ �� �տ� ���� ������, FALSE
			return false;
		}

		return true;
	}
	//�������� ó���ϱ� ���� �Լ�
    public static float Divide( int value1, int value2 )
    {
		if( value2!=0 )
        {
            return value1 / (float)value2;
        }

        return 0;
    }

	//�������� ó���ϱ� ���� �Լ�
    public static Vector3 Divide( Vector3 vector, int value )
    {
		vector.x = Divide( vector.x, value );
		vector.y = Divide( vector.y, value );
		vector.z = Divide( vector.z, value );

        return vector;
    }

	//�������� ó���ϱ� ���� �Լ�
    public static float Divide( float value1, float value2 )
    {
        if( value2!=0 )
        {
            return value1 / value2;
        }

        return 0;
    }
}