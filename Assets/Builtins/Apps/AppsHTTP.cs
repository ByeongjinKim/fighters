using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

//웹 프로토콜을 처리하기 위한 클래스
public class AppsHTTP : MonoBehaviour
{
	private static string	SessionID	= null;
	private static bool		bHttpLog	= true;

	public void Get( string url, bool log=true )
	{
		if( !Func.Is(url) ) return;

		WWWForm form = new WWWForm();
		if( SessionID.Length>0 )
		{
			form.AddField( "PHPSESSID", (SessionID) );
		}

		StartCoroutine( WaitForRequest( url, form ) );
	}

	public void Post( string url, AppsHTTPPost post=null )
	{
		if( !Library.Is(url) ) return;

		WWWForm form = new WWWForm();

		if( post!=null )
		{
			foreach( KeyValuePair<string, string> arg in post.dictionary ) 
			{ 
				form.AddField( arg.Key, arg.Value ); 
			}

			tagFile file = null;
			foreach( KeyValuePair<string, tagFile> arg in post.files ) 
			{
				file = arg.Value;
				if( file!=null )
				{
					form.AddBinaryData( arg.Key, file.bytes, file.filename, file.minetype ); 
				}
			}
		}

		if( Library.Is(SessionID) )
		{
			form.AddField( "PHPSESSID", SessionID );
		}

		StartCoroutine( WaitForRequest( url, form ) );
	}

	private IEnumerator WaitForRequest( string url, WWWForm form=null )
	{
		if( !Library.Is(url) ) yield break;
//		if( form==null ) yield break;	//(NULL)값을 허용함

		UnityWebRequest www = null;

		for( int loop=0; loop<3; loop++ )
		{
			if( form!=null && form.data.Length>0 )
			{
				www = Internet.Protocol( url, form );
			}
			else
			{
				www = Internet.Protocol( url );
			}

			yield return www.SendWebRequest();

			//check for errors 
			if( www.result==UnityWebRequest.Result.Success ) 
			{
				while( www.GetResponseHeaders()!=null && www.GetResponseHeaders().ContainsKey("SET-COOKIE") )
				{
					char[] splitter = { ';' };
					string[] headers = www.GetResponseHeaders()["SET-COOKIE"].Split(splitter); 

					foreach( string header in headers ) 
					{
						if( string.IsNullOrEmpty(header) ) continue;

						string[] column = header.Split( '=' );

						if( column[0]=="PHPSESSID" )
						{
							SessionID = column[1];
						}
					} 

					break;
				}

				if( Receive(www) )
				{
					if( bHttpLog )
					{
						Debug.Log( "(http ok : "+www.url+") "+www.downloadHandler.text );
					}
				}
				else
				{
					if( www.downloadHandler.text!=null )
					{
#if UNITY_EDITOR
						Debug.Log("(http error : "+www.url+") "+www.downloadHandler.text);
#else
						Debug.LogError("(http error : "+www.url+") "+www.downloadHandler.text);
#endif
					}
					else
					{
						Debug.LogError("(http error : "+www.url+")");
					}

					Apps.ProtocolError( www );
				}
			}
			else
			{
				www.Dispose();

				//프로토콜 재시도
				yield return new WaitForSeconds(1f);
				continue;
			}

			break;
		}

		if( www.result!=UnityWebRequest.Result.Success )
		{
			if( !Apps.HttpError(www) )
			{
#if UNITY_EDITOR
				Debug.Log( www.url+" => "+www.downloadHandler.text );
#endif

				objConfirm confirm = CApp.This.Confirm.ON( CApp.This.Language.Get(TEXT.서버와_접속이_끊겼습니다), CONFIRM.YESNO, CApp.This.Engine.funcRestart );
				if( confirm!=null )
				{
					confirm.SetRejectCallback( CApp.This.Engine.funcQuit );
					confirm.data.allowEmptySpaceConfirm = false;
				}
			}
		}

		www.Dispose();
	}

	//패킷 수신을 처리하기 위한 함수
	bool Receive( UnityWebRequest www )
	{
		if( www==null ) return false;

		AppsParameter col = AppsParameter.JsonParse( www.downloadHandler.text );
		if( col==null ) return false;
		if( col.array==null ) return false;

		AppsParameter child = null;
		foreach( Hashtable hash in col.array )
		{
			child = AppsParameter.Initialize( hash );
			if( child!=null )
			{
				child.www = www;
			}

			Apps.Receive( child );
		}

		return true;
	}

	//로그를 설정하기 위한 함수
	public static void SetLog( bool log )
	{
		bHttpLog = log;
	}

	//패킷 수신을 처리하기 위한 함수
	public bool Receive( string text, UnityWebRequest www=null )
	{
		if( !Library.Is(text) ) return false;
//		if( www==null ) return false;	//(NULL)값을 허용함

		AppsParameter col = AppsParameter.JsonParse( text );
		if( col==null ) return false;
		if( col.array==null ) return false;

		foreach( Hashtable hash in col.array )
		{
			AppsParameter child = AppsParameter.Initialize( hash );
			if( child!=null )
			{
				child.www = www;
			}

			Apps.Receive( child );
		}

		return true;
	}
}