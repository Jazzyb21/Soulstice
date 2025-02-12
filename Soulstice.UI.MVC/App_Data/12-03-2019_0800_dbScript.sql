/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.5026)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reservations]') AND type in (N'U'))
ALTER TABLE [dbo].[Reservations] DROP CONSTRAINT IF EXISTS [FK_Reservations_GymMembers]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reservations]') AND type in (N'U'))
ALTER TABLE [dbo].[Reservations] DROP CONSTRAINT IF EXISTS [FK_Reservations_Classes1]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GymMembers]') AND type in (N'U'))
ALTER TABLE [dbo].[GymMembers] DROP CONSTRAINT IF EXISTS [FK_GymMembers_AspNetUsers]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Classes]') AND type in (N'U'))
ALTER TABLE [dbo].[Classes] DROP CONSTRAINT IF EXISTS [FK_Classes_WeekDays]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Classes]') AND type in (N'U'))
ALTER TABLE [dbo].[Classes] DROP CONSTRAINT IF EXISTS [FK_Classes_Instructors]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]') AND type in (N'U'))
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT IF EXISTS [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]') AND type in (N'U'))
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT IF EXISTS [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]') AND type in (N'U'))
ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT IF EXISTS [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]') AND type in (N'U'))
ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT IF EXISTS [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
/****** Object:  Table [dbo].[WeekDays]    Script Date: 12/3/2019 8:16:14 AM ******/
DROP TABLE IF EXISTS [dbo].[WeekDays]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 12/3/2019 8:16:14 AM ******/
DROP TABLE IF EXISTS [dbo].[Reservations]
GO
/****** Object:  Table [dbo].[Instructors]    Script Date: 12/3/2019 8:16:14 AM ******/
DROP TABLE IF EXISTS [dbo].[Instructors]
GO
/****** Object:  Table [dbo].[GymMembers]    Script Date: 12/3/2019 8:16:14 AM ******/
DROP TABLE IF EXISTS [dbo].[GymMembers]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 12/3/2019 8:16:14 AM ******/
DROP TABLE IF EXISTS [dbo].[Classes]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/3/2019 8:16:14 AM ******/
DROP TABLE IF EXISTS [dbo].[AspNetUsers]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/3/2019 8:16:14 AM ******/
DROP TABLE IF EXISTS [dbo].[AspNetUserRoles]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/3/2019 8:16:14 AM ******/
DROP TABLE IF EXISTS [dbo].[AspNetUserLogins]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/3/2019 8:16:14 AM ******/
DROP TABLE IF EXISTS [dbo].[AspNetUserClaims]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/3/2019 8:16:14 AM ******/
DROP TABLE IF EXISTS [dbo].[AspNetRoles]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 12/3/2019 8:16:14 AM ******/
DROP TABLE IF EXISTS [dbo].[__MigrationHistory]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 12/3/2019 8:16:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__MigrationHistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/3/2019 8:16:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetRoles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/3/2019 8:16:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/3/2019 8:16:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/3/2019 8:16:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/3/2019 8:16:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUsers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 12/3/2019 8:16:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Classes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Classes](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[InstructorID] [int] NULL,
	[ReservationLimit] [int] NOT NULL,
	[Fee] [smallmoney] NOT NULL,
	[WeekDayID] [int] NOT NULL,
	[Time] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Classes_1] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[GymMembers]    Script Date: 12/3/2019 8:16:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GymMembers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GymMembers](
	[GymID] [nvarchar](128) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[State] [char](2) NOT NULL,
	[Phone] [char](10) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[GoalDescription] [nvarchar](max) NULL,
	[ProfilePic] [nvarchar](200) NULL,
 CONSTRAINT [PK_GymMember] PRIMARY KEY CLUSTERED 
(
	[GymID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Instructors]    Script Date: 12/3/2019 8:16:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Instructors]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Instructors](
	[InstructorID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Specialty] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Instructors] PRIMARY KEY CLUSTERED 
(
	[InstructorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 12/3/2019 8:16:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reservations]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Reservations](
	[ReservationID] [int] IDENTITY(1,1) NOT NULL,
	[GymID] [nvarchar](128) NOT NULL,
	[ClassID] [int] NOT NULL,
 CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[WeekDays]    Script Date: 12/3/2019 8:16:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WeekDays]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WeekDays](
	[WeekDayID] [int] IDENTITY(1,1) NOT NULL,
	[DayOfWeek] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_WeekDays] PRIMARY KEY CLUSTERED 
(
	[WeekDayID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201912021654267_InitialCreate', N'Soulstice.UI.MVC.Models.ApplicationDbContext', 0x1F8B0800000000000400DD5C5B6FE3B6127E2F70FE83A0A7738AD4CAE5EC624F60B7489DA40DCEE68275B2386F0B5AA21D61254A15A93441D15FD687FEA4FE8533942859E245175BB19D628185450EBF190E87E47038CC5F7FFC39FEE1390CAC279C503F2213FB6874685B98B891E793E5C44ED9E2BB0FF60FDFFFE39BF185173E5B9F0BBA134E072D099DD88F8CC5A78E43DD471C223A0A7D378968B46023370A1DE445CEF1E1E17F9CA3230703840D589635FE9412E68738FB80CF69445C1CB31405D79187032ACAA16696A15A3728C434462E9ED8B3280D28F35D3C7AB81A5D7F9E8EF226B67516F808C499E160615B8890882106C29E3E503C63494496B3180A5070FF1263A05BA08062D189D31579D7FE1C1EF3FE38AB8605949B5216853D018F4E84821CB9F95A6AB64B05820A2F40D5EC85F73A53E3C4BEF27056F4290A400132C3D3699070E2897D5DB238A3F10D66A3A2E12887BC4C00EED728F93AAA221E589DDB1D9406753C3AE4FF0EAC691AB034C113825396A0E0C0BA4BE781EFFE17BFDC475F31999C1CCD17271FDEBD47DEC9FB7FE39377D59E425F81AE560045774914E30464C38BB2FFB6E5D4DB3972C3B259A54DAE15B025981BB6758D9E3F62B2648F306B8E3FD8D6A5FF8CBDA24418D703F1612A412396A4F0799306019A07B8AC771A79F2FF1BB81EBF7B3F08D71BF4E42FB3A197F8C3C449605E7DC241564B1FFD389F5EB5F1FE22C82E9328E4DF75FBCA6BBFC0A44D5CDE99C848728F92256675E9C6CECA783B9934871ADEAC0BD4FD376D2EA96ADE5A52DEA1756642C162DBB3A190F775F976B6B8B33886C1CB4C8B6BA4C9E00C3BD6488238B064C295111D753522029DFB3BAF891721F2830116C50E5CC02959F84988CB5EFE18810922D25BE63B4429AC09DECF883E36880E3F07107D86DD3401539D3114C6AFCEEDEE3122F8260DE77C066C8FD7604373FF6B74895C16251784B7DA18EF63E47E8D527641BC73C4F003730B40FE79EF87DD010611E7CC7531A59760CCD89B46E073178057849D1CF786E3ABD4AE9D926980FC50EF9548EBE9978274E599E82914EFC440A6F3509A44FD182D7DD24DD482D42C6A4ED12AAA20EB2B2A07EB26A9A0340B9A11B4CA99530DE6F3652334BCD397C1EEBFD7B7D9E66D5A0B2A6A9CC10A897FC20427B08C797788319C90D50874593776E12C64C3C799BEFADE9471FA8C827468566BCD866C11187E3664B0FB3F1B3231A1F8C9F7B857D2E1285410037C277AFD29AB7DCE49926D7B3AD4BAB96DE6DB59034CD3E58CD2C8F5B359A009828910465D7EF0E1ACF67846DE1B3926021D0343F7F9960725D0375B36AA5B728E03CCB075E6E641C229A22EF254354287BC1E82153BAA46B0556CA42EDCB70A4FB0749CF046881F8228CC549F30755AF8C4F56314B46A496AD9710BE37D2F79C835E738C684336CD54417E6FA500817A0E4230D4A9B86C64EC5E29A0DD1E0B59AC6BCCD855D8DBB12A1D88A4DB6F8CE06BB14FEDBAB1866B3C6B6609CCD2AE9228031ACB70B03156795AE06201F5CF6CD40A51393C140854BB51503AD6B6C07065A57C99B33D0FC88DA75FCA5F3EABE9967FDA0BCFD6DBD515D3BB0CD9A3EF6CC3473DF13DA30688113D53CCFE7BC123F33CDE10CE414E7332A5C5DD94438F80CB37AC866E5EF6AFD50A7194436A226C095A1B5808A0B41054899503D842B62798DD2092FA2076C11776B84156BBF045BB10115BB7A315A21345F9FCAC6D9E9F451F6ACB406C5C83B1D162A381A839017AF7AC73B28C514975515D3C517EEE30D573A2606A341412D9EAB4149456706D752619AED5AD239647D5CB28DB424B94F062D159D195C4BC246DB95A4710A7AB8051BA9A8BE850F34D98A4847B9DB947563274F9A120563C7905D35BE4671EC936525DB4A9458B33CD56AFADDAC7FFA519863382ED5642195D2969C5894A025966A8135487AE927949D2386E688C779A65EA89069F756C3F25FB0AC6E9FEA2016FB4041CD7F8B9B55C3357E6DC3553D12017409DD0CB95B93C5D23546A06F6EF1143814A04413BE9F46411A12B397656E9D5FE255DBE7252AC2D891E457BC2845658AAF5BD77FA7D15167C69023557A32EB8F9619C2A4F3C20FAD6ADDE49B9A518A505515C514BEDAD9E8995C9AFE2326BB8CFD07AC15E1756698C853A90288A29E1895540705AC52D71DB59E8D52C5ACD7744794524EAA9052550F29AB89253521AB156BE11934AAA7E8CE414D25A9A2ABB5DD9135492555684DF51AD81A99E5BAEEA89ABC932AB0A6BA3BF62A09455E49F7780F331E6436DBC4F203EF66BB9801E37596C56136C1CABD7E15A852DC134BDCDC2B60A27C2F4DCA78EADBCCA4F260C7662665C030AF41B56BF1FA12D478976FC6ACDD75D796F9A6BB7E335E3FC37D55F3504E7E3249C9BD3C014A27BDB13875B53FB6518E6139896D156A04A37AA10C87234E309AFD124C031FF305BD20B846C45F60CAF2FC0EFBF8F0E8587AAAB33FCF661C4ABD40736A35BD9DA98FD91652B5C8134ADC4794A889131B3C2D59812A31E92BE2E1E789FD5BD6EA340B6FF05F59F18175451F88FF4B0A15F7498AADDFD544D06152ED3B3CEE2805FDFD4DBC9AE8AEF2ABFF7DC99B1E58B7094CA753EB5052F43AC35F7F4BD14B9ABCE906D2ACFDC2E2EDCEB6DAA3052DAA345BD67FA330F7D920EF130A29FF19A2E77FF5154DFB06612344CD3B83A1F00651A1E91DC13A58C637041E7CB2EC0D41BFCEEADF14AC239AF13D814FFA83C9AF09BA2F4345CB1DEE439A53D33696A44CCFADD9D81BA566EE7A6F5292B6379AE86A62760FB84193AF377351DE5852F3605BA726677930EC5DDAFDAB272AEF4B6EF2CA69DF6D4AF236B3901BEE97FE56C9C77B902EA749FFD97D8AF1B66DCD1406DEF33CCD7E89C47B666C629BDF7DBAF0B68DCD1420DE7363EB9514BC67B6B6ABFD73C796D6790BDD798AAF9AAD64B8CED14591DB5278F3903B1CFFE7111841EE51E62F2FF539634DF9AE2D0C572466A6E6643599B1327114BE0A4533DB7E7D151B7E6367054D335B438A67136FB1FE37F21634CDBC0D8993BB483ED6A62EEA12C25BD6B1A66CAAB7946C5CEB494B6E7B9BCFDA7837FF96728B07514A6DF6186E97DF4E2AF1202A1972EAF4481D562F8A61EFACFCED46D8BFA9BF5C41F0BFE448B05BDB354B9A2BB2888ACD5B92A820912234D798210FB6D4B384F90BE432A8E601E8ECE97816D4E3D72073EC5D91DB94C529832EE3701ED4025EDC0968E29FE547D7651EDFC6FC8B0ED10510D3E781FB5BF263EA075E29F7A526266480E0DE8508F7F2B1643CECBB7C29916E22D21148A8AF748AEE71180700466FC90C3DE1756403F3FB8897C87D5945004D20ED035157FBF8DC47CB04855460ACDAC327D8B0173E7FFF7FA4FEDFFBC2540000, N'6.2.0-61023')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'40a7425b-b5e2-41b6-8953-11cbd252a6a8', N'Admin')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2f6f151e-5467-4602-8377-6af11c8040b0', N'40a7425b-b5e2-41b6-8953-11cbd252a6a8')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2f6f151e-5467-4602-8377-6af11c8040b0', N'admin@soulstice.com', 0, N'AI/ofxigzhH+AVapOs36i7hjxuBaSOM49Bce0YhHos+S3yVeoYlOGseYNSZNk34dQw==', N'77b418c2-5514-4710-9b24-762c589609cb', NULL, 0, 0, NULL, 1, 0, N'admin@soulstice.com')
SET IDENTITY_INSERT [dbo].[Classes] ON 

INSERT [dbo].[Classes] ([ClassID], [ClassName], [Description], [InstructorID], [ReservationLimit], [Fee], [WeekDayID], [Time]) VALUES (1, N'Body Pump', N'The original barbell class that strengthens your entire body. This 60-minute class challenges all your major
muscle groups by using squats, presses, lifts, curls, etc.', 2, 15, 15.0000, 1, N'9:00 AM')
INSERT [dbo].[Classes] ([ClassID], [ClassName], [Description], [InstructorID], [ReservationLimit], [Fee], [WeekDayID], [Time]) VALUES (2, N'BodyAttack', N'A sports-inspired 60-minute cardio workout for building strength and stamina. This high-energy interval
training class combines athletic aerobic movements with strength and stabilization exercises.', 1, 15, 20.0000, 1, N'10:00 AM')
INSERT [dbo].[Classes] ([ClassID], [ClassName], [Description], [InstructorID], [ReservationLimit], [Fee], [WeekDayID], [Time]) VALUES (3, N'Chair Yoga', N'This is a gentle class with the option of using a yoga chair, incorporating range of motion exercises,
alignment, stretching, strengthening, awareness, breathing and relaxation to refresh, energize, improve posture, deepen
breathing and improve sense of well-being.', 4, 10, 25.0000, 1, N'11:00 AM')
INSERT [dbo].[Classes] ([ClassID], [ClassName], [Description], [InstructorID], [ReservationLimit], [Fee], [WeekDayID], [Time]) VALUES (4, N'BodyCombat', N'Fiercely energetic, empowering cardio workout inspired by martials arts and drawing from an array of
disciplines such as Karate, Kickboxing, Taekwondo, Thai Chi & Muay Thai. (', 3, 20, 30.0000, 2, N'9:00 AM')
INSERT [dbo].[Classes] ([ClassID], [ClassName], [Description], [InstructorID], [ReservationLimit], [Fee], [WeekDayID], [Time]) VALUES (5, N'GRIT', N': High-intensity interval training (HIIT), one of the hottest fitness trends, is the fastest way to get fit.', 1, 15, 25.0000, 2, N'10:00 AM')
SET IDENTITY_INSERT [dbo].[Classes] OFF
SET IDENTITY_INSERT [dbo].[Instructors] ON 

INSERT [dbo].[Instructors] ([InstructorID], [FirstName], [LastName], [Specialty]) VALUES (1, N'Trey', N'Pucker', N'Body By Trey')
INSERT [dbo].[Instructors] ([InstructorID], [FirstName], [LastName], [Specialty]) VALUES (2, N'Abbi', N'Abrams', N'Strength Training')
INSERT [dbo].[Instructors] ([InstructorID], [FirstName], [LastName], [Specialty]) VALUES (3, N'Gemma', N'Carden', N'Cardio')
INSERT [dbo].[Instructors] ([InstructorID], [FirstName], [LastName], [Specialty]) VALUES (4, N'Illana', N'Wexler', N'Yoga')
SET IDENTITY_INSERT [dbo].[Instructors] OFF
SET IDENTITY_INSERT [dbo].[WeekDays] ON 

INSERT [dbo].[WeekDays] ([WeekDayID], [DayOfWeek]) VALUES (1, N'Monday')
INSERT [dbo].[WeekDays] ([WeekDayID], [DayOfWeek]) VALUES (2, N'Tuesday')
INSERT [dbo].[WeekDays] ([WeekDayID], [DayOfWeek]) VALUES (3, N'Wednesday')
INSERT [dbo].[WeekDays] ([WeekDayID], [DayOfWeek]) VALUES (4, N'Thursday')
INSERT [dbo].[WeekDays] ([WeekDayID], [DayOfWeek]) VALUES (5, N'Friday')
INSERT [dbo].[WeekDays] ([WeekDayID], [DayOfWeek]) VALUES (6, N'Saturday')
SET IDENTITY_INSERT [dbo].[WeekDays] OFF
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]'))
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]'))
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]'))
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]'))
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]'))
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]'))
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]'))
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]'))
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Classes_Instructors]') AND parent_object_id = OBJECT_ID(N'[dbo].[Classes]'))
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_Instructors] FOREIGN KEY([InstructorID])
REFERENCES [dbo].[Instructors] ([InstructorID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Classes_Instructors]') AND parent_object_id = OBJECT_ID(N'[dbo].[Classes]'))
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_Instructors]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Classes_WeekDays]') AND parent_object_id = OBJECT_ID(N'[dbo].[Classes]'))
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_WeekDays] FOREIGN KEY([WeekDayID])
REFERENCES [dbo].[WeekDays] ([WeekDayID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Classes_WeekDays]') AND parent_object_id = OBJECT_ID(N'[dbo].[Classes]'))
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_WeekDays]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GymMembers_AspNetUsers]') AND parent_object_id = OBJECT_ID(N'[dbo].[GymMembers]'))
ALTER TABLE [dbo].[GymMembers]  WITH CHECK ADD  CONSTRAINT [FK_GymMembers_AspNetUsers] FOREIGN KEY([GymID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GymMembers_AspNetUsers]') AND parent_object_id = OBJECT_ID(N'[dbo].[GymMembers]'))
ALTER TABLE [dbo].[GymMembers] CHECK CONSTRAINT [FK_GymMembers_AspNetUsers]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reservations_Classes1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reservations]'))
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Classes1] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Classes] ([ClassID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reservations_Classes1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reservations]'))
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_Classes1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reservations_GymMembers]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reservations]'))
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_GymMembers] FOREIGN KEY([GymID])
REFERENCES [dbo].[GymMembers] ([GymID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reservations_GymMembers]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reservations]'))
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_GymMembers]
GO
