using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-----------------------------------------------------------------------------------------------------------------------------------
// ���̵�ƼƼ ������ ó���ϱ� ���� Ŭ����
//-----------------------------------------------------------------------------------------------------------------------------------
public class CIdentity : MonoBehaviour
{
	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
    [System.Serializable]
    public class tagData
    {
	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		public tagIdentity			identity		= (null);

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		public List<tagIdentity>	Identities		= new List<tagIdentity>();

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
    };
    public tagData		data		= new tagData();

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	protected CApp		app			= (null);
	protected CPlay		play		= (null);

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	void OnEnable()
	{
		(this.app)		= (CApp.This);
		(this.play)		= (CPlay.This);
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// ���̵�ƼƼ�� ����ϱ� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	public tagIdentity Register( tagPerson person )
	{
	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( (person)==(null) ) return (null);

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		tagIdentity		identity	= Create();

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		(identity.type)	= (IDENTITY.PERSON);
		(identity.obj)	= (person);

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		GetList().Add(identity);

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return (identity);
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// ���̵�ƼƼ�� ����ϱ� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	public tagIdentity Register( tagCompany company )
	{
	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( (company)==(null) ) return (null);

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		tagIdentity identity = Find(company);
		if( (identity)!=(null) )
		{
			return (identity);
		}
		else
		{
			(identity) = Create();
		}

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		(identity.type)	= (IDENTITY.COMPANY);
		(identity.obj)	= (company);

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		GetList().Add(identity);

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( !app.ViewLoading.Is() )
		{
			app.ViewDashboardBusiness.Reload();
		}

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return (identity);
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// ���̵�ƼƼ�� �����ϱ� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	public tagIdentity Create()
	{
	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return new tagIdentity();

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// ���̵�ƼƼ�� �����ϱ� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	public tagIdentity Create( IDENTITY nIdentity, string id )
	{
	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( !Func.Is(id) ) return (null);

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		tagIdentity identity = new tagIdentity();

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		(identity.type)	= (nIdentity);

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( true )
		{
			//-----------------------------------------------------------------------------------------------------------------------
		    // -
		    //-----------------------------------------------------------------------------------------------------------------------
			switch( nIdentity )
			{
				//-------------------------------------------------------------------------------------------------------------------
			    // �ι� (PERSON)
			    //-------------------------------------------------------------------------------------------------------------------
				case (IDENTITY.PERSON):
					(identity.obj)	= app.Person.Find(id);
					break;

				//-------------------------------------------------------------------------------------------------------------------
			    // -
			    //-------------------------------------------------------------------------------------------------------------------
			}

			//-----------------------------------------------------------------------------------------------------------------------
		    // -
		    //-----------------------------------------------------------------------------------------------------------------------
			if( (identity.obj)==(null) )
			{
				(identity.obj)	= (id);
			}

			//-----------------------------------------------------------------------------------------------------------------------
		    // -
		    //-----------------------------------------------------------------------------------------------------------------------
		}

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return (identity);
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// ����Ʈ�� ��� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	public List<tagIdentity> GetList()
	{
	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return (data.Identities);

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	public static IDENTITY Parse( string value )
	{
	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( !Func.Is(value) ) return (IDENTITY.NOTHING);

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		(value)	= value.ToUpper();

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		int End = (int)(IDENTITY.END);
		for( int i=0; i<(End); i++ )
		{
			if( ((IDENTITY)(i)).ToString()==(value) )
			{
				return (IDENTITY)(i);
			}
		}

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return (IDENTITY.NOTHING);
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// �̸��� ��� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	public string GetID( tagIdentity identity )
	{
	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( (identity)==(null) ) return (null);

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		switch( identity.type )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// ��� (COMPANY)
			//-----------------------------------------------------------------------------------------------------------------------
			case (IDENTITY.COMPANY):
				return app.Company.GetID(identity.Company());

			//-----------------------------------------------------------------------------------------------------------------------
			// �ι� (PERSON)
			//-----------------------------------------------------------------------------------------------------------------------
			case (IDENTITY.PERSON):
				return app.Person.GetID(identity.Person());

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
	// ����ڸ� �˻��ϱ� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	public tagIdentity Find( IDENTITY type, string id=(null) )
	{
	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
//		if( !Func.Is(id) ) return (null);	//(NULL)���� �����

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		foreach( tagIdentity identity in GetList() )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			if( (identity.type)!=(type) ) continue;

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			switch( identity.type )
			{
				//-------------------------------------------------------------------------------------------------------------------
				// ��� (COMPANY)
				//-------------------------------------------------------------------------------------------------------------------
				case (IDENTITY.COMPANY):
					if( identity.ID()==(id) )
					{
						return (identity);
					}
					break;

				//-------------------------------------------------------------------------------------------------------------------
				// �ι� (PERSON)
				//-------------------------------------------------------------------------------------------------------------------
				case (IDENTITY.PERSON):
					return (identity);

				//-------------------------------------------------------------------------------------------------------------------
				// -
				//-------------------------------------------------------------------------------------------------------------------
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
	// ����ڸ� �˻��ϱ� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	public void Select( tagIdentity identity )
	{
	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( (identity)==(null) ) return;

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		(data.identity)	= (identity);

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		app.ViewTop.Set(identity);

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// �̸��� ��� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	public tagIdentity Get()
	{
	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return (data.identity);

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// ��� ������ ��� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	public tagCompany Company()
	{
	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		tagIdentity	identity = Get();
		if( (identity)!=(null) && identity.Company()!=(null) )
		{
			return identity.Company();
		}

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( app.Person.Is(app.Player.Person()) )
		{
			return app.Player.Person().Company();
		}

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return (null);
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// ������ ��� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	public tagNationStatic Nation()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( Get()!=(null) )
		{
			if( (Get().type)==(IDENTITY.COMPANY) )
			{
				if( Get().Company()!=(null) && Func.Is(Get().Company().id) )
				{
					return (Get().Company().nation);
				}
			}
			else
			if( (Get().type)==(IDENTITY.PERSON) )
			{
				return app.Player.Nation();
			}
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (null);
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// ����ڸ� Ȯ���ϱ� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool Is( tagIdentity identity, tagPerson person )
	{
	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( (identity)==(null) ) return false;
		if( (person)==(null) ) return false;

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( (identity.type)==(IDENTITY.PERSON) && identity.Person()==(person) )
		{
			return true;
		}

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// ����ڸ� Ȯ���ϱ� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	public tagIdentity Find( tagCompany company )
	{
	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( (company)==(null) ) return (null);

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		foreach( tagIdentity identity in GetList() )
		{
			if( (identity.type)==(IDENTITY.COMPANY) && identity.Company()==(company) )
			{
				return (identity);
			}
		}

	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return (null);
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// �ڱ� ������ ��� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	public decimal GetCash( tagIdentity identity )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (identity)==(null) ) return (0);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		List<tagCash> Cashes = GetCashes(identity);
		if( (Cashes)!=(null) )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			decimal cash = (0);

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			foreach( tagCash cash0 in Cashes )
			{
				(cash) += Func.Divide( (cash0.value), (decimal)(cash0.currency.value) );
			}

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			return (cash);
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (0);
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// �ڱ� ������ ��� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	public List<tagCash> GetCashes( tagIdentity identity )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (identity)==(null) ) return (null);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (identity.type)==(IDENTITY.COMPANY) )
		{
			tagCompany company = identity.Company();
			if( (company)!=(null) )
			{
				return (company.Cashes);
			}			
		}
		else
		if( (identity.type)==(IDENTITY.PERSON) )
		{
			tagPerson person = identity.Person();
			if( (person)!=(null) )
			{
				return (person.Cashes);
			}
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (null);
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// �ڱ� ������ ��� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	public List<tagCash> GetCashes()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return GetCashes( Get() );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// �ڱ� ������ ��� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	public decimal GetCash()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return GetCash( Get() );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	public void Change( tagIdentity identity )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (identity)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		app.ViewIndigator.ON( (this), app.Language.Get(TEXT.����ڸ�_��ȯ���Դϴ�) );
		ManagementHash.Identity( identity );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// ����ڰ� �濵�� �������� Ȯ���ϱ� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool IsPerson()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( Type()==(IDENTITY.PERSON) )
		{
			return true;
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// ����ڰ� ��� �������� Ȯ���ϱ� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool IsCompany()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( Type()==(IDENTITY.COMPANY) )
		{
			return true;
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// ����ڰ� ��� �������� Ȯ���ϱ� ���� �Լ�
	//-------------------------------------------------------------------------------------------------------------------------------
	public IDENTITY Type()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( Get()!=(null) )
		{
			return (Get().type);
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (IDENTITY.NOTHING);
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
}

//-----------------------------------------------------------------------------------------------------------------------------------
// -
//-----------------------------------------------------------------------------------------------------------------------------------