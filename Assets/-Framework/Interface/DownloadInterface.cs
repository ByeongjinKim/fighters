using System;

public class DownloadInterface
{
	//다운로드를 요청하기 위한 함수
	public static void ON( string url, Action<object, object> func=null, object wParam=null, object lParam=null )
	{
		if( !Library.Is(url) ) return;
//		if( func==null ) return;	//(NULL)값을 허용함
//		if( wParam==null ) return;	//(NULL)값을 허용함
//		if( lParam==null ) return;	//(NULL)값을 허용함

		ApplicationBehaviour.This.Download.ON( url, func, wParam, lParam );
	}
}