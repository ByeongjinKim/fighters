using System;

public class DownloadInterface
{
	//�ٿ�ε带 ��û�ϱ� ���� �Լ�
	public static void ON( string url, Action<object, object> func=null, object wParam=null, object lParam=null )
	{
		if( !Library.Is(url) ) return;
//		if( func==null ) return;	//(NULL)���� �����
//		if( wParam==null ) return;	//(NULL)���� �����
//		if( lParam==null ) return;	//(NULL)���� �����

		ApplicationBehaviour.This.Download.ON( url, func, wParam, lParam );
	}
}