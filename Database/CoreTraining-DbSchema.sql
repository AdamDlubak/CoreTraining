/****** Object:  Table [dbo].[Activity]    Script Date: 21.09.2021 14:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activity](
	[Id] [uniqueidentifier] NOT NULL,
	[UniqueReferenceCode] [nvarchar](20) NOT NULL,
	[PropertyId] [uniqueidentifier] NOT NULL,
	[CreationTime] [datetimeoffset](7) NOT NULL,
	[ActivityStatusId] [uniqueidentifier] NOT NULL,
	[QuotingRentMinId] [uniqueidentifier] NULL,
	[QuotingRentMaxId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 21.09.2021 14:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [uniqueidentifier] NOT NULL,
	[PropertyName] [nvarchar](128) NULL,
	[PropertyNumber] [nvarchar](140) NULL,
	[Line1] [nvarchar](128) NULL,
	[Postcode] [nvarchar](32) NULL,
	[City] [nvarchar](128) NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EnumType]    Script Date: 21.09.2021 14:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnumType](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_EnumType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EnumTypeItem]    Script Date: 21.09.2021 14:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnumTypeItem](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](40) NOT NULL,
	[EnumTypeId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_EnumTypeItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeasurementUnitValue]    Script Date: 21.09.2021 14:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeasurementUnitValue](
	[Id] [uniqueidentifier] NOT NULL,
	[SquareFeet] [decimal](20, 2) NULL,
	[SquareMeter] [decimal](20, 2) NULL,
 CONSTRAINT [PK_MeasurementUnitValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Property]    Script Date: 21.09.2021 14:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property](
	[Id] [uniqueidentifier] NOT NULL,
	[UniqueReferenceCode] [nvarchar](20) NOT NULL,
	[AddressId] [uniqueidentifier] NULL,
	[CreationTime] [datetimeoffset](7) NOT NULL,
	[PropertyTypeId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertyType]    Script Date: 21.09.2021 14:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyType](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PropertyType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Activity] ADD  CONSTRAINT [DF_Activity_Id]  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[Address] ADD  CONSTRAINT [DF_Address_Id]  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[EnumType] ADD  CONSTRAINT [DF_EnumType_Id]  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[EnumTypeItem] ADD  CONSTRAINT [DF_EnumTypeItem_Id]  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[MeasurementUnitValue] ADD  CONSTRAINT [DF_MeasurementUnitValue_Id]  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[Property] ADD  CONSTRAINT [DF_Property_Id]  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[PropertyType] ADD  CONSTRAINT [DF_PropertyType_Id]  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_EnumTypeItem] FOREIGN KEY([ActivityStatusId])
REFERENCES [dbo].[EnumTypeItem] ([Id])
GO
ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_EnumTypeItem]
GO
ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_MeasurementUnitValue] FOREIGN KEY([QuotingRentMaxId])
REFERENCES [dbo].[MeasurementUnitValue] ([Id])
GO
ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_MeasurementUnitValue]
GO
ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_MeasurementUnitValue1] FOREIGN KEY([QuotingRentMinId])
REFERENCES [dbo].[MeasurementUnitValue] ([Id])
GO
ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_MeasurementUnitValue1]
GO
ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_Property] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
GO
ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_Property]
GO
ALTER TABLE [dbo].[EnumTypeItem]  WITH CHECK ADD  CONSTRAINT [FK_EnumTypeItem_EnumType] FOREIGN KEY([EnumTypeId])
REFERENCES [dbo].[EnumType] ([Id])
GO
ALTER TABLE [dbo].[EnumTypeItem] CHECK CONSTRAINT [FK_EnumTypeItem_EnumType]
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_Address] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_Address]
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_PropertyType] FOREIGN KEY([PropertyTypeId])
REFERENCES [dbo].[PropertyType] ([Id])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_PropertyType]
GO
