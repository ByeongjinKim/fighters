using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-----------------------------------------------------------------------------------------------------------------------------------
// �ڱ� ������ ó���ϱ� ���� ����ü
//-----------------------------------------------------------------------------------------------------------------------------------
public class tagCash
{
	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	public tagCurrencyStatic	currency	= (null);
	public decimal				value		= (0);

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	public override string ToString()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return CApp.This.Cash.ExchangeToString( Func.Divide( (value), (decimal)(currency.value) ), (currency) )+" ("+base.ToString()+")";

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