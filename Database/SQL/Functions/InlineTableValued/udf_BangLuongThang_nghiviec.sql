CREATE FUNCTION [dbo].[udf_BangLuongThang_nghiviec]     
(
@month int,
@year int
)      
RETURNS table      
AS     
RETURN (
	SELECT 
	empl.Card_No,
	empl.Employee_ID,
	empl.Card_Code,
	empl.Employee_Firstname,
	empl.Employee_LastName,
	empl.BirthDate,
	empl.DepartmentCode,
	empl.TeamCode,
	empl.Position_ID,
	empl.StartedDate,
	empl.ChucDanh,
	isnull(salary.s1,0) as s1,isnull(salary.s2,0) as s2,isnull(salary.s3,0) as s3,isnull(salary.s4,0) as s4,isnull(salary.s5,0) as s5,isnull(salary.s6,0) as s6,isnull(salary.s7,0) as s7,isnull(salary.s8,0) as s8,isnull(salary.s9,0) as s9,isnull(salary.s10,0) as s10,
	isnull(salary.s11,0) as s11,isnull(salary.s12,0) as s12,isnull(salary.s13,0) as s13,isnull(salary.s14,0) as s14,isnull(salary.s15,0) as s15,isnull(salary.s16,0) as s16,isnull(salary.s17,0) as s17,isnull(salary.s18,0) as s18,isnull(salary.s19,0) as s19,isnull(salary.s20,0) as s20,
	isnull(salary.s21,0) as s21,isnull(salary.s22,0) as s22,isnull(salary.s23,0) as s23,isnull(salary.s24,0) as s24,isnull(salary.s25,0) as s25,
	isnull(salary.s26,0) as s26,isnull(salary.s27,0) as s27,isnull(salary.s28,0) as s28,isnull(salary.s29,0) as s29,isnull(salary.s30,0) as s30,
	isnull(salary.s31,0) as s31,isnull(salary.s32,0) as s32,isnull(salary.s33,0) as s33,isnull(salary.s34,0) as s34,isnull(salary.s35,0) as s35,isnull(salary.s36,0) as s36,isnull(salary.s37,0) as s37,isnull(salary.s38,0) as s38,isnull(salary.s39,0) as s39,isnull(salary.s40,0) as s40,
	isnull(salary.s41,0) as s41,isnull(salary.s42,0) as s42,isnull(salary.s43,0) as s43,isnull(salary.s44,0) as s44,isnull(salary.s45,0) as s45,isnull(salary.s46,0) as s46,isnull(salary.s47,0) as s47,isnull(salary.s48,0) as s48,isnull(salary.s49,0) as s49,isnull(salary.s50,0) as s50,
	isnull(salary.s51,0) as s51,isnull(salary.s52,0) as s52,isnull(salary.s53,0) as s53,isnull(salary.s54,0) as s54,isnull(salary.s55,0) as s55,isnull(salary.s56,0) as s56,isnull(salary.s57,0) as s57,isnull(salary.s58,0) as s58,isnull(salary.s59,0) as s59,isnull(salary.s60,0) as s60,
	isnull(salary.s61,0) as s61,isnull(salary.s62,0) as s62,isnull(salary.s63,0) as s63,isnull(salary.s64,0) as s64,isnull(salary.s65,0) as s65,isnull(salary.s66,0) as s66,isnull(salary.s67,0) as s67,isnull(salary.s68,0) as s68,isnull(salary.s69,0) as s69,isnull(salary.s70,0) as s70,
	isnull(salary.s71,0) as s71,isnull(salary.s72,0) as s72,isnull(salary.s73,0) as s73,isnull(salary.s74,0) as s74,isnull(salary.s75,0) as s75,isnull(salary.s76,0) as s76,isnull(salary.s77,0) as s77,isnull(salary.s78,0) as s78,isnull(salary.s79,0) as s79,isnull(salary.s80,0) as s80,
	isnull(salary.s81,0) as s81,isnull(salary.s82,0) as s82,isnull(salary.s83,0) as s83,isnull(salary.s84,0) as s84,isnull(salary.s85,0) as s85,isnull(salary.s86,0) as s86,isnull(salary.s87,0) as s87,isnull(salary.s88,0) as s88,isnull(salary.s89,0) as s89,isnull(salary.s90,0) as s90,
	isnull(salary.s91,0) as s91,isnull(salary.s92,0) as s92,isnull(salary.s93,0) as s93,isnull(salary.s94,0) as s94,isnull(salary.s95,0) as s95,isnull(salary.s96,0) as s96,isnull(salary.s97,0) as s97,isnull(salary.s98,0) as s98,isnull(salary.s99,0) as s99
	,isnull(salary.s100,0) as  s100
,isnull(salary.s101,0) as  s101
,isnull(salary.s102,0) as  s102
,isnull(salary.s103,0) as  s103
,isnull(salary.s104,0) as  s104
,isnull(salary.s105,0) as  s105
,isnull(salary.s106,0) as  s106
,isnull(salary.s107,0) as  s107
,isnull(salary.s108,0) as  s108
,isnull(salary.s109,0) as  s109
,isnull(salary.s110,0) as  s110
,isnull(salary.s111,0) as  s111
,isnull(salary.s112,0) as  s112
,isnull(salary.s113,0) as  s113
,isnull(salary.s114,0) as  s114
,isnull(salary.s115,0) as  s115
,isnull(salary.s116,0) as  s116
,isnull(salary.s117,0) as  s117
,isnull(salary.s118,0) as  s118
,isnull(salary.s119,0) as  s119
,isnull(salary.s120,0) as  s120
,isnull(salary.s121,0) as  s121
,isnull(salary.s122,0) as  s122
,isnull(salary.s123,0) as  s123
,isnull(salary.s124,0) as  s124
,isnull(salary.s125,0) as  s125
,isnull(salary.s126,0) as  s126
,isnull(salary.s127,0) as  s127
,isnull(salary.s128,0) as  s128
,isnull(salary.s129,0) as  s129
,isnull(salary.s130,0) as  s130
,isnull(salary.s131,0) as  s131
,isnull(salary.s132,0) as  s132
,isnull(salary.s133,0) as  s133
,isnull(salary.s134,0) as  s134
,isnull(salary.s135,0) as  s135
,isnull(salary.s136,0) as  s136
,isnull(salary.s137,0) as  s137
,isnull(salary.s138,0) as  s138
,isnull(salary.s139,0) as  s139
,isnull(salary.s140,0) as  s140
,isnull(salary.s141,0) as  s141
,isnull(salary.s142,0) as  s142
,isnull(salary.s143,0) as  s143
,isnull(salary.s144,0) as  s144
,isnull(salary.s145,0) as  s145
,isnull(salary.s146,0) as  s146
,isnull(salary.s147,0) as  s147
,isnull(salary.s148,0) as  s148
,isnull(salary.s149,0) as  s149
,isnull(salary.s150,0) as  s150
,isnull(salary.s151,0) as  s151
,isnull(salary.s152,0) as  s152
,isnull(salary.s153,0) as  s153
,isnull(salary.s154,0) as  s154
,isnull(salary.s155,0) as  s155
,isnull(salary.s156,0) as  s156
,isnull(salary.s157,0) as  s157
,isnull(salary.s158,0) as  s158
,isnull(salary.s159,0) as  s159
,isnull(salary.s160,0) as  s160
,isnull(salary.s161,0) as  s161
,isnull(salary.s162,0) as  s162
,isnull(salary.s163,0) as  s163
,isnull(salary.s164,0) as  s164
,isnull(salary.s165,0) as  s165
,isnull(salary.s166,0) as  s166
,isnull(salary.s167,0) as  s167
,isnull(salary.s168,0) as  s168
,isnull(salary.s169,0) as  s169
,isnull(salary.s170,0) as  s170

	,TernimationDate,
	OfficialDate,
	Salary_Month,
	Salary_Year
from SmartBooks_Salary_Off salary
left join dbo.SmartBooks_Employee empl on salary.Employee_ID COLLATE DATABASE_DEFAULT= empl.Employee_ID 
where Salary_Month = @month and Salary_Year = @year

)
--select * from udf_BangLuongThang_nghiviec('4','2019')




GO
