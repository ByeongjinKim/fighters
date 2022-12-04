﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-----------------------------------------------------------------------------------------------------------------------------------
// -
//-----------------------------------------------------------------------------------------------------------------------------------
public enum TABLE_SKILL_TIES {			ID,				//스킬 고유 아이디
										SKL_GRADE,		//스킬의 등급
										SKL_CLS,		//스킬의 소유 캐릭터						(1 = 머셔 / 2 = 엘드 / 3 = 셉지)
										SKL_PRE,		//오픈되기 위해 필요한 스킬의 아이디			(0 = 없음, 사용안함 / -1 = skill_base 테이블 에서 참조, '/' 로 복수 입력 가능)
										SKL_NEXT,		//오픈되면 잠금 해제 될 다음 스킬의 아이디	(0 = 없음, 사용안함 / -1 = skill_base 테이블 에서 참조, '/' 로 복수 입력 가능)
										LEVEL_UNLOCK,	//스킬이 잠금해제 되는 캐릭터의 레벨			(0 = 기본보유 / -1 = skill_base 테이블 에서 참조 / 1 ~ = 해당 레벨에 잠김해제)
										SKL_COOL,		//스킬의 쿨타임							(시간 입력 (초) / -1 = skill_base 테이블 에서 참조)
										CHAIN_COUNT,	//콤보로 인식할 스킬의 수					(chain_open - chain_follow - chain_finish 에 입력되는 스킬들은 각 단계의 콤보로 정의 / -1 = 콤보로 정의 하지않고 입력된 스킬들이 한번에 연속 작동)
										CHAIN_OPEN,		//콤보의 시작 스킬							(콤보의 오픈스킬 아이디 입력 : 시작 스킬 입력 : 무조건 1종 필요)
										CHAIN_FOLLOW,	//콤보의 연계 스킬							(콤보의 연계스킬 아이디 입력 : 0 = 중간연계가 없는 경우 / -1 = 더 이상 연계 없음)
										CHAIN_FINISH,	//콤보의 마지막 스킬						(콤보의 종료스킬 아이디 입력 : -1 = 연계 없음)

										END };

//-----------------------------------------------------------------------------------------------------------------------------------
// -
//-----------------------------------------------------------------------------------------------------------------------------------