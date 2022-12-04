using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//-----------------------------------------------------------------------------------------------------------------------------------
// �μ� ����Ʈ�� ó���ϱ� ���� Ŭ����
//-----------------------------------------------------------------------------------------------------------------------------------
public class CViewDepartmentList : ViewPanel
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
		public List<uiIcon>		Icons		= new List<uiIcon>();

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	};
	public tagData		data		= new tagData();

	//-------------------------------------------------------------------------------------------------------------------------------
	// �������̽��� Ȱ��ȭ �ϱ� ���� �Լ�
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
			Indigator();

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			app.DepartmentStatic.CorverTextureAllDownload();
			app.Download.SetCallback( funcInitialize );

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
	// �������̽��� ��Ȱ��ȭ �ϱ� ���� �Լ�
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
	// ����Ʈ�� �����ϱ� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	void funcInitialize( object wParam=(null), object lParam=(null) )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		foreach( tagDepartmentStatic departmentstatic in app.DepartmentStatic.GetList() )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			if( !app.Business.IsDepartment( app.Business.Get(), (departmentstatic) ) ) continue;
			if( app.ViewBusiness.IsDepartment(departmentstatic) ) continue;

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			Register( departmentstatic );

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		ScrollView().Init();
		Refresh();

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		Indigator( false );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// ���� ������ ����ϱ� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	void Register( tagDepartmentStatic departmentstatic )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (departmentstatic)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		uiIcon icon = (Func.Create( ScrollView().Content(), (Resources.Load(PATH.UI_DEPARTMENT_LIST_ITEM) as GameObject) ).GetComponent(typeof(uiIcon)) as uiIcon);
		if( (icon)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		icon.Set( departmentstatic );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (app.ViewBusiness.Get().businessstatic.Type)==(UPDATE_TYPE.Farm) )
		{
			if( (departmentstatic.id)==(DEPARTMENT.����) && app.ViewBusiness.FindFromType(DEPARTMENT.������)!=(null) )
			{
				icon.Hold( app.Language.Get(TEXT.�����ο�_�Բ�_������_��_�����ϴ�) );
			}
			else
			if( (departmentstatic.id)==(DEPARTMENT.������) && app.ViewBusiness.FindFromType(DEPARTMENT.����)!=(null) )
			{
				icon.Hold( app.Language.Get(TEXT.���ο�_�Բ�_������_��_�����ϴ�) );
			}
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		GetList().Add( icon );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// ����Ʈ�� ��� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	public List<uiIcon> GetList()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.Icons);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// ����Ʈ�� ���ΰ�ħ �ϱ� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	void Refresh()
	{
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
		foreach( uiIcon icon in GetList() )
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
	// ���ü�� �Ǽ��ϱ� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	void funcBuild( object wParam=(null), object lParam=(null) )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (wParam)==(null) || wParam.GetType()!=typeof(tagDepartmentStatic) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		tagDepartmentStatic departmentstatic = (wParam as tagDepartmentStatic);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		Indigator( app.Language.Get(TEXT.�μ���_�����_���Դϴ�) );
		ManagementHash.DepartmentCreate( app.Business.Get(), (departmentstatic) );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// ��� �Է¿� �����ϱ� ���� �Լ�
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
	// �������̽��� Ȱ��ȭ �ϱ� ���� �Լ�
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
		foreach( uiIcon icon in GetList() )
		{
			if( (control)==icon.Control() && (Action)==(CONTROL_ACTION.SELECT) )
			{
				app.Confirm.ON( Func.Script( app.Language.Get(TEXT.__�θ�_�����Ͻðڽ��ϱ�), app.Language.Get(app.DepartmentStatic._GetName(icon.Get())) ), (CONFIRM.YESNO), (funcBuild), icon.Get() );
				return true;
			}
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// �޸𸮸� �ʱ�ȭ �ϱ� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	public override void Unloader()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// �������̽��� �ҷ����� ���� �Լ�
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
			(subject.text)	= app.Language.Get(TEXT.�μ�_�����);
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