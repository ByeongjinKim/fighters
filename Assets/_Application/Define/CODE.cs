﻿//-----------------------------------------------------------------------------------------------------------------------------------
// -
//-----------------------------------------------------------------------------------------------------------------------------------
public class CODE
{
	//-------------------------------------------------------------------------------------------------------------------------------
	// IDENTITY
	//-------------------------------------------------------------------------------------------------------------------------------
	public static IDENTITY Identity( string id )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (id)==(null) ) return (IDENTITY.NOTHING);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		for( int i=(1); i<(int)(IDENTITY.END); i++ )
		{
			if( ((IDENTITY)(i)).ToString()==(id) )
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
	// INVENTORY_OPTION
	//-------------------------------------------------------------------------------------------------------------------------------
	public static INVENTORY_OPTION InventoryOption( string id )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (id)==(null) ) return (INVENTORY_OPTION.NOTHING);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		for( int i=(1); i<(int)(INVENTORY_OPTION.END); i++ )
		{
			if( ((INVENTORY_OPTION)(i)).ToString()==(id) )
			{
				return (INVENTORY_OPTION)(i);
			}
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (INVENTORY_OPTION.NOTHING);
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
}

//-----------------------------------------------------------------------------------------------------------------------------------
// -
//-----------------------------------------------------------------------------------------------------------------------------------