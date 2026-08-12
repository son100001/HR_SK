-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_BaoCaoLuong]
--exec sp_BaoCaoLuong 5,2020,4,'VN'
	-- Add the parameters for the stored procedure here
	@Month int,
	@Year int,
	@TypeOfReport int=1,--1:danh sách lương;2:Phiếu lương
	@LAN nvarchar(50)='VN',
	@fact nvarchar(50)=null,
	@dept nvarchar(50)=null,
	@sect nvarchar(50)=null,
	@team nvarchar(50)=null,
	@pos nvarchar(50)=null,
	@posc nvarchar(50)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @NgayDauThang datetime, @NgayCuoiThang datetime
	set @NgayDauThang=DATEFROMPARTS(@Year,@Month,1)
	set @NgayCuoiThang=dateadd(month,1,@NgayDauThang)-1

	declare @BangLuong table([Employee_ID] [nvarchar](50) NOT NULL,PayDate [datetime] NULL,[s1] [float] NULL,[s2] [float] NULL,[s3] [float] NULL,[s4] [float] NULL,[s5] [float] NULL,[s6] [float] NULL,[s7] [float] NULL,[s8] [float] NULL,[s9] [float] NULL,[s10] [float] NULL,[s11] [float] NULL,[s12] [float] NULL,[s13] [float] NULL,[s14] [float] NULL,[s15] [float] NULL,[s16] [float] NULL,[s17] [float] NULL,[s18] [float] NULL,[s19] [float] NULL,[s20] [float] NULL,[s21] [float] NULL,[s22] [float] NULL,[s23] [float] NULL,[s24] [float] NULL,[s25] [float] NULL,[s26] [float] NULL,[s27] [float] NULL,[s28] [float] NULL,[s29] [float] NULL,[s30] [float] NULL,[s31] [float] NULL,[s32] [float] NULL,[s33] [float] NULL,[s34] [float] NULL,[s35] [float] NULL,[s36] [float] NULL,[s37] [float] NULL,[s38] [float] NULL,[s39] [float] NULL,[s40] [float] NULL,[s41] [float] NULL,[s42] [float] NULL,[s43] [float] NULL,[s44] [float] NULL,[s45] [float] NULL,[s46] [float] NULL,[s47] [float] NULL,[s48] [float] NULL,[s49] [float] NULL,[s50] [float] NULL,[s51] [float] NULL,[s52] [float] NULL,[s53] [float] NULL,[s54] [float] NULL,[s55] [float] NULL,[s56] [float] NULL,[s57] [float] NULL,[s58] [float] NULL,[s59] [float] NULL,[s60] [float] NULL,[s61] [float] NULL,[s62] [float] NULL,[s63] [float] NULL,[s64] [float] NULL,[s65] [float] NULL,[s66] [float] NULL,[s67] [float] NULL,[s68] [float] NULL,[s69] [float] NULL,[s70] [float] NULL,[s71] [float] NULL,[s72] [float] NULL,[s73] [float] NULL,[s74] [float] NULL,[s75] [float] NULL,[s76] [float] NULL,[s77] [float] NULL,[s78] [float] NULL,[s79] [float] NULL,[s80] [float] NULL,[s81] [float] NULL,[s82] [float] NULL,[s83] [float] NULL,[s84] [float] NULL,[s85] [float] NULL,[s86] [float] NULL,[s87] [float] NULL,[s88] [float] NULL,[s89] [float] NULL,[s90] [float] NULL,[s91] [float] NULL,[s92] [float] NULL,[s93] [float] NULL,[s94] [float] NULL,[s95] [float] NULL,[s96] [float] NULL,[s97] [float] NULL,[s98] [float] NULL,[s99] [float] NULL,[s100] [float] NULL,[s101] [float] NULL,[s102] [float] NULL,[s103] [float] NULL,[s104] [float] NULL,[s105] [float] NULL,[s106] [float] NULL,[s107] [float] NULL,[s108] [float] NULL,[s109] [float] NULL,[s110] [float] NULL,[s111] [float] NULL,[s112] [float] NULL,[s113] [float] NULL,[s114] [float] NULL,[s115] [float] NULL,[s116] [float] NULL,[s117] [float] NULL,[s118] [float] NULL,[s119] [float] NULL,[s120] [float] NULL,[s121] [float] NULL,[s122] [float] NULL,[s123] [float] NULL,[s124] [float] NULL,[s125] [float] NULL,[s126] [float] NULL,[s127] [float] NULL,[s128] [float] NULL,[s129] [float] NULL,[s130] [float] NULL,[s131] [float] NULL,[s132] [float] NULL,[s133] [float] NULL,[s134] [float] NULL,[s135] [float] NULL,[s136] [float] NULL,[s137] [float] NULL,[s138] [float] NULL,[s139] [float] NULL,[s140] [float] NULL,[s141] [float] NULL,[s142] [float] NULL,[s143] [float] NULL,[s144] [float] NULL,[s145] [float] NULL,[s146] [float] NULL,[s147] [float] NULL,[s148] [float] NULL,[s149] [float] NULL,[s150] [float] NULL,[s151] [float] NULL,[s152] [float] NULL,[s153] [float] NULL,[s154] [float] NULL,[s155] [float] NULL,[s156] [float] NULL,[s157] [float] NULL,[s158] [float] NULL,[s159] [float] NULL,[s160] [float] NULL,[s161] [float] NULL,[s162] [float] NULL,[s163] [float] NULL,[s164] [float] NULL,[s165] [float] NULL,[s166] [float] NULL,[s167] [float] NULL,[s168] [float] NULL,[s169] [float] NULL,[s170] [float] NULL primary key ([Employee_ID]))
	insert into @BangLuong
	select REPLACE([Employee_ID],'_TV','')as [Employee_ID]
	,isnull(PayDate,dateadd(day,-1,dateadd(month,1,datefromparts(salary_year,salary_month,1)))) as PayDate
	,sum(case when Employee_ID like '%_TV' then 0 else isnull(s1,0) end) as s1
	,sum(case when Employee_ID like '%_TV' then 0 else isnull(s2,0) end) as s2
	,sum(isnull([s3],0)) as s3
	,sum(case when Employee_ID like '%_TV' then 0 else isnull(s4,0) end) as s4
	,sum(case when Employee_ID like '%_TV' then 0 else isnull(s5,0) end) as s5
	,sum(case when Employee_ID like '%_TV' then 0 else isnull(s6,0) end) as s6
	,sum(case when Employee_ID like '%_TV' then 0 else isnull(s7,0) end) as s7
	,sum(isnull([s8],0)) as [s8],sum(isnull([s9],0)) as [s9],sum(isnull([s10],0)) as [s10],sum(isnull([s11],0)) as [s11],sum(isnull([s12],0)) as [s12],sum(isnull([s13],0)) as [s13],sum(isnull([s14],0)) as [s14],sum(isnull([s15],0)) as [s15],sum(isnull([s16],0)) as [s16],sum(isnull([s17],0)) as [s17],sum(isnull([s18],0)) as [s18],sum(isnull([s19],0)) as [s19],sum(isnull([s20],0)) as [s20],sum(isnull([s21],0)) as [s21],sum(isnull([s22],0)) as [s22],sum(isnull([s23],0)) as [s23],sum(isnull([s24],0)) as [s24],sum(isnull([s25],0)) as [s25],sum(isnull([s26],0)) as [s26],sum(isnull([s27],0)) as [s27],sum(isnull([s28],0)) as [s28],sum(isnull([s29],0)) as [s29],sum(isnull([s30],0)) as [s30],sum(isnull([s31],0)) as [s31],sum(isnull([s32],0)) as [s32],sum(isnull([s33],0)) as [s33],sum(isnull([s34],0)) as [s34],sum(isnull([s35],0)) as [s35],sum(isnull([s36],0)) as [s36],sum(isnull([s37],0)) as [s37],sum(isnull([s38],0)) as [s38],sum(isnull([s39],0)) as [s39],sum(isnull([s40],0)) as [s40],sum(isnull([s41],0)) as [s41],sum(isnull([s42],0)) as [s42],sum(isnull([s43],0)) as [s43],sum(isnull([s44],0)) as [s44],sum(isnull([s45],0)) as [s45],sum(isnull([s46],0)) as [s46],sum(isnull([s47],0)) as [s47],sum(isnull([s48],0)) as [s48],sum(isnull([s49],0)) as [s49],sum(isnull([s50],0)) as [s50],sum(isnull([s51],0)) as [s51],sum(isnull([s52],0)) as [s52],sum(isnull([s53],0)) as [s53],sum(isnull([s54],0)) as [s54],sum(isnull([s55],0)) as [s55]	,sum(case when Employee_ID like '%_TV' then 0 else s56 end) as s56
	,sum(case when Employee_ID like '%_TV' then 0 else isnull(s57,0) end) as s57
	,sum(isnull([s58],0)) as [s58],sum(isnull([s59],0)) as [s59],sum(isnull([s60],0)) as [s60],sum(isnull([s61],0)) as [s61],sum(isnull([s62],0)) as [s62],sum(isnull([s63],0)) as [s63],sum(isnull([s64],0)) as [s64],0,sum(isnull([s66],0)) as [s66],sum(isnull([s67],0)) as [s67],sum(isnull([s68],0)) as [s68],sum(isnull([s69],0)) as [s69],sum(isnull([s70],0)) as [s70],sum(isnull([s71],0)) as [s71],sum(isnull([s72],0)) as [s72],sum(isnull([s73],0)) as [s73],sum(isnull([s74],0)) as [s74]
	,sum(case when Employee_ID like '%_TV' then 0 else isnull(s75,0) end) as s75
	,sum(case when Employee_ID like '%_TV' then 0 else isnull(s76,0) end) as s76
	,sum(case when Employee_ID like '%_TV' then 0 else isnull(s77,0) end) as s77
	,sum(case when Employee_ID like '%_TV' then 0 else isnull(s78,0) end) as s78
	,sum(case when Employee_ID like '%_TV' then 0 else isnull(s79,0) end) as s79
	,sum(case when Employee_ID like '%_TV' then 0 else isnull(s80,0) end) as s80
	,sum(case when Employee_ID like '%_TV' then 0 else isnull(s81,0) end) as s81
	,sum(isnull([s82],0)) as [s82],sum(isnull([s83],0)) as [s83],sum(isnull([s84],0)) as [s84],0,sum(isnull([s86],0)) as [s86],sum(isnull([s87],0)) as [s87],sum(isnull([s88],0)) as [s88],sum(isnull([s89],0)) as [s89],sum(isnull([s90],0)) as [s90],sum(isnull([s91],0)) as [s91],sum(isnull([s92],0)) as [s92],sum(isnull([s93],0)) as [s93],sum(isnull([s94],0)) as [s94],sum(isnull([s95],0)) as [s95],sum(isnull([s96],0)) as [s96],sum(isnull([s97],0)) as [s97],sum(isnull([s98],0)) as [s98],sum(isnull([s99],0)) as [s99],sum(isnull([s100],0)) as [s100],sum(isnull([s101],0)) as [s101],sum(isnull([s102],0)) as [s102],sum(isnull([s103],0)) as [s103],sum(isnull([s104],0)) as [s104],sum(isnull([s105],0)) as [s105],sum(isnull([s106],0)) as [s106],sum(isnull([s107],0)) as [s107],sum(isnull([s108],0)) as [s108],sum(isnull([s109],0)) as [s109],sum(isnull([s110],0)) as [s110],sum(isnull([s111],0)) as [s111],sum(isnull([s112],0)) as [s112],sum(isnull([s113],0)) as [s113],sum(isnull([s114],0)) as [s114],sum(isnull([s115],0)) as [s115],sum(isnull([s116],0)) as [s116],sum(isnull([s117],0)) as [s117],sum(isnull([s118],0)) as [s118],sum(isnull([s119],0)) as [s119],sum(isnull([s120],0)) as [s120],sum(isnull([s121],0)) as [s121],sum(isnull([s122],0)) as [s122],sum(isnull([s123],0)) as [s123],sum(isnull([s124],0)) as [s124],sum(isnull([s125],0)) as [s125],sum(isnull([s126],0)) as [s126],sum(isnull([s127],0)) as [s127],sum(isnull([s128],0)) as [s128],sum(isnull([s129],0)) as [s129],sum(isnull([s130],0)) as [s130],sum(isnull([s131],0)) as [s131],sum(isnull([s132],0)) as [s132],sum(isnull([s133],0)) as [s133],sum(isnull([s134],0)) as [s134],sum(isnull([s135],0)) as [s135],sum(isnull([s136],0)) as [s136],sum(isnull([s137],0)) as [s137],sum(isnull([s138],0)) as [s138],sum(isnull([s139],0)) as [s139],sum(isnull([s140],0)) as [s140],sum(isnull([s141],0)) as [s141],sum(isnull([s142],0)) as [s142],sum(isnull([s143],0)) as [s143],sum(isnull([s144],0)) as [s144],sum(isnull([s145],0)) as [s145],sum(isnull([s146],0)) as [s146],sum(isnull([s147],0)) as [s147],sum(isnull([s148],0)) as [s148],sum(isnull([s149],0)) as [s149],sum(isnull([s150],0)) as [s150],sum(isnull([s151],0)) as [s151],sum(isnull([s152],0)) as [s152],sum(isnull([s153],0)) as [s153],sum(isnull([s154],0)) as [s154],sum(isnull([s155],0)) as [s155],sum(isnull([s156],0)) as [s156],sum(isnull([s157],0)) as [s157],sum(isnull([s158],0)) as [s158],sum(isnull([s159],0)) as [s159],sum(isnull([s160],0)) as [s160],sum(isnull([s161],0)) as [s161],sum(isnull([s162],0)) as [s162],sum(isnull([s163],0)) as [s163],sum(isnull([s164],0)) as [s164],sum(isnull([s165],0)) as [s165],sum(isnull([s166],0)) as [s166],sum(isnull([s167],0)) as [s167],sum(isnull([s168],0)) as [s168],sum(isnull([s169],0)) as [s169],sum(isnull([s170],0)) as [s170]
		from smartbooks_salary where salary_year=@Year and salary_month=@month and [Key]=case when @TypeOfReport=3 then 'ResignSalary' else 'MonthlySalary' end
		group by REPLACE([Employee_ID],'_TV',''),isnull(PayDate,dateadd(day,-1,dateadd(month,1,datefromparts(salary_year,salary_month,1))))
	if @TypeOfReport =1 begin--tổng hợp lương chính thức
		select
		(case when empl.PositionCategory_ID='NVVP' then '01 - Main ofice' else empl.Factory_ID end) as Factory
		,(case when empl.PositionCategory_ID='NVVP' then '01 - Main ofice'
				when isnull(empl.Factory_ID,'KhongRo') = 'X01' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('TD','PV','TV','YT') then N'02 - Other department'
				when isnull(empl.Factory_ID,'KhongRo') = 'X01' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('HR','MR','PHIM','KHO','TVD','TK') then N'03 - Office factory 01'
				when isnull(empl.Factory_ID,'KhongRo') = 'X01' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('KHUON','INMAU','MAU') then N'04 - Color, sample, pannel room - Factory 01'
				when isnull(empl.Factory_ID,'KhongRo') = 'X01' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('CNI','KCS','DS','SH','XNH') then N'05 - Workers -  Factory 01'
				when isnull(empl.Factory_ID,'KhongRo') = 'X03' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('GDX','TK') then N'06 - Office factory 03'
				when isnull(empl.Factory_ID,'KhongRo') = 'X03' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('TD') then N'07 - Other department factory 03'
				when isnull(empl.Factory_ID,'KhongRo') = 'X03' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('KHUON','INMAU','MAU') then N'08 - Color, sample, pannel room - Factory 03'
				when isnull(empl.Factory_ID,'KhongRo') = 'X03' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('CNI','KCS','DS','SH','XNH') then N'09 - Workers -  Factory 03'
				when isnull(empl.Factory_ID,'KhongRo') = 'X05' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('HR','TK') then N'10 - Office factory 05'
				when isnull(empl.Factory_ID,'KhongRo') = 'X05' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('TD','TV') then N'11 - Other department - Factory 05'
				when isnull(empl.Factory_ID,'KhongRo') = 'X05' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('MAU') then N'12 - Sample - Factory 05'
				when isnull(empl.Factory_ID,'KhongRo') = 'X05' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('CNI','KCS','DS','SH','XNH','CC','CNT') then N'13 - Workers -  Factory 05'
		else isnull(empl.Factory_ID,'KhongRo') end) as NhomTHLuongISVN
		,isnull(empl.PositionCategory_ID,'KhongRo')as PositionCategory_ID
		,isnull(empl.SectionName,'KhongRo') as SectionName
		,count(s.Employee_ID) as SoCNV,sum(isnull(s1,0))as s1,sum(isnull(s2,0))as s2,sum(isnull(s3,0))as s3,sum(isnull(s4,0))as s4,sum(isnull(s5,0))as s5,sum(isnull(s6,0))as s6,sum(isnull(s7,0))as s7,sum(isnull(s8,0))as s8,sum(isnull(s9,0))as s9,sum(isnull(s10,0))as s10,sum(isnull(s11,0))as s11,sum(isnull(s12,0))as s12,sum(isnull(s13,0))as s13,sum(isnull(s14,0))as s14,sum(isnull(s15,0))as s15,sum(isnull(s16,0))as s16,sum(isnull(s17,0))as s17,sum(isnull(s18,0))as s18,sum(isnull(s19,0))as s19,sum(isnull(s20,0))as s20,sum(isnull(s21,0))as s21,sum(isnull(s22,0))as s22,sum(isnull(s23,0))as s23,sum(isnull(s24,0))as s24,sum(isnull(s25,0))as s25,sum(isnull(s26,0))as s26,sum(isnull(s27,0))as s27,sum(isnull(s28,0))as s28,sum(isnull(s29,0))as s29,sum(isnull(s30,0))as s30,sum(isnull(s31,0))as s31,sum(isnull(s32,0))as s32,sum(isnull(s33,0))as s33,sum(isnull(s34,0))as s34,sum(isnull(s35,0))as s35,sum(isnull(s36,0))as s36,sum(isnull(s37,0))as s37,sum(isnull(s38,0))as s38,sum(isnull(s39,0))as s39,sum(isnull(s40,0))as s40,sum(isnull(s41,0))as s41,sum(isnull(s42,0))as s42,sum((case when isnull(s43,0)<0 then 0 else isnull(s43,0) end))as s43,sum(isnull(s44,0))as s44,sum(isnull(s45,0))as s45,sum(isnull(s46,0))as s46,sum(isnull(s47,0))as s47,sum(isnull(s48,0))as s48,sum(isnull(s49,0))as s49,sum(isnull(s50,0))as s50,sum(isnull(s51,0))as s51,sum(isnull(s52,0))as s52,sum(isnull(s53,0))as s53,sum(isnull(s54,0))as s54,sum(isnull(s55,0))as s55,sum(isnull(s56,0))as s56,sum(isnull(s57,0))as s57,sum(isnull(s58,0))as s58,sum(isnull(s59,0))as s59,sum(isnull(s60,0))as s60,sum(isnull(s61,0))as s61,sum(isnull(s62,0))as s62,sum(isnull(s63,0))as s63,sum(isnull(s64,0))as s64,sum(isnull(s65,0))as s65,sum(isnull(s66,0))as s66,sum(isnull(s67,0))as s67,sum(isnull(s68,0))as s68,sum(isnull(s69,0))as s69,sum(isnull(s70,0))as s70,sum(isnull(s71,0))as s71,sum(isnull(s72,0))as s72,sum(isnull(s73,0))as s73,sum(isnull(s74,0))as s74,sum(isnull(s75,0))as s75,sum(isnull(s76,0))as s76,sum(isnull(s77,0))as s77,sum(isnull(s78,0))as s78,sum(isnull(s79,0))as s79,sum(isnull(s80,0))as s80,sum(isnull(s81,0))as s81,sum(isnull(s82,0))as s82,sum(isnull(s83,0))as s83,sum(isnull(s84,0))as s84,sum(isnull(s85,0))as s85,sum(isnull(s86,0))as s86,sum(isnull(s87,0))as s87,sum(isnull(s88,0))as s88,sum(isnull(s89,0))as s89,sum(isnull(s90,0))as s90,sum(isnull(s91,0))as s91,sum(isnull(s92,0))as s92,sum(isnull(s93,0))as s93,sum(isnull(s94,0))as s94,sum(isnull(s95,0))as s95,sum(isnull(s96,0))as s96,sum(isnull(s97,0))as s97,sum(isnull(s98,0))as s98,sum(isnull(s99,0))as s99,sum(isnull(s100,0))as s100,sum(isnull(s101,0))as s101,sum(isnull(s102,0))as s102,sum(isnull(s103,0))as s103,sum(isnull(s104,0))as s104,sum(isnull(s105,0))as s105,sum(isnull(s106,0))as s106,sum(isnull(s107,0))as s107,sum(isnull(s108,0))as s108,sum(isnull(s109,0))as s109,sum(isnull(s110,0))as s110,sum(isnull(s111,0))as s111,sum(isnull(s112,0))as s112,sum(isnull(s113,0))as s113,sum(isnull(s114,0))as s114,sum(isnull(s115,0))as s115,sum(isnull(s116,0))as s116,sum(isnull(s117,0))as s117,sum(isnull(s118,0))as s118,sum(isnull(s119,0))as s119,sum(isnull(s120,0))as s120,sum(isnull(s121,0))as s121,sum(isnull(s122,0))as s122,sum(isnull(s123,0))as s123,sum(isnull(s124,0))as s124,sum(isnull(s125,0))as s125,sum(isnull(s126,0))as s126,sum(isnull(s127,0))as s127,sum(isnull(s128,0))as s128,sum(isnull(s129,0))as s129,sum(isnull(s130,0))as s130,sum(isnull(s131,0))as s131,sum(isnull(s132,0))as s132,sum(isnull(s133,0))as s133,sum(isnull(s134,0))as s134,sum(isnull(s135,0))as s135,sum(isnull(s136,0))as s136,sum(isnull(s137,0))as s137,sum(isnull(s138,0))as s138,sum(isnull(s139,0))as s139,sum(isnull(s140,0))as s140,sum(isnull(s141,0))as s141,sum(isnull(s142,0))as s142,sum(isnull(s143,0))as s143,sum(isnull(s144,0))as s144,sum(isnull(s145,0))as s145,sum(isnull(s146,0))as s146,sum(isnull(s147,0))as s147,sum(isnull(s148,0))as s148,sum(isnull(s149,0))as s149,sum(isnull(s150,0))as s150,sum(isnull(s151,0))as s151,sum(isnull(s152,0))as s152,sum(isnull(s153,0))as s153,sum(isnull(s154,0))as s154,sum(isnull(s155,0))as s155,sum(isnull(s156,0))as s156,sum(isnull(s157,0))as s157,sum(isnull(s158,0))as s158,sum(isnull(s159,0))as s159,sum(isnull(s160,0))as s160,sum(isnull(s161,0))as s161,sum(isnull(s162,0))as s162,sum(isnull(s163,0))as s163,sum(isnull(s164,0))as s164,sum(isnull(s165,0))as s165,sum(isnull(s166,0))as s166,sum(isnull(s167,0))as s167,sum(isnull(s168,0))as s168,sum(isnull(s169,0))as s169,sum(isnull(s170,0))as s170
		,sum(case when not(isnull(empl.bankaccount,'')='' or isnull(erp.ParameterValue,'2')='1') then s55 else 0 end) as ATM
		,sum(case when isnull(empl.bankaccount,'')='' or isnull(erp.ParameterValue,'2')='1' then s55 else 0 end) as CASH
		from
		@BangLuong s
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,@NgayCuoiThang) empl
		on s.Employee_ID=empl.Employee_ID
		left join
		[dbo].[HR_EmpRegisParameter] erp
		on s.Employee_ID=erp.Employee_ID and s.Paydate between erp.Fromdate and erp.todate and erp.Parameter='HinhThucThanhToanLuong'
		where empl.Employee_ID is not null and empl.Factory_ID not in ('TV03','TV05')
		group by (case when empl.PositionCategory_ID='NVVP' then '01 - Main ofice' else empl.Factory_ID end)
				,(case when empl.PositionCategory_ID='NVVP' then '01 - Main ofice'
				when isnull(empl.Factory_ID,'KhongRo') = 'X01' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('TD','PV','TV','YT') then N'02 - Other department'
				when isnull(empl.Factory_ID,'KhongRo') = 'X01' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('HR','MR','PHIM','KHO','TVD','TK') then N'03 - Office factory 01'
				when isnull(empl.Factory_ID,'KhongRo') = 'X01' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('KHUON','INMAU','MAU') then N'04 - Color, sample, pannel room - Factory 01'
				when isnull(empl.Factory_ID,'KhongRo') = 'X01' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('CNI','KCS','DS','SH','XNH') then N'05 - Workers -  Factory 01'
				when isnull(empl.Factory_ID,'KhongRo') = 'X03' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('GDX','TK') then N'06 - Office factory 03'
				when isnull(empl.Factory_ID,'KhongRo') = 'X03' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('TD') then N'07 - Other department factory 03'
				when isnull(empl.Factory_ID,'KhongRo') = 'X03' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('KHUON','INMAU','MAU') then N'08 - Color, sample, pannel room - Factory 03'
				when isnull(empl.Factory_ID,'KhongRo') = 'X03' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('CNI','KCS','DS','SH','XNH') then N'09 - Workers -  Factory 03'
				when isnull(empl.Factory_ID,'KhongRo') = 'X05' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('HR','TK') then N'10 - Office factory 05'
				when isnull(empl.Factory_ID,'KhongRo') = 'X05' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('TD','TV') then N'11 - Other department - Factory 05'
				when isnull(empl.Factory_ID,'KhongRo') = 'X05' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('MAU') then N'12 - Sample - Factory 05'
				when isnull(empl.Factory_ID,'KhongRo') = 'X05' AND isnull(empl.PositionCategory_ID,'')<>'NVVP' AND empl.SectionName in ('CNI','KCS','DS','SH','XNH','CC','CNT') then N'13 - Workers -  Factory 05'
		else isnull(empl.Factory_ID,'KhongRo') end)
				,isnull(empl.PositionCategory_ID,'KhongRo')
				,isnull(empl.SectionName,'KhongRo')
	end else if @TypeOfReport =3 begin--tổng hợp lương thôi việc
		select
		empl.factory_id,empl.sectionname,empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate,empl.TernimationDate
		,isnull(s.s1,0)as s1,isnull(s.s2,0)as s2,isnull(s.s3,0)as s3,isnull(s.s4,0)as s4,isnull(s.s5,0)as s5,isnull(s.s6,0)as s6,isnull(s.s7,0)as s7,isnull(s.s8,0)as s8,isnull(s.s9,0)as s9,isnull(s.s10,0)as s10,isnull(s.s11,0)as s11,isnull(s.s12,0)as s12,isnull(s.s13,0)as s13,isnull(s.s14,0)as s14,isnull(s.s15,0)as s15,isnull(s.s16,0)as s16,isnull(s.s17,0)as s17,isnull(s.s18,0)as s18,isnull(s.s19,0)as s19,isnull(s.s20,0)as s20,isnull(s.s21,0)as s21,isnull(s.s22,0)as s22,isnull(s.s23,0)as s23,isnull(s.s24,0)as s24,isnull(s.s25,0)as s25,isnull(s.s26,0)as s26,isnull(s.s27,0)as s27,isnull(s.s28,0)as s28,isnull(s.s29,0)as s29,isnull(s.s30,0)as s30,isnull(s.s31,0)as s31,isnull(s.s32,0)as s32,isnull(s.s33,0)as s33,isnull(s.s34,0)as s34,isnull(s.s35,0)as s35,isnull(s.s36,0)as s36,isnull(s.s37,0)as s37,isnull(s.s38,0)as s38,isnull(s.s39,0)as s39,isnull(s.s40,0)as s40,isnull(s.s41,0)as s41,isnull(s.s42,0)as s42,(case when isnull(s.s43,0)<0 then 0 else isnull(s.s43,0) end)as s43,isnull(s.s44,0)as s44,isnull(s.s45,0)as s45,isnull(s.s46,0)as s46,isnull(s.s47,0)as s47,isnull(s.s48,0)as s48,isnull(s.s49,0)as s49,isnull(s.s50,0)as s50,isnull(s.s51,0)as s51,isnull(s.s52,0)as s52,isnull(s.s53,0)as s53,isnull(s.s54,0)as s54,isnull(s.s55,0)as s55,isnull(s.s56,0)as s56,isnull(s.s57,0)as s57,isnull(s.s58,0)as s58,isnull(s.s59,0)as s59,isnull(s.s60,0)as s60,isnull(s.s61,0)as s61,isnull(s.s62,0)as s62,isnull(s.s63,0)as s63,isnull(s.s64,0)as s64,isnull(s.s65,0)as s65,isnull(s.s66,0)as s66,isnull(s.s67,0)as s67,isnull(s.s68,0)as s68,isnull(s.s69,0)as s69,isnull(s.s70,0)as s70,isnull(s.s71,0)as s71,isnull(s.s72,0)as s72,isnull(s.s73,0)as s73,isnull(s.s74,0)as s74,isnull(s.s75,0)as s75,isnull(s.s76,0)as s76,isnull(s.s77,0)as s77,isnull(s.s78,0)as s78,isnull(s.s79,0)as s79,isnull(s.s80,0)as s80,isnull(s.s81,0)as s81,isnull(s.s82,0)as s82,isnull(s.s83,0)as s83,isnull(s.s84,0)as s84,isnull(s.s85,0)as s85,isnull(s.s86,0)as s86,isnull(s.s87,0)as s87,isnull(s.s88,0)as s88,isnull(s.s89,0)as s89,isnull(s.s90,0)as s90,isnull(s.s91,0)as s91,isnull(s.s92,0)as s92,isnull(s.s93,0)as s93,isnull(s.s94,0)as s94,isnull(s.s95,0)as s95,isnull(s.s96,0)as s96,isnull(s.s97,0)as s97,isnull(s.s98,0)as s98,isnull(s.s99,0)as s99,isnull(s.s100,0)as s100,isnull(s.s101,0)as s101,isnull(s.s102,0)as s102,isnull(s.s103,0)as s103,isnull(s.s104,0)as s104,isnull(s.s105,0)as s105,isnull(s.s106,0)as s106,isnull(s.s107,0)as s107,isnull(s.s108,0)as s108,isnull(s.s109,0)as s109,isnull(s.s110,0)as s110,isnull(s.s111,0)as s111,isnull(s.s112,0)as s112,isnull(s.s113,0)as s113,isnull(s.s114,0)as s114,isnull(s.s115,0)as s115,isnull(s.s116,0)as s116,isnull(s.s117,0)as s117,isnull(s.s118,0)as s118,isnull(s.s119,0)as s119,isnull(s.s120,0)as s120,isnull(s.s121,0)as s121,isnull(s.s122,0)as s122,isnull(s.s123,0)as s123,isnull(s.s124,0)as s124,isnull(s.s125,0)as s125,isnull(s.s126,0)as s126,isnull(s.s127,0)as s127,isnull(s.s128,0)as s128,isnull(s.s129,0)as s129,isnull(s.s130,0)as s130,isnull(s.s131,0)as s131,isnull(s.s132,0)as s132,isnull(s.s133,0)as s133,isnull(s.s134,0)as s134,isnull(s.s135,0)as s135,isnull(s.s136,0)as s136,isnull(s.s137,0)as s137,isnull(s.s138,0)as s138,isnull(s.s139,0)as s139,isnull(s.s140,0)as s140,isnull(s.s141,0)as s141,isnull(s.s142,0)as s142,isnull(s.s143,0)as s143,isnull(s.s144,0)as s144,isnull(s.s145,0)as s145,isnull(s.s146,0)as s146,isnull(s.s147,0)as s147,isnull(s.s148,0)as s148,isnull(s.s149,0)as s149,isnull(s.s150,0)as s150,isnull(s.s151,0)as s151,isnull(s.s152,0)as s152,isnull(s.s153,0)as s153,isnull(s.s154,0)as s154,isnull(s.s155,0)as s155,isnull(s.s156,0)as s156,isnull(s.s157,0)as s157,isnull(s.s158,0)as s158,isnull(s.s159,0)as s159,isnull(s.s160,0)as s160,isnull(s.s161,0)as s161,isnull(s.s162,0)as s162,isnull(s.s163,0)as s163,isnull(s.s164,0)as s164,isnull(s.s165,0)as s165,isnull(s.s166,0)as s166,isnull(s.s167,0)as s167,isnull(s.s168,0)as s168,isnull(s.s169,0)as s169,isnull(s.s170,0)as s170
		,tctv.s55 as tctv,ttpn.s55 as ttpn,tccn.s54 as tccn,-truythupn.s55 as truythupn
		,case when isnull(ttpn.s55,0)>0 then ttpn.s55 when isnull(truythupn.s55,0)>0 then -truythupn.s55 else 0 end as TTTruyThuPN
		,isnull(s.s54,0)+isnull(tctv.s55,0)+isnull(ttpn.s55,0)+isnull(tccn.s54,0)-isnull(truythupn.s55,0) as ThucNhan
		,round(isnull(s.s54,0)+isnull(tctv.s55,0)+isnull(ttpn.s55,0)+isnull(tccn.s54,0)-isnull(truythupn.s55,0),3) as ThucNhanRound
		,case when not(isnull(empl.bankaccount,'')='' or isnull(erp.ParameterValue,'2')='1') then round(isnull(s.s54,0)+isnull(tctv.s55,0)+isnull(ttpn.s55,0)+isnull(tccn.s54,0)-isnull(truythupn.s55,0),3) else 0 end as ATM
		,case when isnull(empl.bankaccount,'')='' or isnull(erp.ParameterValue,'2')='1' then round(isnull(s.s54,0)+isnull(tctv.s55,0)+isnull(ttpn.s55,0)+isnull(tccn.s54,0)-isnull(truythupn.s55,0),3) else 0 end as CASH
		from
		@BangLuong s
		left join
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,@NgayCuoiThang) empl
		on s.Employee_ID=empl.Employee_ID
		left join
		SmartBooks_Salary tctv
		on s.Employee_ID=tctv.Employee_ID and @Month=tctv.salary_month and @year=tctv.salary_year and tctv.[Key]='TroCapThoiViec'
		left join
		SmartBooks_Salary ttpn
		on s.Employee_ID=ttpn.Employee_ID and @Month=ttpn.salary_month and @year=ttpn.salary_year and ttpn.[Key]='ThanhToanPhepNam'
		left join
		SmartBooks_Salary tccn
		on s.Employee_ID=tccn.Employee_ID and @Month=tccn.salary_month and @year=tccn.salary_year and tccn.[Key]='TroCapConNho'
		left join
		SmartBooks_Salary truythupn
		on s.Employee_ID=truythupn.Employee_ID and @Month=truythupn.salary_month and @year=truythupn.salary_year and truythupn.[Key]='TruyThuPhepNam'
		left join
		[dbo].[HR_EmpRegisParameter] erp
		on s.Employee_ID=erp.Employee_ID and s.Paydate between erp.Fromdate and erp.todate and erp.Parameter='HinhThucThanhToanLuong'
		where empl.Employee_ID is not null
	end else if  @TypeOfReport =4 begin--lương bất thường
		select empl.Employee_ID,[dbo].[udf_FullName](empl.[Employee_Firstname],empl.Employee_LastName) as FullName,empl.StartedDate,empl.TernimationDate
		,(case when dateadd(month,1,DATEFROMPARTS(ms.Salary_Year,ms.Salary_Month,1))>=empl.ternimationdate then N'Đã thôi việc nhưng vẫn được lưu vào lương tháng.'
			when not (empl.TernimationDate between DATEFROMPARTS(rs.Salary_Year,rs.Salary_Month,2) and dateadd(month,1,DATEFROMPARTS(rs.Salary_Year,rs.Salary_Month,1))) then N'Không thôi việc trong thời gian này nhưng vẫn được lưu vào lương thôi việc.'
			else null
		end) as Remark
		from
		[dbo].[udf_EmployeeFilter](@LAN,@fact,@dept,@sect,@team,@pos,@posc,null,@NgayCuoiThang) empl
		left join
		smartbooks_salary ms
		on empl.Employee_ID=ms.Employee_ID AND ms.[Key]='MonthlySalary' and ms.salary_year=@year and ms.salary_month=@month
		left join
		smartbooks_salary rs
		on empl.Employee_ID=rs.Employee_ID AND rs.[Key]='ResignSalary' and rs.salary_year=@year and rs.salary_month=@month
		where dateadd(month,1,DATEFROMPARTS(ms.Salary_Year,ms.Salary_Month,1))>=empl.ternimationdate
			or empl.ternimationdate not between DATEFROMPARTS(rs.Salary_Year,rs.Salary_Month,2) and dateadd(month,1,DATEFROMPARTS(rs.Salary_Year,rs.Salary_Month,1))
	end
END

--select distinct [Key] from smartbooks_salary



GO
