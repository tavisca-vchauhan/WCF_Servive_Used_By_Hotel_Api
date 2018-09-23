USE [hotel]
GO
/****** Object:  Table [dbo].[bookdetail]    Script Date: 9/22/2018 10:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bookdetail](
	[roomid] [int] NOT NULL,
	[hotelid] [int] NOT NULL,
	[hotelname] [nchar](40) NOT NULL,
	[hoteladdress] [nchar](150) NOT NULL,
	[roomnumber] [int] NOT NULL,
	[price] [float] NOT NULL,
	[roomtype] [nchar](20) NOT NULL,
 CONSTRAINT [PK_bookdetail] PRIMARY KEY CLUSTERED 
(
	[roomid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
